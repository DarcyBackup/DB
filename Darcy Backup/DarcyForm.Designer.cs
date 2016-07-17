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
            this.List_Backup = new System.Windows.Forms.ListView();
            this.Button_Delete = new System.Windows.Forms.Button();
            this.Button_Activate = new System.Windows.Forms.Button();
            this.Label_Backup = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Label_Settings = new System.Windows.Forms.Label();
            this.Label_About = new System.Windows.Forms.Label();
            this.Button_Edit = new System.Windows.Forms.Button();
            this.Button_New = new System.Windows.Forms.Button();
            this.Label_Toggle = new System.Windows.Forms.Label();
            this.Button_Perform = new Darcy_Backup.DarcyButton();
            this.Settings_Panel = new Darcy_Backup.DarcySettingsPanel();
            this.Settings_Check_Minimized = new System.Windows.Forms.CheckBox();
            this.Settings_Check_Autorun = new System.Windows.Forms.CheckBox();
            this.Settings_Label_Language = new System.Windows.Forms.Label();
            this.Settings_Language_Panel = new Darcy_Backup.DarcySettingsLanguagePanel();
            this.Language_Label_Finnish = new System.Windows.Forms.Label();
            this.Language_Label_Swedish = new System.Windows.Forms.Label();
            this.Language_Label_English = new System.Windows.Forms.Label();
            this.About_Panel = new Darcy_Backup.DarcyAboutPanel();
            this.About_LinkLabel_Website = new System.Windows.Forms.LinkLabel();
            this.About_Label_License = new System.Windows.Forms.Label();
            this.About_Label_Authors = new System.Windows.Forms.Label();
            this.About_Label_Version = new System.Windows.Forms.Label();
            this.About_Label_Title = new System.Windows.Forms.Label();
            this.Panel_Selected_Log = new Darcy_Backup.DarcySelectedLogPanel();
            this.Dynamic_Mode = new System.Windows.Forms.Label();
            this.Label_Mode = new System.Windows.Forms.Label();
            this.Dynamic_Process_Specific2 = new System.Windows.Forms.Label();
            this.Label_Process_Specific2 = new System.Windows.Forms.Label();
            this.Dynamic_Process_Specific1 = new System.Windows.Forms.Label();
            this.Label_Process_Specific1 = new System.Windows.Forms.Label();
            this.Dynamic_Automated = new System.Windows.Forms.Label();
            this.Dynamic_Process = new System.Windows.Forms.Label();
            this.Dynamic_Destination = new System.Windows.Forms.Label();
            this.Dynamic_Source = new System.Windows.Forms.Label();
            this.Label_Automated = new System.Windows.Forms.Label();
            this.Label_Process = new System.Windows.Forms.Label();
            this.Label_Destination = new System.Windows.Forms.Label();
            this.Label_Source = new System.Windows.Forms.Label();
            this.List_Log = new System.Windows.Forms.ListView();
            this.Label_HeaderLog = new System.Windows.Forms.Label();
            this.Label_HeaderSelected = new System.Windows.Forms.Label();
            this.Settings_Panel.SuspendLayout();
            this.Settings_Language_Panel.SuspendLayout();
            this.About_Panel.SuspendLayout();
            this.Panel_Selected_Log.SuspendLayout();
            this.SuspendLayout();
            // 
            // List_Backup
            // 
            this.List_Backup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.List_Backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List_Backup.Location = new System.Drawing.Point(450, 85);
            this.List_Backup.MultiSelect = false;
            this.List_Backup.Name = "List_Backup";
            this.List_Backup.Size = new System.Drawing.Size(663, 425);
            this.List_Backup.TabIndex = 10;
            this.List_Backup.UseCompatibleStateImageBehavior = false;
            this.List_Backup.SelectedIndexChanged += new System.EventHandler(this.List_Backup_Selection_Changed);
            // 
            // Button_Delete
            // 
            this.Button_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(231)))), ((int)(((byte)(170)))));
            this.Button_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Delete.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Delete.Location = new System.Drawing.Point(690, 516);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(92, 25);
            this.Button_Delete.TabIndex = 11;
            this.Button_Delete.Text = "Delete";
            this.Button_Delete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Delete.UseVisualStyleBackColor = false;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Button_Activate
            // 
            this.Button_Activate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(231)))), ((int)(((byte)(170)))));
            this.Button_Activate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Activate.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Activate.Location = new System.Drawing.Point(936, 516);
            this.Button_Activate.Name = "Button_Activate";
            this.Button_Activate.Size = new System.Drawing.Size(79, 25);
            this.Button_Activate.TabIndex = 12;
            this.Button_Activate.Text = "Activate";
            this.Button_Activate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Activate.UseVisualStyleBackColor = false;
            this.Button_Activate.Click += new System.EventHandler(this.Button_Activate_Click);
            // 
            // Label_Backup
            // 
            this.Label_Backup.AutoSize = true;
            this.Label_Backup.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Backup.Location = new System.Drawing.Point(445, 51);
            this.Label_Backup.Name = "Label_Backup";
            this.Label_Backup.Size = new System.Drawing.Size(123, 29);
            this.Label_Backup.TabIndex = 13;
            this.Label_Backup.Text = "Backup List";
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
            this.Label_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Label_Settings.Location = new System.Drawing.Point(5, 6);
            this.Label_Settings.Name = "Label_Settings";
            this.Label_Settings.Size = new System.Drawing.Size(56, 16);
            this.Label_Settings.TabIndex = 21;
            this.Label_Settings.Text = "Settings";
            this.Label_Settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Settings.Click += new System.EventHandler(this.Label_Settings_Click);
            this.Label_Settings.DoubleClick += new System.EventHandler(this.Label_Settings_Click);
            this.Label_Settings.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Label_Settings.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Label_About
            // 
            this.Label_About.AutoSize = true;
            this.Label_About.BackColor = System.Drawing.Color.Transparent;
            this.Label_About.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_About.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Label_About.Location = new System.Drawing.Point(80, 6);
            this.Label_About.Name = "Label_About";
            this.Label_About.Size = new System.Drawing.Size(43, 16);
            this.Label_About.TabIndex = 22;
            this.Label_About.Text = "About";
            this.Label_About.Click += new System.EventHandler(this.Label_About_Click);
            this.Label_About.DoubleClick += new System.EventHandler(this.Label_About_Click);
            this.Label_About.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Label_About.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Button_Edit
            // 
            this.Button_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(231)))), ((int)(((byte)(170)))));
            this.Button_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Edit.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Edit.Location = new System.Drawing.Point(570, 516);
            this.Button_Edit.Name = "Button_Edit";
            this.Button_Edit.Size = new System.Drawing.Size(92, 25);
            this.Button_Edit.TabIndex = 27;
            this.Button_Edit.Text = "Edit";
            this.Button_Edit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Edit.UseVisualStyleBackColor = false;
            this.Button_Edit.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // Button_New
            // 
            this.Button_New.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(231)))), ((int)(((byte)(170)))));
            this.Button_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_New.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_New.Location = new System.Drawing.Point(450, 516);
            this.Button_New.Name = "Button_New";
            this.Button_New.Size = new System.Drawing.Size(92, 25);
            this.Button_New.TabIndex = 28;
            this.Button_New.Text = "New";
            this.Button_New.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_New.UseVisualStyleBackColor = false;
            this.Button_New.Click += new System.EventHandler(this.Button_New_Click);
            // 
            // Label_Toggle
            // 
            this.Label_Toggle.BackColor = System.Drawing.Color.Transparent;
            this.Label_Toggle.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Toggle.Location = new System.Drawing.Point(807, 518);
            this.Label_Toggle.Name = "Label_Toggle";
            this.Label_Toggle.Size = new System.Drawing.Size(123, 23);
            this.Label_Toggle.TabIndex = 29;
            this.Label_Toggle.Text = "Toggle Automated:";
            this.Label_Toggle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Button_Perform
            // 
            this.Button_Perform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(231)))), ((int)(((byte)(170)))));
            this.Button_Perform.DarcyDisabled = false;
            this.Button_Perform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Perform.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Perform.Location = new System.Drawing.Point(1021, 516);
            this.Button_Perform.Name = "Button_Perform";
            this.Button_Perform.Size = new System.Drawing.Size(92, 25);
            this.Button_Perform.TabIndex = 9;
            this.Button_Perform.Text = "Perform";
            this.Button_Perform.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Perform.UseVisualStyleBackColor = false;
            this.Button_Perform.Click += new System.EventHandler(this.Button_Perform_Click);
            // 
            // Settings_Panel
            // 
            this.Settings_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.Settings_Panel.Controls.Add(this.Settings_Check_Minimized);
            this.Settings_Panel.Controls.Add(this.Settings_Check_Autorun);
            this.Settings_Panel.Controls.Add(this.Settings_Label_Language);
            this.Settings_Panel.Controls.Add(this.Settings_Language_Panel);
            this.Settings_Panel.Location = new System.Drawing.Point(1164, 39);
            this.Settings_Panel.Name = "Settings_Panel";
            this.Settings_Panel.Size = new System.Drawing.Size(140, 139);
            this.Settings_Panel.TabIndex = 23;
            this.Settings_Panel.Visible = false;
            // 
            // Settings_Check_Minimized
            // 
            this.Settings_Check_Minimized.BackColor = System.Drawing.Color.Transparent;
            this.Settings_Check_Minimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Check_Minimized.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Settings_Check_Minimized.Location = new System.Drawing.Point(7, 60);
            this.Settings_Check_Minimized.Name = "Settings_Check_Minimized";
            this.Settings_Check_Minimized.Size = new System.Drawing.Size(132, 24);
            this.Settings_Check_Minimized.TabIndex = 1;
            this.Settings_Check_Minimized.Text = "Start Minimized";
            this.Settings_Check_Minimized.UseVisualStyleBackColor = false;
            this.Settings_Check_Minimized.CheckedChanged += new System.EventHandler(this.Settings_Check_Minimized_CheckedChanged);
            this.Settings_Check_Minimized.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Check_Minimized.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Check_Autorun
            // 
            this.Settings_Check_Autorun.BackColor = System.Drawing.Color.Transparent;
            this.Settings_Check_Autorun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Check_Autorun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Settings_Check_Autorun.Location = new System.Drawing.Point(7, 20);
            this.Settings_Check_Autorun.Name = "Settings_Check_Autorun";
            this.Settings_Check_Autorun.Size = new System.Drawing.Size(132, 22);
            this.Settings_Check_Autorun.TabIndex = 0;
            this.Settings_Check_Autorun.Text = "Autorun";
            this.Settings_Check_Autorun.UseVisualStyleBackColor = false;
            this.Settings_Check_Autorun.CheckedChanged += new System.EventHandler(this.Settings_Check_Autorun_CheckedChanged);
            this.Settings_Check_Autorun.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Check_Autorun.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Label_Language
            // 
            this.Settings_Label_Language.BackColor = System.Drawing.Color.Transparent;
            this.Settings_Label_Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Label_Language.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Settings_Label_Language.Location = new System.Drawing.Point(7, 100);
            this.Settings_Label_Language.Name = "Settings_Label_Language";
            this.Settings_Label_Language.Size = new System.Drawing.Size(131, 23);
            this.Settings_Label_Language.TabIndex = 2;
            this.Settings_Label_Language.Text = "Language";
            this.Settings_Label_Language.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Settings_Label_Language.Click += new System.EventHandler(this.Settings_Label_Language_Click);
            this.Settings_Label_Language.DoubleClick += new System.EventHandler(this.Settings_Label_Language_Click);
            this.Settings_Label_Language.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Label_Language.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Language_Panel
            // 
            this.Settings_Language_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.Settings_Language_Panel.Controls.Add(this.Language_Label_Finnish);
            this.Settings_Language_Panel.Controls.Add(this.Language_Label_Swedish);
            this.Settings_Language_Panel.Controls.Add(this.Language_Label_English);
            this.Settings_Language_Panel.Location = new System.Drawing.Point(144, 90);
            this.Settings_Language_Panel.Name = "Settings_Language_Panel";
            this.Settings_Language_Panel.Size = new System.Drawing.Size(94, 106);
            this.Settings_Language_Panel.TabIndex = 24;
            this.Settings_Language_Panel.Visible = false;
            // 
            // Language_Label_Finnish
            // 
            this.Language_Label_Finnish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Language_Label_Finnish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Language_Label_Finnish.Location = new System.Drawing.Point(5, 71);
            this.Language_Label_Finnish.Name = "Language_Label_Finnish";
            this.Language_Label_Finnish.Size = new System.Drawing.Size(81, 23);
            this.Language_Label_Finnish.TabIndex = 2;
            this.Language_Label_Finnish.Text = "Finnish";
            this.Language_Label_Finnish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Language_Label_Finnish.Click += new System.EventHandler(this.Language_Label_Click);
            this.Language_Label_Finnish.MouseEnter += new System.EventHandler(this.MouseEnter_LanguageLabels);
            this.Language_Label_Finnish.MouseLeave += new System.EventHandler(this.MouseLeave_LanguageLabels);
            // 
            // Language_Label_Swedish
            // 
            this.Language_Label_Swedish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Language_Label_Swedish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Language_Label_Swedish.Location = new System.Drawing.Point(5, 41);
            this.Language_Label_Swedish.Name = "Language_Label_Swedish";
            this.Language_Label_Swedish.Size = new System.Drawing.Size(81, 23);
            this.Language_Label_Swedish.TabIndex = 1;
            this.Language_Label_Swedish.Text = "Swedish";
            this.Language_Label_Swedish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Language_Label_Swedish.Click += new System.EventHandler(this.Language_Label_Click);
            this.Language_Label_Swedish.MouseEnter += new System.EventHandler(this.MouseEnter_LanguageLabels);
            this.Language_Label_Swedish.MouseLeave += new System.EventHandler(this.MouseLeave_LanguageLabels);
            // 
            // Language_Label_English
            // 
            this.Language_Label_English.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Language_Label_English.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Language_Label_English.Location = new System.Drawing.Point(5, 11);
            this.Language_Label_English.Name = "Language_Label_English";
            this.Language_Label_English.Size = new System.Drawing.Size(81, 23);
            this.Language_Label_English.TabIndex = 0;
            this.Language_Label_English.Text = "English";
            this.Language_Label_English.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Language_Label_English.Click += new System.EventHandler(this.Language_Label_Click);
            this.Language_Label_English.MouseEnter += new System.EventHandler(this.MouseEnter_LanguageLabels);
            this.Language_Label_English.MouseLeave += new System.EventHandler(this.MouseLeave_LanguageLabels);
            // 
            // About_Panel
            // 
            this.About_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.About_Panel.Controls.Add(this.About_LinkLabel_Website);
            this.About_Panel.Controls.Add(this.About_Label_License);
            this.About_Panel.Controls.Add(this.About_Label_Authors);
            this.About_Panel.Controls.Add(this.About_Label_Version);
            this.About_Panel.Controls.Add(this.About_Label_Title);
            this.About_Panel.Location = new System.Drawing.Point(1239, 39);
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
            // Panel_Selected_Log
            // 
            this.Panel_Selected_Log.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Selected_Log.Controls.Add(this.Dynamic_Mode);
            this.Panel_Selected_Log.Controls.Add(this.Label_Mode);
            this.Panel_Selected_Log.Controls.Add(this.Dynamic_Process_Specific2);
            this.Panel_Selected_Log.Controls.Add(this.Label_Process_Specific2);
            this.Panel_Selected_Log.Controls.Add(this.Dynamic_Process_Specific1);
            this.Panel_Selected_Log.Controls.Add(this.Label_Process_Specific1);
            this.Panel_Selected_Log.Controls.Add(this.Dynamic_Automated);
            this.Panel_Selected_Log.Controls.Add(this.Dynamic_Process);
            this.Panel_Selected_Log.Controls.Add(this.Dynamic_Destination);
            this.Panel_Selected_Log.Controls.Add(this.Dynamic_Source);
            this.Panel_Selected_Log.Controls.Add(this.Label_Automated);
            this.Panel_Selected_Log.Controls.Add(this.Label_Process);
            this.Panel_Selected_Log.Controls.Add(this.Label_Destination);
            this.Panel_Selected_Log.Controls.Add(this.Label_Source);
            this.Panel_Selected_Log.Controls.Add(this.List_Log);
            this.Panel_Selected_Log.Controls.Add(this.Label_HeaderLog);
            this.Panel_Selected_Log.Controls.Add(this.Label_HeaderSelected);
            this.Panel_Selected_Log.Location = new System.Drawing.Point(0, 25);
            this.Panel_Selected_Log.Name = "Panel_Selected_Log";
            this.Panel_Selected_Log.Size = new System.Drawing.Size(436, 664);
            this.Panel_Selected_Log.TabIndex = 26;
            // 
            // Dynamic_Mode
            // 
            this.Dynamic_Mode.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dynamic_Mode.Location = new System.Drawing.Point(224, 153);
            this.Dynamic_Mode.Name = "Dynamic_Mode";
            this.Dynamic_Mode.Size = new System.Drawing.Size(209, 17);
            this.Dynamic_Mode.TabIndex = 22;
            this.Dynamic_Mode.Text = "dyn mode";
            this.Dynamic_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Mode
            // 
            this.Label_Mode.AutoSize = true;
            this.Label_Mode.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Mode.Location = new System.Drawing.Point(26, 153);
            this.Label_Mode.Name = "Label_Mode";
            this.Label_Mode.Size = new System.Drawing.Size(45, 17);
            this.Label_Mode.TabIndex = 21;
            this.Label_Mode.Text = "Mode:";
            this.Label_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dynamic_Process_Specific2
            // 
            this.Dynamic_Process_Specific2.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Process_Specific2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dynamic_Process_Specific2.Location = new System.Drawing.Point(224, 253);
            this.Dynamic_Process_Specific2.Name = "Dynamic_Process_Specific2";
            this.Dynamic_Process_Specific2.Size = new System.Drawing.Size(209, 17);
            this.Dynamic_Process_Specific2.TabIndex = 20;
            this.Dynamic_Process_Specific2.Text = "dyn process";
            this.Dynamic_Process_Specific2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Process_Specific2
            // 
            this.Label_Process_Specific2.AutoSize = true;
            this.Label_Process_Specific2.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Process_Specific2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Process_Specific2.Location = new System.Drawing.Point(26, 253);
            this.Label_Process_Specific2.Name = "Label_Process_Specific2";
            this.Label_Process_Specific2.Size = new System.Drawing.Size(54, 17);
            this.Label_Process_Specific2.TabIndex = 19;
            this.Label_Process_Specific2.Text = "Process:";
            this.Label_Process_Specific2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dynamic_Process_Specific1
            // 
            this.Dynamic_Process_Specific1.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Process_Specific1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dynamic_Process_Specific1.Location = new System.Drawing.Point(224, 223);
            this.Dynamic_Process_Specific1.Name = "Dynamic_Process_Specific1";
            this.Dynamic_Process_Specific1.Size = new System.Drawing.Size(209, 17);
            this.Dynamic_Process_Specific1.TabIndex = 18;
            this.Dynamic_Process_Specific1.Text = "dyn process";
            this.Dynamic_Process_Specific1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Process_Specific1
            // 
            this.Label_Process_Specific1.AutoSize = true;
            this.Label_Process_Specific1.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Process_Specific1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Process_Specific1.Location = new System.Drawing.Point(26, 223);
            this.Label_Process_Specific1.Name = "Label_Process_Specific1";
            this.Label_Process_Specific1.Size = new System.Drawing.Size(54, 17);
            this.Label_Process_Specific1.TabIndex = 17;
            this.Label_Process_Specific1.Text = "Process:";
            this.Label_Process_Specific1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dynamic_Automated
            // 
            this.Dynamic_Automated.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Automated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dynamic_Automated.Location = new System.Drawing.Point(224, 283);
            this.Dynamic_Automated.Name = "Dynamic_Automated";
            this.Dynamic_Automated.Size = new System.Drawing.Size(209, 17);
            this.Dynamic_Automated.TabIndex = 16;
            this.Dynamic_Automated.Text = "dyn automated";
            this.Dynamic_Automated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dynamic_Process
            // 
            this.Dynamic_Process.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Process.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dynamic_Process.Location = new System.Drawing.Point(224, 193);
            this.Dynamic_Process.Name = "Dynamic_Process";
            this.Dynamic_Process.Size = new System.Drawing.Size(209, 17);
            this.Dynamic_Process.TabIndex = 15;
            this.Dynamic_Process.Text = "dyn process";
            this.Dynamic_Process.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dynamic_Destination
            // 
            this.Dynamic_Destination.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Destination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dynamic_Destination.Location = new System.Drawing.Point(224, 113);
            this.Dynamic_Destination.Name = "Dynamic_Destination";
            this.Dynamic_Destination.Size = new System.Drawing.Size(209, 17);
            this.Dynamic_Destination.TabIndex = 13;
            this.Dynamic_Destination.Text = "dyn dest";
            this.Dynamic_Destination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dynamic_Source
            // 
            this.Dynamic_Source.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Source.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Dynamic_Source.Location = new System.Drawing.Point(224, 83);
            this.Dynamic_Source.Name = "Dynamic_Source";
            this.Dynamic_Source.Size = new System.Drawing.Size(209, 17);
            this.Dynamic_Source.TabIndex = 12;
            this.Dynamic_Source.Text = "dyn source";
            this.Dynamic_Source.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Automated
            // 
            this.Label_Automated.AutoSize = true;
            this.Label_Automated.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Automated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Automated.Location = new System.Drawing.Point(26, 283);
            this.Label_Automated.Name = "Label_Automated";
            this.Label_Automated.Size = new System.Drawing.Size(76, 17);
            this.Label_Automated.TabIndex = 9;
            this.Label_Automated.Text = "Automated:";
            this.Label_Automated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Process
            // 
            this.Label_Process.AutoSize = true;
            this.Label_Process.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Process.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Process.Location = new System.Drawing.Point(26, 193);
            this.Label_Process.Name = "Label_Process";
            this.Label_Process.Size = new System.Drawing.Size(54, 17);
            this.Label_Process.TabIndex = 8;
            this.Label_Process.Text = "Process:";
            this.Label_Process.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Destination
            // 
            this.Label_Destination.AutoSize = true;
            this.Label_Destination.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Destination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Destination.Location = new System.Drawing.Point(26, 113);
            this.Label_Destination.Name = "Label_Destination";
            this.Label_Destination.Size = new System.Drawing.Size(77, 17);
            this.Label_Destination.TabIndex = 6;
            this.Label_Destination.Text = "Destination:";
            this.Label_Destination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Source
            // 
            this.Label_Source.AutoSize = true;
            this.Label_Source.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Source.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Source.Location = new System.Drawing.Point(26, 83);
            this.Label_Source.Name = "Label_Source";
            this.Label_Source.Size = new System.Drawing.Size(50, 17);
            this.Label_Source.TabIndex = 5;
            this.Label_Source.Text = "Source:";
            this.Label_Source.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // List_Log
            // 
            this.List_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.List_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List_Log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.List_Log.Location = new System.Drawing.Point(23, 404);
            this.List_Log.Name = "List_Log";
            this.List_Log.Size = new System.Drawing.Size(416, 243);
            this.List_Log.TabIndex = 2;
            this.List_Log.UseCompatibleStateImageBehavior = false;
            // 
            // Label_HeaderLog
            // 
            this.Label_HeaderLog.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_HeaderLog.Location = new System.Drawing.Point(12, 334);
            this.Label_HeaderLog.Name = "Label_HeaderLog";
            this.Label_HeaderLog.Size = new System.Drawing.Size(204, 33);
            this.Label_HeaderLog.TabIndex = 1;
            this.Label_HeaderLog.Text = "Log";
            this.Label_HeaderLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_HeaderSelected
            // 
            this.Label_HeaderSelected.BackColor = System.Drawing.Color.Transparent;
            this.Label_HeaderSelected.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_HeaderSelected.Location = new System.Drawing.Point(12, 24);
            this.Label_HeaderSelected.Name = "Label_HeaderSelected";
            this.Label_HeaderSelected.Size = new System.Drawing.Size(204, 33);
            this.Label_HeaderSelected.TabIndex = 0;
            this.Label_HeaderSelected.Text = "Selected Entry";
            this.Label_HeaderSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_Darcy_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1574, 701);
            this.Controls.Add(this.Label_Toggle);
            this.Controls.Add(this.Button_New);
            this.Controls.Add(this.Button_Edit);
            this.Controls.Add(this.Label_About);
            this.Controls.Add(this.Label_Settings);
            this.Controls.Add(this.Label_Backup);
            this.Controls.Add(this.Button_Activate);
            this.Controls.Add(this.Button_Delete);
            this.Controls.Add(this.List_Backup);
            this.Controls.Add(this.Button_Perform);
            this.Controls.Add(this.Settings_Panel);
            this.Controls.Add(this.About_Panel);
            this.Controls.Add(this.Panel_Selected_Log);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1180, 740);
            this.Name = "Form_Darcy_Panel";
            this.Text = "Darcy Backup";
            this.ResizeEnd += new System.EventHandler(this.Form_Darcy_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form_Darcy_Resize);
            this.Settings_Panel.ResumeLayout(false);
            this.Settings_Language_Panel.ResumeLayout(false);
            this.About_Panel.ResumeLayout(false);
            this.About_Panel.PerformLayout();
            this.Panel_Selected_Log.ResumeLayout(false);
            this.Panel_Selected_Log.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarcyButton Button_Perform;
        private System.Windows.Forms.ListView List_Backup;
        private System.Windows.Forms.Button Button_Delete;
        private System.Windows.Forms.Button Button_Activate;
        private System.Windows.Forms.Label Label_Backup;
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
        private DarcySelectedLogPanel Panel_Selected_Log;
        private System.Windows.Forms.Button Button_Edit;
        private System.Windows.Forms.Button Button_New;
        private System.Windows.Forms.Label Label_Toggle;
        private System.Windows.Forms.Label Label_HeaderSelected;
        private System.Windows.Forms.ListView List_Log;
        private System.Windows.Forms.Label Label_HeaderLog;
        private System.Windows.Forms.Label Label_Automated;
        private System.Windows.Forms.Label Label_Process;
        private System.Windows.Forms.Label Dynamic_Automated;
        private System.Windows.Forms.Label Dynamic_Process;
        private System.Windows.Forms.Label Dynamic_Process_Specific1;
        private System.Windows.Forms.Label Label_Process_Specific1;
        private System.Windows.Forms.Label Dynamic_Process_Specific2;
        private System.Windows.Forms.Label Label_Process_Specific2;
        private System.Windows.Forms.Label Dynamic_Mode;
        private System.Windows.Forms.Label Label_Mode;
        private System.Windows.Forms.Label Dynamic_Destination;
        private System.Windows.Forms.Label Dynamic_Source;
        private System.Windows.Forms.Label Label_Destination;
        private System.Windows.Forms.Label Label_Source;
    }
}

