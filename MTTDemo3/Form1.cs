using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTTDemo3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawRedRect(object sender, EventArgs e)
        {
            // Red Rectangles
            Graphics red = panel1.CreateGraphics();
            Random rnd = new Random();
            //random hex color code
            Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 1; i < 1000; i++)
                {
                    Pen p = new Pen(Color.FromArgb(rnd.Next()));
                    int x = rnd.Next(panel1.Height);
                    int y = rnd.Next(panel1.Width);
                    int height = rnd.Next(100);
                    int width = rnd.Next(100);
                    //rectangle with random colors
                    red.DrawRectangle(p, x, y, height, width);
                    Thread.Sleep(100);
                }
            });
        }

        private void DrawBlueRect(object sender, EventArgs e)
        {
            //Blue Rectangles
            Graphics blue = panel2.CreateGraphics();
            Random rnd = new Random();
            Task t2 = Task.Factory.StartNew(() =>
            {
                for (int i = 1; i < 1000; i++)
                {
                    int x = rnd.Next(panel2.Height);
                    int y = rnd.Next(panel2.Width);
                    int height = rnd.Next(100);
                    int width = rnd.Next(100);
                    blue.DrawRectangle(Pens.Blue, x, y, height, width);
                    Thread.Sleep(100);
                }
            });
        }
    }
}
