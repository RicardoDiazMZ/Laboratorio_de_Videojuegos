using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace Colision
{
    public class Canvas
    {
        static Bitmap bmp;
        static Graphics g;
        PictureBox pct;

        public Canvas(PictureBox pct)
        {
            this.pct = pct;
            bmp = new Bitmap(pct.Width, pct.Height);
            Init();
        }

        private void Init()
        {
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            pct.Image = bmp;
            pct.Invalidate();
        }

        public void Render(Scene scene, int x, int y)
        {
            for (int f = 0; f < scene.Pelotas.Count; f++)
            {
                g.Clear(Color.Black);
                g.FillEllipse(new SolidBrush(Color.FromArgb(0, 0, 255)), 10 + x, 10 + y, 50, 50);
                
            }
            pct.Invalidate(); 
        }
    }

}
