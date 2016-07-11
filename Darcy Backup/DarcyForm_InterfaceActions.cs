using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    public partial class Form_Darcy
    {

        
        private void MouseEnter_Italic(object sender, EventArgs e)
        {
            ((Control)sender).Font = new Font(((Control)sender).Font, FontStyle.Italic);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen pen = new Pen(Color.FromArgb(130, 135, 144));

            e.Graphics.DrawLine(pen, 4, 38, Width, 38);
            pen.Dispose();
        }

        private void Button_Source_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Text_Source.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Button_Destination_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Text_Destination.Text = folderBrowserDialog.SelectedPath;
            }
        }


        private void Button_New_Click(object sender, EventArgs e)
        {
            if (changes == true)
            {
                DialogResult result = MessageBox.Show("Do you want to discard your changes?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    LoadNew();
                }
            }
        }

        private void Button_Discard_Click(object sender, EventArgs e)
        {

            if (buttonEnabled.Button_Discard == false)
                return;

            if (changes == false)
                return;


            if (loaded == -1)
                return;


            Text_Source.Text = entries[loaded].source;
            Text_Destination.Text = entries[loaded].destination;
            Text_Frequency.Text = entries[loaded].frequency.ToString();
            Check_Differential.Checked = entries[loaded].differential;

            Dynamic_Entry.Font = new Font(Dynamic_Entry.Font, FontStyle.Regular);
            Dynamic_Entry.Text = entries[loaded].entry.ToString();

            buttonEnabled.Button_Save = false;
            Button_Save.BackColor = Color.FromArgb(248, 244, 255);
            Button_Save.ForeColor = Color.FromArgb(0, 0, 0);

            buttonEnabled.Button_Discard = false;
            Button_Discard.BackColor = Color.FromArgb(248, 244, 255);
            Button_Discard.ForeColor = Color.FromArgb(0, 0, 0);

        }

        private void Button_Load_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (List_Backup.SelectedItems.Count > 0)
            {
                index = List_Backup.Items.IndexOf(List_Backup.SelectedItems[0]);
            }


            Text_Source.Text = entries[index].source;
            Text_Destination.Text = entries[index].destination;
            Text_Frequency.Text = entries[index].frequency.ToString();
            Check_Differential.Checked = entries[index].differential;

            buttonEnabled.Button_Save = false;
            Button_Save.BackColor = Color.FromArgb(248, 244, 255);
            Button_Save.ForeColor = Color.FromArgb(0, 0, 0);

            buttonEnabled.Button_Discard = false;
            Button_Discard.BackColor = Color.FromArgb(248, 244, 255);
            Button_Discard.ForeColor = Color.FromArgb(0, 0, 0);

            Dynamic_Entry.Font = new Font(Dynamic_Entry.Font, FontStyle.Regular);
            Dynamic_Entry.Text = entries[index].entry.ToString();

            changes = false;
            loaded = index;


        }
        private void Button_Remove_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (List_Backup.SelectedItems.Count > 0)
            {
                index = List_Backup.Items.IndexOf(List_Backup.SelectedItems[0]);
            }
            else
                return;

            RemoveFromList(index);
            RemoveEntry(index);

            Save();

            LoadNew();
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
        private void Form_Darcy_OnPaint(PaintEventArgs e)
        {
            int i = 0;
        }
        private void Form_Darcy_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.ShowInTaskbar == false)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
        private void Text_Source_TextChanged(object sender, EventArgs e)
        {
            ChangesMade();
        }

        private void Text_Destination_TextChanged(object sender, EventArgs e)
        {
            ChangesMade();
        }

        private void Text_Frequency_TextChanged(object sender, EventArgs e)
        {
            ChangesMade();
        }

        private void Check_Differential_CheckedChanged(object sender, EventArgs e)
        {
            ChangesMade();
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
    }
}
