using System;
using System.Reflection.Metadata;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Actividad3
{
    public partial class Form : System.Windows.Forms.Form
    {
        Bitmap bmp;
        Graphics g;

        public PointF a, b, c, d;

        public Form()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            g.Clear(Color.Transparent);
            g.DrawLine(Pens.White, bmp.Width / 2, 0, bmp.Width / 2, bmp.Height);
            g.DrawLine(Pens.White, 0, bmp.Height / 2, bmp.Width, bmp.Height / 2);

            pictureBox1.Invalidate();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void RenderOrigen()
        {
            a = new Point(0, 0);
            b = new Point(0, 100);
            c = new Point(100, 100);
            d = new Point(100, 0);

            g.Clear(Color.Transparent);
            g.DrawLine(Pens.White, bmp.Width / 2, 0, bmp.Width / 2, bmp.Height);
            g.DrawLine(Pens.White, 0, bmp.Height / 2, bmp.Width, bmp.Height / 2);

            Origen(a, b);
            Origen(b, c);
            Origen(c, d);
            Origen(d, a);

            pictureBox1.Invalidate();
        }

        private void RenderPivote()
        {
            a = new Point(0, 0);
            b = new Point(0, 100);
            c = new Point(100, 100);
            d = new Point(100, 0);

            g.Clear(Color.Transparent);
            g.DrawLine(Pens.White, bmp.Width / 2, 0, bmp.Width / 2, bmp.Height);
            g.DrawLine(Pens.White, 0, bmp.Height / 2, bmp.Width, bmp.Height / 2);

            pictureBox1.Invalidate();
        }

        private void RenderCentro()
        {
            a = new Point(0, 0);
            b = new Point(0, 100);
            c = new Point(100, 100);
            d = new Point(100, 0);

            g.Clear(Color.Transparent);
            g.DrawLine(Pens.White, bmp.Width / 2, 0, bmp.Width / 2, bmp.Height);
            g.DrawLine(Pens.White, 0, bmp.Height / 2, bmp.Width, bmp.Height / 2);

            Centro(a, b);
            Centro(b, c);
            Centro(c, d);
            Centro(d, a);

            pictureBox1.Invalidate();
        }
        private PointF Rotate(PointF a)
        {
            double angle = double.Parse(textBox1.Text) * Math.PI / 180;
            PointF b = new PointF();
            b.X = (float)((a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle)));
            b.Y = (float)((a.X * Math.Sin(angle)) + (a.Y * Math.Cos(angle)));
            return b;
        }

        private PointF TranslateToCenter(PointF a)
        {
            int Sx = (bmp.Width / 2);
            int Sy = (bmp.Height / 2);
            return new PointF(Sx + a.X, Sy - a.Y);
        }

        private PointF Translate(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        private void Origen(PointF a, PointF b)
        {
            a = Translate(a, new PointF(-50, -50)); // centroide
            b = Translate(b, new PointF(-50, -50)); // centroide

            PointF c = Rotate(a);
            PointF d = Rotate(b);//*/

            c = TranslateToCenter(c);
            d = TranslateToCenter(d);
            c = Translate(c, new PointF(0, 0));
            d = Translate(d, new PointF(0, 0));

            g.DrawLine(Pens.YellowGreen, c, d);
        }

        private void Pivote(PointF a, PointF b, PointF c, PointF d)
        {
            double angle = double.Parse(textBox1.Text) * Math.PI / 180;

            PointF a2, b2, c2, d2;

            int Sx = (bmp.Width / 2);
            int Sy = (bmp.Height / 2);

            a2 = new PointF();
            b2 = new PointF();
            c2 = new PointF();
            d2 = new PointF();

            a2.X = Sx + (float)((a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle)));
            a2.Y = Sy - (float)((a.X * Math.Sin(angle)) + (a.Y * Math.Cos(angle)));
            b2.X = Sx + (float)((b.X * Math.Cos(angle)) - (b.Y * Math.Sin(angle)));
            b2.Y = Sy - (float)((b.X * Math.Sin(angle)) + (b.Y * Math.Cos(angle)));
            c2.X = Sx + (float)((c.X * Math.Cos(angle)) - (c.Y * Math.Sin(angle)));
            c2.Y = Sy - (float)((c.X * Math.Sin(angle)) + (c.Y * Math.Cos(angle)));
            d2.X = Sx + (float)((d.X * Math.Cos(angle)) - (d.Y * Math.Sin(angle)));
            d2.Y = Sy - (float)((d.X * Math.Sin(angle)) + (d.Y * Math.Cos(angle)));

            g.DrawLine(Pens.YellowGreen, a2, b2);
            g.DrawLine(Pens.YellowGreen, b2, c2);
            g.DrawLine(Pens.YellowGreen, c2, d2);
            g.DrawLine(Pens.YellowGreen, d2, a2);
        }

        private void Centro(PointF a, PointF b)
        {
            a = Translate(a, new PointF(-50, -50)); // centroide
            b = Translate(b, new PointF(-50, -50)); // centroide

            PointF c = Rotate(a);
            PointF d = Rotate(b);

            c = TranslateToCenter(c);
            d = TranslateToCenter(d);
            c = Translate(c, new PointF(50, -50));
            d = Translate(d, new PointF(50, -50));

            g.DrawLine(Pens.YellowGreen, c, d);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            RenderOrigen();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            g.Clear(Color.Transparent);
            RenderPivote();
            Pivote(a, b, c, d);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            RenderCentro();
        }

    }
}