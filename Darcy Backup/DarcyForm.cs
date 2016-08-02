/*
Copyright 2016 Marcel Siggelsten

This file is part of Darcy Backup.

Darcy Backup is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, 
either version 2 of the License, or (at your option) any later version.

Darcy Backup is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with Darcy. If not, see http://www.gnu.org/licenses/.
*/

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
        
        delegate void EnableCancelCallback(bool b);
        public void EnableCancel(bool b)
        {
            if (List_Backup.InvokeRequired == true)
            {
                EnableCancelCallback d = new EnableCancelCallback(EnableCancel);
                this.Invoke(d, new object[] { b });
            }
            else
            {
                Button_Cancel.Enabled = b;
            }
        }
        delegate bool RemoveFromListCallback(EntryClass entry, int index); 
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

            int i = CurrentListSel;
            if (i == -1)
            {
                Button_Cancel.Enabled = false;
                i = 0;
            }
            else
            {
                if (Entries[i].Status != "Resting")
                    Button_Cancel.Enabled = true;
                else
                    Button_Cancel.Enabled = false;
            }

            Dynamic_Source.Visible = true;
            Dynamic_Destination.Visible = true;
            Dynamic_Mode.Visible = true;
            Dynamic_Process.Visible = true;
            Dynamic_Automated.Visible = true;

            Label_HeaderSelected.Text = "Entry " + Entries[i].Entry;

            Dynamic_Source.Text = Entries[i].Source;
            Dynamic_Destination.Text = Entries[i].Destination;

            Dynamic_Mode.Text = ModeToString(Entries[i].Mode);

            if (Entries[i].Mode == 0)
            {
                if (Entries[i].Hash == true)
                    Dynamic_Hash.Text = "Yes";
                else
                    Dynamic_Hash.Text = "No";
                Dynamic_Hash.Visible = true;
                Label_Hash.Visible = true;
            }
            else
            {
                Dynamic_Hash.Visible = false;
                Label_Hash.Visible = false;
            }


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
                    Button_Activate.Enabled = false;
                }
                else
                {
                    Label_Automated.Visible = true;
                    Dynamic_Automated.Visible = true;
                    Button_Activate.Enabled = true;
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
                    Button_Activate.Enabled = false;
                }
                else
                {
                    Label_Automated.Visible = true;
                    Dynamic_Automated.Visible = true;
                    Button_Activate.Enabled = true;
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

                Label_Hash.SetBounds(rect.X, _automatedLabelYSchedule + 30, rect.Width, rect.Height);


                rect = Dynamic_Automated.Bounds;
                Dynamic_Automated.SetBounds(rect.X, _automatedLabelYSchedule, rect.Width, rect.Height);

                Dynamic_Hash.SetBounds(rect.X, _automatedLabelYSchedule + 30, rect.Width, rect.Height);

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

                Label_Hash.SetBounds(rect.X, _automatedLabelYTimer + 30, rect.Width, rect.Height);


                rect = Dynamic_Automated.Bounds;
                Dynamic_Automated.SetBounds(rect.X, _automatedLabelYTimer, rect.Width, rect.Height);

                Dynamic_Hash.SetBounds(rect.X, _automatedLabelYTimer + 30, rect.Width, rect.Height);
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


                Rectangle rect = Label_Process.Bounds;
                Label_Hash.SetBounds(rect.X, rect.Y + 30, rect.Width, rect.Height);

                
                rect = Dynamic_Process.Bounds;
                Dynamic_Hash.SetBounds(rect.X, rect.Y + 30, rect.Width, rect.Height);

            }
        }

        private void List_Backup_Selection_Changed(object sender, EventArgs e)
        {
            if (List_Backup.SelectedItems.Count == 0)
                return;

            CurrentListSel = List_Backup.SelectedItems[0].Index;
            Update_SelectedEntry();
        }


        delegate void AddToLogCallback(int entry, string error, string tag);
        public void AddToLog(int entry, string error, string tag)
        {
            string[] strArr = new string[3];
            ListViewItem item;
            strArr[0] = "Entry " + (entry + 1);
            strArr[1] = error;
            strArr[2] = GetTimeString(DateTime.Now);
            item = new ListViewItem(strArr);
            if (tag == "")
                item.Tag = error;
            else
                item.Tag = tag;

            if (List_Log.InvokeRequired == true)
            {
                AddToLogCallback d = new AddToLogCallback(AddToLog);
                this.Invoke(d, new object[] { entry, error, tag});
            }
            else
            {
                List_Log.Items.Insert(0, item);
            }
        }
        delegate void UpdateListItemCallback(EntryClass entry, int index);
        public void UpdateListItem(EntryClass entry, int index)
        {
            string[] strArr = new string[9];
            strArr[0] = entry.Entry.ToString();
            strArr[1] = entry.Source;
            strArr[2] = entry.Destination;
            strArr[3] = ModeToString(entry.Mode);
            strArr[4] = ProcessToString(entry.Process);
            strArr[5] = entry.LastPerformed;
            strArr[6] = entry.NextScheduled;
            strArr[7] = entry.Status;
            strArr[8] = AutomatedToString(entry.Automated);


            if (List_Backup.InvokeRequired == true)
            {
                UpdateListItemCallback d = new UpdateListItemCallback(UpdateListItem);
                if (this.IsDisposed == false)
                    this.Invoke(d, new object[] { entry, index });
            }
            else
            {

                List_Backup.Items[index].SubItems[0].Text = entry.Entry.ToString();
                List_Backup.Items[index].SubItems[1].Text = entry.Source;
                List_Backup.Items[index].SubItems[2].Text = entry.Destination;
                List_Backup.Items[index].SubItems[3].Text = ModeToString(entry.Mode);
                List_Backup.Items[index].SubItems[4].Text = ProcessToString(entry.Process);
                List_Backup.Items[index].SubItems[5].Text = entry.LastPerformed;
                List_Backup.Items[index].SubItems[6].Text = entry.NextScheduled;
                List_Backup.Items[index].SubItems[7].Text = entry.Status;
                List_Backup.Items[index].SubItems[8].Text = AutomatedToString(entry.Automated);


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
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    File.Delete(_fullPath);
                    break;
                }
                catch (IOException error)
                {
                    if (i == 9)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                        return;
                    }
                    else
                        continue;
                }
                catch (System.NotSupportedException error)
                {
                    if (i == 9)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                        return;
                    }
                    else
                        continue;
                }
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


            try
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(_fullPath, true))
                {
                    for (int i = 0; i < Entries.Length; i++)
                    {

                        string writeString = "";

                        writeString += Entries[i].Entry + ";" + Entries[i].Source + ";" + Entries[i].Destination + ";" + Entries[i].Mode + ";" + Entries[i].Process + ";" + Entries[i].NextScheduled + ";" + Entries[i].LastPerformed + ";";
                        for (int k = 0; k < Entries[i].Days.Length; k++)
                            writeString += Entries[i].Days[k] + ";";
                        writeString += Entries[i].TimeOfDay + ";" + Entries[i].Timer + ";" + Entries[i].TotalSize + ";" + Entries[i].Automated + ";" + Entries[i].Hash;

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
            catch (IOException error)
            {
                return;
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
            DateTime lastPerformed;
            if (entry.LastPerformed != "Never")
                lastPerformed = GetDateTimeFromString(entry.LastPerformed);
            else
                lastPerformed = new DateTime();

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



            //Check if today is a scheduled day
            for (int i = 0; i < days.Length; i ++)
            {
                if (days[i] == today)
                {
                    //Has the schedule hour:minute passed?
                    if (hour < schedHour || (hour == schedHour && minute <= schedMinute))
                    {
                        //Has it already been performed this day:hour:minute?
                        if (entry.LastPerformed != "Never" && lastDay == today && lastHour == hour && lastMinute == minute)
                        {

                        }
                        else
                        {
                            foundDay = days[i];
                            foundMonth = DateTime.Now.Month;
                            foundYear = DateTime.Now.Year;
                            return nextPerformString = foundDay + "/" + foundMonth + "/" + foundYear + "-" + entry.TimeOfDay;
                        }
                    }
                    //Set scheduled to next day, if there is any
                    if (i + 1 < days.Length)
                    {
                        foundDay = days[i + 1];
                        foundMonth = DateTime.Now.Month;
                        foundYear = DateTime.Now.Year;
                        return nextPerformString = foundDay + "/" + foundMonth + "/" + foundYear + "-" + entry.TimeOfDay;
                    }
                    //If there is no next, the first entry must be the closest
                    else
                    {
                        foundDay = days[0];
                        foundMonth = ((DateTime)DateTime.Now.AddMonths(1)).Month;
                        foundYear = ((DateTime)DateTime.Now.AddMonths(1)).Year;
                        return nextPerformString = foundDay + "/" + foundMonth + "/" + foundYear + "-" + entry.TimeOfDay;
                    }
                }
            }

            //days[0] is not today, so it is safe to do this
            if (days.Length == 0)
            {
                foundDay = days[0];
                foundMonth = DateTime.Now.Month;
                foundYear = DateTime.Now.Year;
                return nextPerformString = foundDay + "/" + foundMonth + "/" + foundYear + "-" + entry.TimeOfDay;
            }


            //Try and find the first (if any) scheduled day before today and return i + 1
            for (int i = days.Length - 1; i >= 0; i --)
            {
                //Because of the break, this will be the first time a val is == or < today
                if (days[i] == today || days[i] < today)
                {
                    //Since this is the first hit, i + 1 (if !null) must be > today
                    if (i + 1 < days.Length)
                    {
                        foundDay = days[i + 1];
                        foundMonth = DateTime.Now.Month;
                        foundYear = DateTime.Now.Year;
                        return nextPerformString = foundDay + "/" + foundMonth + "/" + foundYear + "-" + entry.TimeOfDay;
                    }
                    //No scheduled day is < or == today
                    else
                        break;
                }
            }

            //Try and find the first (if any) scheduled day after today and retrn i
            for (int i = 0; i < days.Length; i ++)
            {
                if (days[i] > today)
                {
                    foundDay = days[i];
                    foundMonth = DateTime.Now.Month;
                    foundYear = DateTime.Now.Year;
                    return nextPerformString = foundDay + "/" + foundMonth + "/" + foundYear + "-" + entry.TimeOfDay;
                }
            }
            
            
            //No scheduled day today or later this month is legal. Add 1 month to the first day and return
            foundDay = days[0];
            foundMonth = ((DateTime)DateTime.Now.AddMonths(1)).Month;
            foundYear = ((DateTime)DateTime.Now.AddMonths(1)).Year;
            return nextPerformString = foundDay + "/" + foundMonth + "/" + foundYear + "-" + entry.TimeOfDay;
        }
        public void QueueAction()
        {
            if (_editNewOngoing == true)
                return;
            
            for (int i = 0; i < Entries.Length; i++)
            {
                string process = ProcessToString(Entries[i].Process);
                if (process == "Manual" || (Entries[i].Automated == false && (process == "Scheduled" || process == "Timer")))
                {
                    if (Entries[i].NextScheduled != "Manual Mode");
                    {
                        Entries[i].NextScheduled = "Manual Mode";
                        UpdateListItem(Entries[i], i);
                        Save();
                    }
                    continue;
                }

                string lastPerformed = Entries[i].LastPerformed;
                string status = Entries[i].Status;
                bool perform = false;

                if (process == "Scheduled")
                {
                    DateTime now = DateTime.Now;

                    if (status == "Resting")
                    { 
                        string nextPerform = GetNextSchedulePerform(Entries[i]);
                        Entries[i].NextScheduled = nextPerform;

                        string nowString = GetTimeString(DateTime.Now);

                        if (nowString == nextPerform)
                            if (nowString != Entries[i].LastPerformed)
                                perform = true;
                    }
                }
                else if (process == "Timer")
                {
                    if (lastPerformed == "Never")
                    {
                        Entries[i].Status = "In Queue";
                        UpdateListItem(Entries[i], i);
                    }
                    else if (status == "Resting")
                    {
                        string nextPerform = "";
                        perform = CalculateTimeDifference(Entries[i].LastPerformed, Entries[i].Timer, out nextPerform);
                        Entries[i].NextScheduled = nextPerform;
                    }
                }

                if (perform == true)
                {
                    Entries[i].Status = "In Queue";
                    if (i == CurrentListSel)
                        EnableCancel(true);
                }

                UpdateListItem(Entries[i], i);
                Save();
            }
        }
        public void CheckPerform()
        {
            if (_editNewOngoing == true)
                return;

            for (int i = 0; i < Entries.Length; i++)
            {
                if (Entries[i].Status == "In Queue")
                {
                    if (Entries[i].Ongoing == false)
                    {
                        Entries[i].Ongoing = true;
                        perform.Start(i);
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

                        UpdateListItem(Entries[i], i);
                        Save();
                        
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
            string language = "";
            if (sender == Language_Label_English || sender == Language_Img_English)
            {
                Language_Img_English.Image = Properties.Resources.Check2;
                language = "English";
            }
            else
                Language_Img_English.Image = null;

            if (sender == Language_Label_Swedish || sender == Language_Img_Swedish)
            {
                Language_Img_Swedish.Image = Properties.Resources.Check2;
                language = "Swedish";
            }
            else
                Language_Img_Swedish.Image = null;

            if (sender == Language_Label_Finnish || sender == Language_Img_Finnish)
            {
                Language_Img_Finnish.Image = Properties.Resources.Check2;
                language = "Finnish";
            }
            else
                Language_Img_Finnish.Image = null;
            
            if (language == "")
                language = "English";


            Properties.Settings.Default.Language = language;
            Properties.Settings.Default.Save();
        }
        
        private void MouseEnter_BlackFont(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.Black;

            if (((Control)sender).GetType() == typeof(DarcyLabel))
            {
                if (((Control)sender).Tag != null)
                {
                    if (((Label)((Control)sender).Tag).Image != null)
                    {
                        ((Label)((Control)sender).Tag).Image = Properties.Resources.Check2;
                        ((Label)((Control)sender).Tag).Invalidate();
                    }
                }
            }
            else if (((Control)sender).GetType() == typeof(DarcyImgLabel))
            {
                if (((Label)sender).Image != null)
                {
                    ((Label)sender).Image = Properties.Resources.Check2;
                    ((Label)sender).Invalidate();
                }
                if (((Control)sender).Tag != null)
                    ((Control)((Control)sender).Tag).ForeColor = Color.Black;
            }
            
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

            if (((Control)sender).GetType() == typeof(DarcyLabel))
            {
                if (((Control)sender).Tag != null)
                {
                    if (((Label)((Control)sender).Tag).Image != null)
                    {
                        ((Label)((Control)sender).Tag).Image = Properties.Resources.Check1;
                        ((Label)((Control)sender).Tag).Invalidate();
                    }
                }
            }
            else if (((Control)sender).GetType() == typeof(DarcyImgLabel))
            {
                if (((Label)sender).Image != null)
                {
                    ((Label)sender).Image = Properties.Resources.Check1;
                    ((Label)sender).Invalidate();
                }
                if (((Control)sender).Tag != null)
                    ((Control)((Control)sender).Tag).ForeColor = Color.FromArgb(66, 66, 66); 
            }

            ((Control)sender).ForeColor = Color.FromArgb(66, 66, 66);
        }
        private void Select_Setting(object sender)
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

        private void Label_Settings_Click(object sender, EventArgs e)
        {
            Label_Settings.Focus();
            Select_Setting(sender);
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

            UpdateListItem(Entries[index], index);

            Button_Cancel.Enabled = true;

            List_Backup.Focus();
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

                        List_Backup.Focus();
                    }

                    //Edit
                    else
                    {
                        for (int i = 0; i < Entries.Length; i ++)
                        {
                            if (Entries[i].Entry == entry.Entry)
                            {
                                Entries[i] = entry;
                                UpdateListItem(entry, i);
                                Update_SelectedEntry();
                                Save();

                                List_Backup.Focus();
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
                    _editNewObj.Dispose();
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
            {
                Entries[i].Automated = false;
                Button_Activate.Text = "Activate";
            }
            else
            {
                Entries[i].Automated = true;
                Button_Activate.Text = "Deactivate";
            }

            UpdateListItem(Entries[i], i);
            Update_SelectedEntry();
            Save();

            List_Backup.Focus();

        }
        public EntryClass GetEntry(int id)
        {
            return Entries[id];
        }
        private void Button_New_Click(object sender, EventArgs e)
        {
            if (_editNewOngoing == true)
            {
                if (_editNewObj != null)
                    _editNewObj.Focus();
                return;
            }

            _editNewObj = new Form_New_Entry(this, 0, Entries.Length + 1, _themeColor);
            _editNewObj.Show();
            _editNewOngoing = true;
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (List_Backup.SelectedItems.Count == 0)
                return;
            if (_editNewOngoing == true)
            {
                if (_editNewObj != null)
                    _editNewObj.Focus();
                return;
            }

            int i = List_Backup.SelectedItems[0].Index;

            _editNewObj = new Form_New_Entry(this, 1, i, _themeColor);
            _editNewObj.Show();
            _editNewOngoing = true;
        }

        private void DarcyFormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }

        private Color _themeColor;
        private void SetTheme(string theme)
        {
            _themeColor = Color.FromArgb(85, 85, 85);

            if (theme == "Red")
                _themeColor = Color.FromArgb(188, 18, 10);
            else if (theme == "Blue")
                _themeColor = Color.FromArgb(64, 52, 203);

            Label_Backup.ForeColor = _themeColor;
            Label_HeaderSelected.ForeColor = _themeColor;
            Label_HeaderLog.ForeColor = _themeColor;
            About_Label_Title.ForeColor = _themeColor;
        }

        private void Theme_Label_Click(object sender, EventArgs e)
        {
            //((Label)sender).Focus();
            String theme = "";
            if (sender == Theme_Label_Gray || sender == Theme_Img_Gray)
            {
                Theme_Img_Gray.Image = Properties.Resources.Check2;
                theme = "Gray";
            }
            else
                Theme_Img_Gray.Image = null;

            if (sender == Theme_Label_Red || sender == Theme_Img_Red)
            {
                Theme_Img_Red.Image = Properties.Resources.Check2;
                theme = "Red";
            }
            else
                Theme_Img_Red.Image = null;

            if (sender == Theme_Label_Blue || sender == Theme_Img_Blue)
            {
                Theme_Img_Blue.Image = Properties.Resources.Check2;
                theme = "Blue";
            }
            else
                Theme_Img_Blue.Image = null;

            if (theme == "")
                theme = "Gray";

            SetTheme(theme);

            Properties.Settings.Default.Theme = theme;
            Properties.Settings.Default.Save();
        }

        DarcyLogForm _DarcyLogForm;
        private void List_Log_DoubleClick(object sender, EventArgs e)
        {

            if (_DarcyLogForm != null)
                _DarcyLogForm.Dispose();
            if (List_Log.SelectedItems.Count != 0)
            {
                if (List_Log.SelectedItems[0].SubItems.Count != 0)
                {
                    string entry = List_Log.SelectedItems[0].SubItems[0].Text;
                    string time = List_Log.SelectedItems[0].SubItems[2].Text;
                    string error = (string)List_Log.SelectedItems[0].Tag;
                    _DarcyLogForm = new DarcyLogForm(entry, time, error, _themeColor);
                    _DarcyLogForm.Visible = true;
                }
            }
        }

        private void Settings_Label_Click(object sender, EventArgs e)
        {
            //((Label)sender).Focus();
            if (sender == Settings_Label_Autorun || sender == Settings_Img_Autorun)
            {
                if (Settings_Img_Autorun.Image != null)
                {
                    _rkApp.DeleteValue("DarcyBackup", false);
                    Settings_Img_Autorun.Image = null;
                }
                else
                {
                    _rkApp.SetValue("DarcyBackup", Application.ExecutablePath);
                    Settings_Img_Autorun.Image = Properties.Resources.Check2;
                }
            }
            else if (sender == Settings_Label_Minimized || sender == Settings_Img_Minimized)
            {
                if (Settings_Img_Minimized.Image != null)
                {
                    Properties.Settings.Default.MinimizedOnStartup = false;
                    Settings_Img_Minimized.Image = null;
                }
                else
                {
                    Properties.Settings.Default.MinimizedOnStartup = true;
                    Settings_Img_Minimized.Image = Properties.Resources.Check2;
                }
            }
            else if (sender == Settings_Label_Tray || sender == Settings_Img_Tray)
            {
                if (Settings_Img_Tray.Image != null)
                {
                    Properties.Settings.Default.ToTray = false;
                    Settings_Img_Tray.Image = null;
                }
                else
                {
                    Properties.Settings.Default.ToTray = true;
                    Settings_Img_Tray.Image = Properties.Resources.Check2;
                }
            }
            else if (sender == Settings_Label_Updates || sender == Settings_Img_Updates)
            {
                if (Settings_Img_Updates.Image != null)
                {
                    Properties.Settings.Default.Updates = false;
                    Settings_Img_Updates.Image = null;
                }
                else
                {
                    Properties.Settings.Default.Updates = true;
                    Settings_Img_Updates.Image = Properties.Resources.Check2;

                    InitializeUpdateThread();
                }
            }
            
            Properties.Settings.Default.Save();
        }

        private void List_Backup_DoubleClick(object sender, EventArgs e)
        {
            if (List_Backup.SelectedItems.Count != 0)
            {
                if (List_Backup.SelectedItems[0].SubItems.Count != 0)
                {
                    if (_editNewOngoing == true)
                    {
                        if (_editNewObj != null)
                            _editNewObj.Focus();
                        return;
                    }
                    if (_DarcyLogForm != null)
                        _DarcyLogForm.Dispose();

                    int i = List_Backup.SelectedItems[0].Index;

                    _editNewObj = new Form_New_Entry(this, 1, i, _themeColor);
                    _editNewObj.Show();
                    _editNewOngoing = true;
                }
            }
        }

        private void Form_Darcy_Panel_Click(object sender, EventArgs e)
        {
            Panel_Selected_Log.Focus();
        }

        private void Panel_Selected_Log_Click(object sender, EventArgs e)
        {
            ((Panel)sender).Focus();
        }
        

        private void Label_Settings_Focus_Leave(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(66, 66, 66);
            for (int i = 0; i < _privateSettingsPanels.Count(); i++)
            {
                if (_privateSettingsPanels[i] == null)
                    continue;
                _privateSettingsPanels[i].Visible = false;
                _privateSettingsLabels[i].ForeColor = color;
            }
        }

        private void Label_Click_Focus(object sender, EventArgs e)
        {
            ((Label)sender).Focus();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {

            int index = 0;
            if (List_Backup.SelectedItems.Count > 0)
            {
                index = List_Backup.Items.IndexOf(List_Backup.SelectedItems[0]);
            }
            else
                return;

            if (Entries[index].Status == "In Queue")
            {
                Entries[index].Status = "Resting";
                UpdateListItem(Entries[index], index);
                Button_Cancel.Enabled = false;
            }
            else
            {
                perform.Cancel = true;
            }

            List_Backup.Focus();
            List_Backup.Focus();
        }

        private void List_Backup_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            /*
            if (List_Backup.SelectedItems.Count == 0)
            {_currentListSel
                Button_Cancel.Enabled = false;
            }
            */
        }

        private void Label_Settings_MouseHover(object sender, EventArgs e)
        {
            bool noFound = true;

            for (int i = 0; i < _privateSettingsPanels.Count(); i++)
            {
                if (_privateSettingsPanels[i] == null)
                    continue;
                if (_privateSettingsLabels[i] != sender)
                    if (_privateSettingsPanels[i].Visible == true)
                        noFound = false;
            }

            if (noFound == true)
                return;
            
            Select_Setting(sender);
        }
    }
}
