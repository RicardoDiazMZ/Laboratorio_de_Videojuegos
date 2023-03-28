using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYB
{
    public class Personaje
    {
        public Image textura;
        public VPoint persona;
        public bool collision { get; set; }
        public Personaje(VPoint a, Image img, float r)
        {
            persona = a;
            Init(img);
            persona.Radius = r;
        }
        public Personaje(VPoint a, Image img, float r, bool instance)
        {
            persona = a;
            Init(img);
            persona.Radius = r;
            persona.IsPinned = instance;
        }
        public void Init(Image img)
        {
            textura = img;
        }

        public void Render(Graphics g, int width, int height)
        {

            g.DrawImage(textura, persona.Pos.X - (persona.Radius), persona.Pos.Y - (persona.Radius), persona.Diameter, persona.Diameter);
        }
    }
}
