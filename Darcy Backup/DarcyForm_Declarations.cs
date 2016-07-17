using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    public partial class Form_Darcy_Panel
    {

        private string _currPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private string _fullPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\db.dbss";

        private EntryClass[] Entries;

        private resizeStruct[] _resizeArray;

        private int _currentListSel = -1;

        private bool _editNewOngoing = false;
        private Form_New_Entry _editNewObj;

        private struct resizeStruct
        {
            public Control control;
            public int width;
            public int height;
            public bool stayX;
            public bool stayY;
        }
    }
}
