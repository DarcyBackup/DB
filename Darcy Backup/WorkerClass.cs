using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Darcy_Backup
{
    class WorkerClass 
    {
        Form_Darcy obj;
        public WorkerClass(Form_Darcy fd)
        {
            obj = fd;
        }

        public void Work()
        {
            while(true)
            {
                Thread.Sleep(10000);
                obj.CheckAction();
            }
        }
    }
}
