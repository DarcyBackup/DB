using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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

            InitializeFields();

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
            InitializeWorkerThread();
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

        private static int RESIZE_ARRAY_SIZE = 7;

        private void InitializeResize()
        {
             /*  Add controls to scale with resize, here
            //
            //  Button_Perform
            //  Button_Activaate
            //  Button_Remove
            //  List_Backup
            //
            //  entries: 4
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

            ResizeArray[BUTTON_NEW].control = Button_New2;
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

            //SET FORM TO LAST VALUE

            int height = Properties.Settings.Default.Height;
            int width = Properties.Settings.Default.Width;

            this.Bounds = (new Rectangle(this.Bounds.X, this.Bounds.Y, width, height));
        }
        /*
        //  END OF RESIZE
        */
        private void InitializeFields()
        {
            buttonEnabled.Button_Discard = false;
            buttonEnabled.Button_Save = false;
        }

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

            entries = new entryStruct[entryString.Length];

            for (int i = 0; i < entryString.Length; i++)
            {
                string[] temp = entryString[i].Split(';');

                if (temp.Length != 6)
                    continue;

                int parsed = 0;
                if (Int32.TryParse(temp[0], out parsed) == false)
                    continue;

                entries[i].entry = parsed;
                entries[i].source = temp[1];
                entries[i].destination = temp[2];

                if (Int32.TryParse(temp[3], out parsed) == false)
                    continue;

                entries[i].frequency = parsed;

                bool readBool;
                if (temp[4] == "True")
                    readBool = true;
                else if (temp[4] == "False")
                    readBool = false;
                else
                    continue;

                entries[i].differential = readBool;

                entries[i].lastPerformed = temp[5];

                entries[i].validated = true;
                entries[i].newEntry = false;

                lastLine = entries[i].entry;
            }

            for (int i = 0; i < entries.Length; i++)
            {
                AddToList(entries[i], -1);
            }
        }

        private void InitializeGUI()
        {
            List_Backup.View = View.Details;
            List_Backup.FullRowSelect = true;
            List_Backup.GridLines = false;

            List_Backup.ColumnWidthChanged += List_Backup_ColumnWidthChanged;

            List_Backup.Columns.Add("Entry", Properties.Settings.Default.List_Entry);
            List_Backup.Columns.Add("Source", Properties.Settings.Default.List_Source);
            List_Backup.Columns.Add("Destination", Properties.Settings.Default.List_Destination);
            List_Backup.Columns.Add("Frequency", Properties.Settings.Default.List_Frequency);
            List_Backup.Columns.Add("Differential", Properties.Settings.Default.List_Differential);
            List_Backup.Columns.Add("Last Performed", Properties.Settings.Default.List_Performed);

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

            Dynamic_Entry.Text = "New";

            buttonEnabled.Button_Save = false;
            Button_Save.BackColor = Color.FromArgb(248, 244, 255);
            Button_Save.ForeColor = Color.FromArgb(0, 0, 0);

            buttonEnabled.Button_Discard = false;
            Button_Discard.BackColor = Color.FromArgb(248, 244, 255);
            Button_Discard.ForeColor = Color.FromArgb(0, 0, 0);

        }
    }
}
