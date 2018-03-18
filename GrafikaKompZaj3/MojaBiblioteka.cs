using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace MojaBiblioteka
{
    class DrawString
    {
        public static void drawText(System.Drawing.Graphics g, string text, Punkt pos)
        {
            using (Font myFont = new Font("Arial", 9))
            {
                g.DrawString(text, myFont, Brushes.Black,pos);
               
            }
        }

    }
    class Punkt
    {
        public double x, y;
        public Punkt() { x = 0; y = 0; }
        public Punkt(Punkt copy) { x = copy.x; y = copy.y; }
        public Punkt(double a, double b) { x = a; y = b; }
        public static Punkt operator +(Punkt pierwszy, Punkt drugi) { return new Punkt(pierwszy.x + drugi.x, pierwszy.y + drugi.y); }
        public static Punkt operator *(double mnożnik, Punkt punkt) { return new Punkt(punkt.x * mnożnik, punkt.y * mnożnik); }
        public static Punkt operator -(Punkt pierwszy, Punkt drugi) { return new Punkt(pierwszy.x-drugi.x, pierwszy.y - drugi.y); }
        public static Punkt operator /( Punkt punkt, double mnożnik) { return new Punkt(punkt.x / mnożnik, punkt.y / mnożnik); }


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
