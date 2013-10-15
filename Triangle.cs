using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE01
{
    class Triangle : GeometricObject
    {
        public Triangle(double size)
        {
            setSize(size);
        }

        protected override void specialPaint(PaintEventArgs e, int min, int offset)
        {
            Pen p = new Pen(getColor(), 3);
            
            //e.Graphics.DrawRectangle(p, 0, 0, min - 2, min - 2);
            //e.Graphics.DrawPolygon(p, 

            Point point1 = new Point(offset, min - offset); // lower left
            Point point2 = new Point(min - offset, min - offset); // lower right
            Point point3 = new Point((min - 2) / 2, offset); // top, middle
            
            Point[] trianglePoints = { point1, point2, point3 };

            e.Graphics.DrawPolygon(p, trianglePoints);
        }
    }
}
