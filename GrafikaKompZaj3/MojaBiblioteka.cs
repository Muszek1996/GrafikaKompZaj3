﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace MojaBiblioteka
{

    class Punkt
    {
        public double x, y;
        public Punkt() { x = 0; y = 0; }
        public Punkt(Punkt copy) { x = copy.x; y = copy.y; }
        public Punkt(double a, double b) { x = a; y = b; }
        public static Punkt operator +(Punkt pierwszy, Punkt drugi) { return new Punkt(pierwszy.x + drugi.x, pierwszy.y + drugi.y); }
        public static Punkt operator *(double mnożnik, Punkt punkt) { return new Punkt(punkt.x * mnożnik, punkt.y * mnożnik); }

        public void drawPunkt(System.Drawing.Graphics g, int level)
        {
            using (Font myFont = new Font("Arial", 9))
            {
               
                string pos = "(" + Math.Round(x,2).ToString() + "," + Math.Round(y, 2).ToString() + ")";
                g.DrawString(".", new Font("Arial", 25), Brushes.Red, new Point((int)x - 10, (int)y - 29));
                if (level == 1)
                    g.DrawString(pos, myFont, Brushes.Green, new Point((int)x, (int)y - 15));
            }
        }

        public static implicit operator PointF(Punkt a)
        {
            return new PointF((float)a.x, (float)a.y);
        }


    }
    class Prosta
    {
        public Punkt start, end;

        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 2);
        public double countDelta(Prosta drugaProsta)
        {
            double x1, x2, x3, x4, y1, y2, y3, y4;
            x1 = start.x;
            x2 = end.x;
            x3 = drugaProsta.start.x;
            x4 = drugaProsta.end.x;
            y1 = start.y;
            y2 = end.y;
            y3 = drugaProsta.start.y;
            y4 = drugaProsta.end.y;
            double delta = (x2 - x1) * (y3 - y4) - (x3 - x4) * (y2 - y1);
            return delta;
        }
        public double countDeltaMi(Prosta drugaProsta)
        {
            if (countDelta(drugaProsta) == 0) return 0;
            double x1, x2, x3, x4, y1, y2, y3, y4;
            x1 = start.x;
            x2 = end.x;
            x3 = drugaProsta.start.x;
            x4 = drugaProsta.end.x;
            y1 = start.y;
            y2 = end.y;
            y3 = drugaProsta.start.y;
            y4 = drugaProsta.end.y;

            double deltaMi = (x3 - x1) * (y3 - y4) - (x3 - x4) * (y3 - y1);
            return deltaMi;
        }

        public double countMi(Prosta drugaProsta)
        {
            double mi = countDeltaMi(drugaProsta) / countDelta(drugaProsta);
            return mi;
        }
        public Punkt Przeciecie(Prosta druga)
        {
            Punkt p1 = (1 - countMi(druga)) * this.start + (countMi(druga) * end);
            return p1;
        }

        public void drawProsta(System.Drawing.Graphics g, int level)
        {
            start.drawPunkt(g, level);
            end.drawPunkt(g, level);
            g.DrawLine(pen1, start, end);
        }

        public Prosta(Punkt a, Punkt b)
        {
            start = new Punkt(a);
            end = new Punkt(b);
        }



    }
}