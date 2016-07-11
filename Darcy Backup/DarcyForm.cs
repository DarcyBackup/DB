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
        


        private void AddEntry(entryStruct entry)
        {

            entryStruct[] newEntries = new entryStruct[entries.Length + 1];

            for (int i = 0; i < entries.Length; i ++)
            {
                newEntries[i] = entries[i];
            }

            newEntries[newEntries.Length - 1] = entry;

            entries = newEntries;
        }

        private void RemoveEntry(int index)
        {
            entryStruct[] newEntries = new entryStruct[entries.Length - 1];
            int addCount = 0;
            for (int i = 0; i < entries.Length; i ++)
            {
                if (i != index)
                { 
                    newEntries[addCount] = entries[i];
                    addCount ++;
                }
            }
            entries = newEntries;
        }

        

        private void ChangesMade()
        {
            if (changes == false)
            {
                changes = true;

                Dynamic_Entry.Font = new Font(Dynamic_Entry.Font, FontStyle.Bold);

                buttonEnabled.Button_Save = true;
                Button_Save.BackColor = Color.FromArgb(228, 213, 255);
                Button_Save.ForeColor = Color.FromArgb(111, 111, 111);

                buttonEnabled.Button_Discard = true;
                Button_Discard.BackColor = Color.FromArgb(228, 213, 255);
                Button_Discard.ForeColor = Color.FromArgb(111, 111, 111);
            }
        }
        private void LoadNew()
        {
            buttonEnabled.Button_Save = false;
            Button_Save.BackColor = Color.FromArgb(248, 244, 255);
            Button_Save.ForeColor = Color.FromArgb(0, 0, 0);

            buttonEnabled.Button_Discard = false;
            Button_Discard.BackColor = Color.FromArgb(248, 244, 255);
            Button_Discard.ForeColor = Color.FromArgb(0, 0, 0);

            Text_Source.Text = "";
            Text_Destination.Text = "";
            Text_Frequency.Text = "";
            Check_Differential.Checked = false;

            Dynamic_Entry.Font = new Font(Dynamic_Entry.Font, FontStyle.Regular);
            Dynamic_Entry.Text = "New";

            changes = false;
            loaded = -1;
        }

        private bool ValidateInput(out entryStruct entry)
        {

            entry = new entryStruct();
            

            //INPUT SOURCE
            if (Text_Source.Text.Length == 0)
            {
                MessageBox.Show("Invalid input in Source", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (File.Exists(Text_Source.Text) == false)
            {
                if (Directory.Exists(Text_Source.Text) == false)
                {
                    MessageBox.Show("Invalid input in Source, file or folder does not exist", "Error", MessageBoxButtons.OK);
                    return false;
                }
            }
            entry.source = Text_Source.Text;
            

            //INPUT DESTINATION
            if (Text_Destination.Text.Length == 0)
            {
                MessageBox.Show("Invalid input in Destination", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (Directory.Exists(Text_Destination.Text) == false)
            {
                DialogResult res = MessageBox.Show("The specified folder does not exist. Do you want to create it?", "Does not exist", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    System.IO.Directory.CreateDirectory(Text_Source.Text);
                else
                    return false;
            }
            entry.destination = Text_Destination.Text;


            //INPUT FREQUENCY
            int temp = 0;
            if (Text_Frequency.Text.Length == 0 || Int32.TryParse(Text_Frequency.Text, out temp) == false)
            {
                MessageBox.Show("Invalid input in Frequency", "Error", MessageBoxButtons.OK);
                return false;
            }
            entry.frequency = temp;



            //INPUT DIFFERENTIAL
            entry.differential = Check_Differential.Checked;

            return true;
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

        delegate void AddToListCallback(entryStruct entry, int index); //for thread-safe interface actions
        private void AddToList(entryStruct entry, int index)
        {
            string[] strArr = new string[6];
            ListViewItem item;
            strArr[0] = entry.entry.ToString();
            strArr[1] = entry.source;
            strArr[2] = entry.destination;
            strArr[3] = entry.frequency.ToString();
            strArr[4] = entry.differential.ToString();
            strArr[5] = entry.lastPerformed;
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
                for (int i = 0; i < entries.Length; i++)
                {

                    string writeString = "";

                    writeString += entries[i].entry + ";" + entries[i].source + ";" + entries[i].destination + ";" + entries[i].frequency + ";" + entries[i].differential + ";" + entries[i].lastPerformed;

                    file.WriteLine(writeString);
                }

            }
        }

        

        
        public void CheckAction()
        {
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i].lastPerformed == "Never" || entries[i].lastPerformed == "In Queue" || entries[i].lastPerformed == "In Progress")
                {
                }
                else
                {
                    double difference = CalculateTimeDifference(entries[i].lastPerformed);
                    if ((int)difference >= entries[i].frequency)
                    {
                    }
                    else
                        continue;
                }
                if (entries[i].ongoing == false)
                {
                    entries[i].ongoing = true;
                    Perform(i);
                    string str = GetTimeString();
                    entries[i].lastPerformed = str;
                    entries[i].ongoing = false;

                    Save();


                    RemoveFromList(i);
                    AddToList(entries[i], i);
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
            Label_Settings.Font = new Font(Label_Settings.Font, FontStyle.Regular);
            Settings_Panel.Visible = false;

            bool visible = About_Panel.Visible;

            if (visible == true)
                About_Panel.Visible = false;
            else
                About_Panel.Visible = true;
        }
        
        private void Language_Label_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = ((Control)sender).Text;
            Properties.Settings.Default.Save();

            if (sender == Language_Label_English)
                Language_Label_English.Font = new Font(Language_Label_English.Font, FontStyle.Bold | FontStyle.Italic);
            else
                Language_Label_English.Font = new Font(Language_Label_English.Font, FontStyle.Regular);

            if (sender == Language_Label_Swedish)
                Language_Label_Swedish.Font = new Font(Language_Label_Swedish.Font, FontStyle.Bold | FontStyle.Italic);
            else
                Language_Label_Swedish.Font = new Font(Language_Label_Swedish.Font, FontStyle.Regular);

            if (sender == Language_Label_Finnish)
                Language_Label_Finnish.Font = new Font(Language_Label_Finnish.Font, FontStyle.Bold | FontStyle.Italic);
            else
                Language_Label_Finnish.Font = new Font(Language_Label_Finnish.Font, FontStyle.Regular);



        }

        private void Settings_Label_Language_Click(object sender, EventArgs e)
        {
            bool visible = Settings_Language_Panel.Visible;

            if (visible == true)
                Settings_Language_Panel.Visible = false;
            else
                Settings_Language_Panel.Visible = true;
        }
        private void MouseEnter_Bold(object sender, EventArgs e)
        {
            ((Control)sender).Font = new Font(((Control)sender).Font, FontStyle.Bold);
        }
        private void MouseEnter_LanguageLabels(object sender, EventArgs e)
        {
            bool underline = ((Control)sender).Font.Italic;

            if (underline == false)
                ((Control)sender).Font = new Font(((Control)sender).Font, FontStyle.Bold);
            else
                ((Control)sender).Font = new Font(((Control)sender).Font, FontStyle.Bold | FontStyle.Italic);
        }
        private void MouseLeave_LanguageLabels(object sender, EventArgs e)
        {
            bool underline = ((Control)sender).Font.Italic;
            
            if (underline == false)
                ((Control)sender).Font = new Font(((Control)sender).Font, FontStyle.Regular);
            else
                ((Control)sender).Font = new Font(((Control)sender).Font, FontStyle.Italic);
        }

        private void MouseLeave_Regular(object sender, EventArgs e)
        {
            if (sender ==  Label_Settings)
                if (Settings_Panel.Visible == true)
                    return;
            if (sender == Label_About)
                if (About_Panel.Visible == true)
                    return;
            ((Control)sender).Font = new Font(((Control)sender).Font, FontStyle.Regular);
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
            Label_About.Font = new Font(Label_About.Font, FontStyle.Regular);

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


            entries[index].lastPerformed = "In Queue";

            Save();

            RemoveFromList(index);
            AddToList(entries[index], index);
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (buttonEnabled.Button_Save == false)
                return;

            if (changes == false)
                return;


            entryStruct entry;
            if (ValidateInput(out entry) == true)
            {
                if (loaded == -1)
                {

                    lastLine++;
                    entry.entry = lastLine;
                    entry.lastPerformed = "Never";

                    AddEntry(entry);
                    AddToList(entry, -1);
                    Save();
                }
                else
                {
                    entries[loaded].source = entry.source;
                    entries[loaded].destination = entry.destination;
                    entries[loaded].frequency = entry.frequency;
                    entries[loaded].differential = entry.differential;


                    buttonEnabled.Button_Save = false;
                    Button_Save.BackColor = Color.FromArgb(248, 244, 255);
                    Button_Save.ForeColor = Color.FromArgb(0, 0, 0);

                    buttonEnabled.Button_Discard = false;
                    Button_Discard.BackColor = Color.FromArgb(248, 244, 255);
                    Button_Discard.ForeColor = Color.FromArgb(0, 0, 0);

                    Dynamic_Entry.Font = new Font(Dynamic_Entry.Font, FontStyle.Regular);

                    changes = false;

                    RemoveFromList(loaded);
                    AddToList(entries[loaded], loaded);

                    Save();
                }
            }
        }
    }
}
