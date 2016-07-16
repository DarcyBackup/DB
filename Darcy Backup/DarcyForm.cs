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

        delegate void AddToListCallback(EntryClass entry, int index); //for thread-safe interface actions
        private void AddToList(EntryClass entry, int index)
        {
            string[] strArr = new string[6];
            ListViewItem item;
            strArr[0] = entry.Entry.ToString();
            strArr[1] = entry.Source;
            strArr[2] = entry.Destination;
            strArr[3] = entry.Timer.ToString();
            strArr[4] = "true";//entry.differential.ToString();
            strArr[5] = entry.LastPerformed;
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

                    writeString += Entries[i].Entry + ";" + Entries[i].Source + ";" + Entries[i].Destination + ";" + Entries[i].Timer + ";" + "true" + ";" + Entries[i].LastPerformed;

                    file.WriteLine(writeString);
                }

            }
        }

        

        
        public void CheckAction()
        {
            for (int i = 0; i < Entries.Length; i++)
            {
                string lp = Entries[i].LastPerformed;
                if (lp == "Never" || lp == "In Queue" || lp == "In Progress" || lp == "")
                {
                }
                else
                {
                    double difference = CalculateTimeDifference(Entries[i].LastPerformed);
                    if ((int)difference >= Entries[i].Timer)
                    {
                    }
                    else
                        continue;
                }
                if (Entries[i].Ongoing == false)
                {
                    Entries[i].Ongoing = true;
                    Perform(i);
                    string str = GetTimeString();
                    Entries[i].LastPerformed = str;
                    Entries[i].Ongoing = false;

                    Save();


                    RemoveFromList(i);
                    AddToList(Entries[i], i);
                }
            }
        }
        private string GetTimeString()
        {
            string str = "";

            string hour = DateTime.Now.Hour.ToString();
            if (hour.Length == 1)
                hour = "0" + hour;
            string minute = DateTime.Now.Minute.ToString();
            if (minute.Length == 1)
                minute = "0" + minute;
            
            str += DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "-" + hour + ":" + minute;

            return str;
        }
        private double CalculateTimeDifference(String timeString)
        {

            string[] slashSplit = timeString.Split('/');
            string[] minusSplit = slashSplit[2].Split('-');
            string[] colonSplit = minusSplit[1].Split(':');

            
            int day = Int32.Parse(slashSplit[0]);
            int month = Int32.Parse(slashSplit[1]);
            int year = Int32.Parse(minusSplit[0]);
            int hour = Int32.Parse(colonSplit[0]);
            int minute = Int32.Parse(colonSplit[1]);

            DateTime currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            DateTime timeToCheck = new DateTime(year, month, day, hour, minute, 0);

            double minutes = currentTime.Subtract(timeToCheck).TotalMinutes;

            return minutes;
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
