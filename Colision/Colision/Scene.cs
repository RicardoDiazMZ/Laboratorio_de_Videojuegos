using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colision
{
    public class Scene
    {
        public List<Pelota> Pelotas;
        public int pelotas = 0;

        public Scene()
        {
            Pelotas = new List<Pelota>();
        }

        public void add()
        {
            pelotas++;
        }
    }
}
