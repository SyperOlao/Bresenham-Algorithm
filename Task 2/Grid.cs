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
        private int pixelsWidth;
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

            pixelsWidth = (height - y) / amount;
            temp = 0;
            for (int i = 0; i <= amount; i++)
            {
                graphics.DrawLine(pen, x, temp, width, temp); //Draw X
                temp += pixelsWidth;
            }

            pen.Dispose();
        }

        public void DrawPixel(Graphics graphics, int x, int y)
        {
            Brush brush = new SolidBrush(Color.Black);
            int bitMapXCoordinate = (x - 1) * pixelsHeight;
            int bitMapYCoordinate = (y - 1) * pixelsWidth;

            Rectangle drawPixelRect = new Rectangle(bitMapXCoordinate, bitMapYCoordinate, 20, 20);
            graphics.FillRectangle(brush, drawPixelRect);
            brush.Dispose();
        }

       
    }
}