namespace Darcy_Backup
{
    partial class Form_Disclaimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Disclaimer));
            this.Text_License = new System.Windows.Forms.TextBox();
            this.Button_Accept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_Decline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Text_License
            // 
            this.Text_License.BackColor = System.Drawing.Color.White;
            this.Text_License.Enabled = false;
            this.Text_License.ForeColor = System.Drawing.Color.Black;
            this.Text_License.Location = new System.Drawing.Point(12, 73);
            this.Text_License.Multiline = true;
            this.Text_License.Name = "Text_License";
            this.Text_License.Size = new System.Drawing.Size(394, 303);
            this.Text_License.TabIndex = 0;
            this.Text_License.Text = resources.GetString("Text_License.Text");
            // 
            // Button_Accept
            // 
            this.Button_Accept.Location = new System.Drawing.Point(331, 382);
            this.Button_Accept.Name = "Button_Accept";
            this.Button_Accept.Size = new System.Drawing.Size(75, 23);
            this.Button_Accept.TabIndex = 1;
            this.Button_Accept.Text = "Accept";
            this.Button_Accept.UseVisualStyleBackColor = true;
            this.Button_Accept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "License Agreement";
            // 
            // Button_Decline
            // 
            this.Button_Decline.Location = new System.Drawing.Point(234, 382);
            this.Button_Decline.Name = "Button_Decline";
            this.Button_Decline.Size = new System.Drawing.Size(75, 23);
            this.Button_Decline.TabIndex = 3;
            this.Button_Decline.Text = "Decline";
            this.Button_Decline.UseVisualStyleBackColor = true;
            this.Button_Decline.Click += new System.EventHandler(this.ButtonDecline_Click);
            // 
            // Form_Disclaimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 412);
            this.Controls.Add(this.Button_Decline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Accept);
            this.Controls.Add(this.Text_License);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Disclaimer";
            this.Text = "Darcy Backup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Text_License;
        private System.Windows.Forms.Button Button_Accept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Decline;
    }
}