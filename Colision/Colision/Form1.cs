using System.Windows.Forms;

namespace Colision
{
    public partial class Form1 : Form
    {
        static Bitmap bmp;
        static Graphics g;
        static public float deltaTime;
        public List<Particula> particulas = new List<Particula>();
        public Random rand = new Random();
        public int b = 0;

        public Form1()
        {
            InitializeComponent();
            
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

        public void Emitir()
        {
            particulas.Add(new Particula(rand, bmp.Size, b));
            b++;
        }

        public void Draw(Graphics g, Bitmap bmp, float deltaTime)
        {
            Parallel.For(0, particulas.Count, b =>//ACTUALIZAMOS EN PARALELO
            {
                Particula P;
                particulas[b].Update(bmp, deltaTime, particulas);
                P = particulas[b];

            });

            Particula p;
            for (int b = 0; b < particulas.Count; b++)//PINTAMOS EN SECUENCIA
            {
                p = particulas[b];
                g.FillEllipse(new SolidBrush(p.c), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Emitir();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            g.Clear(Color.Black);

            Draw(g, bmp, deltaTime);

            label1.Text = "pelotas" + b;

            pictureBox1.Invalidate();

            deltaTime += .01f;
        }
    }
}