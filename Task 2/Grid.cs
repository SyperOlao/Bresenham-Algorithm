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

        private int sign(int x)
        {
            return (x > 0) ? 1 : (x < 0) ? -1 : 0;
            //возвращает 0, если аргумент (x) равен нулю; -1, если x < 0 и 1, если x > 0.
        }

        public void DrawBresenhamLine(int xstart, int ystart, int xend, int yend, Graphics g){
            Pen pen = new Pen(Color.Black);
            int x, y, dx, dy, incx, incy, pdx, pdy, es, el, err;
            dx = xend - xstart;//проекция на ось икс
            dy = yend - ystart;//проекция на ось игрек

            incx = sign(dx);
            /*
             * Определяем, в какую сторону нужно будет сдвигаться. Если dx < 0, т.е. отрезок идёт
             * справа налево по иксу, то incx будет равен -1.
             * Это будет использоваться в цикле постороения.
             */
            incy = sign(dy);
            /*
             * Аналогично. Если рисуем отрезок снизу вверх -
             * это будет отрицательный сдвиг для y (иначе - положительный).
             */

            if (dx < 0) dx = -dx;//далее мы будем сравнивать: "if (dx < dy)"
            if (dy < 0) dy = -dy;//поэтому необходимо сделать dx = |dx|; dy = |dy|
                                 //эти две строчки можно записать и так: dx = Math.abs(dx); dy = Math.abs(dy);

            if (dx > dy)
            //определяем наклон отрезка:
            {
                /*
                 * Если dx > dy, то значит отрезок "вытянут" вдоль оси икс, т.е. он скорее длинный, чем высокий.
                 * Значит в цикле нужно будет идти по икс (строчка el = dx;), значит "протягивать" прямую по иксу
                 * надо в соответствии с тем, слева направо и справа налево она идёт (pdx = incx;), при этом
                 * по y сдвиг такой отсутствует.
                 */
                pdx = incx; pdy = 0;
                es = dy; el = dx;
            }
            else//случай, когда прямая скорее "высокая", чем длинная, т.е. вытянута по оси y
            {
                pdx = 0; pdy = incy;
                es = dx; el = dy;//тогда в цикле будем двигаться по y
            }

            x = xstart;
            y = ystart;
            err = el / 2;
                                                     //ставим первую точку
            DrawPixel(g, x, y);                     //все последующие точки возможно надо сдвигать, поэтому первую ставим вне цикла

            for (int t = 0; t < el; t++)//идём по всем точкам, начиная со второй и до последней
            {
                err -= es;
                if (err < 0)
                {
                    err += el;
                    x += incx;//сдвинуть прямую (сместить вверх или вниз, если цикл проходит по иксам)
                    y += incy;//или сместить влево-вправо, если цикл проходит по y
                }
                else
                {
                    x += pdx;//продолжить тянуть прямую дальше, т.е. сдвинуть влево или вправо, если
                    y += pdy;//цикл идёт по иксу; сдвинуть вверх или вниз, если по y
                }

                DrawPixel(g, x, y);
            }
        }

    }
}
