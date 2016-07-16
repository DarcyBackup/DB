using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darcy_Backup
{
    public class EntryClass
    {
        public int Entry;

        //Common
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Mode { get; set; }
        public int Process { get; set; }
        public bool Paused { get; set; }

        //Info
        public string LastPerformed { get; set; }
        public string NextScheduled { get; set; }
        public string TotalSize { get; set; }
        public bool Ongoing { get; set;  }


        //Scheduled
        public string TimeOfDay { get; set; }
        public bool[] Days { get; set; }


        //Timer
        public int Timer { get; set; }


        public EntryClass()
        {
            LastPerformed = "Never";

            Paused = false;

            Days = new bool[31];
            for (int i = 0; i < Days.Length; i++)
                Days[i] = false;
        }
    }
}
