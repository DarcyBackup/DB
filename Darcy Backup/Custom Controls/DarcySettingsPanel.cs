using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    class DarcySettingsPanel : Panel
    {
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen pen = new Pen(Color.FromArgb(130, 135, 144));

            //e.Graphics.DrawLine(pen, 0, 0, 0, Height);
            //e.Graphics.DrawLine(pen, 0, 0, Width, 0);
            e.Graphics.DrawLine(pen, 0, Height - 1, Width - 1, Height - 1);
            e.Graphics.DrawLine(pen, Width - 1, 0, Width - 1, Height);
            //e.Graphics.DrawLine(pen, 5, 124, Width - 16, 124);

            pen.Dispose();
        }
    }
}
