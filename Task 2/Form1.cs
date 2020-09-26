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
            Draw(graphics); 
          
        }

        void Draw(Graphics graphics)
        {
            Grid grid = new Grid();
          // System.Drawing.Bitmap.GetPixelFormatSize(PixelFormat.Format32bppArgb);
            int pixelsSize = 20;
            grid.DrawGrid(graphics, 0, 0, pictureBox1.Width, pictureBox1.Height, pixelsSize);

            int x1 = int.Parse(textBoxX1.Text);
            int y1 = int.Parse(textBoxY1.Text);
            int x2 = int.Parse(textBoxX2.Text);
            int y2 = int.Parse(textBoxY2.Text);

            grid.DrawBresenhamLine(graphics, x1, y1, x2, y2);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBoxX1.Text);
            int y1 = int.Parse(textBoxY1.Text);
            int x2 = int.Parse(textBoxX2.Text);
            int y2 = int.Parse(textBoxY2.Text);
            Graphics graphics = CreateGraphics();
            Draw(graphics); 
        
            pictureBox1.Refresh(); 
        }
    }
}
