using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            Graphics graf = CreateGraphics();
          
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Grid grid = new Grid();
            System.Drawing.Bitmap.GetPixelFormatSize(PixelFormat.Format32bppArgb);
            int pixelsSize = 20; 
            grid.DrawGrid(graphics, 0, 0, pictureBox1.Width, pictureBox1.Height, pixelsSize);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
