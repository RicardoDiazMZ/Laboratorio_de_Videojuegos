using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Lanzallamas
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
            posx = bmp.Width/2 + 20;
            posy = rand.Next((bmp.Height/2) - 7, (bmp.Height/2) + 7);
            color = Color.FromArgb(255, rand.Next(50, 100), rand.Next(50, 100));

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
                g.DrawImage(Resource1.fire, p.x - 180, p.y - 130);
            }
        }

        public void LifeTime(float deltaTime)
        {

        }
    }
}
