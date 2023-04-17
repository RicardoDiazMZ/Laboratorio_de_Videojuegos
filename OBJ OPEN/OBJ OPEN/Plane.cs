using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIVE_DEMO
{
    public class Plane
    {
        public Vertex normal;
        private float distance;

        public float Distance
        {
            get { return distance; }
        }

        public Plane(Vertex normal, float distance)
        {
            this.normal     = normal;
            this.distance   = distance;
        }
    }
}
