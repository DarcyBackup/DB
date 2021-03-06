﻿namespace Darcy_Backup
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
            this.Button_Delete = new System.Windows.Forms.Button();
            this.Button_Activate = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Button_Edit = new System.Windows.Forms.Button();
            this.Button_New = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Settings_Img_Autorun = new Darcy_Backup.DarcyImgLabel();
            this.Button_Cancel = new Darcy_Backup.DarcyButton();
            this.About_Panel = new Darcy_Backup.DarcySettingsPanel();
            this.About_Label_License = new Darcy_Backup.DarcyLabel();
            this.About_Label_Version = new Darcy_Backup.DarcyLabel();
            this.About_Label_Title = new Darcy_Backup.DarcyLabel();
            this.Theme_Panel = new Darcy_Backup.DarcySettingsPanel();
            this.Theme_Img_Blue = new Darcy_Backup.DarcyImgLabel();
            this.Theme_Img_Red = new Darcy_Backup.DarcyImgLabel();
            this.Theme_Img_Gray = new Darcy_Backup.DarcyImgLabel();
            this.Theme_Label_Gray = new Darcy_Backup.DarcyLabel();
            this.Theme_Label_Blue = new Darcy_Backup.DarcyLabel();
            this.Theme_Label_Red = new Darcy_Backup.DarcyLabel();
            this.Language_Panel = new Darcy_Backup.DarcySettingsPanel();
            this.Language_Img_Finnish = new Darcy_Backup.DarcyImgLabel();
            this.Language_Img_Swedish = new Darcy_Backup.DarcyImgLabel();
            this.Language_Img_English = new Darcy_Backup.DarcyImgLabel();
            this.Language_Label_English = new Darcy_Backup.DarcyLabel();
            this.Language_Label_Finnish = new Darcy_Backup.DarcyLabel();
            this.Language_Label_Swedish = new Darcy_Backup.DarcyLabel();
            this.Settings_Panel = new Darcy_Backup.DarcySettingsPanel();
            this.Settings_Img_Updates = new Darcy_Backup.DarcyImgLabel();
            this.Settings_Img_Minimized = new Darcy_Backup.DarcyImgLabel();
            this.Settings_Img_Tray = new Darcy_Backup.DarcyImgLabel();
            this.Settings_Label_Updates = new Darcy_Backup.DarcyLabel();
            this.Settings_Label_Minimized = new Darcy_Backup.DarcyLabel();
            this.Settings_Label_Tray = new Darcy_Backup.DarcyLabel();
            this.Settings_Label_Autorun = new Darcy_Backup.DarcyLabel();
            this.Darcy_Top_Panel = new Darcy_Backup.DarcyTopPanel();
            this.Label_Themes = new Darcy_Backup.DarcyLabel();
            this.Label_Language = new Darcy_Backup.DarcyLabel();
            this.Label_Settings = new Darcy_Backup.DarcyLabel();
            this.Label_About = new Darcy_Backup.DarcyLabel();
            this.Label_Toggle = new Darcy_Backup.DarcyLabel();
            this.Label_Backup = new Darcy_Backup.DarcyLabel();
            this.List_Backup = new Darcy_Backup.DarcyListView();
            this.Button_Perform = new Darcy_Backup.DarcyButton();
            this.Panel_Selected_Log = new Darcy_Backup.DarcySelectedLogPanel();
            this.Label_Hash = new Darcy_Backup.DarcyLabel();
            this.Dynamic_Hash = new Darcy_Backup.DarcyLabel();
            this.Dynamic_Mode = new Darcy_Backup.DarcyLabel();
            this.Label_Mode = new Darcy_Backup.DarcyLabel();
            this.Dynamic_Process_Specific2 = new Darcy_Backup.DarcyLabel();
            this.Label_Process_Specific2 = new Darcy_Backup.DarcyLabel();
            this.Dynamic_Process_Specific1 = new Darcy_Backup.DarcyLabel();
            this.Label_Process_Specific1 = new Darcy_Backup.DarcyLabel();
            this.Dynamic_Automated = new Darcy_Backup.DarcyLabel();
            this.Dynamic_Process = new Darcy_Backup.DarcyLabel();
            this.Dynamic_Destination = new Darcy_Backup.DarcyLabel();
            this.Dynamic_Source = new Darcy_Backup.DarcyLabel();
            this.Label_Automated = new Darcy_Backup.DarcyLabel();
            this.Label_Process = new Darcy_Backup.DarcyLabel();
            this.Label_Destination = new Darcy_Backup.DarcyLabel();
            this.Label_Source = new Darcy_Backup.DarcyLabel();
            this.List_Log = new System.Windows.Forms.ListView();
            this.Label_HeaderLog = new Darcy_Backup.DarcyLabel();
            this.Label_HeaderSelected = new Darcy_Backup.DarcyLabel();
            this.About_Panel.SuspendLayout();
            this.Theme_Panel.SuspendLayout();
            this.Language_Panel.SuspendLayout();
            this.Settings_Panel.SuspendLayout();
            this.Darcy_Top_Panel.SuspendLayout();
            this.Panel_Selected_Log.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Delete
            // 
            this.Button_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Button_Delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(144)))));
            this.Button_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Delete.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.Button_Delete.Location = new System.Drawing.Point(610, 516);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(60, 25);
            this.Button_Delete.TabIndex = 11;
            this.Button_Delete.Text = "Delete";
            this.Button_Delete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Delete.UseVisualStyleBackColor = false;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Button_Activate
            // 
            this.Button_Activate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Button_Activate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(144)))));
            this.Button_Activate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Activate.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.Button_Activate.Location = new System.Drawing.Point(908, 516);
            this.Button_Activate.Name = "Button_Activate";
            this.Button_Activate.Size = new System.Drawing.Size(80, 25);
            this.Button_Activate.TabIndex = 12;
            this.Button_Activate.Text = "Deactivate";
            this.Button_Activate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Activate.UseVisualStyleBackColor = false;
            this.Button_Activate.Click += new System.EventHandler(this.Button_Activate_Click);
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
            // Button_Edit
            // 
            this.Button_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Button_Edit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(144)))));
            this.Button_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Edit.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.Button_Edit.Location = new System.Drawing.Point(530, 516);
            this.Button_Edit.Name = "Button_Edit";
            this.Button_Edit.Size = new System.Drawing.Size(60, 25);
            this.Button_Edit.TabIndex = 27;
            this.Button_Edit.Text = "Edit";
            this.Button_Edit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Edit.UseVisualStyleBackColor = false;
            this.Button_Edit.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // Button_New
            // 
            this.Button_New.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Button_New.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(144)))));
            this.Button_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_New.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.Button_New.Location = new System.Drawing.Point(450, 516);
            this.Button_New.Name = "Button_New";
            this.Button_New.Size = new System.Drawing.Size(60, 25);
            this.Button_New.TabIndex = 28;
            this.Button_New.Text = "New";
            this.Button_New.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_New.UseVisualStyleBackColor = false;
            this.Button_New.Click += new System.EventHandler(this.Button_New_Click);
            // 
            // Settings_Img_Autorun
            // 
            this.Settings_Img_Autorun.Image = global::Darcy_Backup.Properties.Resources.Check1;
            this.Settings_Img_Autorun.Location = new System.Drawing.Point(1, 22);
            this.Settings_Img_Autorun.Name = "Settings_Img_Autorun";
            this.Settings_Img_Autorun.Size = new System.Drawing.Size(26, 14);
            this.Settings_Img_Autorun.TabIndex = 32;
            this.Settings_Img_Autorun.Click += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Img_Autorun.DoubleClick += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Img_Autorun.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Img_Autorun.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Button_Cancel.DarcyDisabled = false;
            this.Button_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(144)))));
            this.Button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Cancel.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.Button_Cancel.Location = new System.Drawing.Point(1077, 516);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(65, 25);
            this.Button_Cancel.TabIndex = 31;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Cancel.UseVisualStyleBackColor = false;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // About_Panel
            // 
            this.About_Panel.BackColor = System.Drawing.Color.White;
            this.About_Panel.Controls.Add(this.About_Label_License);
            this.About_Panel.Controls.Add(this.About_Label_Version);
            this.About_Panel.Controls.Add(this.About_Label_Title);
            this.About_Panel.Location = new System.Drawing.Point(1370, 194);
            this.About_Panel.Name = "About_Panel";
            this.About_Panel.Size = new System.Drawing.Size(172, 125);
            this.About_Panel.TabIndex = 25;
            this.About_Panel.Visible = false;
            // 
            // About_Label_License
            // 
            this.About_Label_License.AutoSize = true;
            this.About_Label_License.BackColor = System.Drawing.Color.Transparent;
            this.About_Label_License.Font = new System.Drawing.Font("Calibri", 10F);
            this.About_Label_License.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.About_Label_License.Location = new System.Drawing.Point(10, 96);
            this.About_Label_License.Name = "About_Label_License";
            this.About_Label_License.Size = new System.Drawing.Size(99, 17);
            this.About_Label_License.TabIndex = 3;
            this.About_Label_License.Text = "License: GPL 2.0";
            // 
            // About_Label_Version
            // 
            this.About_Label_Version.AutoSize = true;
            this.About_Label_Version.BackColor = System.Drawing.Color.Transparent;
            this.About_Label_Version.Font = new System.Drawing.Font("Calibri", 10F);
            this.About_Label_Version.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.About_Label_Version.Location = new System.Drawing.Point(10, 64);
            this.About_Label_Version.Name = "About_Label_Version";
            this.About_Label_Version.Size = new System.Drawing.Size(49, 17);
            this.About_Label_Version.TabIndex = 1;
            this.About_Label_Version.Text = "Version";
            // 
            // About_Label_Title
            // 
            this.About_Label_Title.AutoSize = true;
            this.About_Label_Title.BackColor = System.Drawing.Color.Transparent;
            this.About_Label_Title.Font = new System.Drawing.Font("Calibri Light", 20F);
            this.About_Label_Title.ForeColor = System.Drawing.Color.Black;
            this.About_Label_Title.Location = new System.Drawing.Point(7, 20);
            this.About_Label_Title.Name = "About_Label_Title";
            this.About_Label_Title.Size = new System.Drawing.Size(160, 33);
            this.About_Label_Title.TabIndex = 0;
            this.About_Label_Title.Text = "Darcy Backup";
            // 
            // Theme_Panel
            // 
            this.Theme_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Theme_Panel.Controls.Add(this.Theme_Img_Blue);
            this.Theme_Panel.Controls.Add(this.Theme_Img_Red);
            this.Theme_Panel.Controls.Add(this.Theme_Img_Gray);
            this.Theme_Panel.Controls.Add(this.Theme_Label_Gray);
            this.Theme_Panel.Controls.Add(this.Theme_Label_Blue);
            this.Theme_Panel.Controls.Add(this.Theme_Label_Red);
            this.Theme_Panel.Location = new System.Drawing.Point(1370, 27);
            this.Theme_Panel.Name = "Theme_Panel";
            this.Theme_Panel.Size = new System.Drawing.Size(96, 102);
            this.Theme_Panel.TabIndex = 26;
            this.Theme_Panel.Visible = false;
            // 
            // Theme_Img_Blue
            // 
            this.Theme_Img_Blue.Image = global::Darcy_Backup.Properties.Resources.Check1;
            this.Theme_Img_Blue.Location = new System.Drawing.Point(1, 74);
            this.Theme_Img_Blue.Name = "Theme_Img_Blue";
            this.Theme_Img_Blue.Size = new System.Drawing.Size(26, 14);
            this.Theme_Img_Blue.TabIndex = 38;
            this.Theme_Img_Blue.Click += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Img_Blue.DoubleClick += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Img_Blue.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Theme_Img_Blue.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Theme_Img_Red
            // 
            this.Theme_Img_Red.Image = global::Darcy_Backup.Properties.Resources.Check1;
            this.Theme_Img_Red.Location = new System.Drawing.Point(1, 48);
            this.Theme_Img_Red.Name = "Theme_Img_Red";
            this.Theme_Img_Red.Size = new System.Drawing.Size(26, 14);
            this.Theme_Img_Red.TabIndex = 37;
            this.Theme_Img_Red.Click += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Img_Red.DoubleClick += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Img_Red.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Theme_Img_Red.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Theme_Img_Gray
            // 
            this.Theme_Img_Gray.Image = global::Darcy_Backup.Properties.Resources.Check1;
            this.Theme_Img_Gray.Location = new System.Drawing.Point(1, 22);
            this.Theme_Img_Gray.Name = "Theme_Img_Gray";
            this.Theme_Img_Gray.Size = new System.Drawing.Size(26, 14);
            this.Theme_Img_Gray.TabIndex = 36;
            this.Theme_Img_Gray.Click += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Img_Gray.DoubleClick += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Img_Gray.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Theme_Img_Gray.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Theme_Label_Gray
            // 
            this.Theme_Label_Gray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Theme_Label_Gray.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Theme_Label_Gray.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Theme_Label_Gray.Location = new System.Drawing.Point(27, 20);
            this.Theme_Label_Gray.Name = "Theme_Label_Gray";
            this.Theme_Label_Gray.Size = new System.Drawing.Size(61, 23);
            this.Theme_Label_Gray.TabIndex = 0;
            this.Theme_Label_Gray.Text = "Gray";
            this.Theme_Label_Gray.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Theme_Label_Gray.Click += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Label_Gray.DoubleClick += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Label_Gray.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Theme_Label_Gray.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Theme_Label_Blue
            // 
            this.Theme_Label_Blue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Theme_Label_Blue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Theme_Label_Blue.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Theme_Label_Blue.Location = new System.Drawing.Point(27, 72);
            this.Theme_Label_Blue.Name = "Theme_Label_Blue";
            this.Theme_Label_Blue.Size = new System.Drawing.Size(61, 23);
            this.Theme_Label_Blue.TabIndex = 2;
            this.Theme_Label_Blue.Text = "Blue";
            this.Theme_Label_Blue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Theme_Label_Blue.Click += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Label_Blue.DoubleClick += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Label_Blue.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Theme_Label_Blue.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Theme_Label_Red
            // 
            this.Theme_Label_Red.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Theme_Label_Red.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Theme_Label_Red.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Theme_Label_Red.Location = new System.Drawing.Point(27, 46);
            this.Theme_Label_Red.Name = "Theme_Label_Red";
            this.Theme_Label_Red.Size = new System.Drawing.Size(61, 23);
            this.Theme_Label_Red.TabIndex = 1;
            this.Theme_Label_Red.Text = "Red";
            this.Theme_Label_Red.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Theme_Label_Red.Click += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Label_Red.DoubleClick += new System.EventHandler(this.Theme_Label_Click);
            this.Theme_Label_Red.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Theme_Label_Red.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Language_Panel
            // 
            this.Language_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Language_Panel.Controls.Add(this.Language_Img_Finnish);
            this.Language_Panel.Controls.Add(this.Language_Img_Swedish);
            this.Language_Panel.Controls.Add(this.Language_Img_English);
            this.Language_Panel.Controls.Add(this.Language_Label_English);
            this.Language_Panel.Controls.Add(this.Language_Label_Finnish);
            this.Language_Panel.Controls.Add(this.Language_Label_Swedish);
            this.Language_Panel.Location = new System.Drawing.Point(1434, 369);
            this.Language_Panel.Name = "Language_Panel";
            this.Language_Panel.Size = new System.Drawing.Size(96, 102);
            this.Language_Panel.TabIndex = 25;
            this.Language_Panel.Visible = false;
            // 
            // Language_Img_Finnish
            // 
            this.Language_Img_Finnish.Image = global::Darcy_Backup.Properties.Resources.Check1;
            this.Language_Img_Finnish.Location = new System.Drawing.Point(1, 74);
            this.Language_Img_Finnish.Name = "Language_Img_Finnish";
            this.Language_Img_Finnish.Size = new System.Drawing.Size(26, 14);
            this.Language_Img_Finnish.TabIndex = 41;
            this.Language_Img_Finnish.Click += new System.EventHandler(this.Language_Label_Click);
            this.Language_Img_Finnish.DoubleClick += new System.EventHandler(this.Language_Label_Click);
            this.Language_Img_Finnish.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Language_Img_Finnish.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Language_Img_Swedish
            // 
            this.Language_Img_Swedish.Image = global::Darcy_Backup.Properties.Resources.Check1;
            this.Language_Img_Swedish.Location = new System.Drawing.Point(1, 48);
            this.Language_Img_Swedish.Name = "Language_Img_Swedish";
            this.Language_Img_Swedish.Size = new System.Drawing.Size(26, 14);
            this.Language_Img_Swedish.TabIndex = 40;
            this.Language_Img_Swedish.Click += new System.EventHandler(this.Language_Label_Click);
            this.Language_Img_Swedish.DoubleClick += new System.EventHandler(this.Language_Label_Click);
            this.Language_Img_Swedish.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Language_Img_Swedish.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Language_Img_English
            // 
            this.Language_Img_English.Image = global::Darcy_Backup.Properties.Resources.Check1;
            this.Language_Img_English.Location = new System.Drawing.Point(1, 22);
            this.Language_Img_English.Name = "Language_Img_English";
            this.Language_Img_English.Size = new System.Drawing.Size(26, 14);
            this.Language_Img_English.TabIndex = 39;
            this.Language_Img_English.Click += new System.EventHandler(this.Language_Label_Click);
            this.Language_Img_English.DoubleClick += new System.EventHandler(this.Language_Label_Click);
            this.Language_Img_English.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Language_Img_English.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Language_Label_English
            // 
            this.Language_Label_English.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Language_Label_English.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Language_Label_English.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Language_Label_English.Location = new System.Drawing.Point(27, 20);
            this.Language_Label_English.Name = "Language_Label_English";
            this.Language_Label_English.Size = new System.Drawing.Size(61, 23);
            this.Language_Label_English.TabIndex = 0;
            this.Language_Label_English.Text = "English";
            this.Language_Label_English.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Language_Label_English.Click += new System.EventHandler(this.Language_Label_Click);
            this.Language_Label_English.DoubleClick += new System.EventHandler(this.Language_Label_Click);
            this.Language_Label_English.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Language_Label_English.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Language_Label_Finnish
            // 
            this.Language_Label_Finnish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Language_Label_Finnish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Language_Label_Finnish.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Language_Label_Finnish.Location = new System.Drawing.Point(27, 72);
            this.Language_Label_Finnish.Name = "Language_Label_Finnish";
            this.Language_Label_Finnish.Size = new System.Drawing.Size(61, 23);
            this.Language_Label_Finnish.TabIndex = 2;
            this.Language_Label_Finnish.Text = "Finnish";
            this.Language_Label_Finnish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Language_Label_Finnish.Click += new System.EventHandler(this.Language_Label_Click);
            this.Language_Label_Finnish.DoubleClick += new System.EventHandler(this.Language_Label_Click);
            this.Language_Label_Finnish.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Language_Label_Finnish.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Language_Label_Swedish
            // 
            this.Language_Label_Swedish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Language_Label_Swedish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Language_Label_Swedish.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Language_Label_Swedish.Location = new System.Drawing.Point(27, 46);
            this.Language_Label_Swedish.Name = "Language_Label_Swedish";
            this.Language_Label_Swedish.Size = new System.Drawing.Size(61, 23);
            this.Language_Label_Swedish.TabIndex = 1;
            this.Language_Label_Swedish.Text = "Swedish";
            this.Language_Label_Swedish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Language_Label_Swedish.Click += new System.EventHandler(this.Language_Label_Click);
            this.Language_Label_Swedish.DoubleClick += new System.EventHandler(this.Language_Label_Click);
            this.Language_Label_Swedish.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Language_Label_Swedish.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Panel
            // 
            this.Settings_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Settings_Panel.Controls.Add(this.Settings_Img_Updates);
            this.Settings_Panel.Controls.Add(this.Settings_Img_Minimized);
            this.Settings_Panel.Controls.Add(this.Settings_Img_Tray);
            this.Settings_Panel.Controls.Add(this.Settings_Label_Updates);
            this.Settings_Panel.Controls.Add(this.Settings_Img_Autorun);
            this.Settings_Panel.Controls.Add(this.Settings_Label_Minimized);
            this.Settings_Panel.Controls.Add(this.Settings_Label_Tray);
            this.Settings_Panel.Controls.Add(this.Settings_Label_Autorun);
            this.Settings_Panel.Location = new System.Drawing.Point(1213, 12);
            this.Settings_Panel.Name = "Settings_Panel";
            this.Settings_Panel.Size = new System.Drawing.Size(151, 128);
            this.Settings_Panel.TabIndex = 23;
            this.Settings_Panel.Visible = false;
            // 
            // Settings_Img_Updates
            // 
            this.Settings_Img_Updates.Image = global::Darcy_Backup.Properties.Resources.Check1;
            this.Settings_Img_Updates.Location = new System.Drawing.Point(1, 100);
            this.Settings_Img_Updates.Name = "Settings_Img_Updates";
            this.Settings_Img_Updates.Size = new System.Drawing.Size(26, 14);
            this.Settings_Img_Updates.TabIndex = 35;
            this.Settings_Img_Updates.Click += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Img_Updates.DoubleClick += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Img_Updates.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Img_Updates.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Img_Minimized
            // 
            this.Settings_Img_Minimized.Image = global::Darcy_Backup.Properties.Resources.Check1;
            this.Settings_Img_Minimized.Location = new System.Drawing.Point(1, 74);
            this.Settings_Img_Minimized.Name = "Settings_Img_Minimized";
            this.Settings_Img_Minimized.Size = new System.Drawing.Size(26, 14);
            this.Settings_Img_Minimized.TabIndex = 34;
            this.Settings_Img_Minimized.Click += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Img_Minimized.DoubleClick += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Img_Minimized.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Img_Minimized.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Img_Tray
            // 
            this.Settings_Img_Tray.Image = global::Darcy_Backup.Properties.Resources.Check1;
            this.Settings_Img_Tray.Location = new System.Drawing.Point(1, 48);
            this.Settings_Img_Tray.Name = "Settings_Img_Tray";
            this.Settings_Img_Tray.Size = new System.Drawing.Size(26, 14);
            this.Settings_Img_Tray.TabIndex = 33;
            this.Settings_Img_Tray.Click += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Img_Tray.DoubleClick += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Img_Tray.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Img_Tray.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Label_Updates
            // 
            this.Settings_Label_Updates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Label_Updates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Settings_Label_Updates.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Settings_Label_Updates.Location = new System.Drawing.Point(27, 98);
            this.Settings_Label_Updates.Name = "Settings_Label_Updates";
            this.Settings_Label_Updates.Size = new System.Drawing.Size(121, 23);
            this.Settings_Label_Updates.TabIndex = 6;
            this.Settings_Label_Updates.Text = "Check for updates";
            this.Settings_Label_Updates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Settings_Label_Updates.Click += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Label_Updates.DoubleClick += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Label_Updates.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Label_Updates.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Label_Minimized
            // 
            this.Settings_Label_Minimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Label_Minimized.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Settings_Label_Minimized.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Settings_Label_Minimized.Location = new System.Drawing.Point(27, 72);
            this.Settings_Label_Minimized.Name = "Settings_Label_Minimized";
            this.Settings_Label_Minimized.Size = new System.Drawing.Size(121, 23);
            this.Settings_Label_Minimized.TabIndex = 5;
            this.Settings_Label_Minimized.Text = "Start minimized";
            this.Settings_Label_Minimized.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Settings_Label_Minimized.Click += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Label_Minimized.DoubleClick += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Label_Minimized.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Label_Minimized.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Label_Tray
            // 
            this.Settings_Label_Tray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Label_Tray.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Settings_Label_Tray.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Settings_Label_Tray.Location = new System.Drawing.Point(27, 46);
            this.Settings_Label_Tray.Name = "Settings_Label_Tray";
            this.Settings_Label_Tray.Size = new System.Drawing.Size(121, 23);
            this.Settings_Label_Tray.TabIndex = 4;
            this.Settings_Label_Tray.Text = "Minimize to tray";
            this.Settings_Label_Tray.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Settings_Label_Tray.Click += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Label_Tray.DoubleClick += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Label_Tray.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Label_Tray.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Settings_Label_Autorun
            // 
            this.Settings_Label_Autorun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Label_Autorun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Settings_Label_Autorun.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.Settings_Label_Autorun.Location = new System.Drawing.Point(27, 20);
            this.Settings_Label_Autorun.Name = "Settings_Label_Autorun";
            this.Settings_Label_Autorun.Size = new System.Drawing.Size(121, 23);
            this.Settings_Label_Autorun.TabIndex = 3;
            this.Settings_Label_Autorun.Text = "Autorun";
            this.Settings_Label_Autorun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Settings_Label_Autorun.Click += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Label_Autorun.DoubleClick += new System.EventHandler(this.Settings_Label_Click);
            this.Settings_Label_Autorun.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Settings_Label_Autorun.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            // 
            // Darcy_Top_Panel
            // 
            this.Darcy_Top_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Darcy_Top_Panel.Controls.Add(this.Label_Themes);
            this.Darcy_Top_Panel.Controls.Add(this.Label_Language);
            this.Darcy_Top_Panel.Controls.Add(this.Label_Settings);
            this.Darcy_Top_Panel.Controls.Add(this.Label_About);
            this.Darcy_Top_Panel.Location = new System.Drawing.Point(29, 30);
            this.Darcy_Top_Panel.Name = "Darcy_Top_Panel";
            this.Darcy_Top_Panel.Size = new System.Drawing.Size(366, 32);
            this.Darcy_Top_Panel.TabIndex = 30;
            // 
            // Label_Themes
            // 
            this.Label_Themes.BackColor = System.Drawing.Color.Transparent;
            this.Label_Themes.Font = new System.Drawing.Font("Calibri", 11F);
            this.Label_Themes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Label_Themes.Location = new System.Drawing.Point(204, 0);
            this.Label_Themes.Name = "Label_Themes";
            this.Label_Themes.Size = new System.Drawing.Size(57, 32);
            this.Label_Themes.TabIndex = 24;
            this.Label_Themes.Text = "Themes";
            this.Label_Themes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Themes.Click += new System.EventHandler(this.Label_Settings_Click);
            this.Label_Themes.DoubleClick += new System.EventHandler(this.Label_Settings_Click);
            this.Label_Themes.Leave += new System.EventHandler(this.Label_Settings_Focus_Leave);
            this.Label_Themes.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Label_Themes.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            this.Label_Themes.MouseHover += new System.EventHandler(this.Label_Settings_MouseHover);
            // 
            // Label_Language
            // 
            this.Label_Language.BackColor = System.Drawing.Color.Transparent;
            this.Label_Language.Font = new System.Drawing.Font("Calibri", 11F);
            this.Label_Language.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Label_Language.Location = new System.Drawing.Point(90, 0);
            this.Label_Language.Name = "Label_Language";
            this.Label_Language.Size = new System.Drawing.Size(72, 32);
            this.Label_Language.TabIndex = 23;
            this.Label_Language.Text = "Languages";
            this.Label_Language.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Language.Click += new System.EventHandler(this.Label_Settings_Click);
            this.Label_Language.DoubleClick += new System.EventHandler(this.Label_Settings_Click);
            this.Label_Language.Leave += new System.EventHandler(this.Label_Settings_Focus_Leave);
            this.Label_Language.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Label_Language.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            this.Label_Language.MouseHover += new System.EventHandler(this.Label_Settings_MouseHover);
            // 
            // Label_Settings
            // 
            this.Label_Settings.BackColor = System.Drawing.Color.Transparent;
            this.Label_Settings.Font = new System.Drawing.Font("Calibri", 11F);
            this.Label_Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Label_Settings.Location = new System.Drawing.Point(5, 0);
            this.Label_Settings.Name = "Label_Settings";
            this.Label_Settings.Size = new System.Drawing.Size(57, 32);
            this.Label_Settings.TabIndex = 21;
            this.Label_Settings.Text = "Settings";
            this.Label_Settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Settings.Click += new System.EventHandler(this.Label_Settings_Click);
            this.Label_Settings.DoubleClick += new System.EventHandler(this.Label_Settings_Click);
            this.Label_Settings.Leave += new System.EventHandler(this.Label_Settings_Focus_Leave);
            this.Label_Settings.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Label_Settings.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            this.Label_Settings.MouseHover += new System.EventHandler(this.Label_Settings_MouseHover);
            // 
            // Label_About
            // 
            this.Label_About.BackColor = System.Drawing.Color.Transparent;
            this.Label_About.Font = new System.Drawing.Font("Calibri", 11F);
            this.Label_About.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Label_About.Location = new System.Drawing.Point(306, 0);
            this.Label_About.Name = "Label_About";
            this.Label_About.Size = new System.Drawing.Size(46, 32);
            this.Label_About.TabIndex = 22;
            this.Label_About.Text = "About";
            this.Label_About.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_About.Click += new System.EventHandler(this.Label_Settings_Click);
            this.Label_About.DoubleClick += new System.EventHandler(this.Label_Settings_Click);
            this.Label_About.Leave += new System.EventHandler(this.Label_Settings_Focus_Leave);
            this.Label_About.MouseEnter += new System.EventHandler(this.MouseEnter_BlackFont);
            this.Label_About.MouseLeave += new System.EventHandler(this.MouseLeave_Regular);
            this.Label_About.MouseHover += new System.EventHandler(this.Label_Settings_MouseHover);
            // 
            // Label_Toggle
            // 
            this.Label_Toggle.BackColor = System.Drawing.Color.Transparent;
            this.Label_Toggle.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.Label_Toggle.Location = new System.Drawing.Point(779, 517);
            this.Label_Toggle.Name = "Label_Toggle";
            this.Label_Toggle.Size = new System.Drawing.Size(123, 23);
            this.Label_Toggle.TabIndex = 29;
            this.Label_Toggle.Text = "Toggle Automated:";
            this.Label_Toggle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Label_Toggle.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_Toggle.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Label_Backup
            // 
            this.Label_Backup.AutoSize = true;
            this.Label_Backup.Font = new System.Drawing.Font("Calibri Light", 20F);
            this.Label_Backup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Backup.Location = new System.Drawing.Point(442, 96);
            this.Label_Backup.Name = "Label_Backup";
            this.Label_Backup.Size = new System.Drawing.Size(135, 33);
            this.Label_Backup.TabIndex = 13;
            this.Label_Backup.Text = "Backup List";
            this.Label_Backup.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_Backup.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // List_Backup
            // 
            this.List_Backup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.List_Backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List_Backup.ForeColor = System.Drawing.Color.Black;
            this.List_Backup.Location = new System.Drawing.Point(450, 150);
            this.List_Backup.MultiSelect = false;
            this.List_Backup.Name = "List_Backup";
            this.List_Backup.Size = new System.Drawing.Size(778, 343);
            this.List_Backup.TabIndex = 10;
            this.List_Backup.UseCompatibleStateImageBehavior = false;
            this.List_Backup.SelectedIndexChanged += new System.EventHandler(this.List_Backup_Selection_Changed);
            this.List_Backup.DoubleClick += new System.EventHandler(this.List_Backup_DoubleClick);
            // 
            // Button_Perform
            // 
            this.Button_Perform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Button_Perform.DarcyDisabled = false;
            this.Button_Perform.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(144)))));
            this.Button_Perform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Perform.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.Button_Perform.Location = new System.Drawing.Point(1163, 516);
            this.Button_Perform.Name = "Button_Perform";
            this.Button_Perform.Size = new System.Drawing.Size(65, 25);
            this.Button_Perform.TabIndex = 9;
            this.Button_Perform.Text = "Perform";
            this.Button_Perform.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Perform.UseVisualStyleBackColor = false;
            this.Button_Perform.Click += new System.EventHandler(this.Button_Perform_Click);
            // 
            // Panel_Selected_Log
            // 
            this.Panel_Selected_Log.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Selected_Log.Controls.Add(this.Label_Hash);
            this.Panel_Selected_Log.Controls.Add(this.Dynamic_Hash);
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
            this.Panel_Selected_Log.Location = new System.Drawing.Point(0, 73);
            this.Panel_Selected_Log.Name = "Panel_Selected_Log";
            this.Panel_Selected_Log.Size = new System.Drawing.Size(436, 616);
            this.Panel_Selected_Log.TabIndex = 26;
            this.Panel_Selected_Log.Click += new System.EventHandler(this.Panel_Selected_Log_Click);
            this.Panel_Selected_Log.DoubleClick += new System.EventHandler(this.Panel_Selected_Log_Click);
            // 
            // Label_Hash
            // 
            this.Label_Hash.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Hash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Hash.Location = new System.Drawing.Point(26, 288);
            this.Label_Hash.Name = "Label_Hash";
            this.Label_Hash.Size = new System.Drawing.Size(97, 19);
            this.Label_Hash.TabIndex = 24;
            this.Label_Hash.Text = "Compare Hash:";
            this.Label_Hash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Hash.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_Hash.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Dynamic_Hash
            // 
            this.Dynamic_Hash.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Hash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Dynamic_Hash.Location = new System.Drawing.Point(129, 288);
            this.Dynamic_Hash.Name = "Dynamic_Hash";
            this.Dynamic_Hash.Size = new System.Drawing.Size(270, 19);
            this.Dynamic_Hash.TabIndex = 23;
            this.Dynamic_Hash.Text = "dyn hash";
            this.Dynamic_Hash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Dynamic_Hash.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Dynamic_Hash.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Dynamic_Mode
            // 
            this.Dynamic_Mode.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Dynamic_Mode.Location = new System.Drawing.Point(129, 137);
            this.Dynamic_Mode.Name = "Dynamic_Mode";
            this.Dynamic_Mode.Size = new System.Drawing.Size(270, 19);
            this.Dynamic_Mode.TabIndex = 22;
            this.Dynamic_Mode.Text = "dyn mode";
            this.Dynamic_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Dynamic_Mode.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Dynamic_Mode.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Label_Mode
            // 
            this.Label_Mode.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Mode.Location = new System.Drawing.Point(26, 137);
            this.Label_Mode.Name = "Label_Mode";
            this.Label_Mode.Size = new System.Drawing.Size(97, 19);
            this.Label_Mode.TabIndex = 21;
            this.Label_Mode.Text = "Mode:";
            this.Label_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Mode.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_Mode.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Dynamic_Process_Specific2
            // 
            this.Dynamic_Process_Specific2.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Process_Specific2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Dynamic_Process_Specific2.Location = new System.Drawing.Point(129, 227);
            this.Dynamic_Process_Specific2.Name = "Dynamic_Process_Specific2";
            this.Dynamic_Process_Specific2.Size = new System.Drawing.Size(270, 19);
            this.Dynamic_Process_Specific2.TabIndex = 20;
            this.Dynamic_Process_Specific2.Text = "dyn process";
            this.Dynamic_Process_Specific2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Dynamic_Process_Specific2.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Dynamic_Process_Specific2.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Label_Process_Specific2
            // 
            this.Label_Process_Specific2.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Process_Specific2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Process_Specific2.Location = new System.Drawing.Point(26, 227);
            this.Label_Process_Specific2.Name = "Label_Process_Specific2";
            this.Label_Process_Specific2.Size = new System.Drawing.Size(97, 19);
            this.Label_Process_Specific2.TabIndex = 19;
            this.Label_Process_Specific2.Text = "Process:";
            this.Label_Process_Specific2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Process_Specific2.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_Process_Specific2.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Dynamic_Process_Specific1
            // 
            this.Dynamic_Process_Specific1.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Process_Specific1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Dynamic_Process_Specific1.Location = new System.Drawing.Point(129, 197);
            this.Dynamic_Process_Specific1.Name = "Dynamic_Process_Specific1";
            this.Dynamic_Process_Specific1.Size = new System.Drawing.Size(270, 19);
            this.Dynamic_Process_Specific1.TabIndex = 18;
            this.Dynamic_Process_Specific1.Text = "dyn process";
            this.Dynamic_Process_Specific1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Dynamic_Process_Specific1.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Dynamic_Process_Specific1.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Label_Process_Specific1
            // 
            this.Label_Process_Specific1.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Process_Specific1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Process_Specific1.Location = new System.Drawing.Point(26, 197);
            this.Label_Process_Specific1.Name = "Label_Process_Specific1";
            this.Label_Process_Specific1.Size = new System.Drawing.Size(97, 19);
            this.Label_Process_Specific1.TabIndex = 17;
            this.Label_Process_Specific1.Text = "Process:";
            this.Label_Process_Specific1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Process_Specific1.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_Process_Specific1.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Dynamic_Automated
            // 
            this.Dynamic_Automated.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Automated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Dynamic_Automated.Location = new System.Drawing.Point(129, 257);
            this.Dynamic_Automated.Name = "Dynamic_Automated";
            this.Dynamic_Automated.Size = new System.Drawing.Size(270, 19);
            this.Dynamic_Automated.TabIndex = 16;
            this.Dynamic_Automated.Text = "dyn automated";
            this.Dynamic_Automated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Dynamic_Automated.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Dynamic_Automated.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Dynamic_Process
            // 
            this.Dynamic_Process.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Process.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Dynamic_Process.Location = new System.Drawing.Point(129, 167);
            this.Dynamic_Process.Name = "Dynamic_Process";
            this.Dynamic_Process.Size = new System.Drawing.Size(270, 19);
            this.Dynamic_Process.TabIndex = 15;
            this.Dynamic_Process.Text = "dyn process";
            this.Dynamic_Process.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Dynamic_Process.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Dynamic_Process.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Dynamic_Destination
            // 
            this.Dynamic_Destination.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Destination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Dynamic_Destination.Location = new System.Drawing.Point(129, 107);
            this.Dynamic_Destination.Name = "Dynamic_Destination";
            this.Dynamic_Destination.Size = new System.Drawing.Size(270, 19);
            this.Dynamic_Destination.TabIndex = 13;
            this.Dynamic_Destination.Text = "dyn dest";
            this.Dynamic_Destination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Dynamic_Destination.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Dynamic_Destination.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Dynamic_Source
            // 
            this.Dynamic_Source.Font = new System.Drawing.Font("Calibri", 10F);
            this.Dynamic_Source.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Dynamic_Source.Location = new System.Drawing.Point(129, 77);
            this.Dynamic_Source.Name = "Dynamic_Source";
            this.Dynamic_Source.Size = new System.Drawing.Size(270, 19);
            this.Dynamic_Source.TabIndex = 12;
            this.Dynamic_Source.Text = "dyn source";
            this.Dynamic_Source.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Dynamic_Source.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Dynamic_Source.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Label_Automated
            // 
            this.Label_Automated.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Automated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Automated.Location = new System.Drawing.Point(26, 257);
            this.Label_Automated.Name = "Label_Automated";
            this.Label_Automated.Size = new System.Drawing.Size(97, 19);
            this.Label_Automated.TabIndex = 9;
            this.Label_Automated.Text = "Automated:";
            this.Label_Automated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Automated.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_Automated.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Label_Process
            // 
            this.Label_Process.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Process.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Process.Location = new System.Drawing.Point(26, 167);
            this.Label_Process.Name = "Label_Process";
            this.Label_Process.Size = new System.Drawing.Size(97, 19);
            this.Label_Process.TabIndex = 8;
            this.Label_Process.Text = "Process:";
            this.Label_Process.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Process.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_Process.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Label_Destination
            // 
            this.Label_Destination.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Destination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Destination.Location = new System.Drawing.Point(26, 107);
            this.Label_Destination.Name = "Label_Destination";
            this.Label_Destination.Size = new System.Drawing.Size(97, 19);
            this.Label_Destination.TabIndex = 6;
            this.Label_Destination.Text = "Destination:";
            this.Label_Destination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Destination.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_Destination.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Label_Source
            // 
            this.Label_Source.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Source.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Source.Location = new System.Drawing.Point(26, 77);
            this.Label_Source.Name = "Label_Source";
            this.Label_Source.Size = new System.Drawing.Size(97, 19);
            this.Label_Source.TabIndex = 5;
            this.Label_Source.Text = "Source:";
            this.Label_Source.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_Source.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_Source.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // List_Log
            // 
            this.List_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.List_Log.Font = new System.Drawing.Font("Calibri", 11F);
            this.List_Log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.List_Log.Location = new System.Drawing.Point(22, 367);
            this.List_Log.MultiSelect = false;
            this.List_Log.Name = "List_Log";
            this.List_Log.Size = new System.Drawing.Size(416, 243);
            this.List_Log.TabIndex = 2;
            this.List_Log.UseCompatibleStateImageBehavior = false;
            this.List_Log.DoubleClick += new System.EventHandler(this.List_Log_DoubleClick);
            // 
            // Label_HeaderLog
            // 
            this.Label_HeaderLog.Font = new System.Drawing.Font("Calibri Light", 20F);
            this.Label_HeaderLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_HeaderLog.Location = new System.Drawing.Point(21, 317);
            this.Label_HeaderLog.Name = "Label_HeaderLog";
            this.Label_HeaderLog.Size = new System.Drawing.Size(204, 33);
            this.Label_HeaderLog.TabIndex = 1;
            this.Label_HeaderLog.Text = "Log";
            this.Label_HeaderLog.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_HeaderLog.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Label_HeaderSelected
            // 
            this.Label_HeaderSelected.BackColor = System.Drawing.Color.Transparent;
            this.Label_HeaderSelected.Font = new System.Drawing.Font("Calibri Light", 20F);
            this.Label_HeaderSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_HeaderSelected.Location = new System.Drawing.Point(21, 21);
            this.Label_HeaderSelected.Name = "Label_HeaderSelected";
            this.Label_HeaderSelected.Size = new System.Drawing.Size(204, 33);
            this.Label_HeaderSelected.TabIndex = 0;
            this.Label_HeaderSelected.Text = "Selected Entry";
            this.Label_HeaderSelected.Click += new System.EventHandler(this.Label_Click_Focus);
            this.Label_HeaderSelected.DoubleClick += new System.EventHandler(this.Label_Click_Focus);
            // 
            // Form_Darcy_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1574, 701);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.About_Panel);
            this.Controls.Add(this.Theme_Panel);
            this.Controls.Add(this.Language_Panel);
            this.Controls.Add(this.Settings_Panel);
            this.Controls.Add(this.Darcy_Top_Panel);
            this.Controls.Add(this.Label_Toggle);
            this.Controls.Add(this.Button_New);
            this.Controls.Add(this.Button_Edit);
            this.Controls.Add(this.Label_Backup);
            this.Controls.Add(this.Button_Activate);
            this.Controls.Add(this.Button_Delete);
            this.Controls.Add(this.List_Backup);
            this.Controls.Add(this.Button_Perform);
            this.Controls.Add(this.Panel_Selected_Log);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1180, 740);
            this.Name = "Form_Darcy_Panel";
            this.Text = "Darcy Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DarcyFormClosing);
            this.ResizeEnd += new System.EventHandler(this.Form_Darcy_ResizeEnd);
            this.Click += new System.EventHandler(this.Form_Darcy_Panel_Click);
            this.DoubleClick += new System.EventHandler(this.Form_Darcy_Panel_Click);
            this.Resize += new System.EventHandler(this.Form_Darcy_Resize);
            this.About_Panel.ResumeLayout(false);
            this.About_Panel.PerformLayout();
            this.Theme_Panel.ResumeLayout(false);
            this.Language_Panel.ResumeLayout(false);
            this.Settings_Panel.ResumeLayout(false);
            this.Darcy_Top_Panel.ResumeLayout(false);
            this.Panel_Selected_Log.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarcyButton Button_Perform;
        private DarcyListView List_Backup;
        private System.Windows.Forms.Button Button_Delete;
        private System.Windows.Forms.Button Button_Activate;
        private DarcyLabel Label_Backup;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private DarcyLabel Label_Settings;
        private DarcyLabel Label_About;
        private DarcySettingsPanel Settings_Panel;
        private DarcyLabel Language_Label_Swedish;
        private DarcyLabel Language_Label_English;
        private DarcyLabel Language_Label_Finnish;
        private DarcySettingsPanel About_Panel;
        private DarcyLabel About_Label_Version;
        private DarcyLabel About_Label_Title;
        private DarcyLabel About_Label_License;
        private DarcySelectedLogPanel Panel_Selected_Log;
        private System.Windows.Forms.Button Button_Edit;
        private System.Windows.Forms.Button Button_New;
        private DarcyLabel Label_Toggle;
        private DarcyLabel Label_HeaderSelected;
        private System.Windows.Forms.ListView List_Log;
        private DarcyLabel Label_HeaderLog;
        private DarcyLabel Label_Automated;
        private DarcyLabel Label_Process;
        private DarcyLabel Dynamic_Automated;
        private DarcyLabel Dynamic_Process;
        private DarcyLabel Dynamic_Process_Specific1;
        private DarcyLabel Label_Process_Specific1;
        private DarcyLabel Dynamic_Process_Specific2;
        private DarcyLabel Label_Process_Specific2;
        private DarcyLabel Dynamic_Mode;
        private DarcyLabel Label_Mode;
        private DarcyLabel Dynamic_Destination;
        private DarcyLabel Dynamic_Source;
        private DarcyLabel Label_Destination;
        private DarcyLabel Label_Source;
        private System.Windows.Forms.ToolTip toolTip1;
        private DarcyTopPanel Darcy_Top_Panel;
        private DarcyLabel Label_Themes;
        private DarcyLabel Label_Language;
        private DarcySettingsPanel Language_Panel;
        private DarcySettingsPanel Theme_Panel;
        private DarcyLabel Theme_Label_Gray;
        private DarcyLabel Theme_Label_Blue;
        private DarcyLabel Theme_Label_Red;
        private DarcyLabel Settings_Label_Minimized;
        private DarcyLabel Settings_Label_Tray;
        private DarcyLabel Settings_Label_Autorun;
        private DarcyLabel Settings_Label_Updates;
        private DarcyButton Button_Cancel;
        private DarcyLabel Dynamic_Hash;
        private DarcyLabel Label_Hash;
        private DarcyImgLabel Settings_Img_Autorun;
        private DarcyImgLabel Theme_Img_Blue;
        private DarcyImgLabel Theme_Img_Red;
        private DarcyImgLabel Theme_Img_Gray;
        private DarcyImgLabel Language_Img_Finnish;
        private DarcyImgLabel Language_Img_Swedish;
        private DarcyImgLabel Language_Img_English;
        private DarcyImgLabel Settings_Img_Updates;
        private DarcyImgLabel Settings_Img_Minimized;
        private DarcyImgLabel Settings_Img_Tray;
    }
}

