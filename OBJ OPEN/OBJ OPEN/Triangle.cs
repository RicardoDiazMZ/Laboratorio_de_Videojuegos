using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LIVE_DEMO
{
    public class Triangle
    {
        public int v0;
        public int v1;
        public int v2;
        public Color color;

        public Triangle(int v0, int v1, int v2, Color color)
        {
            this.v0 = v0;
            this.v1 = v1;
            this.v2 = v2;
            this.color = color;
        }

        public override string ToString()
        {
            return v0 + " " + v1 + " " + v2;
        }
    }
}
