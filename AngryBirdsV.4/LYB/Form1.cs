using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LYB
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        List<VPoint> balls;
        VRope rope;
        List<VBox> boxes;
        VSolver solver;
        Point mouse, trigger;
        bool isMouseDown, isRightButton, launched = false, despawned;
        int ballId;
        float locX, locY;
        public int tempo, activeBird;

        public Form1()
        {
            InitializeComponent();
        }

        private void Init()
        {
            Random rand = new Random();
            canvas = new Canvas(PCT_CANVAS.Size);
            PCT_CANVAS.Image = canvas.bmp;
            balls = new List<VPoint>();
            boxes = new List<VBox>();
            solver = new VSolver(balls);

            balls.Add(new VPoint(170, PCT_CANVAS.Height - 145, balls.Count, false, false, true));

            balls.Add(new VPoint(1200, 470, balls.Count, false, true, false));

            boxes.Add(new VBox(1200, 475 + 65, 320, 40, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);

            boxes.Add(new VBox(1060, 620 + 65, 40, 210, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);

            boxes.Add(new VBox(1340, 620 + 65, 40, 210, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);

            boxes.Add(new VBox(1200, 305 + 5, 80, 40, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);

            boxes.Add(new VBox(1060 + 60, 390 + 5, 40, 210, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);

            boxes.Add(new VBox(1280, 390 + 5, 40, 210, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);

            boxes.Add(new VBox(1200, 155 + 65, 40, 100, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Init();
        }

        private void BTN_EXE_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void PCT_CANVAS_MouseClick(object sender, MouseEventArgs e)
        {
            if (launched && (isRightButton = (e.Button == MouseButtons.Left)) && despawned)
            {
                balls.Add(new VPoint(170, PCT_CANVAS.Height - 145, balls.Count, false, false, true));
                launched = false;
            }
                
        }

        private void spawn()
        {
            balls.Add(new VPoint(170, PCT_CANVAS.Height - 145, balls.Count, false, false, true));
            launched = false;
        }

        private void PCT_CANVAS_MouseDown(object sender, MouseEventArgs e)
        {
            if (CHK_GENERATE.Checked)
            {
                isMouseDown = true;

                isRightButton = (e.Button == MouseButtons.Right);
                if (isRightButton)
                    trigger = e.Location;

                mouse = e.Location;
            }
                
        }

        private void PCT_CANVAS_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (isMouseDown)
            {
                if (e.Button == MouseButtons.Left)//MOVE BALL TO POINTER
                {
                    mouse = e.Location;
                    
                    if (ballId > -1)
                    {
                        balls[ballId].Pos.X = e.Location.X;
                        balls[ballId].Pos.Y = e.Location.Y;

                        balls[ballId].Old = balls[ballId].Pos;
                    }
                }
                else
                {
                    trigger = e.Location;
                }
                    
            }
        }

        private void Dtimer_Tick(object sender, EventArgs e)
        {
            
            if (tempo > 50)
            {
                balls.Remove(balls[activeBird]);
                despawned = true;
                spawn();
                Dtimer.Enabled = false;
                return;
            }
            LBL_STATUS.Text = "Points: " + solver.points;
            tempo ++;
        }

        private void PCT_CANVAS_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (e.Button == MouseButtons.Right && ballId != -1)
            {
                balls[ballId].IsPinned = false;
                activeBird = ballId;
                balls[ballId].Old.X = e.Location.X;
                balls[ballId].Old.Y = e.Location.Y;
                launched = true;
                despawned = false;
                Dtimer.Enabled = true;
                tempo = 0;              
            }

            ballId = -1;
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            canvas.LessFast();

            ballId = solver.Update(canvas.g, canvas.Width, canvas.Height, mouse, isMouseDown);
      
            if(rope!=null)
                rope.Update(canvas.g, canvas.Width, canvas.Height);

            for (int b = 0; b < boxes.Count; b++)
                boxes[b].React(canvas.g, balls, PCT_CANVAS.Width, PCT_CANVAS.Height);//*/   

            if (isMouseDown && isRightButton && ballId != -1)
            {
                canvas.g.DrawLine(Pens.Red, balls[ballId].X, balls[ballId].Y, trigger.X, trigger.Y);
            }
                

            canvas.g.DrawImage(Resource1.resortera, 150f, 640f);

            PCT_CANVAS.Invalidate();

            
        }
    }
}
