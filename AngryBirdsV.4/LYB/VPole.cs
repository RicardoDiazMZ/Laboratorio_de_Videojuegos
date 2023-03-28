using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LYB
{
    public class VPole
    {
        float stiffness, damp;
        Pen brush;
        public VPoint a, b;
        float length, tot, m1,m2, dis, diff;

        Vec2 dxy, offset;

        public Vec2 P1
        {
            get { return a.Pos; }
        }
        public Vec2 P2
        {
            get { return b.Pos; }
        }
        public float aX
        {
            get { return a.Pos.X; }
        }
        public float aY
        {
            get { return a.Pos.Y; }
        }
        public float bX
        {
            get { return b.Pos.X; }
        }
        public float bY
        {
            get { return b.Pos.Y; }
        }

        public VPole(VPoint a, VPoint b)
        {
            this.a = a;
            this.b = b;
            stiffness   = 0.25f;
            damp        = 0.5f;
            length      = a.Pos.Distance(b.Pos);
            brush       = new Pen(Color.Green);
            tot         = a.Mass + b.Mass;
            m1          = b.Mass / tot;
            m2          = a.Mass / tot;
        }

        public void Update()
        {
            dxy     = b.Pos - a.Pos;
            dis     = dxy.Length();
            diff    = stiffness * (length - dis) / dis;
            offset  = dxy * diff * damp;

            if(!a.IsPinned)
                a.Pos   -= offset * m1;

            if(!b.IsPinned)
                b.Pos   += offset * m2;
        }
       
        public void Render(Graphics g, int width, int height)
        {
            Update();
            g.DrawLine(brush, a.Pos.X, a.Pos.Y, b.Pos.X, b.Pos.Y);
        }
    }
}
