using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LYB
{
    public class Util
    {
        static Util instance;
        float t;

        public static Util Instance
        {
            get
            {
                if (instance == null)
                    instance = new Util();
                return Util.instance;
            }
        }
        
        public bool Intersect(float x1, float x2, float x3, float x4, float y1, float y2, float y3, float y4)
        {
            float den, u, x1x2, x1x3, x3x4, y3y4, y1y2, y1y3;

            x1x2 = x1 - x2;
            x3x4 = x3 - x4;
            y1y2 = y1 - y2;
            y3y4 = y3 - y4;

            den = (x1x2 * y3y4) - (y1y2 * x3x4);

            if (den == 0)
                return false;

            x1x3 = x1 - x3;
            y1y3 = y1 - y3;

            t = (x1x3 * y3y4) - (y1y3 * x3x4);
            u = (x1x3 * y1y2) - (y1y3 * x1x2);

            t /= den;
            u /= den;

            if (t > 0 && t < 1 && u > 0)
                return true;

            return false;
        }

        public Vec2 FindPoint(VPole A)
        {
            float x = A.aX + t * (A.bX - A.aX);
            float y = A.aY + t * (A.bY - A.aY);

            return new Vec2(x, y);
        }


        public static Vec2 GetPointLineIntersection(Vec2 p1, Vec2 p2, Vec2 p3)
        {
            Vec2 v = new Vec2(p2.X - p1.X, p2.Y - p1.Y);
            Vec2 w = new Vec2(p3.X - p1.X, p3.Y - p1.Y);

            float len_v = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
            if (len_v == 0)
            {
                return null; // la línea no está definida correctamente
            }
            Vec2 n = new Vec2(v.X / len_v, v.Y / len_v);
            float dist = w.X * n.X + w.Y * n.Y;

            if (dist < 0 || dist > len_v)
            {
                return null; // el punto de intersección está fuera de la línea
            }

            return new Vec2(p1.X + n.X * dist, p1.Y + n.Y * dist);
        }//*/

        public static bool HasIn(Vec2 p1, Vec2 p2, Vec2 p3)
        {
            Vec2 v = new Vec2(p2.X - p1.X, p2.Y - p1.Y);
            Vec2 w = new Vec2(p3.X - p1.X, p3.Y - p1.Y);

            float len_v = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
            if (len_v == 0)
            {
                return false; // la línea no está definida correctamente
            }
            Vec2 n = new Vec2(v.X / len_v, v.Y / len_v);
            float dist = w.X * n.X + w.Y * n.Y;

            if (dist < 0 || dist > len_v)
            {
                return false; // el punto de intersección está fuera de la línea
            }

            return true;
        }


    }
}
