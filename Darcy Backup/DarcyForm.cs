using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Darcy_Backup
{
    
    public partial class Form_Darcy_Panel : Form
    {

        private void AddEntry(EntryClass entry)
        {

            EntryClass[] newEntries = new EntryClass[Entries.Length + 1];

            for (int i = 0; i < Entries.Length; i ++)
            {
                newEntries[i] = Entries[i];
            }

            newEntries[newEntries.Length - 1] = entry;

            Entries = newEntries;
        }

        private void RemoveEntry(int index)
        {
            EntryClass[] newEntries = new EntryClass[Entries.Length - 1];
            int addCount = 0;
            for (int i = 0; i < Entries.Length; i ++)
            {
                if (i != index)
                { 
                    newEntries[addCount] = Entries[i];
                    addCount ++;
                }
            }
            Entries = newEntries;
        }

        delegate int GetSelectedListIndexCallback(ListView lv);
        private int GetSelectedListIndex(ListView lv)
        {
            if (List_Backup.InvokeRequired == true)
            {
                GetSelectedListIndexCallback d = new GetSelectedListIndexCallback(GetSelectedListIndex);
                return (int)this.Invoke(d, new object[] { lv });
            }
            else
            {
                if (lv != null)
                    if (lv.SelectedItems.Count > 0)
                        return lv.SelectedItems[0].Index;
                return -1;
            }
        }
        
        delegate bool RemoveFromListCallback(EntryClass entry, int index); //for thread-safe interface actions
        private bool RemoveFromList(EntryClass entry, int index)
        {
            if (List_Backup.InvokeRequired == true)
            {
                RemoveFromListCallback d = new RemoveFromListCallback(RemoveFromList);
                return (bool)this.Invoke(d, new object[] { entry, index });
            }
            else
            {
                if (entry != null)
                {
                    var items = List_Backup.Items;
                    var item = List_Backup.Items[index];
                    var subitems = item.SubItems;
                    string[] inList = new string[List_Backup.Items[index].SubItems.Count];

                    for (int i = 0; i < inList.Length; i++)
                        inList[i] = List_Backup.Items[index].SubItems[i].Text;

                    if (inList[1] == entry.Source && inList[2] == entry.Destination && inList[3] == ModeToString(entry.Mode)
                        && inList[4] == ProcessToString(entry.Process) && inList[5] == entry.LastPerformed
                        && inList[6] == entry.NextScheduled && inList[7] == entry.Status && inList[8] == AutomatedToString(entry.Automated))
                        return false;
                }

                List_Backup.Items.RemoveAt(index);
                return true;
            }
        }
        public string ModeToString(int mode)
        {
            if (mode == 0)
                return "Changed Files";
            if (mode == 1)
                return "New Copies";
            if (mode == 2)
                return "Replace Files";
            else
                return "Error: Unknown Mode";
        }
        public string ProcessToString(int process)
        {
            if (process == 0)
                return "Scheduled";
            if (process == 1)
                return "Timer";
            if (process == 2)
                return "Manual";
            else
                return "Error: Unknown Process";
        }
        private string AutomatedToString(bool automated)
        {
            if (automated == true)
                return "Yes";
            return "No";
        }
        private string GetDaysString(EntryClass entry)
        {
            string days = "";
            for (int i = 0; i < entry.Days.Length; i++)
                if (entry.Days[i] == true)
                    days += (i + 1) + ", ";

            if (days.Length != 0)
                days = days.Remove(days.Length - 2, 2);

            return days;
        }

        private void Update_SelectedEntry()
        {
            if (Entries == null)
            {
                Label_HeaderSelected.Text = "No Entries";

                Dynamic_Source.Visible = false;
                Dynamic_Destination.Visible = false;
                Dynamic_Mode.Visible = false;
                Dynamic_Process.Visible = false;
                Dynamic_Automated.Visible = false;
                Label_Process_Specific1.Visible = false;
                Label_Process_Specific2.Visible = false;
                Dynamic_Process_Specific1.Visible = false;
                Dynamic_Process_Specific2.Visible = false;

                return;
            }

            int i = _currentListSel;
            if (i == -1)
                i = 0;
            


            Dynamic_Source.Visible = true;
            Dynamic_Destination.Visible = true;
            Dynamic_Mode.Visible = true;
            Dynamic_Process.Visible = true;
            Dynamic_Automated.Visible = true;

            Label_HeaderSelected.Text = "Entry " + Entries[i].Entry;

            Dynamic_Source.Text = Entries[i].Source;
            Dynamic_Destination.Text = Entries[i].Destination;

            Dynamic_Mode.Text = ModeToString(Entries[i].Mode);

            string process = ProcessToString(Entries[i].Process);
            Dynamic_Process.Text = process;

            if (Entries[i].Automated == true)
            {
                Dynamic_Automated.Text = "Yes";
                Button_Activate.Text = "Deactivate";
                if (process == "Manual")
                {
                    Label_Automated.Visible = false;
                    Dynamic_Automated.Visible = false;
                }
                else
                {
                    Label_Automated.Visible = true;
                    Dynamic_Automated.Visible = true;
                }
            }
            else
            {
                Dynamic_Automated.Text = "No";
                Button_Activate.Text = "Activate";
                if (process == "Manual")
                {
                    Label_Automated.Visible = false;
                    Dynamic_Automated.Visible = false;
                }
                else
                {
                    Label_Automated.Visible = true;
                    Dynamic_Automated.Visible = true;
                }
            }
            
            if (process == "Scheduled")
            {
                Label_Process_Specific1.Text = "Days:";
                Label_Process_Specific1.Visible = true;
                Label_Process_Specific2.Text = "Time Of Day:";
                Label_Process_Specific2.Visible = true;

                Dynamic_Process_Specific1.Text = GetDaysString(Entries[i]);
                Dynamic_Process_Specific1.Visible = true;
                Dynamic_Process_Specific2.Text = Entries[i].TimeOfDay;
                Dynamic_Process_Specific2.Visible = true;

                Rectangle rect = Label_Automated.Bounds;
                Label_Automated.SetBounds(rect.X, _automatedLabelYSchedule, rect.Width, rect.Height);
                rect = Dynamic_Automated.Bounds;
                Dynamic_Automated.SetBounds(rect.X, _automatedLabelYSchedule, rect.Width, rect.Height);

            }
            else if (process == "Timer")
            {
                Label_Process_Specific1.Text = "Timer (minutes):";
                Label_Process_Specific1.Visible = true;
                Label_Process_Specific2.Text = "n/a";
                Label_Process_Specific2.Visible = false;

                Dynamic_Process_Specific1.Text = Entries[i].Timer.ToString();
                Dynamic_Process_Specific1.Visible = true;
                Dynamic_Process_Specific2.Text = "n/a";
                Dynamic_Process_Specific2.Visible = false;

                Rectangle rect = Label_Automated.Bounds;
                Label_Automated.SetBounds(rect.X, _automatedLabelYTimer, rect.Width, rect.Height);
                rect = Dynamic_Automated.Bounds;
                Dynamic_Automated.SetBounds(rect.X, _automatedLabelYTimer, rect.Width, rect.Height);
            }
            else if (process == "Manual")
            {
                Label_Process_Specific1.Text = "n/a";
                Label_Process_Specific1.Visible = false;
                Label_Process_Specific2.Text = "n/a";
                Label_Process_Specific2.Visible = false;

                Dynamic_Process_Specific1.Text = "n/a";
                Dynamic_Process_Specific1.Visible = false;
                Dynamic_Process_Specific2.Text = "n/a";
                Dynamic_Process_Specific2.Visible = false;
            }
        }

        private void List_Backup_Selection_Changed(object sender, EventArgs e)
        {
            if (List_Backup.SelectedItems.Count == 0)
                return;

            _currentListSel = List_Backup.SelectedItems[0].Index;
            Update_SelectedEntry();
        }


        delegate void AddToLogCallback(int entry, string error);
        private void AddToLog(int entry, string error)
        {
            string[] strArr = new string[3];
            ListViewItem item;
            strArr[0] = "Entry " + (entry + 1);
            strArr[1] = error;
            strArr[2] = GetTimeString(DateTime.Now);
            item = new ListViewItem(strArr);

            if (List_Log.InvokeRequired == true)
            {
                AddToLogCallback d = new AddToLogCallback(AddToLog);
                this.Invoke(d, new object[] { entry, error });
            }
            else
            {
                List_Log.Items.Insert(0, item);
            }
        }


        delegate void AddToListCallback(EntryClass entry, int index, int selection); //for thread-safe interface actions
        private void AddToList(EntryClass entry, int index, int selection)
        {
            
            string[] strArr = new string[9];
            ListViewItem item;
            strArr[0] = entry.Entry.ToString();
            strArr[1] = entry.Source;
            strArr[2] = entry.Destination;
            strArr[3] = ModeToString(entry.Mode);
            strArr[4] = ProcessToString(entry.Process);
            strArr[5] = entry.LastPerformed;
            strArr[6] = entry.NextScheduled;
            strArr[7] = entry.Status;
            strArr[8] = AutomatedToString(entry.Automated);
            item = new ListViewItem(strArr);
            item.ToolTipText = "test";

            if (index == -1)
                index = List_Backup.Items.Count;

            if (List_Backup.InvokeRequired == true)
            {
                AddToListCallback d = new AddToListCallback(AddToList);
                this.Invoke(d, new object[] { entry, index, selection });
            }
            else
            {
                List_Backup.Items.Insert(index, item);
                if (selection != -1)
                {
                    List_Backup.Items[selection].Selected = true;
                    return;
                }
                if (List_Backup.Items.Count == 1)
                    List_Backup.Items[0].Selected = true;
            }
        }
        private void Save()
        {
            try
            {
                File.Delete(_fullPath);
            }
            catch (IOException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                return;
            }
            catch (System.NotSupportedException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                return;
            }
            

            try
            {
                FileStream fs = File.Create(_fullPath);
                fs.Close();
            }
            catch (IOException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                return;
            }
            catch (System.NotSupportedException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                return;
            }

            if (File.Exists(_fullPath) == false)
                Application.Exit();


            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(_fullPath, true))
            {
                for (int i = 0; i < Entries.Length; i++)
                {

                    string writeString = "";

                    writeString += Entries[i].Entry + ";" + Entries[i].Source + ";" + Entries[i].Destination + ";" + Entries[i].Mode + ";" + Entries[i].Process + ";" + Entries[i].NextScheduled + ";" + Entries[i].LastPerformed + ";";
                    for (int k = 0; k < Entries[i].Days.Length; k++)
                        writeString += Entries[i].Days[k] + ";";
                    writeString += Entries[i].TimeOfDay + ";" + Entries[i].Timer + ";" + Entries[i].TotalSize + ";" + Entries[i].Automated;

                    try
                    {
                        file.WriteLine(writeString);
                    }
                    catch (IOException error)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                        return;
                    }
                    catch (System.NotSupportedException error)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
        }
        private int GetMinuteFromTimeOfDay(string timeOfDay)
        {
            string[] time = timeOfDay.Split(':');

            if (time.Length == 2)
            {
                if (time[0].Length == 2 && time[1].Length == 2)
                {
                    int minute = 0;
                    if (Int32.TryParse(time[1], out minute) == true)
                    {
                        return minute;
                    }
                }
            }
            return -1;
        }
        private int GetHourFromTimeOfDay(string timeOfDay)
        {
            string[] time = timeOfDay.Split(':');

            if (time.Length == 2)
            {
                if (time[0].Length == 2 && time[1].Length == 2)
                {
                    int hour = 0;
                    if (Int32.TryParse(time[0], out hour) == true)
                    {
                        return hour;
                    }
                }
            }
            return -1;
        }
        private string GetNextSchedulePerform(EntryClass entry)
        {
            DateTime lastPerformed = GetDateTimeFromString(entry.LastPerformed);

            string nextPerformString = "";

            int hits = 0;
            for (int i = 0; i < 31;  i ++)
            {
                if (entry.Days[i] == true)
                    hits++;
            }
            if (hits == 0)
                return "No Schedule";

            int[] days = new int[hits];
            int adds = 0;
            for (int i = 0; i < 31; i ++)
            {
                if (entry.Days[i] == true)
                {
                    days[adds] = i + 1;
                    adds++;
                }
            }

            int today = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            int schedHour = GetHourFromTimeOfDay(entry.TimeOfDay);
            int schedMinute = GetMinuteFromTimeOfDay(entry.TimeOfDay);

            int lastDay = lastPerformed.Day;
            int lastHour = lastPerformed.Hour;
            int lastMinute = lastPerformed.Minute;

            int foundDay = -1;
            int foundMonth = -1;
            int foundYear = -1;
            for (int i = days.Length - 1; i >= 0; i--)
            {
                if (days[i] == today)
                {
                    if (schedHour <= hour)
                    {
                        if (schedMinute <= minute)
                        {
                            if (schedHour == hour && schedMinute == minute)
                            {
                                if (lastDay == today && lastHour == hour && lastMinute == minute)
                                {

                                }
                                else
                                {
                                    foundDay = days[i];
                                    foundMonth = DateTime.Now.Month;
                                    foundYear = DateTime.Now.Year;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            foundDay = days[i];
                            foundMonth = DateTime.Now.Month;
                            foundYear = DateTime.Now.Year;
                            break;
                        }
                    }
                    else
                    {
                        foundDay = days[i];
                        foundMonth = DateTime.Now.Month;
                        foundYear = DateTime.Now.Year;
                        break;
                    }
                }
                if (days[i] > today)
                {
                    if (days[i] <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                    {
                        foundDay = days[i];
                        foundMonth = DateTime.Now.Month;
                        foundYear = DateTime.Now.Year;
                        break;
                    }
                }
            }
            if (foundDay == -1 || foundMonth == -1 || foundYear == -1)
            {
                for (int i = 0; i < days.Length; i++)
                {
                    if (days[i] <= today)
                    {
                        if (days[i] <= DateTime.DaysInMonth(DateTime.Now.Year, ((DateTime)DateTime.Now.AddMonths(1)).Month))
                        {
                            foundDay = days[i];
                            foundMonth = ((DateTime)DateTime.Now.AddMonths(1)).Month;
                            foundYear = ((DateTime)DateTime.Now.AddMonths(1)).Year;
                            break;
                        }
                    }
                }
            }

            if (foundDay == -1 || foundMonth == -1 || foundYear == -1)
            {
                return "error";
            }
            
            return nextPerformString = foundDay + "/" + foundMonth + "/" + foundYear + "-" + entry.TimeOfDay;
        }
        public void CheckAction()
        {
            if (_editNewOngoing == true)
                return;

            
            for (int i = 0; i < Entries.Length; i++)
            {
                string process = ProcessToString(Entries[i].Process);
                if (process == "Manual")
                {
                    if (Entries[i].Status == "In Queue" || Entries[i].Status == "In Progress")
                    {
                        /*
                        Entries[i].Ongoing = true;
                        Perform(i);
                        string str = GetTimeString(DateTime.Now);
                        Entries[i].LastPerformed = str;
                        Entries[i].Status = "Resting";
                        Entries[i].Ongoing = false;
                        */
                    }

                    if (Entries[i].NextScheduled != "Manual Mode") ;
                    {
                        Entries[i].NextScheduled = "Manual Mode";
                        Save();
                    }

                    int selectedIndex = GetSelectedListIndex(List_Backup);
                    if (RemoveFromList(Entries[i], i) == true)
                        AddToList(Entries[i], i, selectedIndex);
                    continue;
                }

                string lp = Entries[i].LastPerformed;
                string status = Entries[i].Status;
                if (process == "Scheduled" || process == "Timer")
                {

                    if (Entries[i].Automated == false)
                    {
                        //if (lp == "In Queue" || lp == "In Progress" || lp == "")
                        //Entries[i].LastPerformed = "Manual Mode";

                        if (Entries[i].NextScheduled != "Manual Mode")
                        {
                            Entries[i].NextScheduled = "Manual Mode";
                            Save();
                        }

                        int selectedIndex = GetSelectedListIndex(List_Backup);
                        if (RemoveFromList(Entries[i], i) == true)
                            AddToList(Entries[i], i, selectedIndex);
                        continue;
                    }
                }

                if (process == "Scheduled")
                {
                    DateTime now = DateTime.Now;

                    if (status == "In Queue" || status ==  "In Progress")
                    {

                    }
                    else
                    {
                        DateTime lastPerformed = GetDateTimeFromString(Entries[i].LastPerformed);
                        

                        string nextPerform = GetNextSchedulePerform(Entries[i]);
                        Entries[i].NextScheduled = nextPerform;

                        string nowString = GetTimeString(DateTime.Now);

                        if (nowString == nextPerform)
                            if (nowString != Entries[i].LastPerformed)
                                Entries[i].Status = "In Queue";

                        Save();

                        int selectedIndex = GetSelectedListIndex(List_Backup);
                        if (RemoveFromList(Entries[i], i) == true)
                            AddToList(Entries[i], i, selectedIndex);



                        /*

                        int today = now.Day - 1;

                        bool found = false;
                        int lastScheduledDay = today;
                        for (; lastScheduledDay >= 0; lastScheduledDay--)
                        {
                            if (Entries[i].Days[lastScheduledDay] == true)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (found == false)
                        {
                            lastScheduledDay = 30;
                            for (; lastScheduledDay >= 0; lastScheduledDay--)
                            {
                                if (Entries[i].Days[lastScheduledDay] == true)
                                {
                                    break;
                                }
                            }
                        }

                        if (lastPerformed.Day - 1 <= lastScheduledDay)
                        {
                            if (lastPerformed.Hour >= GetHourFromTimeOfDay(Entries[i].TimeOfDay))
                            {
                                if (lastPerformed.Minute >= GetMinuteFromTimeOfDay(Entries[i].TimeOfDay))
                                    continue;
                            }
                        }

                        if (now.Hour < GetHourFromTimeOfDay(Entries[i].TimeOfDay))
                            continue;
                        if (now.Hour == GetHourFromTimeOfDay(Entries[i].TimeOfDay) && now.Minute < GetMinuteFromTimeOfDay(Entries[i].TimeOfDay))
                            continue;
                        
                        */


                        
                    }

                    bool a = false;
                    if (Entries[i].Ongoing == false && a == true)
                    {
                        Entries[i].Ongoing = true;
                        Perform(i);
                        string str = GetTimeString(DateTime.Now);
                        Entries[i].LastPerformed = str;
                        Entries[i].Status = "Resting";
                        Entries[i].Ongoing = false;

                        string nextPerform = GetNextSchedulePerform(Entries[i]);
                            
                        Entries[i].NextScheduled = nextPerform;

                        Save();

                        int selectedIndex = GetSelectedListIndex(List_Backup);
                        if (RemoveFromList(Entries[i], i) == true)
                            AddToList(Entries[i], i, selectedIndex);
                    }
                }

                if (process == "Timer")
                {
                    if (lp == "Never")
                    {
                        Entries[i].Status = "In Queue";

                        int selectedIndex = GetSelectedListIndex(List_Backup);
                        if (RemoveFromList(Entries[i], i) == true)
                            AddToList(Entries[i], i, selectedIndex);

                    }
                    else if (status == "In Queue" || status == "In Progress")
                    {
                    }
                    else
                    {
                        string nextPerform = "";
                        bool perform = CalculateTimeDifference(Entries[i].LastPerformed, Entries[i].Timer, out nextPerform);
                        if (Entries[i].NextScheduled != nextPerform)
                            Entries[i].NextScheduled = nextPerform;

                        if (perform == true)
                            Entries[i].Status = "In Queue";
                        
                        int selectedIndex = GetSelectedListIndex(List_Backup);
                        if (RemoveFromList(Entries[i], i) == true)
                            AddToList(Entries[i], i, selectedIndex);

                        Save();
                    }

                    bool b = false;
                    if (Entries[i].Ongoing == false && b == true)
                    {
                        Entries[i].Ongoing = true;
                        Perform(i);
                        string str = GetTimeString(DateTime.Now);
                        Entries[i].LastPerformed = str;
                        Entries[i].Status = "Resting";
                        Entries[i].Ongoing = false;

                        string nextPerform = "";
                        CalculateTimeDifference(Entries[i].LastPerformed, Entries[i].Timer, out nextPerform);
                        Entries[i].NextScheduled = nextPerform;

                        Save();

                        int selectedIndex = GetSelectedListIndex(List_Backup);
                        if (RemoveFromList(Entries[i], i) == true)
                            AddToList(Entries[i], i, selectedIndex);
                    }
                }
            }

            for (int i = 0; i < Entries.Length; i++)
            {
                if (Entries[i].Status == "In Queue")
                {
                    if (Entries[i].Ongoing == false)
                    {
                        Entries[i].Ongoing = true;
                        Perform(i);
                        string str = GetTimeString(DateTime.Now);
                        Entries[i].LastPerformed = str;
                        Entries[i].Status = "Resting";
                        Entries[i].Ongoing = false;


                        string process = ProcessToString(Entries[i].Process);
                        if (process == "Scheduled")
                        {
                            string nextPerform = GetNextSchedulePerform(Entries[i]);
                            Entries[i].NextScheduled = nextPerform;
                        }
                        else if (process == "Timer")
                        {
                            string nextPerform;
                            CalculateTimeDifference(Entries[i].LastPerformed, Entries[i].Timer, out nextPerform);
                            Entries[i].NextScheduled = nextPerform;
                        }
                        Save();

                        int selectedIndex = GetSelectedListIndex(List_Backup);
                        if (RemoveFromList(Entries[i], i) == true)
                            AddToList(Entries[i], i, selectedIndex);
                    }
                }
            }


        }
        private string GetTimeString(DateTime dt)
        {
            string str = "";

            string hour = dt.Hour.ToString();
            if (hour.Length == 1)
                hour = "0" + hour;
            string minute = dt.Minute.ToString();
            if (minute.Length == 1)
                minute = "0" + minute;
            
            str += dt.Day + "/" + dt.Month + "/" + dt.Year + "-" + hour + ":" + minute;

            return str;
        }
        private DateTime GetDateTimeFromString(string dateString)
        {
            string[] slashSplit = dateString.Split('/');
            string[] minusSplit = slashSplit[2].Split('-');
            string[] colonSplit = minusSplit[1].Split(':');


            int day = Int32.Parse(slashSplit[0]);
            int month = Int32.Parse(slashSplit[1]);
            int year = Int32.Parse(minusSplit[0]);
            int hour = Int32.Parse(colonSplit[0]);
            int minute = Int32.Parse(colonSplit[1]);

            return new DateTime(year, month, day, hour, minute, 0);
        }
        private bool CalculateTimeDifference(String lastTime, int timer, out string nextPerform)
        {
            DateTime currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            DateTime lastDate = GetDateTimeFromString(lastTime);

            DateTime nextDate = lastDate.AddMinutes(timer);
            nextPerform = GetTimeString(nextDate);

            double minutes = currentTime.Subtract(lastDate).TotalMinutes;

            if ((int)minutes >= timer)
                return true;
            return false;
        }
        
        
        private void Language_Label_Click(object sender, EventArgs e)
        {
            if (sender == Language_Label_English)
                Language_Label_English.Font = new Font(Language_Label_English.Font, FontStyle.Italic);
            else
                Language_Label_English.Font = new Font(Language_Label_English.Font, FontStyle.Regular);

            if (sender == Language_Label_Swedish)
                Language_Label_Swedish.Font = new Font(Language_Label_Swedish.Font, FontStyle.Italic);
            else
                Language_Label_Swedish.Font = new Font(Language_Label_Swedish.Font, FontStyle.Regular);

            if (sender == Language_Label_Finnish)
                Language_Label_Finnish.Font = new Font(Language_Label_Finnish.Font, FontStyle.Italic);
            else
                Language_Label_Finnish.Font = new Font(Language_Label_Finnish.Font, FontStyle.Regular);
            
            Properties.Settings.Default.Language = ((Control)sender).Text;
            Properties.Settings.Default.Save();
        }
        
        private void MouseEnter_BlackFont(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.Black;
        }
        private void MouseEnter_LanguageLabels(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.Black;
        }
        private void MouseLeave_LanguageLabels(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.FromArgb(66, 66, 66); 
        }

        private void MouseLeave_Regular(object sender, EventArgs e)
        {
            if (sender ==  Label_Settings)
                if (Settings_Panel.Visible == true)
                    return;
            if (sender == Label_Language)
                if (Language_Panel.Visible == true)
                    return;
            if (sender == Label_Themes)
                if (Theme_Panel.Visible == true)
                    return;
            if (sender == Label_About)
                if (About_Panel.Visible == true)
                    return;
            ((Control)sender).ForeColor = Color.FromArgb(66, 66, 66);
        }

        private void Settings_Check_Minimized_CheckedChanged(object sender, EventArgs e)
        {
            bool minimized = Settings_Check_Minimized.Checked;
            if (minimized)
            {
                Properties.Settings.Default.MinimizedOnStartup = true;
            }
            else
            {
                Properties.Settings.Default.MinimizedOnStartup = false;
            }
            Properties.Settings.Default.Save();
        }

        private void Label_Settings_Click(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(66, 66, 66);

            int index = 0;

            for (int i = 0; i < _privateSettingsPanels.Count(); i++)
            {
                if (_privateSettingsPanels[i] == null)
                    continue;
                if (_privateSettingsLabels[i] != sender)
                {
                    _privateSettingsPanels[i].Visible = false;
                    _privateSettingsLabels[i].ForeColor = color;
                }
                else
                    index = i;
            }
            
            bool visible = _privateSettingsPanels[index].Visible;

            if (visible == true)
                _privateSettingsPanels[index].Visible = false;
            else
                _privateSettingsPanels[index].Visible = true;
        }

        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private void Settings_Check_Autorun_CheckedChanged(object sender, EventArgs e)
        {
            bool autorun = Settings_Check_Autorun.Checked;
            if (autorun)
            {
                rkApp.SetValue("DarcyBackup", Application.ExecutablePath);
            }
            else
            {
                rkApp.DeleteValue("DarcyBackup", false);
            }
        }

        private void Button_Perform_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (List_Backup.SelectedItems.Count > 0)
            {
                index = List_Backup.Items.IndexOf(List_Backup.SelectedItems[0]);
            }
            else
                return;


            Entries[index].Status = "In Queue";

            Save();
            int selectedIndex = GetSelectedListIndex(List_Backup);
            if (RemoveFromList(Entries[index], index) == true)
                AddToList(Entries[index], index, selectedIndex);
        }

        public void SaveEditNew(EntryClass entry)
        {
            if (_editNewOngoing == true)
            {
                if (_editNewObj != null)
                {
                    _editNewObj.Close();
                    _editNewObj = null;
                    _editNewOngoing = false;
                    
                    //New
                    if (entry.Entry == Entries.Length + 1)
                    {
                        AddEntry(entry);
                        AddToList(entry, -1, -1);

                        Save();
                    }

                    //Edit
                    else
                    {
                        for (int i = 0; i < Entries.Length; i ++)
                        {
                            if (Entries[i].Entry == entry.Entry)
                            {
                                Entries[i] = entry;

                                Save();

                                int selection = GetSelectedListIndex(List_Backup);
                                if (RemoveFromList(entry, i) == true)
                                    AddToList(entry, i, selection);
                                

                            }
                        }
                    }
                }
            }
        }

        public void DiscardEditNew()
        {
            if (_editNewOngoing == true)
            {
                if (_editNewObj != null)
                {
                    _editNewObj = null;
                    _editNewOngoing = false;
                }
            }
        }

        private void Button_Activate_Click(object sender, EventArgs e)
        {
            if (List_Backup.SelectedItems.Count == 0)
                return;

            int i = List_Backup.SelectedItems[0].Index;

            if (ProcessToString(Entries[i].Process) == "Manual")
                return;

            if (Entries[i].Automated == true)
                Entries[i].Automated = false;
            else
                Entries[i].Automated = true;

            Save();

            if (RemoveFromList(Entries[i], i) == true)
                AddToList(Entries[i], i, i);
            
        }
        public EntryClass GetEntry(int id)
        {
            return Entries[id];
        }
        private void Button_New_Click(object sender, EventArgs e)
        {
            if (_editNewOngoing == true)
                return;

            _editNewObj = new Form_New_Entry(this, 0, Entries.Length + 1);
            _editNewObj.Show();
            _editNewOngoing = true;
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (List_Backup.SelectedItems.Count == 0)
                return;
            if (_editNewOngoing == true)
                return;

            int i = List_Backup.SelectedItems[0].Index;

            _editNewObj = new Form_New_Entry(this, 1, i);
            _editNewObj.Show();
            _editNewOngoing = true;
        }

        private void DarcyFormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void Settings_Check_Tray_CheckedChanged(object sender, EventArgs e)
        {

            bool minimized = Settings_Check_Tray.Checked;
            if (minimized)
            {
                Properties.Settings.Default.ToTray = true;
            }
            else
            {
                Properties.Settings.Default.ToTray = false;
            }
            Properties.Settings.Default.Save();
        }
    }
}
