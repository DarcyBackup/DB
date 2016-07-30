using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    class UpdateClass
    {
        string _version;
        public UpdateClass(string version)
        {
            _version = version;
        }
        public void CheckUpdate()
        {
            
            Thread.Sleep(10000);

            /*WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://www.darcybackup.com/deploy/checkVersion.php");
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();*/

            //if (content != _version)
            {
                DialogResult res = MessageBox.Show("There is a new version available for download.\n\nDo you want to open the download page?", "New Version", MessageBoxButtons.YesNo);
                    
                if (res == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://www.darcybackup.com/#download");
                }
            }
        }
    }
}
