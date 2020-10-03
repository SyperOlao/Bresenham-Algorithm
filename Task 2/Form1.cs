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

        
        private void Form1_Resize(object sender, EventArgs e)
        {
            Graphics graf = CreateGraphics();
          
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Draw(graphics);
            DrawEllips(graphics); 
          
        }

        void Draw(Graphics graphics)
        {
            Grid grid = new Grid();
            
            int pixelsSize = 20;
            grid.DrawGrid(graphics, 0, 0, pictureBox1.Width, pictureBox1.Height, pixelsSize);
           
            int x1 = int.Parse(textBoxX1.Text);
            int y1 = int.Parse(textBoxY1.Text);
            int x2 = int.Parse(textBoxX2.Text);
            int y2 = int.Parse(textBoxY2.Text);
            BresenhamAlgorithm bresenhamAlgorithm = new BresenhamAlgorithm();
            bresenhamAlgorithm.DrawBresenhamLine(graphics,grid, x1, y1, x2, y2);
            
        }

        void DrawEllips(Graphics graphics)
        {
            Grid grid = new Grid();
            int pixelsSize = 20;
            grid.DrawGrid(graphics, 0, 0, pictureBox1.Width, pictureBox1.Height, pixelsSize);
           
            int Ex1 = int.Parse(textBoxX1Ellips.Text);
            int Ey1 = int.Parse(textBoxY1Ellips.Text);
            int width = int.Parse(textBoxWidthEllips.Text);
            int height = int.Parse(textBoxHeightEllips.Text);
            BresenhamAlgorithm bresenhamAlgorithm = new BresenhamAlgorithm();
            bresenhamAlgorithm.DrawEllips(graphics,grid,Ex1, Ey1, width, height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = CreateGraphics();
            Draw(graphics);
            pictureBox1.Refresh(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = CreateGraphics();
            DrawEllips(graphics);  
            pictureBox1.Refresh();
        }
    }
}
