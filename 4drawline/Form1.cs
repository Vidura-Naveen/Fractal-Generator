using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4drawline
{
    public partial class Form1 : Form
    {
        List<Point> curve;//hold the curve
        int iteration = 18;
        int w = 2;
        
        

        public Form1()
        {
            InitializeComponent();
            curve = new List<Point>();
            curve.Add(new Point(500, 500));
            curve.Add(new Point(500+w, 500));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
      

       

        public void populate()
        {
            
            curve.Clear();
            curve.Add(new Point(500, 500));
            curve.Add(new Point(500 + w, 500));
            for (int i = 0; i < iteration; i++)
            {
                Point last = curve[curve.Count - 1];
                for (int j = curve.Count - 2; j >= 0; j--)
                {
                    curve.Add(rotate(curve[j], last));
                   
                }
            }
        }

         public Point rotate(Point p, Point p0)

            {
                int x_ = (p.Y - p0.Y) + p0.X;
                int y_ = -(p.X - p0.X) + p0.Y;
                return new Point(x_, y_);
             }

         private void Form1_Paint(object sender, PaintEventArgs e)
         {
             Graphics g = e.Graphics;
             populate();

             for (int i = 1; i < curve.Count; i++)
             {
                 g.DrawLine(Pens.Blue, curve[i - 1], curve[i]);
             }


         }     
        
    }
}
