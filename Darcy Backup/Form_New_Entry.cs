using Ionic.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    public partial class Form_New_Entry : Form
    {
        private Label Label_Source;
        private TextBox Text_Source;
        private TextBox Text_Destination;
        private Label Label_Destination;
        private Label Label_Mode;
        private DarcyComboBox Combo_Mode;
        private RadioButton Radio_Schedule;
        private RadioButton Radio_Timer;
        private RadioButton Radio_Manual;
        private Label Label_Days;
        private Button Button_Day1;
        private Button Button_Day2;
        private Button Button_Day3;
        private Button Button_Day4;
        private Button Button_Day5;
        private Button Button_Day6;
        private Button Button_Day7;
        private Button Button_Day8;
        private Button Button_Day9;
        private Button Button_Day10;
        private Button Button_Day11;
        private Button Button_Day12;
        private Button Button_Day13;
        private Button Button_Day14;
        private Button Button_Day15;
        private Button Button_Day16;
        private Button Button_Day17;
        private Button Button_Day18;
        private Button Button_Day19;
        private Button Button_Day20;
        private Button Button_Day21;
        private Button Button_Day22;
        private Button Button_Day23;
        private Button Button_Day24;
        private Button Button_Day25;
        private Button Button_Day26;
        private Button Button_Day27;
        private Button Button_Day28;
        private Button Button_Day29;
        private Button Button_Day30;
        private Button Button_Day31;
        private Button Button_Discard;
        private Button Button_Save;
        private Button Button_PickSource;
        private Button Button_PickFolder;
        private Label Label_Time;
        private TextBox Text_TimeOfDay;
        private Label Label_Help_Text_Time;
        private Label Label_Help_Days;
        private Label Label_Help_Time;
        private Label Label_Help_Source;
        private Label Label_Help_Destination;
        private Label Label_Help_Text_Days;
        private Label Label_Help_Text_Source;
        private Label Label_Help_Text_Destination;
        private Label Label_Help_Mode;
        private Label Label_Help_Text_Mode;
        private Label Label_Error;
        private Button Button_DayAll;
        private Panel Panel_Schedule;
        private Panel Panel_Timer;
        private Label Label_BackupTimer;
        private Label Label_Help_Text_Timer;
        private TextBox Text_Timer;
        private Label Label_Help_Timer;
        private Panel Panel_Button_Panel;
        private Label Label_Entry;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_New_Entry));
            this.Label_Entry = new System.Windows.Forms.Label();
            this.Label_Source = new System.Windows.Forms.Label();
            this.Text_Source = new System.Windows.Forms.TextBox();
            this.Text_Destination = new System.Windows.Forms.TextBox();
            this.Label_Destination = new System.Windows.Forms.Label();
            this.Label_Mode = new System.Windows.Forms.Label();
            this.Radio_Schedule = new System.Windows.Forms.RadioButton();
            this.Radio_Timer = new System.Windows.Forms.RadioButton();
            this.Radio_Manual = new System.Windows.Forms.RadioButton();
            this.Label_Days = new System.Windows.Forms.Label();
            this.Button_Day1 = new System.Windows.Forms.Button();
            this.Button_Day2 = new System.Windows.Forms.Button();
            this.Button_Day3 = new System.Windows.Forms.Button();
            this.Button_Day4 = new System.Windows.Forms.Button();
            this.Button_Day5 = new System.Windows.Forms.Button();
            this.Button_Day6 = new System.Windows.Forms.Button();
            this.Button_Day7 = new System.Windows.Forms.Button();
            this.Button_Day8 = new System.Windows.Forms.Button();
            this.Button_Day9 = new System.Windows.Forms.Button();
            this.Button_Day10 = new System.Windows.Forms.Button();
            this.Button_Day11 = new System.Windows.Forms.Button();
            this.Button_Day12 = new System.Windows.Forms.Button();
            this.Button_Day13 = new System.Windows.Forms.Button();
            this.Button_Day14 = new System.Windows.Forms.Button();
            this.Button_Day15 = new System.Windows.Forms.Button();
            this.Button_Day16 = new System.Windows.Forms.Button();
            this.Button_Day17 = new System.Windows.Forms.Button();
            this.Button_Day18 = new System.Windows.Forms.Button();
            this.Button_Day19 = new System.Windows.Forms.Button();
            this.Button_Day20 = new System.Windows.Forms.Button();
            this.Button_Day21 = new System.Windows.Forms.Button();
            this.Button_Day22 = new System.Windows.Forms.Button();
            this.Button_Day23 = new System.Windows.Forms.Button();
            this.Button_Day24 = new System.Windows.Forms.Button();
            this.Button_Day25 = new System.Windows.Forms.Button();
            this.Button_Day26 = new System.Windows.Forms.Button();
            this.Button_Day27 = new System.Windows.Forms.Button();
            this.Button_Day28 = new System.Windows.Forms.Button();
            this.Button_Day29 = new System.Windows.Forms.Button();
            this.Button_Day30 = new System.Windows.Forms.Button();
            this.Button_Day31 = new System.Windows.Forms.Button();
            this.Button_Discard = new System.Windows.Forms.Button();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Button_PickSource = new System.Windows.Forms.Button();
            this.Button_PickFolder = new System.Windows.Forms.Button();
            this.Label_Time = new System.Windows.Forms.Label();
            this.Text_TimeOfDay = new System.Windows.Forms.TextBox();
            this.Label_Help_Text_Time = new System.Windows.Forms.Label();
            this.Label_Help_Days = new System.Windows.Forms.Label();
            this.Label_Help_Time = new System.Windows.Forms.Label();
            this.Label_Help_Source = new System.Windows.Forms.Label();
            this.Label_Help_Destination = new System.Windows.Forms.Label();
            this.Label_Help_Text_Days = new System.Windows.Forms.Label();
            this.Label_Help_Text_Source = new System.Windows.Forms.Label();
            this.Label_Help_Text_Destination = new System.Windows.Forms.Label();
            this.Label_Help_Mode = new System.Windows.Forms.Label();
            this.Label_Help_Text_Mode = new System.Windows.Forms.Label();
            this.Label_Error = new System.Windows.Forms.Label();
            this.Button_DayAll = new System.Windows.Forms.Button();
            this.Panel_Schedule = new System.Windows.Forms.Panel();
            this.Panel_Timer = new System.Windows.Forms.Panel();
            this.Label_BackupTimer = new System.Windows.Forms.Label();
            this.Label_Help_Text_Timer = new System.Windows.Forms.Label();
            this.Text_Timer = new System.Windows.Forms.TextBox();
            this.Label_Help_Timer = new System.Windows.Forms.Label();
            this.Panel_Button_Panel = new System.Windows.Forms.Panel();
            this.Combo_Mode = new Darcy_Backup.DarcyComboBox();
            this.Panel_Schedule.SuspendLayout();
            this.Panel_Timer.SuspendLayout();
            this.Panel_Button_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_Entry
            // 
            this.Label_Entry.BackColor = System.Drawing.Color.Transparent;
            this.Label_Entry.Font = new System.Drawing.Font("Calibri Light", 20F);
            this.Label_Entry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Entry.Location = new System.Drawing.Point(18, 18);
            this.Label_Entry.Name = "Label_Entry";
            this.Label_Entry.Size = new System.Drawing.Size(339, 35);
            this.Label_Entry.TabIndex = 0;
            this.Label_Entry.Text = "Entry 1";
            // 
            // Label_Source
            // 
            this.Label_Source.AutoSize = true;
            this.Label_Source.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Source.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Source.Location = new System.Drawing.Point(23, 78);
            this.Label_Source.Name = "Label_Source";
            this.Label_Source.Size = new System.Drawing.Size(46, 17);
            this.Label_Source.TabIndex = 1;
            this.Label_Source.Text = "Source";
            // 
            // Text_Source
            // 
            this.Text_Source.Location = new System.Drawing.Point(26, 99);
            this.Text_Source.Name = "Text_Source";
            this.Text_Source.Size = new System.Drawing.Size(289, 20);
            this.Text_Source.TabIndex = 0;
            // 
            // Text_Destination
            // 
            this.Text_Destination.Location = new System.Drawing.Point(26, 165);
            this.Text_Destination.Name = "Text_Destination";
            this.Text_Destination.Size = new System.Drawing.Size(289, 20);
            this.Text_Destination.TabIndex = 2;
            // 
            // Label_Destination
            // 
            this.Label_Destination.AutoSize = true;
            this.Label_Destination.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Destination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Destination.Location = new System.Drawing.Point(23, 144);
            this.Label_Destination.Name = "Label_Destination";
            this.Label_Destination.Size = new System.Drawing.Size(73, 17);
            this.Label_Destination.TabIndex = 3;
            this.Label_Destination.Text = "Destination";
            // 
            // Label_Mode
            // 
            this.Label_Mode.AutoSize = true;
            this.Label_Mode.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Mode.Location = new System.Drawing.Point(23, 210);
            this.Label_Mode.Name = "Label_Mode";
            this.Label_Mode.Size = new System.Drawing.Size(85, 17);
            this.Label_Mode.TabIndex = 5;
            this.Label_Mode.Text = "Backup Mode";
            // 
            // Radio_Schedule
            // 
            this.Radio_Schedule.AutoSize = true;
            this.Radio_Schedule.ForeColor = System.Drawing.Color.Black;
            this.Radio_Schedule.Location = new System.Drawing.Point(26, 290);
            this.Radio_Schedule.Name = "Radio_Schedule";
            this.Radio_Schedule.Size = new System.Drawing.Size(70, 17);
            this.Radio_Schedule.TabIndex = 5;
            this.Radio_Schedule.TabStop = true;
            this.Radio_Schedule.Text = "Schedule";
            this.Radio_Schedule.UseVisualStyleBackColor = true;
            this.Radio_Schedule.CheckedChanged += new System.EventHandler(this.Radio_Process_CheckedChanged);
            // 
            // Radio_Timer
            // 
            this.Radio_Timer.AutoSize = true;
            this.Radio_Timer.ForeColor = System.Drawing.Color.Black;
            this.Radio_Timer.Location = new System.Drawing.Point(103, 290);
            this.Radio_Timer.Name = "Radio_Timer";
            this.Radio_Timer.Size = new System.Drawing.Size(51, 17);
            this.Radio_Timer.TabIndex = 6;
            this.Radio_Timer.TabStop = true;
            this.Radio_Timer.Text = "Timer";
            this.Radio_Timer.UseVisualStyleBackColor = true;
            this.Radio_Timer.CheckedChanged += new System.EventHandler(this.Radio_Process_CheckedChanged);
            // 
            // Radio_Manual
            // 
            this.Radio_Manual.AutoSize = true;
            this.Radio_Manual.ForeColor = System.Drawing.Color.Black;
            this.Radio_Manual.Location = new System.Drawing.Point(161, 290);
            this.Radio_Manual.Name = "Radio_Manual";
            this.Radio_Manual.Size = new System.Drawing.Size(60, 17);
            this.Radio_Manual.TabIndex = 7;
            this.Radio_Manual.TabStop = true;
            this.Radio_Manual.Text = "Manual";
            this.Radio_Manual.UseVisualStyleBackColor = true;
            this.Radio_Manual.CheckedChanged += new System.EventHandler(this.Radio_Process_CheckedChanged);
            // 
            // Label_Days
            // 
            this.Label_Days.AutoSize = true;
            this.Label_Days.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Days.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Days.Location = new System.Drawing.Point(10, 35);
            this.Label_Days.Name = "Label_Days";
            this.Label_Days.Size = new System.Drawing.Size(35, 17);
            this.Label_Days.TabIndex = 10;
            this.Label_Days.Text = "Days";
            // 
            // Button_Day1
            // 
            this.Button_Day1.BackColor = System.Drawing.Color.White;
            this.Button_Day1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day1.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day1.Location = new System.Drawing.Point(13, 55);
            this.Button_Day1.Name = "Button_Day1";
            this.Button_Day1.Size = new System.Drawing.Size(32, 29);
            this.Button_Day1.TabIndex = 6;
            this.Button_Day1.Text = "1";
            this.Button_Day1.UseVisualStyleBackColor = false;
            this.Button_Day1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day2
            // 
            this.Button_Day2.BackColor = System.Drawing.Color.White;
            this.Button_Day2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day2.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day2.Location = new System.Drawing.Point(51, 55);
            this.Button_Day2.Name = "Button_Day2";
            this.Button_Day2.Size = new System.Drawing.Size(32, 29);
            this.Button_Day2.TabIndex = 9;
            this.Button_Day2.Text = "2";
            this.Button_Day2.UseVisualStyleBackColor = false;
            this.Button_Day2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day3
            // 
            this.Button_Day3.BackColor = System.Drawing.Color.White;
            this.Button_Day3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day3.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day3.Location = new System.Drawing.Point(89, 55);
            this.Button_Day3.Name = "Button_Day3";
            this.Button_Day3.Size = new System.Drawing.Size(32, 29);
            this.Button_Day3.TabIndex = 10;
            this.Button_Day3.Text = "3";
            this.Button_Day3.UseVisualStyleBackColor = false;
            this.Button_Day3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day4
            // 
            this.Button_Day4.BackColor = System.Drawing.Color.White;
            this.Button_Day4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day4.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day4.Location = new System.Drawing.Point(127, 55);
            this.Button_Day4.Name = "Button_Day4";
            this.Button_Day4.Size = new System.Drawing.Size(32, 29);
            this.Button_Day4.TabIndex = 11;
            this.Button_Day4.Text = "4";
            this.Button_Day4.UseVisualStyleBackColor = false;
            this.Button_Day4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day5
            // 
            this.Button_Day5.BackColor = System.Drawing.Color.White;
            this.Button_Day5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day5.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day5.Location = new System.Drawing.Point(165, 55);
            this.Button_Day5.Name = "Button_Day5";
            this.Button_Day5.Size = new System.Drawing.Size(32, 29);
            this.Button_Day5.TabIndex = 12;
            this.Button_Day5.Text = "5";
            this.Button_Day5.UseVisualStyleBackColor = false;
            this.Button_Day5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day6
            // 
            this.Button_Day6.BackColor = System.Drawing.Color.White;
            this.Button_Day6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day6.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day6.Location = new System.Drawing.Point(203, 55);
            this.Button_Day6.Name = "Button_Day6";
            this.Button_Day6.Size = new System.Drawing.Size(32, 29);
            this.Button_Day6.TabIndex = 13;
            this.Button_Day6.Text = "6";
            this.Button_Day6.UseVisualStyleBackColor = false;
            this.Button_Day6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day7
            // 
            this.Button_Day7.BackColor = System.Drawing.Color.White;
            this.Button_Day7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day7.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day7.Location = new System.Drawing.Point(241, 55);
            this.Button_Day7.Name = "Button_Day7";
            this.Button_Day7.Size = new System.Drawing.Size(32, 29);
            this.Button_Day7.TabIndex = 14;
            this.Button_Day7.Text = "7";
            this.Button_Day7.UseVisualStyleBackColor = false;
            this.Button_Day7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day8
            // 
            this.Button_Day8.BackColor = System.Drawing.Color.White;
            this.Button_Day8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day8.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day8.Location = new System.Drawing.Point(279, 55);
            this.Button_Day8.Name = "Button_Day8";
            this.Button_Day8.Size = new System.Drawing.Size(32, 29);
            this.Button_Day8.TabIndex = 15;
            this.Button_Day8.Text = "8";
            this.Button_Day8.UseVisualStyleBackColor = false;
            this.Button_Day8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day9
            // 
            this.Button_Day9.BackColor = System.Drawing.Color.White;
            this.Button_Day9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day9.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day9.Location = new System.Drawing.Point(13, 90);
            this.Button_Day9.Name = "Button_Day9";
            this.Button_Day9.Size = new System.Drawing.Size(32, 29);
            this.Button_Day9.TabIndex = 16;
            this.Button_Day9.Text = "9";
            this.Button_Day9.UseVisualStyleBackColor = false;
            this.Button_Day9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day10
            // 
            this.Button_Day10.BackColor = System.Drawing.Color.White;
            this.Button_Day10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day10.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day10.Location = new System.Drawing.Point(51, 90);
            this.Button_Day10.Name = "Button_Day10";
            this.Button_Day10.Size = new System.Drawing.Size(32, 29);
            this.Button_Day10.TabIndex = 17;
            this.Button_Day10.Text = "10";
            this.Button_Day10.UseVisualStyleBackColor = false;
            this.Button_Day10.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day11
            // 
            this.Button_Day11.BackColor = System.Drawing.Color.White;
            this.Button_Day11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day11.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day11.Location = new System.Drawing.Point(89, 90);
            this.Button_Day11.Name = "Button_Day11";
            this.Button_Day11.Size = new System.Drawing.Size(32, 29);
            this.Button_Day11.TabIndex = 18;
            this.Button_Day11.Text = "11";
            this.Button_Day11.UseVisualStyleBackColor = false;
            this.Button_Day11.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day12
            // 
            this.Button_Day12.BackColor = System.Drawing.Color.White;
            this.Button_Day12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day12.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day12.Location = new System.Drawing.Point(127, 90);
            this.Button_Day12.Name = "Button_Day12";
            this.Button_Day12.Size = new System.Drawing.Size(32, 29);
            this.Button_Day12.TabIndex = 22;
            this.Button_Day12.Text = "12";
            this.Button_Day12.UseVisualStyleBackColor = false;
            this.Button_Day12.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day13
            // 
            this.Button_Day13.BackColor = System.Drawing.Color.White;
            this.Button_Day13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day13.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day13.Location = new System.Drawing.Point(165, 90);
            this.Button_Day13.Name = "Button_Day13";
            this.Button_Day13.Size = new System.Drawing.Size(32, 29);
            this.Button_Day13.TabIndex = 23;
            this.Button_Day13.Text = "13";
            this.Button_Day13.UseVisualStyleBackColor = false;
            this.Button_Day13.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day14
            // 
            this.Button_Day14.BackColor = System.Drawing.Color.White;
            this.Button_Day14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day14.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day14.Location = new System.Drawing.Point(203, 90);
            this.Button_Day14.Name = "Button_Day14";
            this.Button_Day14.Size = new System.Drawing.Size(32, 29);
            this.Button_Day14.TabIndex = 24;
            this.Button_Day14.Text = "14";
            this.Button_Day14.UseVisualStyleBackColor = false;
            this.Button_Day14.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day15
            // 
            this.Button_Day15.BackColor = System.Drawing.Color.White;
            this.Button_Day15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day15.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day15.Location = new System.Drawing.Point(241, 90);
            this.Button_Day15.Name = "Button_Day15";
            this.Button_Day15.Size = new System.Drawing.Size(32, 29);
            this.Button_Day15.TabIndex = 25;
            this.Button_Day15.Text = "15";
            this.Button_Day15.UseVisualStyleBackColor = false;
            this.Button_Day15.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day16
            // 
            this.Button_Day16.BackColor = System.Drawing.Color.White;
            this.Button_Day16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day16.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day16.Location = new System.Drawing.Point(279, 90);
            this.Button_Day16.Name = "Button_Day16";
            this.Button_Day16.Size = new System.Drawing.Size(32, 29);
            this.Button_Day16.TabIndex = 26;
            this.Button_Day16.Text = "16";
            this.Button_Day16.UseVisualStyleBackColor = false;
            this.Button_Day16.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day17
            // 
            this.Button_Day17.BackColor = System.Drawing.Color.White;
            this.Button_Day17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day17.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day17.Location = new System.Drawing.Point(13, 125);
            this.Button_Day17.Name = "Button_Day17";
            this.Button_Day17.Size = new System.Drawing.Size(32, 29);
            this.Button_Day17.TabIndex = 27;
            this.Button_Day17.Text = "17";
            this.Button_Day17.UseVisualStyleBackColor = false;
            this.Button_Day17.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day18
            // 
            this.Button_Day18.BackColor = System.Drawing.Color.White;
            this.Button_Day18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day18.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day18.Location = new System.Drawing.Point(51, 125);
            this.Button_Day18.Name = "Button_Day18";
            this.Button_Day18.Size = new System.Drawing.Size(32, 29);
            this.Button_Day18.TabIndex = 28;
            this.Button_Day18.Text = "18";
            this.Button_Day18.UseVisualStyleBackColor = false;
            this.Button_Day18.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day19
            // 
            this.Button_Day19.BackColor = System.Drawing.Color.White;
            this.Button_Day19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day19.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day19.Location = new System.Drawing.Point(89, 125);
            this.Button_Day19.Name = "Button_Day19";
            this.Button_Day19.Size = new System.Drawing.Size(32, 29);
            this.Button_Day19.TabIndex = 29;
            this.Button_Day19.Text = "19";
            this.Button_Day19.UseVisualStyleBackColor = false;
            this.Button_Day19.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day20
            // 
            this.Button_Day20.BackColor = System.Drawing.Color.White;
            this.Button_Day20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day20.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day20.Location = new System.Drawing.Point(127, 125);
            this.Button_Day20.Name = "Button_Day20";
            this.Button_Day20.Size = new System.Drawing.Size(32, 29);
            this.Button_Day20.TabIndex = 30;
            this.Button_Day20.Text = "20";
            this.Button_Day20.UseVisualStyleBackColor = false;
            this.Button_Day20.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day21
            // 
            this.Button_Day21.BackColor = System.Drawing.Color.White;
            this.Button_Day21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day21.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day21.Location = new System.Drawing.Point(165, 125);
            this.Button_Day21.Name = "Button_Day21";
            this.Button_Day21.Size = new System.Drawing.Size(32, 29);
            this.Button_Day21.TabIndex = 31;
            this.Button_Day21.Text = "21";
            this.Button_Day21.UseVisualStyleBackColor = false;
            this.Button_Day21.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day22
            // 
            this.Button_Day22.BackColor = System.Drawing.Color.White;
            this.Button_Day22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day22.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day22.Location = new System.Drawing.Point(203, 125);
            this.Button_Day22.Name = "Button_Day22";
            this.Button_Day22.Size = new System.Drawing.Size(32, 29);
            this.Button_Day22.TabIndex = 32;
            this.Button_Day22.Text = "22";
            this.Button_Day22.UseVisualStyleBackColor = false;
            this.Button_Day22.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day23
            // 
            this.Button_Day23.BackColor = System.Drawing.Color.White;
            this.Button_Day23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day23.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day23.Location = new System.Drawing.Point(241, 125);
            this.Button_Day23.Name = "Button_Day23";
            this.Button_Day23.Size = new System.Drawing.Size(32, 29);
            this.Button_Day23.TabIndex = 33;
            this.Button_Day23.Text = "23";
            this.Button_Day23.UseVisualStyleBackColor = false;
            this.Button_Day23.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day24
            // 
            this.Button_Day24.BackColor = System.Drawing.Color.White;
            this.Button_Day24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day24.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day24.Location = new System.Drawing.Point(279, 125);
            this.Button_Day24.Name = "Button_Day24";
            this.Button_Day24.Size = new System.Drawing.Size(32, 29);
            this.Button_Day24.TabIndex = 34;
            this.Button_Day24.Text = "24";
            this.Button_Day24.UseVisualStyleBackColor = false;
            this.Button_Day24.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day25
            // 
            this.Button_Day25.BackColor = System.Drawing.Color.White;
            this.Button_Day25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day25.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day25.Location = new System.Drawing.Point(13, 160);
            this.Button_Day25.Name = "Button_Day25";
            this.Button_Day25.Size = new System.Drawing.Size(32, 29);
            this.Button_Day25.TabIndex = 35;
            this.Button_Day25.Text = "25";
            this.Button_Day25.UseVisualStyleBackColor = false;
            this.Button_Day25.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day26
            // 
            this.Button_Day26.BackColor = System.Drawing.Color.White;
            this.Button_Day26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day26.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day26.Location = new System.Drawing.Point(51, 160);
            this.Button_Day26.Name = "Button_Day26";
            this.Button_Day26.Size = new System.Drawing.Size(32, 29);
            this.Button_Day26.TabIndex = 36;
            this.Button_Day26.Text = "26";
            this.Button_Day26.UseVisualStyleBackColor = false;
            this.Button_Day26.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day27
            // 
            this.Button_Day27.BackColor = System.Drawing.Color.White;
            this.Button_Day27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day27.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day27.Location = new System.Drawing.Point(89, 160);
            this.Button_Day27.Name = "Button_Day27";
            this.Button_Day27.Size = new System.Drawing.Size(32, 29);
            this.Button_Day27.TabIndex = 37;
            this.Button_Day27.Text = "27";
            this.Button_Day27.UseVisualStyleBackColor = false;
            this.Button_Day27.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day28
            // 
            this.Button_Day28.BackColor = System.Drawing.Color.White;
            this.Button_Day28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day28.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day28.Location = new System.Drawing.Point(127, 160);
            this.Button_Day28.Name = "Button_Day28";
            this.Button_Day28.Size = new System.Drawing.Size(32, 29);
            this.Button_Day28.TabIndex = 38;
            this.Button_Day28.Text = "28";
            this.Button_Day28.UseVisualStyleBackColor = false;
            this.Button_Day28.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day29
            // 
            this.Button_Day29.BackColor = System.Drawing.Color.White;
            this.Button_Day29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day29.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day29.Location = new System.Drawing.Point(165, 160);
            this.Button_Day29.Name = "Button_Day29";
            this.Button_Day29.Size = new System.Drawing.Size(32, 29);
            this.Button_Day29.TabIndex = 39;
            this.Button_Day29.Text = "29";
            this.Button_Day29.UseVisualStyleBackColor = false;
            this.Button_Day29.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day30
            // 
            this.Button_Day30.BackColor = System.Drawing.Color.White;
            this.Button_Day30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day30.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day30.Location = new System.Drawing.Point(203, 160);
            this.Button_Day30.Name = "Button_Day30";
            this.Button_Day30.Size = new System.Drawing.Size(32, 29);
            this.Button_Day30.TabIndex = 40;
            this.Button_Day30.Text = "30";
            this.Button_Day30.UseVisualStyleBackColor = false;
            this.Button_Day30.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Day31
            // 
            this.Button_Day31.BackColor = System.Drawing.Color.White;
            this.Button_Day31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Day31.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Day31.Location = new System.Drawing.Point(241, 160);
            this.Button_Day31.Name = "Button_Day31";
            this.Button_Day31.Size = new System.Drawing.Size(32, 29);
            this.Button_Day31.TabIndex = 41;
            this.Button_Day31.Text = "31";
            this.Button_Day31.UseVisualStyleBackColor = false;
            this.Button_Day31.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Button_Discard
            // 
            this.Button_Discard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Button_Discard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(144)))));
            this.Button_Discard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Discard.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Discard.ForeColor = System.Drawing.Color.Black;
            this.Button_Discard.Location = new System.Drawing.Point(17, 0);
            this.Button_Discard.Name = "Button_Discard";
            this.Button_Discard.Size = new System.Drawing.Size(75, 25);
            this.Button_Discard.TabIndex = 44;
            this.Button_Discard.Text = "Discard";
            this.Button_Discard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Discard.UseVisualStyleBackColor = false;
            this.Button_Discard.Click += new System.EventHandler(this.Button_Discard_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Button_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(144)))));
            this.Button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Save.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_Save.ForeColor = System.Drawing.Color.Black;
            this.Button_Save.Location = new System.Drawing.Point(117, 0);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(75, 25);
            this.Button_Save.TabIndex = 45;
            this.Button_Save.Text = "Save";
            this.Button_Save.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Save.UseVisualStyleBackColor = false;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_PickSource
            // 
            this.Button_PickSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.Button_PickSource.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(144)))));
            this.Button_PickSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_PickSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.Button_PickSource.Location = new System.Drawing.Point(321, 99);
            this.Button_PickSource.Name = "Button_PickSource";
            this.Button_PickSource.Size = new System.Drawing.Size(32, 20);
            this.Button_PickSource.TabIndex = 1;
            this.Button_PickSource.Text = "...";
            this.Button_PickSource.UseVisualStyleBackColor = false;
            this.Button_PickSource.Click += new System.EventHandler(this.Button_PickSource_Click);
            // 
            // Button_PickFolder
            // 
            this.Button_PickFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.Button_PickFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(135)))), ((int)(((byte)(144)))));
            this.Button_PickFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_PickFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.Button_PickFolder.Location = new System.Drawing.Point(321, 165);
            this.Button_PickFolder.Name = "Button_PickFolder";
            this.Button_PickFolder.Size = new System.Drawing.Size(32, 20);
            this.Button_PickFolder.TabIndex = 3;
            this.Button_PickFolder.Text = "...";
            this.Button_PickFolder.UseVisualStyleBackColor = false;
            this.Button_PickFolder.Click += new System.EventHandler(this.Button_PickFolder_Click);
            // 
            // Label_Time
            // 
            this.Label_Time.AutoSize = true;
            this.Label_Time.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.Label_Time.Location = new System.Drawing.Point(10, 210);
            this.Label_Time.Name = "Label_Time";
            this.Label_Time.Size = new System.Drawing.Size(73, 17);
            this.Label_Time.TabIndex = 46;
            this.Label_Time.Text = "Time of day";
            // 
            // Text_TimeOfDay
            // 
            this.Text_TimeOfDay.Location = new System.Drawing.Point(13, 230);
            this.Text_TimeOfDay.Name = "Text_TimeOfDay";
            this.Text_TimeOfDay.Size = new System.Drawing.Size(108, 20);
            this.Text_TimeOfDay.TabIndex = 43;
            // 
            // Label_Help_Text_Time
            // 
            this.Label_Help_Text_Time.AutoSize = true;
            this.Label_Help_Text_Time.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Italic);
            this.Label_Help_Text_Time.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Text_Time.Location = new System.Drawing.Point(109, 210);
            this.Label_Help_Text_Time.Name = "Label_Help_Text_Time";
            this.Label_Help_Text_Time.Size = new System.Drawing.Size(162, 17);
            this.Label_Help_Text_Time.TabIndex = 48;
            this.Label_Help_Text_Time.Text = "24-hour format (e.g. 22:00)";
            // 
            // Label_Help_Days
            // 
            this.Label_Help_Days.AutoSize = true;
            this.Label_Help_Days.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Help_Days.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Days.Location = new System.Drawing.Point(51, 35);
            this.Label_Help_Days.Name = "Label_Help_Days";
            this.Label_Help_Days.Size = new System.Drawing.Size(14, 17);
            this.Label_Help_Days.TabIndex = 49;
            this.Label_Help_Days.Text = "?";
            this.Label_Help_Days.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Days.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Days.MouseEnter += new System.EventHandler(this.Help_MouseEnter);
            this.Label_Help_Days.MouseLeave += new System.EventHandler(this.Help_MouseLeave);
            // 
            // Label_Help_Time
            // 
            this.Label_Help_Time.AutoSize = true;
            this.Label_Help_Time.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Help_Time.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Time.Location = new System.Drawing.Point(89, 210);
            this.Label_Help_Time.Name = "Label_Help_Time";
            this.Label_Help_Time.Size = new System.Drawing.Size(14, 17);
            this.Label_Help_Time.TabIndex = 50;
            this.Label_Help_Time.Text = "?";
            this.Label_Help_Time.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Time.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Time.MouseEnter += new System.EventHandler(this.Help_MouseEnter);
            this.Label_Help_Time.MouseLeave += new System.EventHandler(this.Help_MouseLeave);
            // 
            // Label_Help_Source
            // 
            this.Label_Help_Source.AutoSize = true;
            this.Label_Help_Source.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Help_Source.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Source.Location = new System.Drawing.Point(75, 78);
            this.Label_Help_Source.Name = "Label_Help_Source";
            this.Label_Help_Source.Size = new System.Drawing.Size(14, 17);
            this.Label_Help_Source.TabIndex = 51;
            this.Label_Help_Source.Text = "?";
            this.Label_Help_Source.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Source.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Source.MouseEnter += new System.EventHandler(this.Help_MouseEnter);
            this.Label_Help_Source.MouseLeave += new System.EventHandler(this.Help_MouseLeave);
            // 
            // Label_Help_Destination
            // 
            this.Label_Help_Destination.AutoSize = true;
            this.Label_Help_Destination.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Help_Destination.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Destination.Location = new System.Drawing.Point(102, 144);
            this.Label_Help_Destination.Name = "Label_Help_Destination";
            this.Label_Help_Destination.Size = new System.Drawing.Size(14, 17);
            this.Label_Help_Destination.TabIndex = 52;
            this.Label_Help_Destination.Text = "?";
            this.Label_Help_Destination.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Destination.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Destination.MouseEnter += new System.EventHandler(this.Help_MouseEnter);
            this.Label_Help_Destination.MouseLeave += new System.EventHandler(this.Help_MouseLeave);
            // 
            // Label_Help_Text_Days
            // 
            this.Label_Help_Text_Days.AutoSize = true;
            this.Label_Help_Text_Days.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Italic);
            this.Label_Help_Text_Days.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Text_Days.Location = new System.Drawing.Point(71, 35);
            this.Label_Help_Text_Days.Name = "Label_Help_Text_Days";
            this.Label_Help_Text_Days.Size = new System.Drawing.Size(264, 17);
            this.Label_Help_Text_Days.TabIndex = 55;
            this.Label_Help_Text_Days.Text = "Select the days you want to the backup to run";
            // 
            // Label_Help_Text_Source
            // 
            this.Label_Help_Text_Source.AutoSize = true;
            this.Label_Help_Text_Source.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Italic);
            this.Label_Help_Text_Source.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Text_Source.Location = new System.Drawing.Point(95, 78);
            this.Label_Help_Text_Source.Name = "Label_Help_Text_Source";
            this.Label_Help_Text_Source.Size = new System.Drawing.Size(162, 17);
            this.Label_Help_Text_Source.TabIndex = 56;
            this.Label_Help_Text_Source.Text = "Select an input file or folder";
            // 
            // Label_Help_Text_Destination
            // 
            this.Label_Help_Text_Destination.AutoSize = true;
            this.Label_Help_Text_Destination.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Italic);
            this.Label_Help_Text_Destination.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Text_Destination.Location = new System.Drawing.Point(122, 144);
            this.Label_Help_Text_Destination.Name = "Label_Help_Text_Destination";
            this.Label_Help_Text_Destination.Size = new System.Drawing.Size(136, 17);
            this.Label_Help_Text_Destination.TabIndex = 57;
            this.Label_Help_Text_Destination.Text = "Select an output folder";
            // 
            // Label_Help_Mode
            // 
            this.Label_Help_Mode.AutoSize = true;
            this.Label_Help_Mode.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Help_Mode.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Mode.Location = new System.Drawing.Point(114, 210);
            this.Label_Help_Mode.Name = "Label_Help_Mode";
            this.Label_Help_Mode.Size = new System.Drawing.Size(14, 17);
            this.Label_Help_Mode.TabIndex = 58;
            this.Label_Help_Mode.Text = "?";
            this.Label_Help_Mode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Mode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Mode.MouseEnter += new System.EventHandler(this.Help_MouseEnter);
            this.Label_Help_Mode.MouseLeave += new System.EventHandler(this.Help_MouseLeave);
            // 
            // Label_Help_Text_Mode
            // 
            this.Label_Help_Text_Mode.AutoSize = true;
            this.Label_Help_Text_Mode.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Italic);
            this.Label_Help_Text_Mode.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Text_Mode.Location = new System.Drawing.Point(134, 210);
            this.Label_Help_Text_Mode.Name = "Label_Help_Text_Mode";
            this.Label_Help_Text_Mode.Size = new System.Drawing.Size(226, 17);
            this.Label_Help_Text_Mode.TabIndex = 59;
            this.Label_Help_Text_Mode.Text = "Replace changed files since last backup";
            // 
            // Label_Error
            // 
            this.Label_Error.AutoSize = true;
            this.Label_Error.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Error.ForeColor = System.Drawing.Color.Red;
            this.Label_Error.Location = new System.Drawing.Point(23, 558);
            this.Label_Error.Name = "Label_Error";
            this.Label_Error.Size = new System.Drawing.Size(64, 17);
            this.Label_Error.TabIndex = 60;
            this.Label_Error.Text = "Error Text";
            // 
            // Button_DayAll
            // 
            this.Button_DayAll.BackColor = System.Drawing.Color.White;
            this.Button_DayAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_DayAll.Font = new System.Drawing.Font("Calibri", 10F);
            this.Button_DayAll.Location = new System.Drawing.Point(279, 160);
            this.Button_DayAll.Name = "Button_DayAll";
            this.Button_DayAll.Size = new System.Drawing.Size(32, 29);
            this.Button_DayAll.TabIndex = 42;
            this.Button_DayAll.Text = "All";
            this.Button_DayAll.UseVisualStyleBackColor = false;
            this.Button_DayAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Days_MouseClick);
            // 
            // Panel_Schedule
            // 
            this.Panel_Schedule.Controls.Add(this.Button_DayAll);
            this.Panel_Schedule.Controls.Add(this.Label_Days);
            this.Panel_Schedule.Controls.Add(this.Button_Day1);
            this.Panel_Schedule.Controls.Add(this.Button_Day2);
            this.Panel_Schedule.Controls.Add(this.Button_Day3);
            this.Panel_Schedule.Controls.Add(this.Button_Day4);
            this.Panel_Schedule.Controls.Add(this.Button_Day5);
            this.Panel_Schedule.Controls.Add(this.Label_Help_Text_Days);
            this.Panel_Schedule.Controls.Add(this.Button_Day6);
            this.Panel_Schedule.Controls.Add(this.Button_Day7);
            this.Panel_Schedule.Controls.Add(this.Button_Day8);
            this.Panel_Schedule.Controls.Add(this.Label_Help_Time);
            this.Panel_Schedule.Controls.Add(this.Button_Day9);
            this.Panel_Schedule.Controls.Add(this.Label_Help_Days);
            this.Panel_Schedule.Controls.Add(this.Button_Day10);
            this.Panel_Schedule.Controls.Add(this.Label_Help_Text_Time);
            this.Panel_Schedule.Controls.Add(this.Button_Day11);
            this.Panel_Schedule.Controls.Add(this.Text_TimeOfDay);
            this.Panel_Schedule.Controls.Add(this.Button_Day12);
            this.Panel_Schedule.Controls.Add(this.Label_Time);
            this.Panel_Schedule.Controls.Add(this.Button_Day13);
            this.Panel_Schedule.Controls.Add(this.Button_Day14);
            this.Panel_Schedule.Controls.Add(this.Button_Day15);
            this.Panel_Schedule.Controls.Add(this.Button_Day16);
            this.Panel_Schedule.Controls.Add(this.Button_Day17);
            this.Panel_Schedule.Controls.Add(this.Button_Day31);
            this.Panel_Schedule.Controls.Add(this.Button_Day18);
            this.Panel_Schedule.Controls.Add(this.Button_Day30);
            this.Panel_Schedule.Controls.Add(this.Button_Day19);
            this.Panel_Schedule.Controls.Add(this.Button_Day29);
            this.Panel_Schedule.Controls.Add(this.Button_Day20);
            this.Panel_Schedule.Controls.Add(this.Button_Day28);
            this.Panel_Schedule.Controls.Add(this.Button_Day21);
            this.Panel_Schedule.Controls.Add(this.Button_Day27);
            this.Panel_Schedule.Controls.Add(this.Button_Day22);
            this.Panel_Schedule.Controls.Add(this.Button_Day26);
            this.Panel_Schedule.Controls.Add(this.Button_Day23);
            this.Panel_Schedule.Controls.Add(this.Button_Day25);
            this.Panel_Schedule.Controls.Add(this.Button_Day24);
            this.Panel_Schedule.Location = new System.Drawing.Point(13, 298);
            this.Panel_Schedule.Name = "Panel_Schedule";
            this.Panel_Schedule.Size = new System.Drawing.Size(335, 317);
            this.Panel_Schedule.TabIndex = 62;
            // 
            // Panel_Timer
            // 
            this.Panel_Timer.Controls.Add(this.Label_BackupTimer);
            this.Panel_Timer.Controls.Add(this.Label_Help_Text_Timer);
            this.Panel_Timer.Controls.Add(this.Text_Timer);
            this.Panel_Timer.Controls.Add(this.Label_Help_Timer);
            this.Panel_Timer.Location = new System.Drawing.Point(388, 317);
            this.Panel_Timer.Name = "Panel_Timer";
            this.Panel_Timer.Size = new System.Drawing.Size(335, 317);
            this.Panel_Timer.TabIndex = 63;
            // 
            // Label_BackupTimer
            // 
            this.Label_BackupTimer.AutoSize = true;
            this.Label_BackupTimer.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_BackupTimer.Location = new System.Drawing.Point(10, 35);
            this.Label_BackupTimer.Name = "Label_BackupTimer";
            this.Label_BackupTimer.Size = new System.Drawing.Size(141, 17);
            this.Label_BackupTimer.TabIndex = 62;
            this.Label_BackupTimer.Text = "Backup Timer (minutes)";
            // 
            // Label_Help_Text_Timer
            // 
            this.Label_Help_Text_Timer.AutoSize = true;
            this.Label_Help_Text_Timer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Italic);
            this.Label_Help_Text_Timer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Text_Timer.Location = new System.Drawing.Point(180, 35);
            this.Label_Help_Text_Timer.Name = "Label_Help_Text_Timer";
            this.Label_Help_Text_Timer.Size = new System.Drawing.Size(155, 17);
            this.Label_Help_Text_Timer.TabIndex = 64;
            this.Label_Help_Text_Timer.Text = "Minutes between backups";
            // 
            // Text_Timer
            // 
            this.Text_Timer.Location = new System.Drawing.Point(13, 60);
            this.Text_Timer.Name = "Text_Timer";
            this.Text_Timer.Size = new System.Drawing.Size(174, 20);
            this.Text_Timer.TabIndex = 8;
            // 
            // Label_Help_Timer
            // 
            this.Label_Help_Timer.AutoSize = true;
            this.Label_Help_Timer.Font = new System.Drawing.Font("Calibri", 10F);
            this.Label_Help_Timer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label_Help_Timer.Location = new System.Drawing.Point(157, 35);
            this.Label_Help_Timer.Name = "Label_Help_Timer";
            this.Label_Help_Timer.Size = new System.Drawing.Size(14, 17);
            this.Label_Help_Timer.TabIndex = 63;
            this.Label_Help_Timer.Text = "?";
            this.Label_Help_Timer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Timer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Help_MouseClick);
            this.Label_Help_Timer.MouseEnter += new System.EventHandler(this.Help_MouseEnter);
            this.Label_Help_Timer.MouseLeave += new System.EventHandler(this.Help_MouseLeave);
            // 
            // Panel_Button_Panel
            // 
            this.Panel_Button_Panel.Controls.Add(this.Button_Discard);
            this.Panel_Button_Panel.Controls.Add(this.Button_Save);
            this.Panel_Button_Panel.Location = new System.Drawing.Point(161, 581);
            this.Panel_Button_Panel.Name = "Panel_Button_Panel";
            this.Panel_Button_Panel.Size = new System.Drawing.Size(224, 34);
            this.Panel_Button_Panel.TabIndex = 64;
            // 
            // Combo_Mode
            // 
            this.Combo_Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Combo_Mode.ForeColor = System.Drawing.Color.Black;
            this.Combo_Mode.FormattingEnabled = true;
            this.Combo_Mode.Items.AddRange(new object[] {
            "Changed Files Only",
            "Make New Copies",
            "Replace All Files"});
            this.Combo_Mode.Location = new System.Drawing.Point(26, 231);
            this.Combo_Mode.MaxDropDownItems = 3;
            this.Combo_Mode.Name = "Combo_Mode";
            this.Combo_Mode.Size = new System.Drawing.Size(146, 21);
            this.Combo_Mode.TabIndex = 4;
            this.Combo_Mode.SelectionChangeCommitted += new System.EventHandler(this.Combo_Mode_SelectionChangeCommitted);
            // 
            // Form_New_Entry
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1219, 635);
            this.Controls.Add(this.Panel_Button_Panel);
            this.Controls.Add(this.Label_Error);
            this.Controls.Add(this.Label_Help_Text_Mode);
            this.Controls.Add(this.Label_Help_Mode);
            this.Controls.Add(this.Label_Help_Text_Destination);
            this.Controls.Add(this.Label_Help_Text_Source);
            this.Controls.Add(this.Label_Help_Destination);
            this.Controls.Add(this.Label_Help_Source);
            this.Controls.Add(this.Button_PickFolder);
            this.Controls.Add(this.Button_PickSource);
            this.Controls.Add(this.Radio_Manual);
            this.Controls.Add(this.Radio_Timer);
            this.Controls.Add(this.Radio_Schedule);
            this.Controls.Add(this.Combo_Mode);
            this.Controls.Add(this.Label_Mode);
            this.Controls.Add(this.Text_Destination);
            this.Controls.Add(this.Label_Destination);
            this.Controls.Add(this.Text_Source);
            this.Controls.Add(this.Label_Source);
            this.Controls.Add(this.Label_Entry);
            this.Controls.Add(this.Panel_Schedule);
            this.Controls.Add(this.Panel_Timer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_New_Entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_New_Entry_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_New_Entry_KeyPress);
            this.Panel_Schedule.ResumeLayout(false);
            this.Panel_Schedule.PerformLayout();
            this.Panel_Timer.ResumeLayout(false);
            this.Panel_Timer.PerformLayout();
            this.Panel_Button_Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private int Type;
        private int Id;
        private Form_Darcy_Panel Main;
        private EntryClass Entry;

        private Color _themeColor;
        public Form_New_Entry(Form_Darcy_Panel main, int type, int id, Color theme)
        {
            Main = main;
            Type = type;
            Id = id;
            _themeColor = theme;
            if (type == 1)
                Entry = main.GetEntry(id);

            InitializeComponent();

            InitializeFields();

            InitializeGUI();

            this.Visible = true;

            Text_Source.Focus();
        }

        private bool[] ArrayDays;
        private void InitializeFields()
        {
            ArrayDays = new bool[32];
            for (int i = 0; i < ArrayDays.Length; i++)
                ArrayDays[i] = false;
        }

        private void Help_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.Black;
        }

        private void Help_MouseLeave(object sender, EventArgs e)
        {
            if (sender == Label_Help_Days)
                if (Label_Help_Text_Days.Visible == true)
                    return;
            if (sender == Label_Help_Destination)
                if (Label_Help_Text_Destination.Visible == true)
                    return;
            if (sender == Label_Help_Source)
                if (Label_Help_Text_Source.Visible == true)
                    return;
            if (sender == Label_Help_Mode)
                if (Label_Help_Text_Mode.Visible == true)
                    return;
            if (sender == Label_Help_Time)
                if (Label_Help_Text_Time.Visible == true)
                    return;
            if (sender == Label_Help_Timer)
                if (Label_Help_Text_Timer.Visible == true)
                    return;
            ((Control)sender).ForeColor = Color.FromArgb(120, 120, 120);
        }


        private void Help_MouseClick(object sender, MouseEventArgs e)
        {
            Color color = Color.FromArgb(120, 120, 120);
            if (sender == Label_Help_Days)
            {
                if (Label_Help_Text_Days.Visible == true)
                    Label_Help_Text_Days.Visible = false;
                else
                {
                    Label_Help_Text_Days.Visible = true;
                    Label_Help_Text_Destination.Visible = false; Label_Help_Text_Source.Visible = false; Label_Help_Text_Mode.Visible = false; Label_Help_Text_Time.Visible = false; Label_Help_Text_Timer.Visible = false;
                    Label_Help_Destination.ForeColor = color; Label_Help_Source.ForeColor = color; Label_Help_Mode.ForeColor = color; Label_Help_Time.ForeColor = color; Label_Help_Timer.ForeColor = color;
                }
            }
            else if (sender == Label_Help_Destination)
            {
                if (Label_Help_Text_Destination.Visible == true)
                    Label_Help_Text_Destination.Visible = false;
                else
                {
                    Label_Help_Text_Destination.Visible = true;
                    Label_Help_Text_Days.Visible = false; Label_Help_Text_Source.Visible = false; Label_Help_Text_Mode.Visible = false; Label_Help_Text_Time.Visible = false; Label_Help_Text_Timer.Visible = false;
                    Label_Help_Days.ForeColor = color; Label_Help_Source.ForeColor = color; Label_Help_Mode.ForeColor = color; Label_Help_Time.ForeColor = color; Label_Help_Timer.ForeColor = color;
                }
            }
            else if (sender == Label_Help_Source)
            {
                if (Label_Help_Text_Source.Visible == true)
                    Label_Help_Text_Source.Visible = false;
                else
                {
                    Label_Help_Text_Source.Visible = true;
                    Label_Help_Text_Days.Visible = false; Label_Help_Text_Destination.Visible = false; Label_Help_Text_Mode.Visible = false; Label_Help_Text_Time.Visible = false; Label_Help_Text_Timer.Visible = false;
                    Label_Help_Days.ForeColor = color; Label_Help_Destination.ForeColor = color; Label_Help_Mode.ForeColor = color; Label_Help_Time.ForeColor = color; Label_Help_Timer.ForeColor = color;
                }
            }
            else if (sender == Label_Help_Mode)
            {
                if (Label_Help_Text_Mode.Visible == true)
                    Label_Help_Text_Mode.Visible = false;
                else
                {
                    Label_Help_Text_Mode.Visible = true;
                    Label_Help_Text_Days.Visible = false; Label_Help_Text_Destination.Visible = false; Label_Help_Text_Source.Visible = false; Label_Help_Text_Time.Visible = false; Label_Help_Text_Timer.Visible = false;
                    Label_Help_Days.ForeColor = color; Label_Help_Destination.ForeColor = color; Label_Help_Source.ForeColor = color; Label_Help_Time.ForeColor = color; Label_Help_Timer.ForeColor = color;
                }
            }
            else if (sender == Label_Help_Time)
            {
                if (Label_Help_Text_Time.Visible == true)
                    Label_Help_Text_Time.Visible = false;
                else
                {
                    Label_Help_Text_Time.Visible = true;
                    Label_Help_Text_Days.Visible = false; Label_Help_Text_Destination.Visible = false; Label_Help_Text_Mode.Visible = false; Label_Help_Text_Mode.Visible = false; Label_Help_Text_Timer.Visible = false;
                    Label_Help_Days.ForeColor = color; Label_Help_Destination.ForeColor = color; Label_Help_Mode.ForeColor = color; Label_Help_Mode.ForeColor = color; Label_Help_Timer.ForeColor = color;
                }
            }
            else if (sender == Label_Help_Timer)
            {
                if (Label_Help_Text_Timer.Visible == true)
                    Label_Help_Text_Timer.Visible = false;
                else
                {
                    Label_Help_Text_Timer.Visible = true;
                    Label_Help_Text_Days.Visible = false; Label_Help_Text_Destination.Visible = false; Label_Help_Text_Mode.Visible = false; Label_Help_Text_Mode.Visible = false; Label_Help_Text_Time.Visible = false;
                    Label_Help_Days.ForeColor = color; Label_Help_Destination.ForeColor = color; Label_Help_Mode.ForeColor = color; Label_Help_Mode.ForeColor = color; Label_Help_Time.ForeColor = color;
                }
            }
        }

        Button[] ButtonDayArray = new Button[31];
        private void InitializeGUI()
        {
            this.KeyPreview = true;
            this.SetBounds(0, 0, 394, 671);

            if (Type == 0)
            {
                this.Text = "New Entry";
                Label_Entry.Text = "Entry " + Id.ToString();
            }
            else if (Type == 1)
            {
                this.Text = "Edit Entry";
                Label_Entry.Text = "Entry " + (Id + 1).ToString();
            }

            Label_Entry.ForeColor = _themeColor;

            Label_Error.Visible = false;

            Label_Help_Text_Days.Visible = false;
            Label_Help_Text_Destination.Visible = false;
            Label_Help_Text_Source.Visible = false;
            Label_Help_Text_Mode.Visible = false;
            Label_Help_Text_Time.Visible = false;
            Label_Help_Text_Timer.Visible = false;

            Combo_Mode.SelectedIndex = 0;
            Combo_Mode.DropDownStyle = ComboBoxStyle.DropDownList;


            Radio_Schedule.Select();

            
            ButtonDayArray[0] = Button_Day1; ButtonDayArray[1] = Button_Day2; ButtonDayArray[2] = Button_Day3;
            ButtonDayArray[3] = Button_Day4; ButtonDayArray[4] = Button_Day5; ButtonDayArray[5] = Button_Day6;
            ButtonDayArray[6] = Button_Day7; ButtonDayArray[7] = Button_Day8; ButtonDayArray[8] = Button_Day9;
            ButtonDayArray[9] = Button_Day10; ButtonDayArray[10] = Button_Day11; ButtonDayArray[11] = Button_Day12;
            ButtonDayArray[12] = Button_Day13; ButtonDayArray[13] = Button_Day14; ButtonDayArray[14] = Button_Day15;
            ButtonDayArray[15] = Button_Day16; ButtonDayArray[16] = Button_Day17; ButtonDayArray[17] = Button_Day18;
            ButtonDayArray[18] = Button_Day19; ButtonDayArray[19] = Button_Day20; ButtonDayArray[20] = Button_Day21;
            ButtonDayArray[21] = Button_Day22; ButtonDayArray[22] = Button_Day23; ButtonDayArray[23] = Button_Day24;
            ButtonDayArray[24] = Button_Day25; ButtonDayArray[25] = Button_Day26; ButtonDayArray[26] = Button_Day27;
            ButtonDayArray[27] = Button_Day28; ButtonDayArray[28] = Button_Day29; ButtonDayArray[29] = Button_Day30;
            ButtonDayArray[30] = Button_Day31;


            Panel_Timer.Bounds = Panel_Schedule.Bounds;



            if (Type == 1)
            {
                Text_Source.Text = Entry.Source;
                Text_Destination.Text = Entry.Destination;

                Combo_Mode.SelectedIndex = Entry.Mode;

                if (Main.ProcessToString(Entry.Process) == "Scheduled")
                {
                    Panel_Schedule.Visible = true;
                    Panel_Timer.Visible = false;

                    Text_TimeOfDay.Text = Entry.TimeOfDay;

                    /*
                    //
                    //  change this to a prettier solution
                    //
                    */


                    if (Entry.Days[0] == true)
                        Days_MouseClick(Button_Day1, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[1] == true)
                        Days_MouseClick(Button_Day2, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[2] == true)
                        Days_MouseClick(Button_Day3, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[3] == true)
                        Days_MouseClick(Button_Day4, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[4] == true)
                        Days_MouseClick(Button_Day5, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[5] == true)
                        Days_MouseClick(Button_Day6, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[6] == true)
                        Days_MouseClick(Button_Day7, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[7] == true)
                        Days_MouseClick(Button_Day8, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[8] == true)
                        Days_MouseClick(Button_Day9, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[9] == true)
                        Days_MouseClick(Button_Day10, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));

                    if (Entry.Days[10] == true)
                        Days_MouseClick(Button_Day11, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[11] == true)
                        Days_MouseClick(Button_Day12, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[12] == true)
                        Days_MouseClick(Button_Day13, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[13] == true)
                        Days_MouseClick(Button_Day14, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[14] == true)
                        Days_MouseClick(Button_Day15, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[15] == true)
                        Days_MouseClick(Button_Day16, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[16] == true)
                        Days_MouseClick(Button_Day17, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[17] == true)
                        Days_MouseClick(Button_Day18, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[18] == true)
                        Days_MouseClick(Button_Day19, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[19] == true)
                        Days_MouseClick(Button_Day20, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));

                    if (Entry.Days[20] == true)
                        Days_MouseClick(Button_Day21, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[21] == true)
                        Days_MouseClick(Button_Day22, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[22] == true)
                        Days_MouseClick(Button_Day23, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[23] == true)
                        Days_MouseClick(Button_Day24, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[24] == true)
                        Days_MouseClick(Button_Day25, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[25] == true)
                        Days_MouseClick(Button_Day26, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[26] == true)
                        Days_MouseClick(Button_Day27, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[27] == true)
                        Days_MouseClick(Button_Day28, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[28] == true)
                        Days_MouseClick(Button_Day29, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    if (Entry.Days[29] == true)
                        Days_MouseClick(Button_Day30, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));

                    if (Entry.Days[30] == true)
                        Days_MouseClick(Button_Day31, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                }
                else if (Main.ProcessToString(Entry.Process) == "Timer")
                {
                    Radio_Timer.Checked = true;

                    Panel_Schedule.Visible = false;
                    Panel_Timer.Visible = true;

                    Text_Timer.Text = Entry.Timer.ToString();
                }
                else if (Main.ProcessToString(Entry.Process) == "Manual")
                {
                    Radio_Manual.Checked = true;

                    Panel_Schedule.Visible = false;
                    Panel_Timer.Visible = false;
                }
            }
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            /*
            base.OnPaint(e);

            Pen pen = new Pen(Color.FromArgb(130, 135, 144));

            e.Graphics.DrawLine(pen, 20, 52, 360, 52);

            pen.Dispose();
            */
        }

        private void Days_MouseClick(object sender, MouseEventArgs e)
        {
            Control control = ((Control)sender);
            Color color = Color.FromArgb(127, 127, 127);

            int day = 0;
            String text = control.Text;
            if (control == Button_DayAll)
            {
                if (ArrayDays[31] == true)
                {

                    control.ForeColor = Color.Black;
                    control.BackColor = Color.White;
                    ArrayDays[31] = false;

                    for (int i = 0; i < ButtonDayArray.Length; i++)
                    {
                        ArrayDays[i] = false;
                        control = ButtonDayArray[i];
                        control.ForeColor = Color.Black;
                        control.BackColor = Color.White;
                    }
                }
                else
                {
                    control.ForeColor = Color.White;
                    control.BackColor = color;
                    ArrayDays[31] = true;

                    for (int i = 0; i < ButtonDayArray.Length; i++)
                    {
                        ArrayDays[i] = true;
                        control = ButtonDayArray[i];
                        control.ForeColor = Color.White;
                        control.BackColor = color;
                    }
                }
            }
            else if (Int32.TryParse(text, out day))
            {
                day = day - 1;

                if (ArrayDays[day] == true)
                {
                    ArrayDays[day] = false;
                    control.ForeColor = Color.Black;
                    control.BackColor = Color.White;

                    Button_DayAll.ForeColor = Color.Black;
                    Button_DayAll.BackColor = Color.White;
                    ArrayDays[31] = false;
                }
                else
                {
                    ArrayDays[day] = true;
                    control.ForeColor = Color.White;
                    control.BackColor = color;
                }
            }
        }

        private void Combo_Mode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DarcyComboBox control = (DarcyComboBox)sender;

            if (control.SelectedIndex == 0)
                Label_Help_Text_Mode.Text = "Replace changed files since last backup";
            else if (control.SelectedIndex == 1)
                Label_Help_Text_Mode.Text = "Create new copies every backup";
            else if (control.SelectedIndex == 2)
                Label_Help_Text_Mode.Text = "Replace all files every backup";

        }

        EntryClass entry;
        private bool ValidateInput()
        {
            
            entry = new EntryClass();
            

            //INPUT SOURCE
            if (Text_Source.Text.Length == 0)
            {
                Label_Error.Text = "Invalid input in Source";
                return false;
            }
            else if (File.Exists(Text_Source.Text) == false)
            {
                if (Directory.Exists(Text_Source.Text) == false)
                {
                    Label_Error.Text = "Invalid input in Source, file or folder does not exist";
                    return false;
                }
            }
            entry.Source = Text_Source.Text;

            
            //INPUT DESTINATION
            if (Text_Destination.Text.Length == 0)
            {
                Label_Error.Text = "Invalid input in Destination";
                return false;
            }
            String destination = Text_Destination.Text;
            if (destination.Last() != '\\')
                destination += "\\";
            if (Directory.Exists(destination) == false)
            {
                DialogResult res = MessageBox.Show("The specified destination folder does not exist. Do you want to create it?", "Folder does not exist", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(destination);
                        MessageBox.Show("Folder created successfully", "", MessageBoxButtons.OK);
                    }
                    catch (System.NotSupportedException)
                    {
                        MessageBox.Show("Folder name illegal", "Error", MessageBoxButtons.OK);
                        Label_Error.Text = "Illegal destination name";
                        return false;
                    }
                }
                else
                    return false;
            }
            entry.Destination = destination;


            //INPUT MODE

            if (Combo_Mode.SelectedIndex == -1)
            {
                Label_Error.Text = "No mode selected";
                return false;
            }

            entry.Mode = Combo_Mode.SelectedIndex;



            //INPUT PROCESS



            entry.Automated = true;

            //SCHEDULE
            if (Radio_Schedule.Checked == true)
            {
                entry.Process = 0;

                bool noDays = true;
                for (int i = 0; i < 31; i ++)
                {
                    if (ArrayDays[i] == true)
                        noDays = false;
                    entry.Days[i] = ArrayDays[i];
                }
                if (noDays == true)
                {
                    Label_Error.Text = "No days selected";
                    return false;
                }

                bool timeSuccess = false;
                if (Text_TimeOfDay.Text.Length == 5)
                {
                    string[] time = Text_TimeOfDay.Text.Split(':');

                    if (time.Length == 2)
                    {
                        if (time[0].Length == 2 && time[1].Length == 2)
                        {
                            int temp = 0;
                            if (Int32.TryParse(time[0], out temp) == true)
                            {
                                if (Int32.TryParse(time[1], out temp) == true)
                                {
                                    entry.TimeOfDay = Text_TimeOfDay.Text;
                                    timeSuccess = true;
                                }
                            }
                        }
                    }
                }
                if (timeSuccess == false)
                {
                    Label_Error.Text = "Illegal Time of day (24-hour format)";
                    return false;
                }
            }

                //TIMER
            else if (Radio_Timer.Checked == true)
            {
                entry.Process = 1;

                if (Text_Timer.Text.Length == 0)
                {
                    Label_Error.Text = "Invalid timer input";
                    return false;
                }

                int temp = 0;
                if (Int32.TryParse(Text_Timer.Text, out temp) == true)
                {
                    if (temp > 144000)
                    {
                        Label_Error.Text = "Timer too long";
                        return false;
                    }

                    entry.Timer = temp;
                }
                else
                {
                    Label_Error.Text = "Invalid timer input";
                    return false;
                }
            }
                //MANUAL
            else if (Radio_Manual.Checked == true)
            {
                entry.Process = 2;
                entry.Automated = false;
            }
            else
            {
                Label_Error.Text = "No process selected";
                return false;
            }

            entry.Entry = this.Id;

            if (Type == 1)
            {
                entry.Entry = Entry.Entry;
                entry.LastPerformed = Entry.LastPerformed;
            }

            return true;
        }

        private void OnSave()
        {
            bool validated = ValidateInput();

            if (validated == true)
            {
                Label_Error.Visible = false;
                Main.SaveEditNew(entry);
            }
            else
            {
                Label_Error.Visible = true;
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void Radio_Process_CheckedChanged(object sender, EventArgs e)
        {

            if (sender == Radio_Schedule)
            {
                Panel_Timer.Visible = false;
                Panel_Schedule.Visible = true;
            }
            else if (sender == Radio_Timer)
            {
                Panel_Schedule.Visible = false;
                Panel_Timer.Visible = true;
            }
            else if (sender == Radio_Manual)
            {
                Panel_Timer.Visible = false;
                Panel_Schedule.Visible = false;
            }
        }

        private void Button_Discard_Click(object sender, EventArgs e)
        {
            Main.DiscardEditNew();
        }

        private void Button_PickSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialogEx source = new Ionic.Utils.FolderBrowserDialogEx();
            source.Description = "Select a file or folder to backup";
            source.ShowNewFolderButton = true;
            source.ShowEditBox = true;
            source.ShowFullPathInEditBox = true;
            source.RootFolder = System.Environment.SpecialFolder.MyComputer;
            source.ShowBothFilesAndFolders = true;

            if (source.ShowDialog() == DialogResult.OK)
                Text_Source.Text = source.SelectedPath;
        }

        private void Button_PickFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialogEx destination = new Ionic.Utils.FolderBrowserDialogEx();
            destination.Description = "Select an output folder";
            destination.ShowNewFolderButton = true;
            destination.ShowEditBox = true;
            destination.ShowFullPathInEditBox = true;
            destination.RootFolder = System.Environment.SpecialFolder.MyComputer;
            destination.ShowBothFilesAndFolders = true;

            if (destination.ShowDialog() == DialogResult.OK)
                Text_Destination.Text = destination.SelectedPath;
        }

        private void Form_New_Entry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.DiscardEditNew();
            
        }

        private void Form_New_Entry_KeyPress(object sender, KeyPressEventArgs e)
        {
            //escape
            if (e.KeyChar == '\u001b')
            {
                Main.DiscardEditNew();
            }
            //return
            else if (e.KeyChar == '\r')
            {
                OnSave();
            }
            
        }

        private void Combo_Mode_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i = 0;
        }
    }
}
