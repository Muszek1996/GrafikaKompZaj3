using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MojaBiblioteka;

namespace GrafikaKompZaj3
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 2);
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prosta a = new Prosta(new Punkt(123, 100), new Punkt(200, 200));
            Prosta b = new Prosta(new Punkt(100, 200), new Punkt(200, 100));
            Punkt x = new Punkt(a.Przeciecie(b));


            a.drawProsta(g, 1);
            b.drawProsta(g, 1);
            x.drawPunkt(g, 1);



        }
    }
}
