using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particulas
{
    internal class Particula
    {
        int index;
        Size space;
        public Color c;
        // Variables de posición
        public float x;
        public float y;

        // Variables de velocidad
        private float vx;
        private float vy;

        // Variable de radio
        public float radio;

        // Constructor
        public Particula(int posx, int posy, Random rand, Color color, Size size, int index)
        {
            this.radio = rand.Next(4, 10);
            this.x = posx;//rand.Next((int)radio, size.Width - (int)radio);
            this.y = posy;//rand.Next((int)radio, size.Height - (int)radio);
            c = color; // Color.FromArgb(rand.Next(0, 255), rand.Next(255, 255), rand.Next(255, 255));
            // Velocidades iniciales
            this.vx = rand.Next(-1, 1);
            this.vy = 5;

            this.index = index;
            space = size;
        }

        // Método para actualizar la posición de la particula en función de su velocidad
        public void Update(Bitmap bmp, float deltaTime, List<Particula> particulas)
        {
            for (int b = index + 1; b < particulas.Count; b++)
            {
                Collision(particulas[b]);
            }

            if ((x - radio) <= 0 || (x + radio) >= space.Width)
            {
                if (x - radio <= 0)
                    x = radio + 3;
                else
                    x = space.Width - radio - 3;

                vx *= -.5f;
                vy *= .75f;
            }

            if ((y - radio) <= 0 || (y + radio) >= space.Height)
            {
                if (y - radio <= 0)
                    y = radio + 3;
                else
                    vy = 0;

                vx *= .10f;
                vy *= -.55f;
            }

            this.x += this.vx * deltaTime;
            this.y += this.vy * deltaTime/8;
        }

        // Método para manejar colisiones entre particulas
        public void Collision(Particula otraParticula)
        {
            float distancia = (float)Math.Sqrt(Math.Pow((otraParticula.x - this.x), 2) + Math.Pow((otraParticula.y - this.y), 2));

            if (distancia < (this.radio + otraParticula.radio))//ESTO SIGNIFICA COLISIÓN...
            {
                // Calculamos las velocidades finales de cada particula en función de su masa y velocidad inicial
                float masaTotal = this.radio + otraParticula.radio;
                float masaRelativa = this.radio / masaTotal;

                float v1fx = this.vx - masaRelativa * (this.vx - otraParticula.vx) / 100;
                float v1fy = this.vy - masaRelativa * (this.vy - otraParticula.vy) / 100;

                float v2fx = otraParticula.vx - masaRelativa * (otraParticula.vx - this.vx) / 100;
                float v2fy = otraParticula.vy - masaRelativa * (otraParticula.vy - this.vy) / 100;

                // Actualizamos las velocidades de las particulas
                this.vx = v1fx;     // -----AQUI CAMBIAMOS EL ANGULO---------
                this.vy = v1fy;     // -----AQUI CAMBIAMOS EL ANGULO--------------

                otraParticula.vx = v2fx;//-----AQUI CAMBIAMOS EL ANGULO----------------------
                otraParticula.vy = v2fy;//-----AQUI CAMBIAMOS EL ANGULO----------------------

                // Movemos las particulas para evitar que se superpongan
                float distanciaOverlap = (this.radio + otraParticula.radio) - distancia;
                float dx = (this.x - otraParticula.x) / distancia;
                float dy = (this.y - otraParticula.y) / distancia;

                this.x += dx * distanciaOverlap / 2f;
                this.y += dy * distanciaOverlap / 2f;

                otraParticula.x -= dx * distanciaOverlap / 2f;
                otraParticula.y -= dy * distanciaOverlap / 2f;
            }
        }
    }
}
