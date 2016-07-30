using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Darcy_Backup
{
    class DarcyLabel : Label
    {
        public DarcyLabel() : base()
        {
            DoubleBuffered = true;
        }
    }
}
