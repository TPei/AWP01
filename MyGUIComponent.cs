using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE01
{
    class MyGUIComponent : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen p = new Pen(Color.Red, 1);
            int min = Math.Min(this.Width, this.Height);
            e.Graphics.DrawRectangle(p, 0, 0, min-1, min-1);

            p = new Pen(Color.Black, 1);
            e.Graphics.DrawEllipse(p, 0, 0, min-1, min-1);
        }
    }
}
