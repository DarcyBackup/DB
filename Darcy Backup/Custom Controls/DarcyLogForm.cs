using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    public partial class DarcyLogForm : Form
    {
        public DarcyLogForm(string entry, string time, string error, Color theme)
        {
            InitializeComponent();

            this.KeyPreview = true;

            Label_Entry.Text = entry;
            Label_Entry.ForeColor = theme;
            Label_Time.Text = time;
            Text_Error.Text = error;
        }

        private void DarcyLogForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\u001b')
            {
                this.Dispose();
            }
        }
    }
}
