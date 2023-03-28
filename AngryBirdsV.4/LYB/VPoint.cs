using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace LYB
{
    public class VPoint
    {
        bool BoxIsPinned = true;
        bool isPinned = false;
        bool PigisPinned = false;
        bool isDestroyed = false;
        bool fromBody = false;
        bool isBird = false;
        Vec2 pos, old, vel, gravity, maxVel;
        int id;
        public float Mass;
        float radius, bounce, diameter, m, frict = .99f;
        float groundFriction = 0.7f;
        Color c;
        SolidBrush brush;
        Image ballImage = Resource1.red;
        Image pigImage = Resource1.pig;
        //TextureBrush brush1;
        //Image bird = Resource1.red;

        public bool FromBody
        {
            get { return fromBody; }
            set { fromBody = value; }
        }
        public bool Destroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }
        public float Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool IsPinned
        {
            get { return isPinned; }
            set { isPinned = value; }

        }
        public bool PigIsPinned
        {
            get { return PigisPinned; }
            set { PigisPinned = value; }

        }

        public bool BoxIsPinned2
        {
            get { return BoxIsPinned; }
            set { BoxIsPinned = value; }

        }
        public float X
        {
            get { return pos.X; }
            set { pos.X = value; }
        }
        public float Y
        {
            get { return pos.Y; }
            set { pos.Y = value; }
        }
        public Vec2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public Vec2 Old
        {
            get { return old; }
            set { old = value; }
        }
        public float Radius
        {
            get { return radius; }
            set { radius = value; diameter = radius + radius; }
        }

        public VPoint(int x, int y)
        {
            this.id = -1;
            Init(x, y, 0, 0);
        }
        public VPoint(int x, int y, int id, bool BoxPinned, bool PigPinned, bool BirdPinned)
        {
            this.id = id;
            PigisPinned = PigPinned;
            BoxIsPinned = BoxPinned;
            IsPinned = BirdPinned;
            Init(x, y, 0, 0);
        }
        public VPoint(int x, int y, int id)
        {
            this.id = id;
            Init(x, y, 0, 0);
        }
        public VPoint(int x, int y, float vx, float vy, int id, bool PigPinned)
        {
            this.id = id;
            PigisPinned = PigPinned;
            Init(x, y, vx, vy);
        }

        public VPoint(int x, int y, float vx, float vy, int id)
        {
            this.id = id;
            Init(x, y, vx, vy);
        }

        private void Init(int x, int y, float vx, float vy)
        {
            pos = new Vec2(x, y);
            old = new Vec2(x, y);
            gravity = new Vec2(0, 1);//
            vel = new Vec2(vx, vy);
            maxVel = new Vec2(5, 5);
            radius = 20;
            diameter = radius + radius;
            Mass = 1f;
            bounce = 1f;
            c = Color.Red;
            //brush = new SolidBrush(c);
            //brush1 = new TextureBrush(bird);
            if (BoxIsPinned)
            {
                BoxPin();
            }
            if (IsPinned)
            {
                BirdPin();
            }
            if (PigisPinned)
            {
                PigPin();
            }
        }

        public void BoxPin()
        {
            brush = new SolidBrush(Color.Blue);
            radius = 10;
            diameter = radius + radius;
            BoxIsPinned = true;
        }

        public void BirdPin()
        {
            brush = new SolidBrush(Color.Green);
            radius = 30;
            diameter = radius + radius;
            isPinned = true;
            isBird = true;
        }

        public void PigPin()
        {
           brush= new SolidBrush(Color.Green);
            radius = 35;
            diameter = radius + radius;
            PigisPinned = true;
        }

        public void Update(int width, int height)
        {
            if (isPinned)
                return;

            if (PigisPinned)
                return;

            if (!isDestroyed && BoxIsPinned)
                return;

            vel = (pos - old) *  frict;

            old = pos;
            pos += vel + gravity;

            if (vel.Length() > maxVel.Length())
            {
                vel = vel.Normalize() * maxVel.Length();
            }
        }

        public void Constraints(int width, int height)
        {
            if (!isBird && (pos.X > width - radius))     { pos.X = width - radius;   old.X = (pos.X + vel.X); }
            if (pos.X < radius)             { pos.X = radius;           old.X = (pos.X + vel.X) ; }
            if (pos.Y > height - radius)    { pos.Y = height - radius;  old.Y = (pos.Y + vel.Y) ; }
            if (pos.Y < radius)             { pos.Y = radius;           old.Y = (pos.Y + vel.Y) ; }
        }

        public void Render(Graphics g, int width, int height)
        {
            if (fromBody)
                return;

            Update(width, height);
            Constraints(width, height);

            //g.FillEllipse(brush, pos.X - radius, pos.Y - radius, diameter, diameter);
            //ImageAnimator.UpdateFrames(ballImage);
            if (isBird)
                g.DrawImage(ballImage, pos.X - radius, pos.Y - radius, diameter, diameter);
            if (PigisPinned)
                g.DrawImage(pigImage, pos.X - radius, pos.Y - radius, diameter, diameter);


        }


        public override string ToString()
        {
            return "ID: "+id+" : "+pos.ToString();
        }

    }
}
