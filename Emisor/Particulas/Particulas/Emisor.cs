using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Windows.Forms;

namespace Particulas
{
    internal class Emisor
    {
        public List<Particula> particulas = new List<Particula>();
        public Random rand = new Random();
        int posx, posy;
        Color color;
        public int b = 1;

        public void Emitir(Bitmap bmp)
        {
            posx = rand.Next(0, bmp.Width);
            posy = rand.Next(10);
            color = Color.FromArgb(rand.Next(100, 255), 255, 255);

            particulas.Add(new Particula(posx, posy, rand, color, bmp.Size, b));
            b++;
        }

        public void Max(int b)
        {
            b--;
            particulas.RemoveAt(0);
            
        }

        public void Del(int b)
        {
            particulas.RemoveAt(b);
            b--;
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

        public void LifeTime(float deltaTime)
        {
            
        }

    }
}
