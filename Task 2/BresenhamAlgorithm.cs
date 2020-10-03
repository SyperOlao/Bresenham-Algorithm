using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class BresenhamAlgorithm
    {
        
        public void DrawBresenhamLine(Graphics graphics,Grid grid,int x1, int y1, int x2, int y2)
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

            grid.DrawPixel(graphics, x, y);

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

                grid.DrawPixel(graphics, x, y);
            }
        }
        private int Check(int x)
        {
            return (x > 0) ? 1 : (x < 0) ? -1 : 0;
            //возвращает 0, если аргумент (x) равен нулю; -1, если x < 0 и 1, если x > 0.
        }

        public void DrawEllips(Graphics graphics,Grid grid, int xc, int yc, int rx, int ry)
        {
            double dx, dy, d1, d2;
            int x, y;
            x = 0;
            y = ry;

            // Initial decision parameter of region 1 
            d1 = (ry * ry) - (rx * rx * ry) + (0.25 * rx * rx);
            dx = 2 * ry * ry * x;
            dy = 2 * rx * rx * y;

            // For region 1 
            while (dx < dy)
            {

                // Print points based on 4-way symmetry 
                grid.DrawPixel(graphics, x + xc, y + yc);
                grid.DrawPixel(graphics, -x + xc, y + yc);
                grid.DrawPixel(graphics, x + xc, -y + yc);
                grid.DrawPixel(graphics, -x + xc, -y + yc);

                // Checking and updating value of 
                // decision parameter based on algorithm 
                if (d1 < 0)
                {
                    x++;
                    dx = dx + (2 * ry * ry);
                    d1 = d1 + dx + (ry * ry);
                }
                else
                {
                    x++;
                    y--;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d1 = d1 + dx - dy + (ry * ry);
                }
            }

            // Decision parameter of region 2 
            d2 = ((ry * ry) * ((x + 0.5) * (x + 0.5))) +
                 ((rx * rx) * ((y - 1) * (y - 1))) -
                  (rx * rx * ry * ry);

            // Plotting points of region 2 
            while (y >= 0)
            {

                // Print points based on 4-way symmetry 
                grid.DrawPixel(graphics, x + xc, y + yc);
                grid.DrawPixel(graphics, -x + xc, y + yc);
                grid.DrawPixel(graphics, x + xc, -y + yc);
                grid.DrawPixel(graphics, -x + xc, -y + yc);

                // Checking and updating parameter 
                // value based on algorithm 
                if (d2 > 0)
                {
                    y--;
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + (rx * rx) - dy;
                }
                else
                {
                    y--;
                    x++;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + dx - dy + (rx * rx);
                }
            }
        }
    }
}
