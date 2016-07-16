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

            CheckForUpdates();

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

            ResizeArray = new resizeStruct[RESIZE_ARRAY_SIZE];

            ResizeArray[BUTTON_PERFORM].control = Button_Perform;
            ResizeArray[BUTTON_PERFORM].width = 12;
            ResizeArray[BUTTON_PERFORM].height = 10;
            ResizeArray[BUTTON_PERFORM].stayX = false;
            ResizeArray[BUTTON_PERFORM].stayY = false;
        
            ResizeArray[BUTTON_ACTIVATE].control = Button_Activate;
            ResizeArray[BUTTON_ACTIVATE].width = 132;
            ResizeArray[BUTTON_ACTIVATE].height = 10;
            ResizeArray[BUTTON_ACTIVATE].stayX = false;
            ResizeArray[BUTTON_ACTIVATE].stayY = false;

            ResizeArray[BUTTON_DELETE].control = Button_Delete;
            ResizeArray[BUTTON_DELETE].width = -1;
            ResizeArray[BUTTON_DELETE].height = 10;
            ResizeArray[BUTTON_DELETE].stayX = true;
            ResizeArray[BUTTON_DELETE].stayY = false;

            ResizeArray[LIST_BACKUP].control = List_Backup;
            ResizeArray[LIST_BACKUP].width = 12;
            ResizeArray[LIST_BACKUP].height = 42;
            ResizeArray[LIST_BACKUP].stayX = true;
            ResizeArray[LIST_BACKUP].stayY = true;

            ResizeArray[BUTTON_NEW].control = Button_New;
            ResizeArray[BUTTON_NEW].width = -1;
            ResizeArray[BUTTON_NEW].height = 10;
            ResizeArray[BUTTON_NEW].stayX = true;
            ResizeArray[BUTTON_NEW].stayY = false;

            ResizeArray[BUTTON_EDIT].control = Button_Edit;
            ResizeArray[BUTTON_EDIT].width = -1;
            ResizeArray[BUTTON_EDIT].height = 10;
            ResizeArray[BUTTON_EDIT].stayX = true;
            ResizeArray[BUTTON_EDIT].stayY = false;

            ResizeArray[LABEL_TOGGLE].control = Label_Toggle;
            ResizeArray[LABEL_TOGGLE].width = 216;
            ResizeArray[LABEL_TOGGLE].height = 10;
            ResizeArray[LABEL_TOGGLE].stayX = false;
            ResizeArray[LABEL_TOGGLE].stayY = false;

            ResizeArray[PANEL_SELECTEDLOG].control = Panel_Selected_Log;
            ResizeArray[PANEL_SELECTEDLOG].width = -1;
            ResizeArray[PANEL_SELECTEDLOG].height = 42;
            ResizeArray[PANEL_SELECTEDLOG].stayX = true;
            ResizeArray[PANEL_SELECTEDLOG].stayY = true;

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
            bool exists = File.Exists(fullPath);

            if (exists == false)
            {
                FileStream fs = File.Create(fullPath);
                fs.Close();

                exists = File.Exists(fullPath);
                if (exists == false)
                {
                    MessageBox.Show("Can not create dbss file in this folder", "Error", MessageBoxButtons.OK);
                    Application.Exit();
                }
                

            }


            string[] entryString = System.IO.File.ReadAllLines(fullPath);

            Entries = new EntryClass[entryString.Length];
            for (int i = 0; i < Entries.Length; i ++)
                Entries[i] = new EntryClass();

            for (int i = 0; i < entryString.Length; i++)
            {
                string[] temp = entryString[i].Split(';');

                if (temp.Length != 6)
                    continue;

                int parsed = 0;
                if (Int32.TryParse(temp[0], out parsed) == false)
                    continue;

                Entries[i].Entry = parsed;
                Entries[i].Source = temp[1];
                Entries[i].Destination = temp[2];

                if (Int32.TryParse(temp[3], out parsed) == false)
                    continue;

                Entries[i].Timer = parsed;

                bool readBool;
                if (temp[4] == "True")
                    readBool = true;
                else if (temp[4] == "False")
                    readBool = false;
                else
                    continue;

                if (readBool)
                    Entries[i].Mode = 0;
                //Entries[i].differential = readBool;

                Entries[i].LastPerformed = temp[5];
                

                lastLine = Entries[i].Entry;
            }

            for (int i = 0; i < Entries.Length; i++)
            {
                AddToList(Entries[i], -1);
            }
        }

        private void InitializeGUI()
        {
            List_Backup.View = View.Details;
            List_Backup.FullRowSelect = true;
            List_Backup.MultiSelect = false;
            List_Backup.GridLines = false;
            List_Backup.HideSelection = false;

            List_Backup.ColumnWidthChanged += List_Backup_ColumnWidthChanged;

            List_Backup.Columns.Add("Entry", Properties.Settings.Default.List_Entry);
            List_Backup.Columns.Add("Source", Properties.Settings.Default.List_Source);
            List_Backup.Columns.Add("Destination", Properties.Settings.Default.List_Destination);
            List_Backup.Columns.Add("Frequency", Properties.Settings.Default.List_Frequency);
            List_Backup.Columns.Add("Differential", Properties.Settings.Default.List_Differential);
            List_Backup.Columns.Add("Last Performed", Properties.Settings.Default.List_Performed);





            List_Log.View = View.Details;
            List_Log.FullRowSelect = true;
            List_Log.GridLines = false;
            List_Log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;

            List_Log.Columns.Add("", 150);
            List_Log.Columns.Add("", 150);
            List_Log.Columns.Add("", 150);



            string[] strArr = new string[3];
            ListViewItem item;
            strArr[0] = "Tja";
            strArr[1] = "Ba";
            strArr[2] = "La";
            item = new ListViewItem(strArr);

            for (int i = 0; i < 100; i++)
            {
                strArr[0] = "Tja" + i;
                item = new ListViewItem(strArr);
                List_Log.Items.Insert(i, item);
            }




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

        }
    }
}
