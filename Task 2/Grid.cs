using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Grid
    {
        private int pixelsWidht;
        private int pixelsHeight; 

        public void DrawGrid(Graphics graphics, int x, int y, int width, int height, int amount)
        {
            Pen pen = new Pen(Color.Black, 2);
            int temp = 0;
            pixelsHeight = (width - x) / amount;
            for (int i = 0; i <= amount; i++)
            {
                graphics.DrawLine(pen, temp, y, temp, height); //Draw Y
                temp += pixelsHeight;
            }
            pixelsWidht = (height - y) / amount;
            for (int i = 0; i <= amount; i++)
            {
                graphics.DrawLine(pen, x, temp, width, temp); //Draw X
                temp += pixelsWidht;
            }
            pen.Dispose();
        }
        
        public void DrawPixel(Graphics graphics, int x, int y){
            Brush brush = new SolidBrush(Color.Black);
            graphics.FillRectangle(brush, x, y, pixelsWidht, pixelsHeight);
            brush.Dispose(); 
        }

    }
}
