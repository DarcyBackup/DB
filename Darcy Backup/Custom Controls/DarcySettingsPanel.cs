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

            Brush brush = (new Pen(Color.FromArgb(226, 226, 226))).Brush;
            Rectangle rect = new Rectangle(0, 12, Width, Height);
            e.Graphics.FillRectangle(brush, rect);



            Pen pen = new Pen(Color.FromArgb(175, 175, 175));

            e.Graphics.DrawLine(pen, 0, 12, 0, Height);
            e.Graphics.DrawLine(pen, Width - 1, 12, Width - 1, Height);
            e.Graphics.DrawLine(pen, 0, Height - 1, Width - 1, Height - 1);

            e.Graphics.DrawImage(Properties.Resources.SettingsArrow, new Point(21, 1));

            e.Graphics.DrawLine(pen, 0, 12, 20, 12);
            e.Graphics.DrawLine(pen, 42, 12, Width, 12);





            //e.Graphics.DrawLine(pen, 5, 124, Width - 16, 124);

            pen.Dispose();
        }
    }
}
