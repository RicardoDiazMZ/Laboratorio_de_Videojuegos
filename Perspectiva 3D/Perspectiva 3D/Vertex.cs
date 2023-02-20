using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perspectiva_3D
{
    public class Vertex
    {
        public Vertex(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public Vertex RotateX(int angle)
        {
            float rad = (float)(angle * Math.PI / 180);
            float cos = (float)Math.Cos(rad);
            float sin = (float)Math.Sin(rad);
            float yn = (Y * cos) - (Z * sin);
            float zn = (Y * sin) + (Z * cos);
            return new Vertex(X, yn, zn);
        }

        public Vertex RotateY(int angle)
        {
            float rad = (float)(angle * Math.PI / 180);
            float cos = (float)Math.Cos(rad);
            float sin = (float)Math.Sin(rad);
            float Zn = (Z * cos) - (X * sin);
            float Xn = (Z * sin) + (X * cos);
            return new Vertex(Xn, Y, Zn);
        }

        public Vertex RotateZ(int angle)
        {
            float rad = (float)(angle * Math.PI / 180);
            float cos = (float)Math.Cos(rad);
            float sin = (float)Math.Sin(rad);
            float Xn = (X * cos) - (Y * sin);
            float Yn = (X * sin) + (Y * cos);
            return new Vertex(Xn, Yn, Z);
        }

        public Vertex Project(int viewWidth, int viewHeight, int fov, int viewDistance)
        {
            float factor = fov / (viewDistance + Z);
            float Xn = X * factor + viewWidth / 2;
            float Yn = Y * factor + viewHeight / 2;
            return new Vertex(Xn, Yn, 0);
        }   
    }
}
