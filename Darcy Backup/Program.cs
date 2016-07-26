using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form_Disclaimer fd = new Form_Disclaimer();
            if (fd.Ok == true)
            {
                Application.Run(new Form_Darcy_Panel());
            }
            else
            {
                Application.Run(fd);
                fd.Dispose();
                Application.Run(new Form_Darcy_Panel());
                
            }
            //Application.Run(new Form_New_Entry(0, 1));
        }
    }
}
