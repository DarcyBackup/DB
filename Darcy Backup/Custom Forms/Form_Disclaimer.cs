using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    public partial class Form_Disclaimer : Form
    {
        public bool Ok = false;
        private string _fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Darcy Backup\\ini.ini");
        private string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public Form_Disclaimer()
        {
            InitializeComponent();

            Text_License.ReadOnly = true;

            if (Directory.Exists(dirPath + "\\Darcy Backup") == false)
            {
                Directory.CreateDirectory(dirPath + "\\Darcy Backup");
            }

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
                    Application.Exit();
                }
                catch (System.NotSupportedException error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
            else
            {
                string[] str = File.ReadAllLines(_fullPath);
                if (str.Length == 1)
                {
                    if (str[0] == "1")
                    {
                        Ok = true;
                        return;
                    }
                }
            }
        }

        private void Save()
        {
            try
            {
                File.Delete(_fullPath);
            }
            catch (IOException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                Application.Exit();
            }
            catch (System.NotSupportedException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                Application.Exit();
            }
            
            try
            {
                FileStream fs = File.Create(_fullPath);
                fs.Close();
            }
            catch (IOException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                Application.Exit();
            }
            catch (System.NotSupportedException error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                Application.Exit();
            }

            if (File.Exists(_fullPath) == false)
                Application.Exit();


            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(_fullPath, true))
            {
                try
                {
                    file.WriteLine("1");
                }
                catch (IOException error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                    Application.Exit();
                }
                catch (System.NotSupportedException error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
        }
    

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
            return;
        }

        private void ButtonDecline_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
