namespace Darcy_Backup
{
    partial class DarcyLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DarcyLogForm));
            this.Label_Entry = new System.Windows.Forms.Label();
            this.Label_Time = new System.Windows.Forms.Label();
            this.Text_Error = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label_Entry
            // 
            this.Label_Entry.AutoSize = true;
            this.Label_Entry.Font = new System.Drawing.Font("Calibri Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Entry.Location = new System.Drawing.Point(17, 27);
            this.Label_Entry.Name = "Label_Entry";
            this.Label_Entry.Size = new System.Drawing.Size(72, 33);
            this.Label_Entry.TabIndex = 0;
            this.Label_Entry.Text = "Entry";
            // 
            // Label_Time
            // 
            this.Label_Time.AutoSize = true;
            this.Label_Time.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.Label_Time.Location = new System.Drawing.Point(20, 81);
            this.Label_Time.Name = "Label_Time";
            this.Label_Time.Size = new System.Drawing.Size(71, 17);
            this.Label_Time.TabIndex = 1;
            this.Label_Time.Text = "Timestamp";
            // 
            // Text_Error
            // 
            this.Text_Error.BackColor = System.Drawing.Color.White;
            this.Text_Error.Enabled = false;
            this.Text_Error.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.Text_Error.ForeColor = System.Drawing.Color.Black;
            this.Text_Error.Location = new System.Drawing.Point(23, 115);
            this.Text_Error.Multiline = true;
            this.Text_Error.Name = "Text_Error";
            this.Text_Error.Size = new System.Drawing.Size(346, 150);
            this.Text_Error.TabIndex = 2;
            this.Text_Error.Text = "Error message";
            // 
            // DarcyLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(399, 301);
            this.Controls.Add(this.Text_Error);
            this.Controls.Add(this.Label_Time);
            this.Controls.Add(this.Label_Entry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DarcyLogForm";
            this.Text = "Log";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DarcyLogForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Entry;
        private System.Windows.Forms.Label Label_Time;
        private System.Windows.Forms.TextBox Text_Error;
    }
}