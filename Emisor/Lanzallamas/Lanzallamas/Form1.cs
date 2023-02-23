using System.Windows.Forms;

namespace Lanzallamas
{
    public partial class Form1 : Form
    {
        static Emisor emisor = new Emisor();
        static Bitmap bmp;
        static Graphics g;
        static public float deltaTime;
        static int dt, n = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            if (pictureBox1.Width == 0)
                return;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            deltaTime = 1;
            pictureBox1.Image = bmp;

            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            g.DrawImage(Resource1.TrenchFloppa,0,0);

            if (emisor.b <= 14)
            {
                emisor.Emitir(bmp);
                n++;
                dt = 0;
            }
            else if (emisor.b >= 14)
            {
                emisor.Max(n);
                emisor.b--;
                n--;
                dt = 0;
            }

            emisor.Draw(g, bmp, deltaTime);
            g.DrawImage(Resource1.flamethrower, (bmp.Width / 2) + 25, (bmp.Height / 2) - 95);

            emisor.LifeTime(deltaTime);

            pictureBox1.Invalidate();
            deltaTime += .05f;
            dt += 1;
        }
    }
}