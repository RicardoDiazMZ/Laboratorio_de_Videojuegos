using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LYB
{
    public class VRope
    {
        public List<VPoint> pts;
        public List<VPole> pls;

        public VRope(float x, float y, int segments, float interval, int id)
        {
            pts = new List<VPoint>();
            pls = new List<VPole>();
            for (int i = 0; i < segments; i++)
            {
                pts.Add(new VPoint((int)(x + i * interval), (int)y, id + i));
                pts[i].FromBody = true;
                pts[i].Radius = 15;
            }
            //pts[0].Pin();

            //pts[pts.Count - 1].Pin();
            for (int i = 0; i < segments - 1; i++)
            {
                pls.Add(new VPole(pts[i], pts[i + 1 % segments]));
            }
        }

        public void Update(Graphics g, int Width, int Height)
        {
            for (int i = 0; i < pts.Count; i++)
            {
                pts[i].Update(Width, Height);
                pts[i].Constraints(Width, Height);

                g.DrawEllipse(Pens.OrangeRed, pts[i].X - pts[i].Radius, pts[i].Y - pts[i].Radius, pts[i].Diameter, pts[i].Diameter);
                g.FillEllipse(Brushes.Brown, pts[i].X - pts[i].Radius, pts[i].Y - pts[i].Radius, pts[i].Diameter, pts[i].Diameter);
            }
            for (int i = 0; i < pls.Count; i++)
                pls[i].Render(g, Width, Height);

            
        }

    }
}
