﻿using Microsoft.Win32;
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
        private string _fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Darcy Backup\\db.dbss");

        RegistryKey _rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        string _assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public EntryClass[] Entries { get; set; }


        Perform perform;

        private resizeStruct[] _resizeArray;

        public int CurrentListSel = -1;

        private bool _editNewOngoing = false;
        private Form_New_Entry _editNewObj;

        private struct resizeStruct
        {
            public Control control;
            public int width;
            public int height;
            public bool stayX;
            public bool stayY;
        }

        public Form_Darcy_Panel()
        {

            InitializeComponent();

            if (Properties.Settings.Default.UpgradeSettings == true)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeSettings = false;
                Properties.Settings.Default.Save();
            }

            
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

            InitializeTheme();

            InitializeCache();

            if (Properties.Settings.Default.Updates == true)
                InitializeUpdateThread();


            perform = new Perform(this);

            InitializeWorkerThreads();
        }

        private void InitializeTheme()
        {
            string theme = Properties.Settings.Default.Theme;
            if (theme.Length == 0)
                theme = "Gray";

            if (theme == "Gray")
            {
                Theme_Img_Gray.Image = Properties.Resources.Check1;

                Theme_Img_Red.Image = null;
                Theme_Img_Blue.Image = null;
            }
            else if (theme == "Red")
            {
                Theme_Img_Red.Image = Properties.Resources.Check1;

                Theme_Img_Gray.Image = null;
                Theme_Img_Blue.Image = null;
            }
            else if (theme == "Blue")
            {
                Theme_Img_Blue.Image = Properties.Resources.Check1;

                Theme_Img_Gray.Image = null;
                Theme_Img_Red.Image = null;
            }

            SetTheme(theme);
        }
        private void InitializeLanguage()
        {
            string language = Properties.Settings.Default.Language;
            if (language.Length == 0)
                language = "English";

            if (language == "English")
            {
                Language_Img_English.Image = Properties.Resources.Check1;

                Language_Img_Swedish.Image = null;
                Language_Img_Finnish.Image = null;
            }
            else if (language == "Swedish")
            {
                Language_Img_Swedish.Image = Properties.Resources.Check1;

                Language_Img_English.Image = null;
                Language_Img_Finnish.Image = null;
            }
            else if (language == "Finnish")
            {
                Language_Img_Finnish.Image = Properties.Resources.Check1;

                Language_Img_English.Image = null;
                Language_Img_Swedish.Image = null;
            }
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
        private static int BUTTON_CANCEL = 8;

        private static int RESIZE_ARRAY_SIZE = 9;

        private void InitializeResize()
        {
            /*  
           //
           //  Add controls to scale with resize, here
           // 
           */

            _resizeArray = new resizeStruct[RESIZE_ARRAY_SIZE];

            _resizeArray[BUTTON_PERFORM].control = Button_Perform;
            _resizeArray[BUTTON_PERFORM].width = 32;
            _resizeArray[BUTTON_PERFORM].height = 30;
            _resizeArray[BUTTON_PERFORM].stayX = false;
            _resizeArray[BUTTON_PERFORM].stayY = false;

            _resizeArray[BUTTON_CANCEL].control = Button_Cancel;
            _resizeArray[BUTTON_CANCEL].width = 117;
            _resizeArray[BUTTON_CANCEL].height = 30;
            _resizeArray[BUTTON_CANCEL].stayX = false;
            _resizeArray[BUTTON_CANCEL].stayY = false;

            _resizeArray[BUTTON_ACTIVATE].control = Button_Activate;
            _resizeArray[BUTTON_ACTIVATE].width = 202;
            _resizeArray[BUTTON_ACTIVATE].height = 30;
            _resizeArray[BUTTON_ACTIVATE].stayX = false;
            _resizeArray[BUTTON_ACTIVATE].stayY = false;

            _resizeArray[BUTTON_DELETE].control = Button_Delete;
            _resizeArray[BUTTON_DELETE].width = -1;
            _resizeArray[BUTTON_DELETE].height = 30;
            _resizeArray[BUTTON_DELETE].stayX = true;
            _resizeArray[BUTTON_DELETE].stayY = false;

            _resizeArray[LIST_BACKUP].control = List_Backup;
            _resizeArray[LIST_BACKUP].width = 32;
            _resizeArray[LIST_BACKUP].height = 75;
            _resizeArray[LIST_BACKUP].stayX = true;
            _resizeArray[LIST_BACKUP].stayY = true;

            _resizeArray[BUTTON_NEW].control = Button_New;
            _resizeArray[BUTTON_NEW].width = -1;
            _resizeArray[BUTTON_NEW].height = 30;
            _resizeArray[BUTTON_NEW].stayX = true;
            _resizeArray[BUTTON_NEW].stayY = false;

            _resizeArray[BUTTON_EDIT].control = Button_Edit;
            _resizeArray[BUTTON_EDIT].width = -1;
            _resizeArray[BUTTON_EDIT].height = 30;
            _resizeArray[BUTTON_EDIT].stayX = true;
            _resizeArray[BUTTON_EDIT].stayY = false;

            _resizeArray[LABEL_TOGGLE].control = Label_Toggle;
            _resizeArray[LABEL_TOGGLE].width = 286;
            _resizeArray[LABEL_TOGGLE].height = 30;
            _resizeArray[LABEL_TOGGLE].stayX = false;
            _resizeArray[LABEL_TOGGLE].stayY = false;

            _resizeArray[PANEL_SELECTEDLOG].control = Panel_Selected_Log;
            _resizeArray[PANEL_SELECTEDLOG].width = -1;
            _resizeArray[PANEL_SELECTEDLOG].height = 75;
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
        UpdateClass _uc = null;
        Thread _ut = null;
        private void InitializeUpdateThread()
        {
            if (_uc != null)
                _uc = null;
            _uc = new UpdateClass(_assemblyVersion);

            if (_ut != null)
                _ut.Abort();

            _ut = new Thread(_uc.CheckUpdate);
            _ut.IsBackground = true;
            _ut.Start();
        }
        private void InitializeWorkerThreads()
        {
            WorkerClass wc = new WorkerClass(this);
            Thread tp = new Thread(wc.ThreadPerform);
            tp.IsBackground = true;
            tp.Start();

            Thread tq = new Thread(wc.ThreadQueue);
            tq.IsBackground = true;
            tq.Start();
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

                if (temp.Length != 43)
                {
                    continue;
                }

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


                if (temp[42] == "True" || temp[42] == "true")
                    readBool = true;
                else if (temp[42] == "False" || temp[42] == "false")
                    readBool = false;
                else
                    continue;

                Entries[i].Hash = readBool;

                
                Entries[i].Validated = true;
            }

            for (int i = 0; i < Entries.Length; i++)
            {
                AddToList(Entries[i], -1, -1);
            }
        }

        private int _automatedLabelYSchedule;
        private int _automatedLabelYTimer;

        private DarcySettingsPanel[] _privateSettingsPanels;
        private Label[] _privateSettingsLabels;

        private void InitializeTags()
        {
            //SETTINGS
            Settings_Img_Autorun.Tag = Settings_Label_Autorun;
            Settings_Label_Autorun.Tag = Settings_Img_Autorun;

            Settings_Img_Tray.Tag = Settings_Label_Tray;
            Settings_Label_Tray.Tag = Settings_Img_Tray;

            Settings_Img_Minimized.Tag = Settings_Label_Minimized;
            Settings_Label_Minimized.Tag = Settings_Img_Minimized;

            Settings_Img_Updates.Tag = Settings_Label_Updates;
            Settings_Label_Updates.Tag = Settings_Img_Updates;


            //THEMES
            Theme_Img_Gray.Tag = Theme_Label_Gray;
            Theme_Label_Gray.Tag = Theme_Img_Gray;

            Theme_Img_Red.Tag = Theme_Label_Red;
            Theme_Label_Red.Tag = Theme_Img_Red;

            Theme_Img_Blue.Tag = Theme_Label_Blue;
            Theme_Label_Blue.Tag = Theme_Img_Blue;
            

            //LANGUAGES
            Language_Img_English.Tag = Language_Label_English;
            Language_Label_English.Tag = Language_Img_English;

            Language_Img_Swedish.Tag = Language_Label_Swedish;
            Language_Label_Swedish.Tag = Language_Img_Swedish;

            Language_Img_Finnish.Tag = Language_Label_Finnish;
            Language_Label_Finnish.Tag = Language_Img_Finnish;
        }

        private void InitializeGUI()
        {
            InitializeTags();

            List_Backup.FocusLabel = Label_Settings;

            Settings_Panel.SetBounds(29, 71, Settings_Panel.Width, Settings_Panel.Height);
            Language_Panel.SetBounds(113, 71, Language_Panel.Width, Language_Panel.Height);
            Theme_Panel.SetBounds(225, 71, Theme_Panel.Width, Theme_Panel.Height);
            About_Panel.SetBounds(327, 71, About_Panel.Width, About_Panel.Height);

            _privateSettingsPanels = new DarcySettingsPanel[4];
            _privateSettingsPanels[0] = Settings_Panel;
            _privateSettingsPanels[1] = Language_Panel;
            _privateSettingsPanels[2] = Theme_Panel;
            _privateSettingsPanels[3] = About_Panel;

            _privateSettingsLabels = new Label[4];
            _privateSettingsLabels[0] = Label_Settings;
            _privateSettingsLabels[1] = Label_Language;
            _privateSettingsLabels[2] = Label_Themes;
            _privateSettingsLabels[3] = Label_About;




            List_Backup.View = View.Details;
            List_Backup.FullRowSelect = true;
            List_Backup.MultiSelect = false;
            List_Backup.GridLines = false;
            List_Backup.HideSelection = true;

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


            //Broken listview, hack
            List_Backup.Columns.Add("", 1); //Boken listview, hack
            //Broken listview, hack

            List_Backup.OwnerDraw = true;
            List_Backup.DrawItem += List_Backup_DrawItem;
            List_Backup.DrawSubItem += List_Backup_DrawSubItem;
            List_Backup.DrawColumnHeader += List_Backup_DrawColumnHeader;


            List_Log.View = View.Details;
            List_Log.HideSelection = true;
            List_Log.FullRowSelect = true;
            List_Log.GridLines = false;
            List_Log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

            List_Log.Columns.Add("", 99);
            List_Log.Columns.Add("", 159);
            List_Log.Columns.Add("", 120);
            List_Log.Columns[2].TextAlign = HorizontalAlignment.Right;

            _automatedLabelYSchedule = Label_Automated.Bounds.Y;
            _automatedLabelYTimer = Label_Process_Specific2.Bounds.Y;
            

            About_Label_Version.Text = "Beta Version " + _assemblyVersion;

            //for (int i = 0; i < 15; i ++)
            //AddToLog(0, "success");

            if (_rkApp.GetValue("DarcyBackup") != null)
                Settings_Img_Autorun.Image = Properties.Resources.Check1;
            else
                Settings_Img_Autorun.Image = null;

            if (Properties.Settings.Default.MinimizedOnStartup == true)
                Settings_Img_Minimized.Image = Properties.Resources.Check1;
            else
                Settings_Img_Minimized.Image = null;

            if (Properties.Settings.Default.ToTray == true)
                Settings_Img_Tray.Image = Properties.Resources.Check1;
            else
                Settings_Img_Tray.Image = null;

            if (Properties.Settings.Default.Updates == true)
                Settings_Img_Updates.Image = Properties.Resources.Check1;
            else
                Settings_Img_Updates.Image = null;

            Update_SelectedEntry();

            Label_HeaderSelected.Focus();
            Label_HeaderSelected.Select();
        }

        private void List_Backup_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(226, 226, 226)), e.Bounds);
            e.Graphics.DrawString(e.Header.Text, e.Font, new SolidBrush(Color.Black), e.Bounds);
        }

        private void List_Backup_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {

            e.DrawDefault = true;
        }
        
        private void List_Backup_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            return;


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
