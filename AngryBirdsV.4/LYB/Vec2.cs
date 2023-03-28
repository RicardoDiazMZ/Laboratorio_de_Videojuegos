using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LYB
{
    public class Vec2
    {
        public float X, Y;

        public Vec2(double x, double y)
        {
            this.X = (float)x;
            this.Y = (float)y;
        }

        public Vec2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        
        public static Vec2 operator +(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X + b.X, a.Y + b.Y);
        }
        
        public static Vec2 operator +(Vec2 a, float b)
        {
            return new Vec2(a.X + b, a.Y + b);
        }//*/
        
        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X - b.X, a.Y - b.Y);
        }//*/
        
        public static Vec2 operator -(Vec2 a, float b)
        {
            return new Vec2(a.X - b, a.Y - b);
        }//*/
        
        public static Vec2 operator *(float a, Vec2 v)
        {
            return new Vec2(a * v.X, a * v.Y);
        }//*/
        
        public static Vec2 operator *(Vec2 v, float a)
        {
            return new Vec2(a * v.X, a * v.Y);
        }//*/

        public static Vec2 operator /(Vec2 v, float a)
        {
            return new Vec2(v.X / a, v.Y / a);
        }

        public float MagSqr()
        {
            return (X * X) + (Y * Y);
        }

        public float Length()
        {
            return (float)Math.Sqrt(MagSqr());
        }

        public Vec2 Normalize()
        {
            float magnitude = (float)Math.Sqrt(X * X + Y * Y);
            if (magnitude > 0)
            {
                X /= magnitude;
                Y /= magnitude;
            }
            return new Vec2(X, Y);
        }


        public float Distance(Vec2 a)
        {
            return (float)Math.Sqrt(Math.Pow(X - a.X, 2) + Math.Pow(Y - a.Y, 2));
        }

        public override string ToString()
        {
            return X + " : " + Y;
        }
    }
}
