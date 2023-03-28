using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LYB
{
    public class VBox
    {
        int id;
        bool self;
        List<Vec2> xp2 = new List<Vec2>();
        float minX, maxX, minY, maxY;
        Vec2 pos;
        int width, height;
        PointF[] pts;
        Color color, c1;
        SolidBrush brush;
        Pen p;
        Pen alarm = new Pen(Color.Red, 10);
        static Random rand = new Random();
        public VPoint a, b, c, d;
        VPole p1, p2, p3, p4, p5, p6;
        List<PointF> dPts;

        public VBox(int x, int y, int width, int height, int id)
        {
            this.width = width;
            this.height = height;

            this.id = id;
            pos = new Vec2(x, y);

            a = new VPoint(x - (width / 2), y - (height / 2), rand.Next(5), rand.Next(-2, 2), id);
            b = new VPoint(x + (width / 2), y - (height / 2), id + 1);
            c = new VPoint(x + (width / 2), y + (height / 2), id + 2);
            d = new VPoint(x - (width / 2), y + (height / 2), id + 3);

            a.FromBody = true;
            b.FromBody = true;
            c.FromBody = true;
            d.FromBody = true;

            brush = new SolidBrush(Color.FromArgb(50, 65, 255));

            Init(a, b, c, d);
        }

        private void Init(VPoint a, VPoint b, VPoint c, VPoint d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;

            pts = new PointF[4];

            p1 = new VPole(a, b);
            p2 = new VPole(b, c);
            p3 = new VPole(c, d);
            p4 = new VPole(d, a);
            p5 = new VPole(b, d);
            p6 = new VPole(c, a);

            c1 = Color.FromArgb(255, 160, 0);
            brush = new SolidBrush(c1);

            color = Color.FromArgb(c1.R - 50, c1.G - 50, c1.B);

            p = new Pen(color, 14);
            p = new Pen(color, a.Radius);
            dPts = new List<PointF>();
        }

        public void Render(Graphics g, int width, int height)
        {
            Update(width, height);

            dPts.Clear();
            dPts.Add(new PointF(pts[0].X - a.Radius, pts[0].Y - a.Radius));
            dPts.Add(new PointF(pts[1].X + a.Radius, pts[1].Y - a.Radius));
            dPts.Add(new PointF(pts[2].X + a.Radius, pts[2].Y + a.Radius));
            dPts.Add(new PointF(pts[3].X - a.Radius, pts[3].Y + a.Radius));

            DrawBox(g);
        }

        private void Update(int width, int height)
        {
            a.Update(width, height); b.Update(width, height); c.Update(width, height); d.Update(width, height);
            a.Constraints(width, height); b.Constraints(width, height); c.Constraints(width, height); d.Constraints(width, height);

            p1.Update(); p2.Update(); p3.Update(); p4.Update(); p5.Update(); p6.Update();

            pts[0] = new PointF(a.Pos.X, a.Pos.Y);
            pts[1] = new PointF(b.Pos.X, b.Pos.Y);
            pts[2] = new PointF(c.Pos.X, c.Pos.Y);
            pts[3] = new PointF(d.Pos.X, d.Pos.Y);

            BoundingBox();
        }
        //--------------------------------------------------------------------------
        public void BoundingBox()
        {
            minX = float.MaxValue;
            maxX = float.MinValue;
            minY = float.MaxValue;
            maxY = float.MinValue;

            minX = Math.Min(Math.Min(pts[0].X, pts[1].X), Math.Min(pts[2].X, pts[3].X));
            minY = Math.Min(Math.Min(pts[0].Y, pts[1].Y), Math.Min(pts[2].Y, pts[3].Y));

            maxX = Math.Max(Math.Max(pts[0].X, pts[1].X), Math.Max(pts[2].X, pts[3].X));
            maxY = Math.Max(Math.Max(pts[0].Y, pts[1].Y), Math.Max(pts[2].Y, pts[3].Y));
        }

        public void React(Graphics g, List<VPoint> pts, int width, int height)//----------------
        {
            Render(g, width, height);

            for (int p = 0; p < pts.Count; p++)
                React(g, pts[p]);//*/
        }

        private bool React(Graphics g, VPoint p)//--------------------------
        {
            if (p == null || p.FromBody)
                return false;


            EdgeCollision(g, p, a, b, c, d);

            return false;
        }

        public void EdgeCollision(Graphics g, VPoint p, VPoint ap, VPoint bp, VPoint cp, VPoint dp)//---------------------------------
        {
            this.a = ap;
            this.b = bp;
            this.c = cp;
            this.d = dp;

            int index;
            float distace, tmp;
            xp2.Clear();

            distace = float.MaxValue;
            VPole a, b, c, d;

            pos.X = pts[0].X + pts[1].X + pts[2].X + pts[3].X;
            pos.Y = pts[0].Y + pts[1].Y + pts[2].Y + pts[3].Y;

            pos.X /= 4;
            pos.Y /= 4;

            index = -1;

            a = new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[1].X, (int)pts[1].Y));
            b = new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[2].X, (int)pts[2].Y));
            c = new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[3].X, (int)pts[3].Y));
            d = new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[0].X, (int)pts[0].Y));

            FindIntersections(a, p.Pos);
            FindIntersections(b, p.Pos);
            FindIntersections(c, p.Pos);
            FindIntersections(d, p.Pos);

            for (int point = 0; point < xp2.Count; point++)
            {
                tmp = xp2[point].Distance(p.Pos);
                if (tmp < distace)
                {
                    distace = tmp;
                    index = point;
                }
            }

            if (distace < p.Radius + 3)
            {
                g.DrawLine(Pens.AliceBlue, xp2[index].X, xp2[index].Y, p.Pos.X, p.Pos.Y);
                g.DrawPolygon(alarm, pts);

                ap.Destroyed = true;
                bp.Destroyed = true;
                cp.Destroyed = true;
                dp.Destroyed = true;

                if (!p.IsPinned)
                {
                    Vec2 temp = p.Pos;
                    p.Pos = p.Old + .000001f;
                    p.Old = temp - 1.5f;
                }
            }
        }

        private void FindIntersections(VPole pole, Vec2 p)//--------------------------
        {
            if (Util.HasIn(pole.P1, pole.P2, p))
            {
                xp2.Add(Util.GetPointLineIntersection(pole.P1, pole.P2, p));
            }
        }

        private void DrawBox(Graphics g)
        {
            p.Width = a.Diameter;
            g.FillPolygon(brush, pts);
            g.DrawPolygon(p, pts);
            p.Width = 10;
            g.DrawLine(p, pts[3].X, pts[3].Y, pts[1].X, pts[1].Y);
            g.DrawLine(p, pts[2].X, pts[2].Y, pts[0].X, pts[0].Y);

            p = new Pen(Color.FromArgb(color.R, color.G,color.B), 8);//4
            g.DrawLine(p, pts[3].X, pts[3].Y, pts[0].X, pts[0].Y);
            g.DrawLines(p, pts);//*/

            color   = Color.FromArgb(c1.R - 55, c1.G - 55, c1.B);
            p       = new Pen(color, 1);//6

            g.DrawLine(p, pts[3].X, pts[3].Y, pts[1].X, pts[1].Y);
            g.DrawLine(p, pts[2].X, pts[2].Y, pts[0].X, pts[0].Y);
            g.DrawLine(p, pts[3].X, pts[3].Y, pts[0].X, pts[0].Y);
            g.DrawLines(p, pts);//*/
        }
    }
}
