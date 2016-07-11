namespace Darcy_Backup
{

    using System.Drawing;
    partial class Form_Darcy_Panel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Darcy_Panel));
            this.Text_Source = new System.Windows.Forms.TextBox();
            this.Label_Source = new System.Windows.Forms.Label();
            this.Button_Source = new System.Windows.Forms.Button();
            this.Text_Destination = new System.Windows.Forms.TextBox();
            this.Label_Destination = new System.Windows.Forms.Label();
            this.Text_Frequency = new System.Windows.Forms.TextBox();
            this.Label_Frequency = new System.Windows.Forms.Label();
            this.Check_Differential = new System.Windows.Forms.CheckBox();
            this.List_Backup = new System.Windows.Forms.ListView();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.Button_Load = new System.Windows.Forms.Button();
            this.Label_Backup = new System.Windows.Forms.Label();
            this.Button_Destination = new System.Windows.Forms.Button();
            this.Button_New = new System.Windows.Forms.Button();
            this.Button_Discard = new System.Windows.Forms.Button();
            this.Label_Entry = new System.Windows.Forms.Label();
            this.Dynamic_Entry = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Label_Settings = new System.Windows.Forms.Label();
            this.Label_About = new System.Windows.Forms.Label();
            this.Pick_Panel = new System.Windows.Forms.Panel();
            this.Button_Perform = new Darcy_Backup.DarcyButton();
            this.Button_Save = new Darcy_Backup.DarcyButton();
            this.Settings_Language_Panel = new Darcy_Backup.DarcySettingsLanguagePanel();
            this.Language_Label_Finnish = new System.Windows.Forms.Label();
            this.Language_Label_Swedish = new System.Windows.Forms.Label();
            this.Language_Label_English = new System.Windows.Forms.Label();
            this.Settings_Panel = new Darcy_Backup.DarcySettingsPanel();
            this.Settings_Check_Minimized = new System.Windows.Forms.CheckBox();
            this.Settings_Check_Autorun = new System.Windows.Forms.CheckBox();
            this.Settings_Label_Language = new System.Windows.Forms.Label();
            this.About_Panel = new Darcy_Backup.DarcyAboutPanel();
            this.About_LinkLabel_Website = new System.Windows.Forms.LinkLabel();
            this.About_Label_License = new System.Windows.Forms.Label();
            this.About_Label_Authors = new System.Windows.Forms.Label();
            this.About_Label_Version = new System.Windows.Forms.Label();
            this.About_Label_Title = new System.Windows.Forms.Label();
            this.Settings_Language_Panel.SuspendLayout();
            this.Settings_Panel.SuspendLayout();
            this.About_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Text_Source
            // 
            this.Text_Source.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.Text_Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_Source.Location = new System.Drawing.Point(29, 85);
            this.Text_Source.Name = "Text_Source";
            this.Text_Source.Size = new System.Drawing.Size(196, 24);
            this.Text_Source.TabIndex = 0;
            this.Text_Source.TextChanged += new System.EventHandler(this.Text_Source_TextChanged);
            // 
            // Label_Source
            // 
            this.Label_Source.AutoSize = true;
            this.Label_Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Source.Location = new System.Drawing.Point(26, 62);
            this.Label_Source.Name = "Label_Source";
            this.Label_Source.Size = new System.Drawing.Size(56, 18);
            this.Label_Source.TabIndex = 1;
            this.Label_Source.Text = "Source";
            // 
            // Button_Source
            // 
            this.Button_Source.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.Button_Source.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Source.Location = new System.Drawing.Point(232, 85);
            this.Button_Source.Name = "Button_Source";
            this.Button_Source.Size = new System.Drawing.Size(37, 24);
            this.Button_Source.TabIndex = 2;
            this.Button_Source.Text = "...";
            this.Button_Source.UseVisualStyleBackColor = false;
            this.Button_Source.Click += new System.EventHandler(this.Button_Source_Click);
            // 
            // Text_Destination
            // 
            this.Text_Destination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.Text_Destination.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_Destination.Location = new System.Drawing.Point(29, 158);
            this.Text_Destination.Name = "Text_Destination";
            this.Text_Destination.Size = new System.Drawing.Size(196, 24);
            this.Text_Destination.TabIndex = 3;
            this.Text_Destination.TextChanged += new System.EventHandler(this.Text_Destination_TextChanged);
            // 
            // Label_Destination
            // 
            this.Label_Destination.AutoSize = true;
            this.Label_Destination.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Destination.Location = new System.Drawing.Point(26, 137);
            this.Label_Destination.Name = "Label_Destination";
            this.Label_Destination.Size = new System.Drawing.Size(82, 18);
            this.Label_Destination.TabIndex = 4;
            this.Label_Destination.Text = "Destination";
            // 
            // Text_Frequency
            // 
            this.Text_Frequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.Text_Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_Frequency.Location = new System.Drawing.Point(29, 233);
            this.Text_Frequency.Name = "Text_Frequency";
            this.Text_Frequency.Size = new System.Drawing.Size(91, 24);
            this.Text_Frequency.TabIndex = 5;
            this.Text_Frequency.TextChanged += new System.EventHandler(this.Text_Frequency_TextChanged);
            // 
            // Label_Frequency
            // 
            this.Label_Frequency.AutoSize = true;
            this.Label_Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Frequency.Location = new System.Drawing.Point(26, 212);
            this.Label_Frequency.Name = "Label_Frequency";
            this.Label_Frequency.Size = new System.Drawing.Size(143, 18);
            this.Label_Frequency.TabIndex = 6;
            this.Label_Frequency.Text = "Frequency (minutes)";
            // 
            // Check_Differential
            // 
            this.Check_Differential.AutoSize = true;
            this.Check_Differential.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Check_Differential.Location = new System.Drawing.Point(32, 297);
            this.Check_Differential.Name = "Check_Differential";
            this.Check_Differential.Size = new System.Drawing.Size(96, 22);
            this.Check_Differential.TabIndex = 7;
            this.Check_Differential.Text = "Differential";
            this.Check_Differential.UseVisualStyleBackColor = true;
            this.Check_Differential.CheckedChanged += new System.EventHandler(this.Check_Differential_CheckedChanged);
            // 
            // List_Backup
            // 
            this.List_Backup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.List_Backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List_Backup.Location = new System.Drawing.Point(428, 85);
            this.List_Backup.MultiSelect = false;
            this.List_Backup.Name = "List_Backup";
            this.List_Backup.Size = new System.Drawing.Size(685, 425);
            this.List_Backup.TabIndex = 10;
            this.List_Backup.UseCompatibleStateImageBehavior = false;
            // 
            // Button_Remove
            // 
            this.Button_Remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.Button_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Remove.Location = new System.Drawing.Point(1035, 516);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(78, 25);
            this.Button_Remove.TabIndex = 11;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = false;
            this.Button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // Button_Load
            // 
            this.Button_Load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.Button_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Load.Location = new System.Drawing.Point(975, 516);
            this.Button_Load.Name = "Button_Load";
            this.Button_Load.Size = new System.Drawing.Size(54, 25);
            this.Button_Load.TabIndex = 12;
            this.Button_Load.Text = "Load";
            this.Button_Load.UseVisualStyleBackColor = false;
            this.Button_Load.Click += new System.EventHandler(this.Button_Load_Click);
            // 
            // Label_Backup
            // 
            this.Label_Backup.AutoSize = true;
            this.Label_Backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Backup.Location = new System.Drawing.Point(425, 62);
            this.Label_Backup.Name = "Label_Backup";
            this.Label_Backup.Size = new System.Drawing.Size(85, 18);
            this.Label_Backup.TabIndex = 13;
            this.Label_Backup.Text = "Backup List";
            // 
            // Button_Destination
            // 
            this.Button_Destination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.Button_Destination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Destination.Location = new System.Drawing.Point(232, 158);
            this.Button_Destination.Name = "Button_Destination";
            this.Button_Destination.Size = new System.Drawing.Size(37, 24);
            this.Button_Destination.TabIndex = 14;
            this.Button_Destination.Text = "...";
            this.Button_Destination.UseVisualStyleBackColor = false;
            this.Button_Destination.Click += new System.EventHandler(this.Button_Destination_Click);
            // 
            // Button_New
            // 
            this.Button_New.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.Button_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_New.Location = new System.Drawing.Point(29, 339);
            this.Button_New.Name = "Button_New";
            this.Button_New.Size = new System.Drawing.Size(57, 25);
            this.Button_New.TabIndex = 15;
            this.Button_New.Text = "New";
            this.Button_New.UseVisualStyleBackColor = false;
            this.Button_New.Click += new System.EventHandler(this.Button_New_Click);
            // 
            // Button_Discard
            // 
            this.Button_Discard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.Button_Discard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Discard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Discard.ForeColor = System.Drawing.Color.Black;
            this.Button_Discard.Location = new System.Drawing.Point(158, 339);
            this.Button_Discard.Name = "Button_Discard";
            this.Button_Discard.Size = new System.Drawing.Size(75, 25);
            this.Button_Discard.TabIndex = 16;
            this.Button_Discard.Text = "Discard";
            this.Button_Discard.UseVisualStyleBackColor = false;
            this.Button_Discard.Click += new System.EventHandler(this.Button_Discard_Click);
            // 
            // Label_Entry
            // 
            this.Label_Entry.AutoSize = true;
            this.Label_Entry.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Entry.Location = new System.Drawing.Point(26, 395);
            this.Label_Entry.Name = "Label_Entry";
            this.Label_Entry.Size = new System.Drawing.Size(110, 18);
            this.Label_Entry.TabIndex = 17;
            this.Label_Entry.Text = "Displayed Entry";
            // 
            // Dynamic_Entry
            // 
            this.Dynamic_Entry.AutoSize = true;
            this.Dynamic_Entry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dynamic_Entry.Location = new System.Drawing.Point(32, 422);
            this.Dynamic_Entry.Name = "Dynamic_Entry";
            this.Dynamic_Entry.Size = new System.Drawing.Size(34, 15);
            this.Dynamic_Entry.TabIndex = 18;
            this.Dynamic_Entry.Text = "Entry";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Click twice to open";
            this.notifyIcon.BalloonTipTitle = "Darcy Backup";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Darcy Backup";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Label_Settings
            // 
            this.Label_Settings.AutoSize = true;
            this.Label_Settings.BackColor = System.Drawing.Color.Transparent;
            this.Label_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Settings.Location = new System.Drawing.Point(5, 15);
            this.Label_Settings.Name = "Label_Settings";
            this.Label_Settings.Size = new System.Drawing.Size(61, 18);
            this.Label_Settings.TabIndex = 21;
            this.Label_Settings.Text = "Settings";
            this.Label_Settings.Click += new System.EventHandler(this.Label_Settings_Click);
            this.Label_Settings.DoubleClick += new System.EventHandler(this.Label_Settings_Click);
            this.Label_Settings.MouseEnter += new System.EventHandler(this.MouseEnter_Bold);
            this.Label_Settings.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Label_About
            // 
            this.Label_About.AutoSize = true;
            this.Label_About.BackColor = System.Drawing.Color.Transparent;
            this.Label_About.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_About.Location = new System.Drawing.Point(80, 15);
            this.Label_About.Name = "Label_About";
            this.Label_About.Size = new System.Drawing.Size(46, 18);
            this.Label_About.TabIndex = 22;
            this.Label_About.Text = "About";
            this.Label_About.Click += new System.EventHandler(this.Label_About_Click);
            this.Label_About.DoubleClick += new System.EventHandler(this.Label_About_Click);
            this.Label_About.MouseEnter += new System.EventHandler(this.MouseEnter_Bold);
            this.Label_About.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Pick_Panel
            // 
            this.Pick_Panel.Location = new System.Drawing.Point(13, 62);
            this.Pick_Panel.Name = "Pick_Panel";
            this.Pick_Panel.Size = new System.Drawing.Size(395, 447);
            this.Pick_Panel.TabIndex = 26;
            // 
            // Button_Perform
            // 
            this.Button_Perform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.Button_Perform.DarcyDisabled = false;
            this.Button_Perform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Perform.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Perform.Location = new System.Drawing.Point(844, 516);
            this.Button_Perform.Name = "Button_Perform";
            this.Button_Perform.Size = new System.Drawing.Size(92, 25);
            this.Button_Perform.TabIndex = 9;
            this.Button_Perform.Text = "Perform";
            this.Button_Perform.UseVisualStyleBackColor = false;
            this.Button_Perform.Click += new System.EventHandler(this.Button_Perform_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.Button_Save.DarcyDisabled = false;
            this.Button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Save.Location = new System.Drawing.Point(92, 339);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(60, 25);
            this.Button_Save.TabIndex = 8;
            this.Button_Save.Text = "Save";
            this.Button_Save.UseVisualStyleBackColor = false;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Settings_Language_Panel
            // 
            this.Settings_Language_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.Settings_Language_Panel.Controls.Add(this.Language_Label_Finnish);
            this.Settings_Language_Panel.Controls.Add(this.Language_Label_Swedish);
            this.Settings_Language_Panel.Controls.Add(this.Language_Label_English);
            this.Settings_Language_Panel.Location = new System.Drawing.Point(139, 127);
            this.Settings_Language_Panel.Name = "Settings_Language_Panel";
            this.Settings_Language_Panel.Size = new System.Drawing.Size(94, 106);
            this.Settings_Language_Panel.TabIndex = 24;
            this.Settings_Language_Panel.Visible = false;
            // 
            // Language_Label_Finnish
            // 
            this.Language_Label_Finnish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Language_Label_Finnish.Location = new System.Drawing.Point(5, 71);
            this.Language_Label_Finnish.Name = "Language_Label_Finnish";
            this.Language_Label_Finnish.Size = new System.Drawing.Size(81, 23);
            this.Language_Label_Finnish.TabIndex = 2;
            this.Language_Label_Finnish.Text = "Finnish";
            this.Language_Label_Finnish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Language_Label_Finnish.Click += new System.EventHandler(this.Language_Label_CLick);
            this.Language_Label_Finnish.MouseEnter += new System.EventHandler(this.MouseEnter_LanguageLabels);
            this.Language_Label_Finnish.MouseLeave += new System.EventHandler(this.MouseLeave_LanguageLabels);
            // 
            // Language_Label_Swedish
            // 
            this.Language_Label_Swedish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Language_Label_Swedish.Location = new System.Drawing.Point(5, 41);
            this.Language_Label_Swedish.Name = "Language_Label_Swedish";
            this.Language_Label_Swedish.Size = new System.Drawing.Size(81, 23);
            this.Language_Label_Swedish.TabIndex = 1;
            this.Language_Label_Swedish.Text = "Swedish";
            this.Language_Label_Swedish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Language_Label_Swedish.Click += new System.EventHandler(this.Language_Label_CLick);
            this.Language_Label_Swedish.MouseEnter += new System.EventHandler(this.MouseEnter_LanguageLabels);
            this.Language_Label_Swedish.MouseLeave += new System.EventHandler(this.MouseLeave_LanguageLabels);
            // 
            // Language_Label_English
            // 
            this.Language_Label_English.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Language_Label_English.Location = new System.Drawing.Point(5, 11);
            this.Language_Label_English.Name = "Language_Label_English";
            this.Language_Label_English.Size = new System.Drawing.Size(81, 23);
            this.Language_Label_English.TabIndex = 0;
            this.Language_Label_English.Text = "English";
            this.Language_Label_English.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Language_Label_English.Click += new System.EventHandler(this.Language_Label_CLick);
            this.Language_Label_English.MouseEnter += new System.EventHandler(this.MouseEnter_LanguageLabels);
            this.Language_Label_English.MouseLeave += new System.EventHandler(this.MouseLeave_LanguageLabels);
            // 
            // Settings_Panel
            // 
            this.Settings_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.Settings_Panel.Controls.Add(this.Settings_Check_Minimized);
            this.Settings_Panel.Controls.Add(this.Settings_Check_Autorun);
            this.Settings_Panel.Controls.Add(this.Settings_Label_Language);
            this.Settings_Panel.Location = new System.Drawing.Point(0, 38);
            this.Settings_Panel.Name = "Settings_Panel";
            this.Settings_Panel.Size = new System.Drawing.Size(140, 139);
            this.Settings_Panel.TabIndex = 23;
            this.Settings_Panel.Visible = false;
            // 
            // Settings_Check_Minimized
            // 
            this.Settings_Check_Minimized.BackColor = System.Drawing.Color.Transparent;
            this.Settings_Check_Minimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Check_Minimized.Location = new System.Drawing.Point(7, 60);
            this.Settings_Check_Minimized.Name = "Settings_Check_Minimized";
            this.Settings_Check_Minimized.Size = new System.Drawing.Size(132, 24);
            this.Settings_Check_Minimized.TabIndex = 1;
            this.Settings_Check_Minimized.Text = "Start Minimized";
            this.Settings_Check_Minimized.UseVisualStyleBackColor = false;
            this.Settings_Check_Minimized.CheckedChanged += new System.EventHandler(this.Settings_Check_Minimized_CheckedChanged);
            this.Settings_Check_Minimized.MouseEnter += new System.EventHandler(this.MouseEnter_Bold);
            this.Settings_Check_Minimized.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Check_Autorun
            // 
            this.Settings_Check_Autorun.BackColor = System.Drawing.Color.Transparent;
            this.Settings_Check_Autorun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Check_Autorun.Location = new System.Drawing.Point(7, 20);
            this.Settings_Check_Autorun.Name = "Settings_Check_Autorun";
            this.Settings_Check_Autorun.Size = new System.Drawing.Size(132, 22);
            this.Settings_Check_Autorun.TabIndex = 0;
            this.Settings_Check_Autorun.Text = "Autorun";
            this.Settings_Check_Autorun.UseVisualStyleBackColor = false;
            this.Settings_Check_Autorun.CheckedChanged += new System.EventHandler(this.Settings_Check_Autorun_CheckedChanged);
            this.Settings_Check_Autorun.MouseEnter += new System.EventHandler(this.MouseEnter_Bold);
            this.Settings_Check_Autorun.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Label_Language
            // 
            this.Settings_Label_Language.BackColor = System.Drawing.Color.Transparent;
            this.Settings_Label_Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Label_Language.Location = new System.Drawing.Point(7, 100);
            this.Settings_Label_Language.Name = "Settings_Label_Language";
            this.Settings_Label_Language.Size = new System.Drawing.Size(131, 23);
            this.Settings_Label_Language.TabIndex = 2;
            this.Settings_Label_Language.Text = "Language";
            this.Settings_Label_Language.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Settings_Label_Language.Click += new System.EventHandler(this.Settings_Label_Language_Click);
            this.Settings_Label_Language.DoubleClick += new System.EventHandler(this.Settings_Label_Language_Click);
            this.Settings_Label_Language.MouseEnter += new System.EventHandler(this.MouseEnter_Bold);
            this.Settings_Label_Language.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // About_Panel
            // 
            this.About_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.About_Panel.Controls.Add(this.About_LinkLabel_Website);
            this.About_Panel.Controls.Add(this.About_Label_License);
            this.About_Panel.Controls.Add(this.About_Label_Authors);
            this.About_Panel.Controls.Add(this.About_Label_Version);
            this.About_Panel.Controls.Add(this.About_Label_Title);
            this.About_Panel.Location = new System.Drawing.Point(80, 38);
            this.About_Panel.Name = "About_Panel";
            this.About_Panel.Size = new System.Drawing.Size(308, 260);
            this.About_Panel.TabIndex = 25;
            this.About_Panel.Visible = false;
            // 
            // About_LinkLabel_Website
            // 
            this.About_LinkLabel_Website.AutoSize = true;
            this.About_LinkLabel_Website.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About_LinkLabel_Website.Location = new System.Drawing.Point(149, 232);
            this.About_LinkLabel_Website.Name = "About_LinkLabel_Website";
            this.About_LinkLabel_Website.Size = new System.Drawing.Size(146, 16);
            this.About_LinkLabel_Website.TabIndex = 4;
            this.About_LinkLabel_Website.TabStop = true;
            this.About_LinkLabel_Website.Text = "www.darcybackup.com";
            // 
            // About_Label_License
            // 
            this.About_Label_License.AutoSize = true;
            this.About_Label_License.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About_Label_License.Location = new System.Drawing.Point(10, 174);
            this.About_Label_License.Name = "About_Label_License";
            this.About_Label_License.Size = new System.Drawing.Size(107, 16);
            this.About_Label_License.TabIndex = 3;
            this.About_Label_License.Text = "License: GPL 2.0";
            // 
            // About_Label_Authors
            // 
            this.About_Label_Authors.AutoSize = true;
            this.About_Label_Authors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About_Label_Authors.Location = new System.Drawing.Point(10, 124);
            this.About_Label_Authors.Name = "About_Label_Authors";
            this.About_Label_Authors.Size = new System.Drawing.Size(207, 16);
            this.About_Label_Authors.TabIndex = 2;
            this.About_Label_Authors.Text = "Author: Darcy Backup Foundation";
            // 
            // About_Label_Version
            // 
            this.About_Label_Version.AutoSize = true;
            this.About_Label_Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About_Label_Version.Location = new System.Drawing.Point(10, 74);
            this.About_Label_Version.Name = "About_Label_Version";
            this.About_Label_Version.Size = new System.Drawing.Size(54, 16);
            this.About_Label_Version.TabIndex = 1;
            this.About_Label_Version.Text = "Version";
            // 
            // About_Label_Title
            // 
            this.About_Label_Title.AutoSize = true;
            this.About_Label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About_Label_Title.Location = new System.Drawing.Point(8, 16);
            this.About_Label_Title.Name = "About_Label_Title";
            this.About_Label_Title.Size = new System.Drawing.Size(160, 29);
            this.About_Label_Title.TabIndex = 0;
            this.About_Label_Title.Text = "Darcy Backup";
            // 
            // Form_Darcy_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1125, 551);
            this.Controls.Add(this.Pick_Panel);
            this.Controls.Add(this.Label_About);
            this.Controls.Add(this.Label_Settings);
            this.Controls.Add(this.Dynamic_Entry);
            this.Controls.Add(this.Label_Entry);
            this.Controls.Add(this.Button_Discard);
            this.Controls.Add(this.Button_New);
            this.Controls.Add(this.Button_Destination);
            this.Controls.Add(this.Label_Backup);
            this.Controls.Add(this.Button_Load);
            this.Controls.Add(this.Button_Remove);
            this.Controls.Add(this.List_Backup);
            this.Controls.Add(this.Button_Perform);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.Check_Differential);
            this.Controls.Add(this.Label_Frequency);
            this.Controls.Add(this.Text_Frequency);
            this.Controls.Add(this.Label_Destination);
            this.Controls.Add(this.Text_Destination);
            this.Controls.Add(this.Button_Source);
            this.Controls.Add(this.Label_Source);
            this.Controls.Add(this.Text_Source);
            this.Controls.Add(this.Settings_Language_Panel);
            this.Controls.Add(this.Settings_Panel);
            this.Controls.Add(this.About_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Darcy_Panel";
            this.Text = "Darcy Backup";
            this.Resize += new System.EventHandler(this.Form_Darcy_Resize);
            this.Settings_Language_Panel.ResumeLayout(false);
            this.Settings_Panel.ResumeLayout(false);
            this.About_Panel.ResumeLayout(false);
            this.About_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Source;
        private System.Windows.Forms.Label Label_Destination;
        private System.Windows.Forms.TextBox Text_Destination;
        private System.Windows.Forms.Label Label_Source;
        private System.Windows.Forms.TextBox Text_Source;
        private System.Windows.Forms.Label Label_Frequency;
        private System.Windows.Forms.TextBox Text_Frequency;
        private System.Windows.Forms.CheckBox Check_Differential;
        private DarcyButton Button_Save;
        private DarcyButton Button_Perform;
        private System.Windows.Forms.ListView List_Backup;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.Button Button_Load;
        private System.Windows.Forms.Label Label_Backup;
        private System.Windows.Forms.Button Button_Destination;
        private System.Windows.Forms.Button Button_New;
        private System.Windows.Forms.Button Button_Discard;
        private System.Windows.Forms.Label Label_Entry;
        private System.Windows.Forms.Label Dynamic_Entry;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label Label_Settings;
        private System.Windows.Forms.Label Label_About;
        private DarcySettingsPanel Settings_Panel;
        private System.Windows.Forms.Label Settings_Label_Language;
        private System.Windows.Forms.CheckBox Settings_Check_Autorun;
        private System.Windows.Forms.CheckBox Settings_Check_Minimized;
        private DarcySettingsLanguagePanel Settings_Language_Panel;
        private System.Windows.Forms.Label Language_Label_Swedish;
        private System.Windows.Forms.Label Language_Label_English;
        private System.Windows.Forms.Label Language_Label_Finnish;
        private DarcyAboutPanel About_Panel;
        private System.Windows.Forms.Label About_Label_Authors;
        private System.Windows.Forms.Label About_Label_Version;
        private System.Windows.Forms.Label About_Label_Title;
        private System.Windows.Forms.LinkLabel About_LinkLabel_Website;
        private System.Windows.Forms.Label About_Label_License;
        private System.Windows.Forms.Panel Pick_Panel;
    }
}

