using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UE01
{
    public partial class myWindow : Form
    {
        // random number of elements
        static int noOfObjects = new Random().Next(0, 100);
        GeometricObject[] objects = new GeometricObject[noOfObjects];

        public myWindow()
        {
            InitializeComponent();
            
            // add all geometric objects
            addObjects();
        }

        // <summary>
        // add several gemoetric objects to the windows
        // </summary>
        public void addObjects()
        {
            // clear all previously drawn shapes
            this.Controls.Clear();

            
            System.Drawing.Size s = ClientSize; // ClientSize vs Size
            int width = s.Width;
            int height = s.Height;

            int size = calculateSize(width, height, noOfObjects); 

            // generate a random number of elements to displa
            Random generator = new Random();
            int column = 0, row = 0;
            
            for (int i = 0; i < objects.Length; i++)
            {
                int rand = generator.Next(0, 3);

                switch (rand)
                {
                    case 0:
                        objects[i] = new Rectangle(generator.NextDouble());
                        break;
                    case 1:
                        objects[i] = new Triangle(generator.NextDouble());
                        break;
                    default:
                        objects[i] = new Circle(generator.NextDouble());
                        break;
                }

                /*
                if (rand == 0)
                    objects[i] = new Rectangle();
                else if (rand == 1)
                    objects[i] = new Triangle();
                else
                    objects[i] = new Circle();
                */

                objects[i].Location = new System.Drawing.Point(column * size, row * size);
                objects[i].Size = new System.Drawing.Size(size, size);
                this.Controls.Add(objects[i]);

                if (((column + 1) * size)+size > width)
                {
                    column = 0;
                    row++;
                }
                else
                    column++;

            }
        }

        // <summary>
        // re-calls addObjects after windows was resized
        // </summary>
        protected override void OnResize(EventArgs e)
        {
            this.Controls.Clear();

            System.Drawing.Size s = ClientSize; // ClientSize vs Size
            int width = s.Width;
            int height = s.Height;

            int size = calculateSize(width, height, noOfObjects);

            int column = 0, row = 0;

            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] != null)
                {
                    objects[i].Location = new System.Drawing.Point(column * size, row * size);
                    objects[i].Size = new System.Drawing.Size(size, size);
                    this.Controls.Add(objects[i]);
                }

                if (((column + 1) * size) + size > width)
                {
                    column = 0;
                    row++;
                }
                else
                    column++;
            }


            //addObjects();
            //Refresh();
        }

        //<summary>
        // calculates size of elements when given window width / height and no of objects
        //</summary>
        private int calculateSize(int width, int height, int noOfObjects)
        {
            #region old algorithm
            /*// (try) to get the space each element has
            // PROBLEM: since they won't fit perfectly, space is wasted -> space calculation fails
            int availableArea = width * height;

            // get area per object and since they are squares, get width and height
            int areaPerObject = availableArea / noOfObjects;
            int size = (int)Math.Sqrt(areaPerObject);

            // simply counting how many elements fit in a row
            int elementsInRow = 0;
            for (int i = 0; ((i + 1) * size) <= width; i++, elementsInRow++) { }

            // calculate the space that is wasted per row
            int wasted = width - elementsInRow * size;


            double wastedPerCent = ((double)wasted / (double)width * 100) / 100;
            
            //int test = size;
            size = (int)(size * (1 - wastedPerCent));
            
            //this.Text = width + " " + wasted + " " + wastedPerCent + " " + (1-wastedPerCent) + " " + test + " " + size;*/
            #endregion
            // try to find optimum size, getting closer from both ends
            double high = (double)Math.Max(width, height);
            double low = 0.0;
            double mid;
            double midval;

            while (Math.Abs(high - low) > 0.000001)
            {
                mid = (low + high) / 2;
                midval = (double)((Math.Floor(width / mid) * Math.Floor(height / mid)));

                if (midval >= noOfObjects)
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }

            double test = (Math.Min(width / Math.Floor(width / low), high / Math.Floor(high / low)));
            int size = (int)test;
            this.Text = size + " " + test;
            return size;
        }

        #region stuff I don't need
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion 
    }
}