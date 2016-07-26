using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    class DarcyListView : ListView
    {
        public DarcyListView() : base()
        {
            this.DoubleBuffered = true;
        }
    }
}
