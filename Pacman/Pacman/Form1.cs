using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        static Bitmap bmp;
        static Graphics g;
        static Movimiento movimiento;

        int level = 1;
        int puntos = 0;
        int totalpuntos = 0;

        int[,] pellets0 = new int[31,28];
        int[,] power0 = new int[31, 28];
        int[,] pellets1 = new int[31, 28];
        int[,] power1 = new int[31, 28];
        int[,] pellets2 = new int[31, 28];
        int[,] power2 = new int[31, 28];

        bool start = true;

        bool panic = false;

        bool right = false;
        bool left = false;
        bool up = false;
        bool down = false;

        bool right1 = false;
        bool left1 = false;
        bool up1 = true;
        bool down1 = false;

        bool right2 = false;
        bool left2 = false;
        bool up2 = true;
        bool down2 = false;

        bool right3 = false;
        bool left3 = false;
        bool up3 = true;
        bool down3 = false;

        bool right4 = false;
        bool left4 = false;
        bool up4 = true;
        bool down4 = false;

        int ct = 0;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(760, 1000);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            Drawmap();

            movimiento = new Movimiento()
            {
                X = player.Left,
                Y = player.Top,

                X1 = G1.Left,
                Y1 = G1.Top,

                X2 = G2.Left,
                Y2 = G2.Top,

                X3 = G3.Left,
                Y3 = G3.Top,

                X4 = G4.Left,
                Y4 = G4.Top,

                Velocidad = 2,
                VelocidadG = 1,

                AnchoPantalla = this.pictureBox1.Width,
                AltoPantalla = this.pictureBox1.Height
            };

            player.Image = Imagenes.Pac_Qui;
            G1.Image = Imagenes.RED;
            G2.Image = Imagenes.PINK;
            G3.Image = Imagenes.BLUE;
            G4.Image = Imagenes.YELLOW;
        }

        private bool Colision0(int x, int y)
        {
            if (Map.map0[y, x] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Colision1(int x, int y)
        {
            if (Map.map1[y, x] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Colision2(int x, int y)
        {
            if (Map.map2[y, x] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Tunel0(int x, int y)
        {
            if (Map.map0[y, x] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Tunel1(int x, int y)
        {
            if (Map.map1[y, x] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Tunel2(int x, int y)
        {
            if (Map.map2[y, x] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Pellet(int x, int y)
        {
            if (Map.map0[y, x] == 1)
            {
                if (pellets0[y, x] == 1)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    puntos += 10;
                    pellets0[y, x] = 0;
                }
            }
            if (Map.map1[y, x] == 1)
            {
                if (pellets1[y, x] == 1)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    puntos += 10;
                    pellets1[y, x] = 0;
                }
            }
            if (Map.map2[y, x] == 1)
            {
                if (pellets2[y, x] == 1)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    puntos += 10;
                    pellets2[y, x] = 0;
                }
            }
        }
        private void Power(int x, int y)
        {
            if (Map.map0[y, x] == 3)
            {
                if (power0[y, x] == 1)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    G1.Image = Imagenes.PANIC;
                    G2.Image = Imagenes.PANIC;
                    G3.Image = Imagenes.PANIC;
                    G4.Image = Imagenes.PANIC;
                    panic = true;
                    puntos += 100;
                    power0[y, x] = 0;
                }
            }
            if (Map.map1[y, x] == 3)
            {
                if (power1[y, x] == 1)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    G1.Image = Imagenes.PANIC;
                    G2.Image = Imagenes.PANIC;
                    G3.Image = Imagenes.PANIC;
                    G4.Image = Imagenes.PANIC;
                    panic = true;
                    puntos += 100;
                    power1[y, x] = 0;
                }
            }
            if (Map.map2[y, x] == 3)
            {
                if (power2[y, x] == 1)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    G1.Image = Imagenes.PANIC;
                    G2.Image = Imagenes.PANIC;
                    G3.Image = Imagenes.PANIC;
                    G4.Image = Imagenes.PANIC;
                    panic = true;
                    puntos += 100;
                    power2[y, x] = 0;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int nuevoX = movimiento.X;
            int nuevoY = movimiento.Y;

            int nuevoX1 = movimiento.X1;
            int nuevoY1 = movimiento.Y1;

            int nuevoX2 = movimiento.X2;
            int nuevoY2 = movimiento.Y2;

            int nuevoX3 = movimiento.X3;
            int nuevoY3 = movimiento.Y3;

            int nuevoX4 = movimiento.X4;
            int nuevoY4 = movimiento.Y4;

            if (level == 1)
            {
                if(up1)
                {
                    movimiento.Y1 -= movimiento.VelocidadG;
                    movimiento.X1 += movimiento.VelocidadG/2;
                    nuevoY1 = movimiento.Y1;
                    if (Colision0((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        up1 = false;
                        movimiento.Y1 += 3;
                        right1 = true;

                    }
                }
                if (right1)
                {
                    movimiento.X1 += movimiento.VelocidadG;
                    nuevoX1 = movimiento.X1 + 18;
                    if (Colision0((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        right1 = false;
                        movimiento.X1 -= 3;
                        down1 = true;

                    }
                }
                if (down1)
                {
                    movimiento.Y1 += movimiento.VelocidadG;
                    nuevoY1 = movimiento.Y1 + 18;
                    if (Colision0((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        down1 = false;
                        movimiento.Y1 -= 3;
                        left1 = true;


                    }
                }
                if (left1)
                {
                    movimiento.X1 -= movimiento.VelocidadG;
                    nuevoX1 = movimiento.X1;
                    if (Colision0((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        left1 = false;
                        movimiento.X1 += 2;
                        up1 = true;
                        
                    }
                }

                if (up2)
                {
                    movimiento.Y2 -= movimiento.VelocidadG;
                    movimiento.X2 -= movimiento.VelocidadG / 2;
                    nuevoY2 = movimiento.Y2;
                    if (Colision0((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        up2 = false;
                        movimiento.Y2 += 3;
                        movimiento.X2 += 3;
                        down2 = true;

                    }
                }
                if (down2)
                {
                    movimiento.Y2 += movimiento.VelocidadG;
                    nuevoY2 = movimiento.Y2 + 18;
                    if (Colision0((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        down2 = false;
                        movimiento.Y2 -= 3;
                        left2 = true;


                    }
                }
                if (left2)
                {
                    movimiento.X2 -= movimiento.VelocidadG;
                    nuevoX2 = movimiento.X2;
                    if (Colision0((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        left2 = false;
                        movimiento.X2 += 2;
                        right2 = true;
                        ct++;
                    }
                }
                if (right2)
                {
                    movimiento.X2 += movimiento.VelocidadG;
                    nuevoX2 = movimiento.X2 + 18;
                    if (Colision0((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        right2 = false;
                        movimiento.X2 -= 3;
                        up2 = true;

                    }
                }

                if (left3)
                {
                    movimiento.X3 -= movimiento.VelocidadG;
                    nuevoX3 = movimiento.X3;
                    if (Colision0((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        left3 = false;
                        movimiento.X3 += 2;
                        up3 = true;
                        
                    }
                }
                if (up3)
                {
                    movimiento.Y3 -= movimiento.VelocidadG;
                    movimiento.Y3 -= movimiento.VelocidadG / 2;
                    nuevoY3 = movimiento.Y3;
                    if (Colision0((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        up3 = false;
                        movimiento.Y3 += 3;
                        movimiento.X3 += 3;
                        down3 = true;

                    }
                }
                if (down3)
                {
                    movimiento.Y3 += movimiento.VelocidadG;
                    nuevoY3 = movimiento.Y3 + 18;
                    if (Colision0((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        down3 = false;
                        movimiento.Y3 -= 3;
                        right3 = true;


                    }
                }
                if (right3)
                {
                    movimiento.X3 += movimiento.VelocidadG;
                    nuevoX3 = movimiento.X3 + 18;
                    if (Colision0((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        right3 = false;
                        movimiento.X3 += 3;
                        up3 = true;

                    }
                }
                if (up3)
                {
                    movimiento.Y3 -= movimiento.VelocidadG;
                    movimiento.Y3 -= movimiento.VelocidadG / 2;
                    nuevoY3 = movimiento.Y3;
                    if (Colision0((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        up3 = false;
                        movimiento.Y3 += 5;
                        movimiento.X3 += 3;
                        left3 = true;

                    }
                }

                if (up4)
                {
                    movimiento.Y4 -= movimiento.VelocidadG;
                    
                    nuevoY4 = movimiento.Y4;
                    if (Colision0((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        up4 = false;
                        movimiento.Y4 += 3;
                        movimiento.X4 -= 2;
                        down4 = true;

                    }
                }
                if (down4)
                {
                    movimiento.Y4 += movimiento.VelocidadG;
                    movimiento.X4 += movimiento.VelocidadG / 2;
                    nuevoY4 = movimiento.Y4 + 18;
                    if (Colision0((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        down4 = false;
                        movimiento.Y4 += 5;
                        up4 = true;
                    }
                }
                if (left4)
                {
                    movimiento.X4 -= movimiento.VelocidadG;
                    movimiento.Y4 += movimiento.VelocidadG;
                    nuevoX4 = movimiento.X4;
                    if (Colision0((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        left4 = false;
                        movimiento.X4 -= 5;
                        down4 = true;
                        ct++;
                    }
                }
                if (down4)
                {
                    movimiento.Y4 += movimiento.VelocidadG;
                    movimiento.X4 += movimiento.VelocidadG / 2;
                    nuevoY4 = movimiento.Y4 + 18;
                    if (Colision0((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        down4 = false;
                        movimiento.Y4 -= 2;
                        left4 = true;


                    }
                }
                if (left4)
                {
                    movimiento.X4 -= movimiento.VelocidadG;
                    nuevoX4 = movimiento.X4;
                    if (Colision0((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        left4 = false;
                        movimiento.X4 += 2;
                        right4 = true;
                        ct++;
                    }
                }
                if (right4)
                {
                    movimiento.X4 += movimiento.VelocidadG;
                    nuevoX4 = movimiento.X4 + 18;
                    if (Colision0((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        right4 = false;
                        movimiento.Y4 -= movimiento.VelocidadG;
                        movimiento.X4 -= 3;
                        down4 = true;

                    }
                }

                if (start)
                {
                    movimiento.X += movimiento.Velocidad;
                    nuevoX = movimiento.X + 18;
                    if (Colision0((nuevoX - 42) / 20, (nuevoY - 44) / 20))
                    {
                        right = false;
                        movimiento.X -= 2;
                    }
                }

                if (right == true && (movimiento.Y - 44) % 20 == 0)
                {
                    start = false;
                    movimiento.X += movimiento.Velocidad;
                    nuevoX = movimiento.X + 18;
                    if (Colision0((nuevoX - 41) / 20, (nuevoY - 44) / 20))
                    {
                        right = false;
                        movimiento.X = movimiento.X - 2;
                    }
                    if (Tunel0((nuevoX - 42) / 20, (nuevoY - 44) / 20))
                    {
                        movimiento.X -= 520;
                    }

                }
                if (left == true && (movimiento.Y - 44) % 20 == 0)
                {
                    start = false;
                    movimiento.X -= movimiento.Velocidad;
                    nuevoX = movimiento.X;
                    if (Colision0((nuevoX - 41) / 20, (nuevoY - 44) / 20))
                    {
                        left = false;
                        movimiento.X = movimiento.X + 2;
                    }
                    if (Tunel0((nuevoX - 42) / 20, (nuevoY - 44) / 20))
                    {
                        movimiento.X += 520;
                    }
                }
                if (up == true && (movimiento.X - 42) % 20 == 0)
                {
                    start = false;
                    movimiento.Y -= movimiento.Velocidad;
                    nuevoY = movimiento.Y;
                    if (Colision0((nuevoX - 42) / 20, (nuevoY - 43) / 20))
                    {
                        up = false;
                        movimiento.Y += 2;
                    }
                }
                if (down == true && (movimiento.X - 42) % 20 == 0)
                {
                    start = false;
                    movimiento.Y += movimiento.Velocidad;
                    nuevoY = movimiento.Y + 18;
                    if (Colision0((nuevoX - 42) / 20, (nuevoY - 43) / 20))
                    {
                        down = false;
                        movimiento.Y -= 2;
                    }
                }

                if (puntos >= 3340)
                {
                    level++;
                    movimiento.X = 312;
                    movimiento.Y = 504;
                    start = true;
                    right = false;
                    left = false;
                    up = false;
                    down = false;
                    totalpuntos += puntos;
                    puntos = 0;
                    Drawmap();
                }
            }
            if (level == 2)
            {
                if (up1)
                {
                    movimiento.Y1 -= movimiento.VelocidadG;
                    movimiento.X1 += movimiento.VelocidadG / 2;
                    nuevoY1 = movimiento.Y1;
                    if (Colision1((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        up1 = false;
                        movimiento.Y1 += 3;
                        right1 = true;

                    }
                }
                if (right1)
                {
                    movimiento.X1 += movimiento.VelocidadG;
                    nuevoX1 = movimiento.X1 + 18;
                    if (Colision1((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        right1 = false;
                        movimiento.X1 -= 3;
                        down1 = true;

                    }
                }
                if (down1)
                {
                    movimiento.Y1 += movimiento.VelocidadG;
                    nuevoY1 = movimiento.Y1 + 18;
                    if (Colision1((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        down1 = false;
                        movimiento.Y1 -= 3;
                        left1 = true;


                    }
                }
                if (left1)
                {
                    movimiento.X1 -= movimiento.VelocidadG;
                    nuevoX1 = movimiento.X1;
                    if (Colision1((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        left1 = false;
                        movimiento.X1 += 2;
                        up1 = true;

                    }
                }

                if (up2)
                {
                    movimiento.Y2 -= movimiento.VelocidadG;
                    movimiento.X2 -= movimiento.VelocidadG / 2;
                    nuevoY2 = movimiento.Y2;
                    if (Colision1((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        up2 = false;
                        movimiento.Y2 += 3;
                        movimiento.X2 += 3;
                        down2 = true;

                    }
                }
                if (down2)
                {
                    movimiento.Y2 += movimiento.VelocidadG;
                    nuevoY2 = movimiento.Y2 + 18;
                    if (Colision1((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        down2 = false;
                        movimiento.Y2 -= 3;
                        left2 = true;


                    }
                }
                if (left2)
                {
                    movimiento.X2 -= movimiento.VelocidadG;
                    nuevoX2 = movimiento.X2;
                    if (Colision1((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        left2 = false;
                        movimiento.X2 += 2;
                        right2 = true;
                        ct++;
                    }
                }
                if (right2)
                {
                    movimiento.X2 += movimiento.VelocidadG;
                    nuevoX2 = movimiento.X2 + 18;
                    if (Colision1((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        right2 = false;
                        movimiento.X2 -= 3;
                        up2 = true;

                    }
                }

                if (left3)
                {
                    movimiento.X3 -= movimiento.VelocidadG;
                    nuevoX3 = movimiento.X3;
                    if (Colision1((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        left3 = false;
                        movimiento.X3 += 2;
                        up3 = true;

                    }
                }
                if (up3)
                {
                    movimiento.Y3 -= movimiento.VelocidadG;
                    movimiento.Y3 -= movimiento.VelocidadG / 2;
                    nuevoY3 = movimiento.Y3;
                    if (Colision1((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        up3 = false;
                        movimiento.Y3 += 3;
                        movimiento.X3 += 3;
                        down3 = true;

                    }
                }
                if (down3)
                {
                    movimiento.Y3 += movimiento.VelocidadG;
                    nuevoY3 = movimiento.Y3 + 18;
                    if (Colision1((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        down3 = false;
                        movimiento.Y3 -= 3;
                        right3 = true;


                    }
                }
                if (right3)
                {
                    movimiento.X3 += movimiento.VelocidadG;
                    nuevoX3 = movimiento.X3 + 18;
                    if (Colision1((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        right3 = false;
                        movimiento.X3 += 3;
                        up3 = true;

                    }
                }
                if (up3)
                {
                    movimiento.Y3 -= movimiento.VelocidadG;
                    movimiento.Y3 -= movimiento.VelocidadG / 2;
                    nuevoY3 = movimiento.Y3;
                    if (Colision1((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        up3 = false;
                        movimiento.Y3 += 5;
                        movimiento.X3 += 3;
                        left3 = true;

                    }
                }

                if (up4)
                {
                    movimiento.Y4 -= movimiento.VelocidadG;

                    nuevoY4 = movimiento.Y4;
                    if (Colision1((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        up4 = false;
                        movimiento.Y4 += 3;
                        movimiento.X4 -= 2;
                        down4 = true;

                    }
                }
                if (down4)
                {
                    movimiento.Y4 += movimiento.VelocidadG;
                    movimiento.X4 += movimiento.VelocidadG / 2;
                    nuevoY4 = movimiento.Y4 + 18;
                    if (Colision1((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        down4 = false;
                        movimiento.Y4 += 5;
                        up4 = true;
                    }
                }
                if (left4)
                {
                    movimiento.X4 -= movimiento.VelocidadG;
                    movimiento.Y4 += movimiento.VelocidadG;
                    nuevoX4 = movimiento.X4;
                    if (Colision1((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        left4 = false;
                        movimiento.X4 -= 5;
                        down4 = true;
                        ct++;
                    }
                }
                if (down4)
                {
                    movimiento.Y4 += movimiento.VelocidadG;
                    movimiento.X4 += movimiento.VelocidadG / 2;
                    nuevoY4 = movimiento.Y4 + 18;
                    if (Colision1((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        down4 = false;
                        movimiento.Y4 -= 2;
                        left4 = true;


                    }
                }
                if (left4)
                {
                    movimiento.X4 -= movimiento.VelocidadG;
                    nuevoX4 = movimiento.X4;
                    if (Colision1((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        left4 = false;
                        movimiento.X4 += 2;
                        right4 = true;
                        ct++;
                    }
                }
                if (right4)
                {
                    movimiento.X4 += movimiento.VelocidadG;
                    nuevoX4 = movimiento.X4 + 18;
                    if (Colision1((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        right4 = false;
                        movimiento.Y4 -= movimiento.VelocidadG;
                        movimiento.X4 -= 3;
                        down4 = true;

                    }
                }
                if (start)
                {
                    movimiento.X += movimiento.Velocidad;
                    nuevoX = movimiento.X + 18;
                    if (Colision1((nuevoX - 42) / 20, (nuevoY - 44) / 20))
                    {
                        right = false;
                        movimiento.X -= 2;
                    }
                }

                if (right == true && (movimiento.Y - 44) % 20 == 0)
                {
                    start = false;
                    movimiento.X += movimiento.Velocidad;
                    nuevoX = movimiento.X + 18;
                    if (Colision1((nuevoX - 41) / 20, (nuevoY - 44) / 20))
                    {
                        right = false;
                        movimiento.X = movimiento.X - 2;
                    }
                    if (Tunel1((nuevoX - 42) / 20, (nuevoY - 44) / 20))
                    {
                        movimiento.X -= 520;
                    }

                }
                if (left == true && (movimiento.Y - 44) % 20 == 0)
                {
                    start = false;
                    movimiento.X -= movimiento.Velocidad;
                    nuevoX = movimiento.X;
                    if (Colision1((nuevoX - 41) / 20, (nuevoY - 44) / 20))
                    {
                        left = false;
                        movimiento.X = movimiento.X + 2;
                    }
                    if (Tunel1((nuevoX - 42) / 20, (nuevoY - 44) / 20))
                    {
                        movimiento.X += 520;
                    }
                }
                if (up == true && (movimiento.X - 42) % 20 == 0)
                {
                    start = false;
                    movimiento.Y -= movimiento.Velocidad;
                    nuevoY = movimiento.Y;
                    if (Colision1((nuevoX - 42) / 20, (nuevoY - 43) / 20))
                    {
                        up = false;
                        movimiento.Y += 2;
                    }
                }
                if (down == true && (movimiento.X - 42) % 20 == 0)
                {
                    start = false;
                    movimiento.Y += movimiento.Velocidad;
                    nuevoY = movimiento.Y + 18;
                    if (Colision1((nuevoX - 42) / 20, (nuevoY - 43) / 20))
                    {
                        down = false;
                        movimiento.Y -= 2;
                    }
                }
                if (puntos >= 3400)
                {
                    level++;
                    movimiento.X = 312;
                    movimiento.Y = 504;
                    start = true;
                    right = false;
                    left = false;
                    up = false;
                    down = false;
                    totalpuntos += puntos;
                    puntos = 0;
                    Drawmap();
                }
            }
            if (level == 3)
            {
                if (up1)
                {
                    movimiento.Y1 -= movimiento.VelocidadG;
                    movimiento.X1 += movimiento.VelocidadG / 2;
                    nuevoY1 = movimiento.Y1;
                    if (Colision2((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        up1 = false;
                        movimiento.Y1 += 3;
                        right1 = true;

                    }
                }
                if (right1)
                {
                    movimiento.X1 += movimiento.VelocidadG;
                    nuevoX1 = movimiento.X1 + 18;
                    if (Colision2((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        right1 = false;
                        movimiento.X1 -= 3;
                        down1 = true;

                    }
                }
                if (down1)
                {
                    movimiento.Y1 += movimiento.VelocidadG;
                    nuevoY1 = movimiento.Y1 + 18;
                    if (Colision2((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        down1 = false;
                        movimiento.Y1 -= 3;
                        left1 = true;


                    }
                }
                if (left1)
                {
                    movimiento.X1 -= movimiento.VelocidadG;
                    nuevoX1 = movimiento.X1;
                    if (Colision2((nuevoX1 - 42) / 20, (nuevoY1 - 44) / 20))
                    {
                        left1 = false;
                        movimiento.X1 += 2;
                        up1 = true;

                    }
                }

                if (up2)
                {
                    movimiento.Y2 -= movimiento.VelocidadG;
                    movimiento.X2 -= movimiento.VelocidadG / 2;
                    nuevoY2 = movimiento.Y2;
                    if (Colision2((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        up2 = false;
                        movimiento.Y2 += 3;
                        movimiento.X2 += 3;
                        down2 = true;

                    }
                }
                if (down2)
                {
                    movimiento.Y2 += movimiento.VelocidadG;
                    nuevoY2 = movimiento.Y2 + 18;
                    if (Colision2((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        down2 = false;
                        movimiento.Y2 -= 3;
                        left2 = true;


                    }
                }
                if (left2)
                {
                    movimiento.X2 -= movimiento.VelocidadG;
                    nuevoX2 = movimiento.X2;
                    if (Colision2((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        left2 = false;
                        movimiento.X2 += 2;
                        right2 = true;
                        ct++;
                    }
                }
                if (right2)
                {
                    movimiento.X2 += movimiento.VelocidadG;
                    nuevoX2 = movimiento.X2 + 18;
                    if (Colision2((nuevoX2 - 42) / 20, (nuevoY2 - 44) / 20))
                    {
                        right2 = false;
                        movimiento.X2 -= 3;
                        up2 = true;

                    }
                }

                if (left3)
                {
                    movimiento.X3 -= movimiento.VelocidadG;
                    nuevoX3 = movimiento.X3;
                    if (Colision2((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        left3 = false;
                        movimiento.X3 += 2;
                        up3 = true;

                    }
                }
                if (up3)
                {
                    movimiento.Y3 -= movimiento.VelocidadG;
                    movimiento.Y3 -= movimiento.VelocidadG / 2;
                    nuevoY3 = movimiento.Y3;
                    if (Colision2((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        up3 = false;
                        movimiento.Y3 += 3;
                        movimiento.X3 += 3;
                        down3 = true;

                    }
                }
                if (down3)
                {
                    movimiento.Y3 += movimiento.VelocidadG;
                    nuevoY3 = movimiento.Y3 + 18;
                    if (Colision2((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        down3 = false;
                        movimiento.Y3 -= 3;
                        right3 = true;


                    }
                }
                if (right3)
                {
                    movimiento.X3 += movimiento.VelocidadG;
                    nuevoX3 = movimiento.X3 + 18;
                    if (Colision2((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        right3 = false;
                        movimiento.X3 += 3;
                        up3 = true;

                    }
                }
                if (up3)
                {
                    movimiento.Y3 -= movimiento.VelocidadG;
                    movimiento.Y3 -= movimiento.VelocidadG / 2;
                    nuevoY3 = movimiento.Y3;
                    if (Colision2((nuevoX3 - 42) / 20, (nuevoY3 - 44) / 20))
                    {
                        up3 = false;
                        movimiento.Y3 += 5;
                        movimiento.X3 += 3;
                        left3 = true;

                    }
                }

                if (up4)
                {
                    movimiento.Y4 -= movimiento.VelocidadG;

                    nuevoY4 = movimiento.Y4;
                    if (Colision2((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        up4 = false;
                        movimiento.Y4 += 3;
                        movimiento.X4 -= 2;
                        down4 = true;

                    }
                }
                if (down4)
                {
                    movimiento.Y4 += movimiento.VelocidadG;
                    movimiento.X4 += movimiento.VelocidadG / 2;
                    nuevoY4 = movimiento.Y4 + 18;
                    if (Colision2((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        down4 = false;
                        movimiento.Y4 += 5;
                        up4 = true;
                    }
                }
                if (left4)
                {
                    movimiento.X4 -= movimiento.VelocidadG;
                    movimiento.Y4 += movimiento.VelocidadG;
                    nuevoX4 = movimiento.X4;
                    if (Colision2((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        left4 = false;
                        movimiento.X4 -= 5;
                        down4 = true;
                        ct++;
                    }
                }
                if (down4)
                {
                    movimiento.Y4 += movimiento.VelocidadG;
                    movimiento.X4 += movimiento.VelocidadG / 2;
                    nuevoY4 = movimiento.Y4 + 18;
                    if (Colision2((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        down4 = false;
                        movimiento.Y4 -= 2;
                        left4 = true;


                    }
                }
                if (left4)
                {
                    movimiento.X4 -= movimiento.VelocidadG;
                    nuevoX4 = movimiento.X4;
                    if (Colision2((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        left4 = false;
                        movimiento.X4 += 2;
                        right4 = true;
                        ct++;
                    }
                }
                if (right4)
                {
                    movimiento.X4 += movimiento.VelocidadG;
                    nuevoX4 = movimiento.X4 + 18;
                    if (Colision2((nuevoX4 - 42) / 20, (nuevoY4 - 44) / 20))
                    {
                        right4 = false;
                        movimiento.Y4 -= movimiento.VelocidadG;
                        movimiento.X4 -= 3;
                        down4 = true;

                    }
                }
                if (start)
                {
                    movimiento.X += movimiento.Velocidad;
                    nuevoX = movimiento.X + 18;
                    if (Colision2((nuevoX - 42) / 20, (nuevoY - 44) / 20))
                    {
                        right = false;
                        movimiento.X -= 2;
                    }
                }

                if (right == true && (movimiento.Y - 44) % 20 == 0)
                {
                    start = false;
                    movimiento.X += movimiento.Velocidad;
                    nuevoX = movimiento.X + 18;
                    if (Colision2((nuevoX - 41) / 20, (nuevoY - 44) / 20))
                    {
                        right = false;
                        movimiento.X = movimiento.X - 2;
                    }
                    if (Tunel2((nuevoX - 42) / 20, (nuevoY - 44) / 20))
                    {
                        movimiento.X -= 520;
                    }

                }
                if (left == true && (movimiento.Y - 44) % 20 == 0)
                {
                    start = false;
                    movimiento.X -= movimiento.Velocidad;
                    nuevoX = movimiento.X;
                    if (Colision2((nuevoX - 41) / 20, (nuevoY - 44) / 20))
                    {
                        left = false;
                        movimiento.X = movimiento.X + 2;
                    }
                    if (Tunel2((nuevoX - 42) / 20, (nuevoY - 44) / 20))
                    {
                        movimiento.X += 520;
                    }
                }
                if (up == true && (movimiento.X - 42) % 20 == 0)
                {
                    start = false;
                    movimiento.Y -= movimiento.Velocidad;
                    nuevoY = movimiento.Y;
                    if (Colision2((nuevoX - 42) / 20, (nuevoY - 43) / 20))
                    {
                        up = false;
                        movimiento.Y += 2;
                    }
                }
                if (down == true && (movimiento.X - 42) % 20 == 0)
                {
                    start = false;
                    movimiento.Y += movimiento.Velocidad;
                    nuevoY = movimiento.Y + 18;
                    if (Colision2((nuevoX - 42) / 20, (nuevoY - 43) / 20))
                    {
                        down = false;
                        movimiento.Y -= 2;
                    }
                }

                if (puntos >= 3460)
                {
                    level++;
                    movimiento.X = 312;
                    movimiento.Y = 504;

                    movimiento.X1 = 310;
                    movimiento.Y1 = 300;
                    movimiento.X2 = 305;
                    movimiento.Y2 = 300;
                    movimiento.X3 = 315;
                    movimiento.Y3 = 300;
                    movimiento.X4 = 325;
                    movimiento.Y4 = 300;

                    start = true;
                    right = false;
                    left = false;
                    up = false;
                    down = false;
                    totalpuntos += puntos;
                    puntos = 0;
                    Drawmap();
                }
            }
            if (player.Bounds.IntersectsWith(G1.Bounds))
            {
                if (panic)
                {
                    movimiento.X1 = 310;
                    movimiento.Y1 = 300;
                    puntos += 200;
                    panic = false;
                    G1.Image = Imagenes.RED;

                }
                else
                    puntos = -1000;
            }
            
            if (player.Bounds.IntersectsWith(G2.Bounds))
            {
                if (panic)
                {
                    movimiento.X2 = 310;
                    movimiento.Y2 = 300;
                    puntos += 200;
                    panic = false;
                    G2.Image = Imagenes.PINK;
                }
                else
                    puntos = -1000;
            }
            if (player.Bounds.IntersectsWith(G3.Bounds))
            {
                if (panic)
                {
                    movimiento.X3 = 310;
                    movimiento.Y3 = 300;
                    puntos += 200;
                    panic = false;
                    G3.Image = Imagenes.BLUE;
                }
                else
                    puntos = -1000;
            }
            if (player.Bounds.IntersectsWith(G4.Bounds))
            {
                puntos = -1000;
                if (panic)
                {
                    movimiento.X4 = 310;
                    movimiento.Y4 = 300;
                    puntos += 200;
                    panic = false;
                    G4.Image = Imagenes.YELLOW;
                }
                else
                    puntos = -1000;
            }

            player.Left = movimiento.X;
            player.Top = movimiento.Y;

            G1.Left = movimiento.X1;
            G1.Top = movimiento.Y1;

            G2.Left = movimiento.X2;
            G2.Top = movimiento.Y2;

            G3.Left = movimiento.X3;
            G3.Top = movimiento.Y3;

            G4.Left = movimiento.X4;
            G4.Top = movimiento.Y4;

            Pellet((nuevoX - 42) / 20, (nuevoY - 44) / 20);
            Power((nuevoX - 42) / 20, (nuevoY - 44) / 20);

            label1.Text = "Score " + puntos;
            label2.Text = "X:" + movimiento.X;
            label3.Text = "Y:" + movimiento.Y;
            label4.Text = "Total Score " + totalpuntos;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                right = true;
                left = false;
                player.Image = Imagenes.Pac_Qui;

            }
            if (e.KeyData == Keys.Left)
            {
                left = true;
                right = false;
                player.Image = Imagenes.Pac_Izq;
            }
            if (e.KeyData == Keys.Up)
            {
                up = true;
                down = false;
                player.Image = Imagenes.Pac_Up;
            }
            if (e.KeyData == Keys.Down)
            {
                down = true;
                up = false;
                player.Image = Imagenes.Pac_Down;
            }
        }

        private void Drawmap()
        {
            pictureBox1.Refresh();
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            if (level == 1)
            {
                g.Clear(Color.Black);
                pictureBox1.Refresh();
                for (int y = 0; y < Map.map0.GetLength(0); y++)
                {
                    for (int x = 0; x < Map.map0.GetLength(1); x++)
                    {
                        if (Map.map0[y, x] == 1)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), x * 20 + 7, y * 20 + 7, 5, 5);
                            pellets0[y, x] = 1;
                        }
                        if (Map.map0[y, x] == 3)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), x * 20 + 6, y * 20 + 6, 10, 10);
                            power0[y, x] = 1;
                        }
                    }
                }
                for (int y = 0; y < Map.map0.GetLength(0); y++)
                {
                    for (int x = 0; x < Map.map0.GetLength(1); x++)
                    {
                        if (Map.map0[y, x] == 0)
                        {
                            g.DrawRectangle(Pens.Blue, x * 20, y * 20, 20, 20);
                        }
                    }
                }
                pictureBox1.Invalidate();
            }
            if (level == 2)
            {
                g.Clear(Color.Black);
                pictureBox1.Refresh();
                for (int y = 0; y < Map.map1.GetLength(0); y++)
                {
                    for (int x = 0; x < Map.map1.GetLength(1); x++)
                    {
                        if (Map.map1[y, x] == 1)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), x * 20 + 7, y * 20 + 7, 5, 5);
                            pellets1[y, x] = 1;
                        }
                        if (Map.map1[y, x] == 3)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), x * 20 + 6, y * 20 + 6, 10, 10);
                            power1[y, x] = 1;
                        }
                    }
                }
                for (int y = 0; y < Map.map1.GetLength(0); y++)
                {
                    for (int x = 0; x < Map.map1.GetLength(1); x++)
                    {
                        if (Map.map1[y, x] == 0)
                        {
                            g.DrawRectangle(Pens.LimeGreen, x * 20, y * 20, 20, 20);
                        }
                    }
                }
                pictureBox1.Invalidate();
            }
            if (level == 3)
            {
                g.Clear(Color.Black);
                pictureBox1.Refresh();
                for (int y = 0; y < Map.map2.GetLength(0); y++)
                {
                    for (int x = 0; x < Map.map2.GetLength(1); x++)
                    {
                        if (Map.map2[y, x] == 1)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), x * 20 + 7, y * 20 + 7, 5, 5);
                            pellets2[y, x] = 1;
                        }
                        if (Map.map2[y, x] == 3)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), x * 20 + 6, y * 20 + 6, 10, 10);
                            power2[y, x] = 1;
                        }
                    }
                }
                for (int y = 0; y < Map.map2.GetLength(0); y++)
                {
                    for (int x = 0; x < Map.map2.GetLength(1); x++)
                    {
                        if (Map.map2[y, x] == 0)
                        {
                            g.DrawRectangle(Pens.Red, x * 20, y * 20, 20, 20);
                        }
                    }
                }
                pictureBox1.Invalidate();
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                player.Image = Imagenes.Pacman_Standby;

            }
            if (e.KeyData == Keys.Left)
            {
                player.Image = Imagenes.Pacman_Standby;
            }
            if (e.KeyData == Keys.Up)
            {
                player.Image = Imagenes.Pacman_Standby;
            }
            if (e.KeyData == Keys.Down)
            {
                player.Image = Imagenes.Pacman_Standby;
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            level = 1;
            movimiento.X = 312;
            movimiento.Y = 504;

            movimiento.X1 = 310;
            movimiento.Y1 = 300;
            movimiento.X2 = 305;
            movimiento.Y2 = 300;
            movimiento.X3 = 315;
            movimiento.Y3 = 300;
            movimiento.X4 = 325;
            movimiento.Y4 = 300;

            start = true;
            right = false;
            left = false;
            up = false;
            down = false;
            puntos = 0;
            Drawmap();
        }
    }
}