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

        public void AlgoritmEllips(Graphics graphics, int x1, int y1, int width, int height)
        {
            DrawPixel(graphics, x1 + width, y1 + height / 2);
            DrawPixel(graphics, x1 + width / 2, y1);
            DrawPixel(graphics, x1, y1 + height / 2);
            DrawPixel(graphics, x1 + width / 2, y1 + height);

            double Y = 0;
            int X1 = x1 + width;
            double X2 = 0;

            int Xdraw = 0;
            int Ydraw = 0;
            int YIterator = y1 + height / 2 + 1;
            double delta = 0;
          
            for (int i = x1 + width - 1; i > x1 + width / 2; i--)
            {
                Y = ((double)y1 + 0.5 * (double)height + (1 / (double)width) * (Math.Sqrt(0.25 * (double)(width * width) * (double)(height * height) - Math.Pow((i - (double)x1 - 0.5 * (double)width), 2) * Math.Pow((double)height, 2))));
                if (Math.Abs(x1 + width / 2 - i) >= Math.Abs(y1 + height / 2 - Y))
                {
                    X2 = (double)x1 + 0.5 * (double)width + (1 / (double)height) * Math.Sqrt(0.25 * (double)(width * width) * (double)(height * height) - Math.Pow(((double)YIterator - (double)y1 - 0.5 * (double)height), 2) * Math.Pow((double)width, 2));

                    delta = Math.Abs(X2 - X1);

                    if (delta < 0.5)
                    {
                        Xdraw = X1;
                    }
                    else
                    {
                        if ((X2 - X1) > 0)
                        {
                            Xdraw = X1 + 1;
                        }
                        else
                        {
                            Xdraw = X1 - 1;
                        }
                    }
                    X1 = (int)Math.Round(X2);

                    DrawPixel(graphics, Xdraw, YIterator);

                    YIterator++;
                }
                else
                {
                 
                    delta = Math.Abs(YIterator - Y);

                    if (delta < 0.5)
                    {
                        Ydraw = YIterator;
                    }
                    else
                    {
                        if ((Y-YIterator) > 0)
                        {
                            Ydraw = YIterator + 1;
                        }
                        else
                        {
                            Ydraw = YIterator - 1;
                        }
                    }
                    YIterator = (int)Math.Round(Y);

                    DrawPixel(graphics, i, Ydraw);

                    YIterator++;
                }
            }
        }




        private int Check(int x)
        {
            return (x > 0) ? 1 : (x < 0) ? -1 : 0;
            //возвращает 0, если аргумент (x) равен нулю; -1, если x < 0 и 1, если x > 0.
        }

        public void DrawBresenhamLine(Graphics graphics, int x1, int y1, int x2, int y2)
        {

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
