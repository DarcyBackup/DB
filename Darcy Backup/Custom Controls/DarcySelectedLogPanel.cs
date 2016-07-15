using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    public class DarcySelectedLogPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            Pen pen = new Pen(Color.FromArgb(130, 135, 144));

            e.Graphics.DrawLine(pen, 12, 60, 432, 60);
            e.Graphics.DrawLine(pen, 12, 370, 432, 370);

            pen.Dispose();
        }

    }
}
