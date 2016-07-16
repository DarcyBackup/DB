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
        private FormWindowState PreviousWindowsState = FormWindowState.Normal;
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.ShowInTaskbar == false)
            {
                PreviousWindowsState = this.WindowState;
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
            else
            {
                this.WindowState = PreviousWindowsState;
            }
        }
    }
}
