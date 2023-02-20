using System.Drawing;
using System.Windows.Forms;

namespace Perspectiva_3D
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Vertex[] vertices;
        public Scene scene;
        public int[,] faces;
        public int angle;

        public Form()
        {
            InitializeComponent();

            timer1.Start();

            init();

            scene = new Scene(new Figure(vertices, faces));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            scene.Draw(g, ClientSize.Width, ClientSize.Height);
        }

        private void init()
        {
            vertices = new Vertex[]
            {
                new Vertex(-1, 1, -1),
                new Vertex(1, 1, -1),
                new Vertex(1, -1, -1),
                new Vertex  (-1, -1, -1),
                new Vertex(-1, 1, 1),
                new Vertex(1, 1, 1),
                new Vertex(1, -1, 1),
                new Vertex(-1, -1, 1)
            };

            faces = new int[,]
            {
                {
                    0, 1, 2, 3
                },
                {
                    1, 5, 6, 2
                },
                {
                    5, 4, 7, 6
                },
                {
                    4, 0, 3, 7
                },
                {
                    0, 4, 5, 1
                },
                {
                    3, 2, 6, 7
                }
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            angle+=2;
        }
    }
}