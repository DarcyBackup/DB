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

        
        
        delegate void RemoveFromListCallback(int index); //for thread-safe interface actions
        private void RemoveFromList(int index)
        {
            if (List_Backup.InvokeRequired == true)
            {
                RemoveFromListCallback d = new RemoveFromListCallback(RemoveFromList);
                this.Invoke(d, new object[] { index });
            }
            else
                List_Backup.Items.RemoveAt(index);
        }
        private string ModeToString(int mode)
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
        private string ProcessToString(int process)
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
        delegate void AddToListCallback(EntryClass entry, int index); //for thread-safe interface actions
        private void AddToList(EntryClass entry, int index)
        {
            
            string[] strArr = new string[8];
            ListViewItem item;
            strArr[0] = entry.Entry.ToString();
            strArr[1] = entry.Source;
            strArr[2] = entry.Destination;
            strArr[3] = ModeToString(entry.Mode);
            strArr[4] = ProcessToString(entry.Process);
            strArr[5] = entry.LastPerformed;
            strArr[6] = entry.NextScheduled;
            strArr[7] = AutomatedToString(entry.Automated);
            item = new ListViewItem(strArr);

            if (index == -1)
                index = List_Backup.Items.Count;

            if (List_Backup.InvokeRequired == true)
            {
                AddToListCallback d = new AddToListCallback(AddToList);
                this.Invoke(d, new object[] { entry, index });
            }
            else
                List_Backup.Items.Insert(index, item);
        }
        private void Save()
        {

            File.Delete(fullPath);

            FileStream fs = File.Create(fullPath);
            fs.Close();
            //File.Encrypt(fullPath); //replace this with a program specific encryption

            if (File.Exists(fullPath) == false)
                Application.Exit();


            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(fullPath, true))
            {
                for (int i = 0; i < Entries.Length; i++)
                {

                    string writeString = "";

                    writeString += Entries[i].Entry + ";" + Entries[i].Source + ";" + Entries[i].Destination + ";" + Entries[i].Mode + ";" + Entries[i].Process + ";" + Entries[i].NextScheduled + ";" + Entries[i].LastPerformed + ";";
                    for (int k = 0; k < Entries[i].Days.Length; k++)
                        writeString += Entries[i].Days[k] + ";";
                    writeString += Entries[i].TimeOfDay + ";" + Entries[i].Timer + ";" + Entries[i].TotalSize + ";" + Entries[i].Automated;

                    file.WriteLine(writeString);
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
            bool[] entryDays = new bool[31];
            entryDays[0] = true;
            entryDays[15] = true;

            entry.Days = entryDays;

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
            for (int i = 0; i < Entries.Length; i++)
            {
                string process = ProcessToString(Entries[i].Process);
                if (process == "Manual")
                    continue;

                string lp = Entries[i].LastPerformed;
                if (process == "Scheduled" || process == "Timer")
                {

                    if (Entries[i].Automated == false)
                    {
                        if (lp == "In Queue" || lp == "In Progress" || lp == "")
                            Entries[i].LastPerformed = "Manual Mode";

                        Entries[i].NextScheduled = "Manual Mode";
                        Save();

                        RemoveFromList(i);
                        AddToList(Entries[i], i);
                        continue;
                    }
                }

                if (process == "Scheduled")
                {
                    DateTime now = DateTime.Now;
                    DateTime lastPerformed = GetDateTimeFromString(Entries[i].LastPerformed);

                    string nextPerform = GetNextSchedulePerform(Entries[i]);
                    Entries[i].NextScheduled = nextPerform;
                    Save();

                    RemoveFromList(i);
                    AddToList(Entries[i], i);

                    int today = now.Day - 1;
                    
                    bool found = false;
                    int lastScheduledDay = today;
                    for (; lastScheduledDay >= 0; lastScheduledDay --)
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
                        for (; lastScheduledDay >= 0; lastScheduledDay --)
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

                    if (Entries[i].Ongoing == false)
                    {
                        Entries[i].Ongoing = true;
                        Perform(i);
                        string str = GetTimeString(DateTime.Now);
                        Entries[i].LastPerformed = str;
                        Entries[i].Ongoing = false;

                        nextPerform = GetNextSchedulePerform(Entries[i]);
                            
                        Entries[i].NextScheduled = nextPerform;

                        Save();

                        RemoveFromList(i);
                        AddToList(Entries[i], i);
                    }
                }

                if (process == "Timer")
                {
                    if (lp == "Never" || lp == "In Queue" || lp == "In Progress" || lp == "")
                    {
                    }
                    else
                    {
                        string nextPerform = "";
                        bool perform = CalculateTimeDifference(Entries[i].LastPerformed, Entries[i].Timer, out nextPerform);
                        if (Entries[i].NextScheduled != nextPerform)
                        {
                            Entries[i].NextScheduled = nextPerform;

                            Save();

                            RemoveFromList(i);
                            AddToList(Entries[i], i);
                        }

                        if (perform == false)
                            continue;
                    }

                    if (Entries[i].Ongoing == false)
                    {
                        Entries[i].Ongoing = true;
                        Perform(i);
                        string str = GetTimeString(DateTime.Now);
                        Entries[i].LastPerformed = str;
                        Entries[i].Ongoing = false;

                        string nextPerform = "";
                        CalculateTimeDifference(Entries[i].LastPerformed, Entries[i].Timer, out nextPerform);
                        Entries[i].NextScheduled = nextPerform;

                        Save();

                        RemoveFromList(i);
                        AddToList(Entries[i], i);
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
        
        private void Label_About_Click(object sender, EventArgs e)
        {
            Settings_Language_Panel.Visible = false;
            Label_Settings.ForeColor = Color.FromArgb(66, 66, 66);
            Settings_Panel.Visible = false;

            bool visible = About_Panel.Visible;

            if (visible == true)
                About_Panel.Visible = false;
            else
                About_Panel.Visible = true;
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

        private void Settings_Label_Language_Click(object sender, EventArgs e)
        {
            bool visible = Settings_Language_Panel.Visible;

            if (visible == true)
                Settings_Language_Panel.Visible = false;
            else
                Settings_Language_Panel.Visible = true;
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
            About_Panel.Visible = false;
            Label_About.ForeColor = Color.FromArgb(66, 66, 66);

            bool visible = Settings_Panel.Visible;

            if (visible == true)
            {
                Settings_Language_Panel.Visible = false;
                Settings_Panel.Visible = false;
            }
            else
                Settings_Panel.Visible = true;
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


            Entries[index].LastPerformed = "In Queue";

            Save();

            RemoveFromList(index);
            AddToList(Entries[index], index);
        }

        public void SaveEditNew(EntryClass entry)
        {
            if (EditNewOngoing == true)
            {
                if (EditNewObj != null)
                {
                    EditNewObj.Close();
                    EditNewObj = null;
                    EditNewOngoing = false;
                    
                    //New
                    if (entry.Entry == Entries.Length + 1)
                    {
                        AddEntry(entry);
                        AddToList(entry, -1);
                    }

                    //Edit
                    else
                    {
                        for (int i = 0; i < Entries.Length; i ++)
                        {
                            if (Entries[i].Entry == entry.Entry)
                            {
                                Entries[i] = entry;
                            }
                        }
                    }
                }
            }
        }

        public void DiscardEditNew()
        {
            if (EditNewOngoing == true)
            {
                if (EditNewObj != null)
                {
                    EditNewObj.Close();
                    EditNewObj = null;
                    EditNewOngoing = false;
                }
            }
        }
        private void Button_New_Click(object sender, EventArgs e)
        {
            EditNewObj = new Form_New_Entry(this, 0, Entries.Length + 1);
            EditNewObj.Show();
            EditNewOngoing = true;
        }
    }
}
