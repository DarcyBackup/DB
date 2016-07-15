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
    public partial class Form_Darcy_Panel
    {

        
        private void MouseEnter_Italic(object sender, EventArgs e)
        {
            ((Control)sender).Font = new Font(((Control)sender).Font, FontStyle.Italic);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen pen = new Pen(Color.FromArgb(130, 135, 144));

            e.Graphics.DrawLine(pen, 0, 25, Width, 25);

            pen.Dispose();

            pen = new Pen(Color.FromArgb(254, 253, 255));

            e.Graphics.FillRectangle(pen.Brush, new Rectangle(0, 0, Width, 25));

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

        private void Button_Activate_Click(object sender, EventArgs e)
        {

            //OLD CODE FOR BUTTON_LOAD
            /*
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

            */
        }
        private void Button_Delete_Click(object sender, EventArgs e)
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
        
        private void Form_Darcy_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
            else if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                int senderHeight = ((Control)sender).ClientRectangle.Height;
                int senderWidth = ((Control)sender).ClientRectangle.Width;

                for (int i = 0; i < RESIZE_ARRAY_SIZE; i++)
                {
                    Rectangle rect = ResizeArray[i].control.Bounds;
                    int newX = 0, newY = 0, newHeight = 0, newWidth = 0;

                    if (ResizeArray[i].height != -1)
                        newHeight = (senderHeight - ResizeArray[i].height) - rect.Y;
                    else
                        newHeight = rect.Height;

                    if (ResizeArray[i].width != -1)
                        newWidth = (senderWidth - ResizeArray[i].width) - rect.X;
                    else
                        newWidth = rect.Width;


                    if (ResizeArray[i].stayX == true)
                        newX = rect.X;
                    else
                    {
                        newX = rect.X + newWidth - rect.Width;
                        newWidth = rect.Width;
                    }
                    if (ResizeArray[i].stayY == true)
                        newY = rect.Y;
                    else
                    {
                        newY = rect.Y + newHeight - rect.Height;
                        newHeight = rect.Height;
                    }
                    ResizeArray[i].control.SetBounds(newX, newY, newWidth, newHeight);
                }

                Properties.Settings.Default.Height = ((Control)sender).Bounds.Height;
                Properties.Settings.Default.Width = ((Control)sender).Bounds.Width;

                /*
                *
                * SelectedLogPanel
                *
                */

                Rectangle logRect = List_Log.Bounds;
                List_Log.SetBounds(logRect.X, logRect.Y, logRect.Width, Panel_Selected_Log.Height - logRect.Y);

            }
        }
        private void Form_Darcy_ResizeEnd(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                int senderHeight = ((Control)sender).ClientRectangle.Height;
                int senderWidth = ((Control)sender).ClientRectangle.Width;


                for (int i = 0; i < RESIZE_ARRAY_SIZE; i++)
                {
                    Rectangle rect = ResizeArray[i].control.Bounds;
                    int newX = 0, newY = 0, newHeight = 0, newWidth = 0;

                    if (ResizeArray[i].height != -1)
                        newHeight = (senderHeight - ResizeArray[i].height) - rect.Y;
                    else
                        newHeight = rect.Height;

                    if (ResizeArray[i].width != -1)
                        newWidth = (senderWidth - ResizeArray[i].width) - rect.X;
                    else
                        newWidth = rect.Width;

                    
                    if (ResizeArray[i].stayX == true)
                        newX = rect.X;
                    else
                    {
                        newX = rect.X + newWidth - rect.Width;
                        newWidth = rect.Width;
                    }
                    if (ResizeArray[i].stayY == true)
                        newY = rect.Y;
                    else
                    {
                        newY = rect.Y + newHeight - rect.Height;
                        newHeight = rect.Height;
                    }
                    ResizeArray[i].control.SetBounds(newX, newY, newWidth, newHeight);
                }
                Properties.Settings.Default.Height = ((Control)sender).Bounds.Height;
                Properties.Settings.Default.Width = ((Control)sender).Bounds.Width;
                Properties.Settings.Default.Save();
            }
        }
        private void List_Backup_ColumnWidthChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.List_Entry = List_Backup.Columns[0].Width;
            Properties.Settings.Default.List_Source = List_Backup.Columns[1].Width;
            Properties.Settings.Default.List_Destination = List_Backup.Columns[2].Width;
            Properties.Settings.Default.List_Frequency = List_Backup.Columns[3].Width;
            Properties.Settings.Default.List_Differential = List_Backup.Columns[4].Width;
            Properties.Settings.Default.List_Performed = List_Backup.Columns[5].Width;

            Properties.Settings.Default.Save();
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
    }
}
