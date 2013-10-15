using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE01
{
    class Circle : GeometricObject
    {
        public Circle(double size)
        {
            setSize(size);
        }

        protected override void specialPaint(PaintEventArgs e, int min, int offset)
        {
            Pen p = new Pen(getColor(), 3);

            e.Graphics.DrawEllipse(p, offset, offset, min - 2 * offset, min - 2 * offset);
        }
    }
}
