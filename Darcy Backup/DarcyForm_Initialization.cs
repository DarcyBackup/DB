using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    public partial class Form_Darcy_Panel
    {
        

        public Form_Darcy_Panel()
        {

            InitializeComponent();
            
            if (Properties.Settings.Default.MinimizedOnStartup == true)
            {
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                this.ShowInTaskbar = false;
            }
            

            InitializeGUI();

            InitializeResize();

            InitializeLanguage();

            InitializeCache();

            //CheckForUpdates();

            InitializeWorkerThread();
        }
        private void CheckForUpdates()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://www.darcybackup.com/deploy/currentVersion.php");
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();
        }
        private void InitializeLanguage()
        {
            string language = Properties.Settings.Default.Language;
            if (language.Length == 0)
                language = "English";

            if (language == "English")
                Language_Label_English.Font = new Font(Language_Label_English.Font, FontStyle.Italic);
            else if (language == "Swedish")
                Language_Label_Swedish.Font = new Font(Language_Label_Swedish.Font, FontStyle.Italic);
            else if (language == "Finnish")
                Language_Label_Finnish.Font = new Font(Language_Label_Finnish.Font, FontStyle.Italic);


        }
        /*
        //  START OF RESIZE
        */

        //  RESIZEARRAY CONSTANTS
        private static int BUTTON_PERFORM = 0;
        private static int BUTTON_ACTIVATE = 1;
        private static int BUTTON_DELETE = 2;
        private static int LIST_BACKUP = 3;
        private static int BUTTON_NEW = 4;
        private static int BUTTON_EDIT = 5;
        private static int LABEL_TOGGLE = 6;
        private static int PANEL_SELECTEDLOG = 7;

        private static int RESIZE_ARRAY_SIZE = 8;

        private void InitializeResize()
        {
            /*  
           //
           //  Add controls to scale with resize, here
           // 
           */

            _resizeArray = new resizeStruct[RESIZE_ARRAY_SIZE];

            _resizeArray[BUTTON_PERFORM].control = Button_Perform;
            _resizeArray[BUTTON_PERFORM].width = 38;
            _resizeArray[BUTTON_PERFORM].height = 15;
            _resizeArray[BUTTON_PERFORM].stayX = false;
            _resizeArray[BUTTON_PERFORM].stayY = false;
        
            _resizeArray[BUTTON_ACTIVATE].control = Button_Activate;
            _resizeArray[BUTTON_ACTIVATE].width = 150;
            _resizeArray[BUTTON_ACTIVATE].height = 15;
            _resizeArray[BUTTON_ACTIVATE].stayX = false;
            _resizeArray[BUTTON_ACTIVATE].stayY = false;

            _resizeArray[BUTTON_DELETE].control = Button_Delete;
            _resizeArray[BUTTON_DELETE].width = -1;
            _resizeArray[BUTTON_DELETE].height = 15;
            _resizeArray[BUTTON_DELETE].stayX = true;
            _resizeArray[BUTTON_DELETE].stayY = false;

            _resizeArray[LIST_BACKUP].control = List_Backup;
            _resizeArray[LIST_BACKUP].width = 30;
            _resizeArray[LIST_BACKUP].height = 62;
            _resizeArray[LIST_BACKUP].stayX = true;
            _resizeArray[LIST_BACKUP].stayY = true;

            _resizeArray[BUTTON_NEW].control = Button_New;
            _resizeArray[BUTTON_NEW].width = -1;
            _resizeArray[BUTTON_NEW].height = 15;
            _resizeArray[BUTTON_NEW].stayX = true;
            _resizeArray[BUTTON_NEW].stayY = false;

            _resizeArray[BUTTON_EDIT].control = Button_Edit;
            _resizeArray[BUTTON_EDIT].width = -1;
            _resizeArray[BUTTON_EDIT].height = 15;
            _resizeArray[BUTTON_EDIT].stayX = true;
            _resizeArray[BUTTON_EDIT].stayY = false;

            _resizeArray[LABEL_TOGGLE].control = Label_Toggle;
            _resizeArray[LABEL_TOGGLE].width = 234;
            _resizeArray[LABEL_TOGGLE].height = 15;
            _resizeArray[LABEL_TOGGLE].stayX = false;
            _resizeArray[LABEL_TOGGLE].stayY = false;

            _resizeArray[PANEL_SELECTEDLOG].control = Panel_Selected_Log;
            _resizeArray[PANEL_SELECTEDLOG].width = -1;
            _resizeArray[PANEL_SELECTEDLOG].height = 42;
            _resizeArray[PANEL_SELECTEDLOG].stayX = true;
            _resizeArray[PANEL_SELECTEDLOG].stayY = true;

            //SET FORM TO LAST VALUE

            int height = Properties.Settings.Default.Height;
            int width = Properties.Settings.Default.Width;

            this.Bounds = (new Rectangle(this.Bounds.X, this.Bounds.Y, width, height));
        }
        /*
        //  END OF RESIZE
        */

        private void InitializeWorkerThread()
        {
            WorkerClass wc = new WorkerClass(this);
            Thread wt = new Thread(wc.Work);
            wt.IsBackground = true;
            wt.Start();
        }

        private void InitializeCache()
        {
            bool exists = File.Exists(_fullPath);

            if (exists == false)
            {
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
            }

            string[] entryString = System.IO.File.ReadAllLines(_fullPath);

            Entries = new EntryClass[entryString.Length];
            for (int i = 0; i < Entries.Length; i ++)
                Entries[i] = new EntryClass();

            for (int i = 0; i < entryString.Length; i++)
            {
                string[] temp = entryString[i].Split(';');

                if (temp.Length != 42)
                    continue;

                int parsed = 0;
                if (Int32.TryParse(temp[0], out parsed) == false)
                    continue;

                Entries[i].Entry = parsed;
                Entries[i].Source = temp[1];
                Entries[i].Destination = temp[2];

                if (Int32.TryParse(temp[3], out parsed) == false)
                    continue;

                if (parsed != 0 && parsed != 1 && parsed != 2)
                    continue;
                Entries[i].Mode = parsed;

                if (Int32.TryParse(temp[4], out parsed) == false)
                    continue;

                if (parsed != 0 && parsed != 1 && parsed != 2)
                    continue;
                Entries[i].Process = parsed;

                Entries[i].NextScheduled = temp[5];
                Entries[i].LastPerformed = temp[6];

                bool readBool;
                bool failed = true;
                for (int k = 0; k < 31; k ++)
                {
                    if (temp[k + 7] == "True" || temp[k + 7] == "true")
                    {
                        readBool = true;
                        failed = false;
                    }
                    else if (temp[k + 7] == "False" || temp[k + 7] == "false")
                    {
                        readBool = false;
                        failed = false;
                    }
                    else
                        break;
                    Entries[i].Days[k] = readBool;
                }
                if (failed == true)
                    continue;


                Entries[i].TimeOfDay = temp[38];

                if (Int32.TryParse(temp[39], out parsed) == false)
                    continue;
                Entries[i].Timer = parsed;

                Entries[i].TotalSize = temp[40];

                if (temp[41] == "True" || temp[41] == "true")
                    readBool = true;
                else if (temp[41] == "False" || temp[41] == "false")
                    readBool = false;
                else
                    continue;
                Entries[i].Automated = readBool;

                Entries[i].Validated = true;
            }

            for (int i = 0; i < Entries.Length; i++)
            {
                AddToList(Entries[i], -1, -1);
            }
        }

        private int _automatedLabelYSchedule;
        private int _automatedLabelYTimer;

        private void InitializeGUI()
        {

            Settings_Panel.SetBounds(0, 25, Settings_Panel.Width, Settings_Panel.Height);
            Settings_Language_Panel.SetBounds(139, 114, Settings_Language_Panel.Width, Settings_Language_Panel.Height);
            About_Panel.SetBounds(75, 25, About_Panel.Width, About_Panel.Height);



            List_Backup.View = View.Details;
            List_Backup.FullRowSelect = true;
            List_Backup.MultiSelect = false;
            List_Backup.GridLines = false;
            List_Backup.HideSelection = false;

            List_Backup.ColumnWidthChanged += List_Backup_ColumnWidthChanged;

            List_Backup.Columns.Add("Entry", Properties.Settings.Default.List_Entry);
            List_Backup.Columns.Add("Source", Properties.Settings.Default.List_Source);
            List_Backup.Columns.Add("Destination", Properties.Settings.Default.List_Destination);
            List_Backup.Columns.Add("Mode", Properties.Settings.Default.List_Mode);
            List_Backup.Columns.Add("Process", Properties.Settings.Default.List_Process);
            List_Backup.Columns.Add("Last Performed", Properties.Settings.Default.List_Performed);
            List_Backup.Columns.Add("Next Backup", Properties.Settings.Default.List_Next);
            List_Backup.Columns.Add("Status", Properties.Settings.Default.List_Status);
            List_Backup.Columns.Add("Automated", Properties.Settings.Default.List_Automated);
            
            //List_Backup.OwnerDraw = true;
            List_Backup.DrawItem += List_Backup_DrawItem;
            List_Backup.DrawSubItem += List_Backup_DrawSubItem;
            List_Backup.DrawColumnHeader += List_Backup_DrawColumnHeader;


            List_Log.View = View.Details;
            List_Log.FullRowSelect = true;
            List_Log.GridLines = false;
            List_Log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

            List_Log.Columns.Add("", 129);
            List_Log.Columns.Add("", 109);
            List_Log.Columns.Add("", 140);
            List_Log.Columns[2].TextAlign = HorizontalAlignment.Right;

            AddToLog(-1, "Test func");

            _automatedLabelYSchedule = Label_Automated.Bounds.Y;
            _automatedLabelYTimer = Label_Process_Specific2.Bounds.Y;


        Settings_Panel.BringToFront();
            Settings_Language_Panel.BringToFront();
            About_Panel.BringToFront();

            About_Label_Version.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();



            if (rkApp.GetValue("DarcyBackup") == null)
            {
                Settings_Check_Autorun.Checked = false;
            }
            else
            {
                Settings_Check_Autorun.Checked = true;
            }
            if (Properties.Settings.Default.MinimizedOnStartup == true)
            {
                Settings_Check_Minimized.Checked = true;
            }


            Update_SelectedEntry();

        }

        private void List_Backup_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void List_Backup_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {

            e.DrawBackground();
            e.DrawText();
        }
        
        private void List_Backup_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            
            if (e.Item.Selected)
            {
                e.Item.ForeColor = Color.Black;
                e.Item.BackColor = Color.LightBlue;
                var subs = e.Item.SubItems;
                for (int i = 0; i < subs.Count; i ++)
                {
                    subs[i].ForeColor = Color.Black;
                    subs[i].BackColor = Color.LightBlue;
                }
                    
            }
            else
            {

                e.Item.ForeColor = SystemColors.HighlightText;
                e.Item.BackColor = SystemColors.Highlight;
            
                var subs = e.Item.SubItems;
                for (int i = 0; i < subs.Count; i++)
                {
                    subs[i].ForeColor = Color.Black;
                    subs[i].BackColor = Color.FromArgb(254, 253, 255);
                }
            }
            

            e.DrawBackground();
            e.DrawText();
        }
    }
}
