using System;
using System.Collections.Generic;
using System.Drawing;
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
        public DarcyLabel FocusLabel { get; set; }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg >= 0x201 && m.Msg <= 0x209)
            {
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                var hit = this.HitTest(pos);
                switch (hit.Location)
                {
                    case ListViewHitTestLocations.AboveClientArea:
                    case ListViewHitTestLocations.BelowClientArea:
                    case ListViewHitTestLocations.LeftOfClientArea:
                    case ListViewHitTestLocations.RightOfClientArea:
                    case ListViewHitTestLocations.None:
                        if (FocusLabel != null)
                            FocusLabel.Focus();
                        return;
                }
            }
            base.WndProc(ref m);
        }
    }
}
