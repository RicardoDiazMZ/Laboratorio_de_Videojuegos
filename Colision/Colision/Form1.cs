namespace Colision
{
    public partial class Form1 : Form
    {
        static Pelota p;
        static Scene scene;
        static Canvas canvas;

        public int x = 0;
        public int y = 0;
        public int boundX0 = 0, boundY0 = 0, boundX, boundY;

        bool up = false;
        bool down = true;
        bool right = true;
        bool left = false;

        public Form1()
        {
            InitializeComponent();
            p = new Pelota();
            init();
        }

        public void init()
        {
            boundX = pictureBox1.Width;
            boundY = pictureBox1.Height;
            scene = new Scene();
            canvas = new Canvas(pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = new Pelota();
            scene.Pelotas.Add(p);
            scene.add();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(x == boundX - 50)
            {
                right = false;
                left = true;
            }
            if (y == boundY - 55)
            {
                down = false;
                up = true;
            }
            if (x == boundX0 - 5)
            {
                right = true;
                left = false;
            }
            if (y == boundY0 - 5)
            {
                down = true;
                up = false;
            }

            if(up)
            {
                y -= 5;
            }
            if (down)
            {
                y += 5;
            }
            if (right)
            {
                x += 5;
            }
            if (left)
            {
                x -= 5;
            }
            canvas.Render(scene, x, y);
            label1.Text = "pelotas: " + scene.pelotas;
        }
    }
}