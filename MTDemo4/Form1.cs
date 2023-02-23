using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTDemo4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Image Rotation Sequential 
            Stopwatch sw = Stopwatch.StartNew();
            //Get all images
            foreach (var file in Directory.GetFiles(@"C:\Training\Day 14\images"))
            {
                // Load Image
                Image img = Image.FromFile(file);
                // Rotate Image
                img.RotateFlip(RotateFlipType.Rotate180FlipX);
                // Save Image
                FileInfo fi = new FileInfo(file);
                img.Save($@"C:\Training\Day 14\rotated\{fi.Name}");
            }
            MessageBox.Show($"Done in {sw.ElapsedMilliseconds}s");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Rotate Images using Parallel Foreach

            Stopwatch sw = Stopwatch.StartNew();
            //Get all images
            Parallel.ForEach(Directory.GetFiles(@"C:\Training\Day 14\images"), (file) =>
            {
                // Load Image
                Image img = Image.FromFile(file);
                // Rotate Image
                img.RotateFlip(RotateFlipType.Rotate180FlipX);
                // Save Image
                FileInfo fi = new FileInfo(file);
                img.Save($@"C:\Training\Day 14\rotated\{fi.Name}");
            });
            MessageBox.Show($"Done in {sw.ElapsedMilliseconds}s");
        }
    }
}
