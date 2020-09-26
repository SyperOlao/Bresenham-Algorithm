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
            temp = 0; 
            for (int i = 0; i <= amount; i++)
            {
                graphics.DrawLine(pen, x, temp, width, temp); //Draw X
                temp += pixelsWidht;
            }

            pen.Dispose();
        }
        
        public void DrawPixel(Graphics graphics, int x, int y){
            Brush brush = new SolidBrush(Color.Black);
            int bitMapXCoordinate = (x - 1) * pixelsHeight;
            int bitMapYCoordinate = (y - 1) * pixelsWidht; 

            Rectangle drawPixelRect = new Rectangle(bitMapXCoordinate, bitMapYCoordinate, 20, 20);
            graphics.FillRectangle(brush, drawPixelRect);
            brush.Dispose(); 
        }

        public void Algoritnm(Graphics graphics, int x1, int y1, int x2, int y2)
        {
            if (x1 > x2)
            {
                int temp = x2;
                x2 = x1;
                x1= temp;
                temp = y2;
                y2 = y1;
                y1= temp;
            }
            int px = x2 - x1;
            int py = y2 - y1;
            int e = 2 * py - px;
            int x = x1;
            int y = y1;
            DrawPixel(graphics, x1, y1);
            while (x < x2)
            {
                if (e > 0)
                {
                    y++;
                    e += 2 * (py - px);
                }
                else
                {
                    e += 2 * py;
                }
                x++;
                DrawPixel(graphics, x, y);
            }
        }

        private int Check(int x)
        {
            return (x > 0) ? 1 : (x < 0) ? -1 : 0;
            //возвращает 0, если аргумент (x) равен нулю; -1, если x < 0 и 1, если x > 0.
        }

        public void DrawBresenhamLine(Graphics graphics, int x1, int y1, int x2, int y2){
   
            int x, y, dx, dy, incx, incy, pdx, pdy, Eshort, Elong, Error;
            dx = x2 - x1;//проекция на ось x
            dy = y2 - y1;//проекция на ось y

            incx = Check(dx);
            incy = Check(dy);
          
            dx = Math.Abs(dx);
            dy = Math.Abs(dy);

            if (dx > dy)
            {
                pdx = incx; pdy = 0;
                Eshort = dy; Elong = dx;
            }
            else//случай, когда прямая, вытянута по оси y
            {
                pdx = 0; pdy = incy;
                Eshort = dx; Elong = dy;//тогда в цикле будем двигаться по y
            }

            x = x1;
            y = y1;
            Error = Elong / 2;
                                                     
            DrawPixel(graphics, x, y);            

            for (int i = 0; i < Elong; i++)
            {
                Error -= Eshort;
                if (Error < 0)
                {
                    Error += Elong;
                    x += incx;//сдвинуть прямую (сместить вверх или вниз, если цикл проходит по иксам)
                    y += incy;//или сместить влево-вправо, если цикл проходит по y
                }
                else
                {
                    x += pdx;
                    y += pdy;
                }

                DrawPixel(graphics, x, y);
            }
        }

    }
}
