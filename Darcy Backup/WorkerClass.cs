﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;

namespace Darcy_Backup
{
    class WorkerClass 
    {
        Form_Darcy_Panel obj;
        public WorkerClass(Form_Darcy_Panel fd)
        {
            obj = fd;
        }

        public void Work()
        {
            while (true)
            {
                Thread.Sleep(10000);
                obj.CheckAction();
            }
        }
    }
}
