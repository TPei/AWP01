using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE01
{
    abstract class GeometricObject : Control
    {
        double relativeSize = 1;
        Color shapeColor = Color.FromArgb(0, 0, 0);

        public GeometricObject(){
            MouseClick += myMouseEventHandler;
        }

        private void myMouseEventHandler(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();

            // generate random color and call something in subclass with this color to repaint
            Random generator = new Random();
            int r = generator.Next(0, 256);
            int g = generator.Next(0, 256);
            int b = generator.Next(0, 256);

            setColor(Color.FromArgb(r, g, b));
            Refresh();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen p = new Pen(Color.Red, 1);
            int min = Math.Min(this.Width, this.Height);
            e.Graphics.DrawRectangle(p, 0, 0, min - 1, min - 1);

            int offset = (int)(min * getSize() / 2);

           this.specialPaint(e, min, offset);
        }

        protected abstract void specialPaint(PaintEventArgs e, int min, int offset);  //virtual??

        // returns relative size of geometric object
        public double getSize()
        {
            return relativeSize;
        }

        // sets reltive size of gemoetric object
        public void setSize(double size)
        {
            relativeSize = Math.Max(Math.Min(size, 1), 0.2);
        }

        // returns geometric objects' color
        public Color getColor()
        {
            return shapeColor;
        }

        // set geometric objects' color
        public void setColor(Color newColor)
        {
            shapeColor = newColor;
        }
    }
}
