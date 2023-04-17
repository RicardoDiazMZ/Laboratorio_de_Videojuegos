using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LIVE_DEMO
{
    public partial class main_form : Form
    {
        Mtx val;
        float textYrot, textXrot, textZrot, textYtras, textXtras, textZtras, scal, fov;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        Vertex rota, tras;

        public main_form()
        {
            InitializeComponent();
        }

        private void BTN_EXE_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            ObjParser parser = new ObjParser("sphere.obj");
            List<float[]> verticesList = parser.Vertices.Select(vertex => new float[] { vertex[0], vertex[1], vertex[2] }).ToList();
            List<int[]> facesList = parser.Faces.Select(face => new int[] { face[0], face[1], face[2] }).ToList();
            List<int[]> triangles = parser.Faces.Select(face => new int[] { face[0], face[1], face[2] }).ToList();

            textXrot = Convert.ToInt32(textBox1.Text);
            textYrot = Convert.ToInt32(textBox2.Text);
            textZrot = Convert.ToInt32(textBox3.Text);

            textXtras = Convert.ToInt32(textBox4.Text);
            textYtras = Convert.ToInt32(textBox5.Text);
            textZtras = Convert.ToInt32(textBox6.Text);

            scal = Convert.ToInt32(textBox7.Text);

            rota = new Vertex(textXrot, textYrot, textZrot);
            tras = new Vertex(textXtras, textYtras, textZtras);

            val = Mtx.Rotate(rota);

            Rasterization raster = new Rasterization(PCT_CANVAS.Size, verticesList, triangles, val, tras, scal, fov);

            PCT_CANVAS.Image = raster.Canvas;
            PCT_CANVAS.Invalidate();
        }

        private void PCT_CANVAS_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
