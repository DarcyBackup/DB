﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Darcy_Backup
{
    public partial class Form_Darcy
    {
        private int loaded = -1;
        private bool changes = false;
        private int lastLine = -1;

        private string currPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private string fullPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\db.dbss";

        private entryStruct[] entries;

        private buttonEnabledStruct buttonEnabled;
        private struct buttonEnabledStruct
        {
            public bool Button_Save;
            public bool Button_Discard;
        }

        private struct entryStruct
        {
            
            public int entry;
            public string source;
            public string destination;
            public int frequency;
            public bool differential;

            public string lastPerformed;

            public bool ongoing;

            public bool validated;
            public bool newEntry;

        }
    }
}
