using System;
using System.Reflection;

namespace Particulas
{
    public partial class Form : System.Windows.Forms.Form
    {
        static Emisor emisor = new Emisor();
        static Bitmap bmp;
        static Graphics g;
        static public float deltaTime;
        static int dt, n = 0;

        public Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Form_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            if (pictureBox.Width == 0)
                return;

            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(bmp);
            deltaTime = 1;
            pictureBox.Image = bmp;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Black);

            if (emisor.b <= 500 && dt >= 2)
            {
                emisor.Emitir(bmp);
                n++;
                dt = 0;
            }
            else if(emisor.b >= 500 && dt >= 2)
            {
                emisor.Max(n);
                emisor.b--;
                n--;
                dt = 0;
            }
            emisor.Draw(g, bmp, deltaTime);

            emisor.LifeTime(deltaTime);

            pictureBox.Invalidate();
            deltaTime += .1f;
            dt += 1;
        }
    }
}