using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

/*Cambios Pendientes: +interseccion
                              +gifs
                              +Acomodar en clases
                              +IA de Ghosts
                              +Ghosts Deathtimer
                              +Fin/Loop de Juego
                              +Smooth tunnels
                              +velocidad desface*/
namespace Pacman
{
    public partial class Form1 : Form
    {
        static Bitmap bmp;
        static Graphics g;
        static Movimiento movimiento;

        int level = 1;
        int puntos = 0;
        int pellets;
        int gametime;
        int powertime;
        int deathtime;
        int pause;
        int intro;

        int G1deathtime;
        int G2deathtime;
        int G3deathtime;
        int G4deathtime;

        int[,] pellets0 = new int[31, 31];
        int[,] power0 = new int[31, 31];
        int[,] pellets1 = new int[31, 31];
        int[,] power1 = new int[31, 31];
        int[,] pellets2 = new int[31, 31];
        int[,] power2 = new int[31, 31];

        bool start = true;
        bool cherryEat = false;

        bool panic1 = false;
        bool panic2 = false;
        bool panic3 = false;
        bool panic4 = false;

        bool G1dead = false;
        bool G2dead = false;
        bool G3dead = false;
        bool G4dead = false;

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

        //Inicializacion
        public Form1()
        {
            InitializeComponent();

            WMP.Ctlcontrols.stop();
            WMP.Visible = false;

            WMP2.Ctlcontrols.stop();
            WMP2.Visible = false;

            WMP3.Ctlcontrols.stop();
            WMP3.Visible = false;

            intro = 42;
            timer1.Stop();

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

                VelocidadG = 1
            };

            player.Image = Resources.Pac_Qui;
            G1.Image = Resources.RED;
            G2.Image = Resources.PINK;
            G3.Image = Resources.CYAN;
            G4.Image = Resources.ORANGE;
        }

        //Colission
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

        //Túneles
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

        //Pellets y puntos
        private void Pellet(int x, int y)
        {

            if (Map.map0[y, x] == 1)
            {
                if (pellets0[y, x] == 1)
                {
                    WMP2.URL = @"waka.wav";
                    WMP2.Ctlcontrols.play();
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    puntos += 10;
                    pellets0[y, x] = 0;
                    pellets--;
                }
            }
            if (Map.map1[y, x] == 1)
            {
                if (pellets1[y, x] == 1)
                {
                    WMP2.URL = @"waka.wav";
                    WMP2.Ctlcontrols.play();
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    puntos += 10;
                    pellets1[y, x] = 0;
                    pellets--;
                }
            }
            if (Map.map2[y, x] == 1)
            {
                if (pellets2[y, x] == 1)
                {
                    WMP2.URL = @"waka.wav";
                    WMP2.Ctlcontrols.play();
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    puntos += 10;
                    pellets2[y, x] = 0;
                    pellets--;
                }
            }
        }

        //Power pellets
        private void Power(int x, int y)
        {
            if (Map.map0[y, x] == 3)
            {
                if (power0[y, x] == 1)
                {
                    WMP3.URL = @"Pacman_Fruit.wav";
                    WMP3.Ctlcontrols.play();
                    WMP.URL = @"Pacman_Large_Pellet_Loop.wav";
                    WMP.Ctlcontrols.play();
                    WMP.settings.playCount = 26;
                    powertime = 500;
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    G1.Image = Resources.PANIC;
                    G2.Image = Resources.PANIC;
                    G3.Image = Resources.PANIC;
                    G4.Image = Resources.PANIC;
                    panic1 = true;
                    panic2 = true;
                    panic3 = true;
                    panic4 = true;
                    puntos += 100;
                    power0[y, x] = 0;
                    pellets--;
                }
            }
            if (Map.map1[y, x] == 3)
            {
                if (power1[y, x] == 1)
                {
                    WMP3.URL = @"Pacman_Fruit.wav";
                    WMP3.Ctlcontrols.play();
                    WMP.URL = @"Pacman_Large_Pellet_Loop.wav";
                    WMP.Ctlcontrols.play();
                    WMP.settings.playCount = 26;
                    powertime = 500;
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    G1.Image = Resources.PANIC;
                    G2.Image = Resources.PANIC;
                    G3.Image = Resources.PANIC;
                    G4.Image = Resources.PANIC;
                    panic1 = true;
                    panic2 = true;
                    panic3 = true;
                    panic4 = true;
                    puntos += 100;
                    power1[y, x] = 0;
                    pellets--;
                }
            }
            if (Map.map2[y, x] == 3)
            {
                if (power2[y, x] == 1)
                {
                    WMP3.URL = @"Pacman_Fruit.wav";
                    WMP3.Ctlcontrols.play();
                    WMP.URL = @"Pacman_Large_Pellet_Loop.wav";
                    WMP.Ctlcontrols.play();
                    WMP.settings.playCount = 26;
                    powertime = 500;
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                    G1.Image = Resources.PANIC;
                    G2.Image = Resources.PANIC;
                    G3.Image = Resources.PANIC;
                    G4.Image = Resources.PANIC;
                    panic1 = true;
                    panic2 = true;
                    panic3 = true;
                    panic4 = true;
                    puntos += 100;
                    power2[y, x] = 0;
                    pellets--;
                }
            }
        }

        //Ticks
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

            label1.Text = "Score: " + puntos;
            label2.Text = "X:" + movimiento.X;
            label3.Text = "Y:" + movimiento.Y;
            label4.Text = "POW: " + powertime;

            if (level == 1)
            {
                //Movimiento de Fantasmas lvl1
                if (up1)
                {
                    movimiento.Y1 -= movimiento.VelocidadG;
                    movimiento.X1 += movimiento.VelocidadG / 2;
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

                //Movimiento de Pac-man lvl1
                if (start)
                {
                    gametime = 0;
                    WMP.URL = @"Pacman_Siren.wav";
                    WMP.settings.playCount = 9999;
                    WMP.Ctlcontrols.play();
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
                        movimiento.X -= 2;
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
                gametime++;
            }
            if (level == 2)
            {
                //Movimiento de Fantasmas lvl2
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

                //Movimiento Pac-Man lvl2
                if (start)
                {
                    gametime = 0;
                    WMP.URL = @"Pacman_Siren.wav";
                    WMP.settings.playCount = 9999;
                    WMP.Ctlcontrols.play();
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
            }
            if (level == 3)
            {
                //Movimiento de Fantasmas lvl3
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

                //Movimiento de Pac-Man lvl3
                if (start)
                {
                    gametime = 0;
                    WMP.URL = @"Pacman_Siren.wav";
                    WMP.settings.playCount = 9999;
                    WMP.Ctlcontrols.play();
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
            }

            //Cherry
            if (gametime >= 1800)
            {
                if (gametime == 1800)
                {
                    Cherry.Image = Resources.Cherry;
                    cherryEat = false;
                }
                if (gametime == 2300)
                {
                    Cherry.Image = Resources.Cherry;
                    Cherry.Image = null;
                    Cherry.Refresh();
                    cherryEat = true;
                }
                if (gametime == 3600)
                {
                    Cherry.Image = Resources.Cherry;
                    cherryEat = false;
                }
                if (gametime == 4100)
                {
                    Cherry.Image = Resources.Cherry;
                    Cherry.Image = null;
                    Cherry.Refresh();
                    cherryEat = true;
                }
                if ((player.Bounds.IntersectsWith(Cherry.Bounds)) && (cherryEat == false))
                {
                    WMP3.URL = @"Pacman_Fruit.wav";
                    WMP3.Ctlcontrols.play();
                    puntos += 500;
                    Cherry.Image = null;
                    Cherry.Refresh();
                    cherryEat = true;
                }

            }


            //Interaccion con Fantasmas
            if (player.Bounds.IntersectsWith(G1.Bounds))
            {
                if (panic1)
                {
                    WMP3.URL = @"Pacman_Ghost_Eat.wav";
                    WMP3.Ctlcontrols.play();
                    G1deathtime = 500;
                    G1.Image = Resources.Eyes;
                    movimiento.X1 = 300;
                    movimiento.Y1 = 324;
                    puntos += 250;
                    G1dead = true;
                }
                else
                {
                    death();
                }
            }
            if (G1deathtime > 0)
            {
                G1deathtime--;
                if (G1deathtime == 472)
                {
                    WMP3.URL = @"Pacman_Ghost_Retreat.wav";
                    WMP3.Ctlcontrols.play();
                }
                if (G1deathtime == 0)
                {
                    panic1 = false;
                    G1dead = false;
                    movimiento.X1 = 300;
                    movimiento.Y1 = 280;
                    G1.Image = Resources.RED;
                }
            }

            if (player.Bounds.IntersectsWith(G2.Bounds))
            {
                if (panic2)
                {
                    WMP3.URL = @"Pacman_Ghost_Eat.wav";
                    WMP3.Ctlcontrols.play();
                    G2deathtime = 500;
                    G2.Image = Resources.Eyes;
                    movimiento.X2 = 300;
                    movimiento.Y2 = 324;
                    puntos += 250;
                    G2dead = true;
                }
                else
                {
                    death();
                }
            }
            if (G2deathtime > 0)
            {
                G2deathtime--;
                if (G2deathtime == 472)
                {
                    WMP3.URL = @"Pacman_Ghost_Retreat.wav";
                    WMP3.Ctlcontrols.play();
                }
                if (G2deathtime == 0)
                {
                    panic2 = false;
                    G2dead = false;
                    movimiento.X2 = 300;
                    movimiento.Y2 = 280;
                    G2.Image = Resources.PINK;

                }

            }
            if (player.Bounds.IntersectsWith(G3.Bounds))
            {
                if (panic3)
                {
                    WMP3.URL = @"Pacman_Ghost_Eat.wav";
                    WMP3.Ctlcontrols.play();
                    G3deathtime = 500;
                    G3.Image = Resources.Eyes;
                    movimiento.X3 = 300;
                    movimiento.Y3 = 324;
                    puntos += 250;
                    G3dead = true;
                }
                else
                {
                    death();
                }
            }
            if (G3deathtime > 0)
            {
                G3deathtime--;
                if (G3deathtime == 472)
                {
                    WMP3.URL = @"Pacman_Ghost_Retreat.wav";
                    WMP3.Ctlcontrols.play();
                }
                if (G3deathtime == 0)
                {
                    panic3 = false;
                    G3dead = false;
                    movimiento.X3 = 300;
                    movimiento.Y3 = 280;
                    G3.Image = Resources.CYAN;
                }

            }
            if (player.Bounds.IntersectsWith(G4.Bounds))
            {
                if (panic4)
                {
                    WMP3.URL = @"Pacman_Ghost_Eat.wav";
                    WMP3.Ctlcontrols.play();
                    G4deathtime = 500;
                    G4.Image = Resources.Eyes;
                    movimiento.X4 = 300;
                    movimiento.Y4 = 324;
                    puntos += 250;
                    G4dead = true;
                }
                else
                {
                    death();
                }
            }
            if (G4deathtime > 0)
            {
                G4deathtime--;
                if (G4deathtime == 472)
                {
                    WMP3.URL = @"Pacman_Ghost_Retreat.wav";
                    WMP3.Ctlcontrols.play();
                }
                if (G4deathtime == 0)
                {
                    panic4 = false;
                    G4dead = false;
                    movimiento.X4 = 300;
                    movimiento.Y4 = 280;
                    G4.Image = Resources.ORANGE;

                }
            }

            if (powertime > 0)
            {
                powertime--;
                if (powertime == 0)
                {
                    WMP.URL = @"Pacman_Siren.wav";
                    WMP.settings.playCount = 9999;
                    WMP.Ctlcontrols.play();
                    panic1 = false;
                    G1.Image = Resources.RED;
                    panic2 = false;
                    G2.Image = Resources.PINK;
                    panic3 = false;
                    G3.Image = Resources.CYAN;
                    panic4 = false;
                    G4.Image = Resources.ORANGE;
                }
            }

            //cambio de nivel
            if (pellets == 0)
            {
                level++;
                pellets = 0;

                player.Left = 312;
                player.Top = 504;

                movimiento.X1 = 312;
                movimiento.Y1 = 280;
                movimiento.X2 = 312;
                movimiento.Y2 = 300;
                movimiento.X3 = 312;
                movimiento.Y3 = 320;
                movimiento.X4 = 312;
                movimiento.Y4 = 340;

                start = true;
                right = false;
                left = false;
                up = false;
                down = false;

                pause = 48;
                timer1.Stop();
                timer2.Start();
                this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox1.Image = Resources.Ready;

                Drawmap();
            }
        }

        //Death
        private void death()
        {
            WMP3.URL = @"Pacman_Death.wav";
            WMP3.Ctlcontrols.play();
            WMP2.Ctlcontrols.stop();
            WMP.Ctlcontrols.stop();
            WMP2.URL = @"You_Died.wav";
            WMP2.Ctlcontrols.play();
            movimiento.X = 312;
            movimiento.Y = 504;
            player.Image= Resources.pac_death;
            pictureBox1.Image = Resources.you_died;
            puntos -= 1000;
            timer1.Stop();
            timer2.Start();
            deathtime = 89;
        }

        //Generacion de Laberinto
        private void Drawmap()
        {
            pictureBox1.Refresh();
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            pellets = 0;

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
                            pellets++;
                        }
                        if (Map.map0[y, x] == 3)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), x * 20 + 6, y * 20 + 6, 10, 10);
                            power0[y, x] = 1;
                            pellets++;
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
                            pellets++;
                        }
                        if (Map.map1[y, x] == 3)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), x * 20 + 6, y * 20 + 6, 10, 10);
                            power1[y, x] = 1;
                            pellets++;
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
                            pellets++;
                        }
                        if (Map.map2[y, x] == 3)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), x * 20, y * 20, 20, 20);
                            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), x * 20 + 6, y * 20 + 6, 10, 10);
                            power2[y, x] = 1;
                            pellets++;
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

        //Timers Independientes
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (deathtime > 0)
            {
                deathtime--;
                if (deathtime == 0)
                {
                    timer1.Start();
                    timer2.Stop();

                    movimiento.X1 = 312;
                    movimiento.Y1 = 280;
                    movimiento.X2 = 312;
                    movimiento.Y2 = 300;
                    movimiento.X3 = 312;
                    movimiento.Y3 = 320;
                    movimiento.X4 = 312;
                    movimiento.Y4 = 340;

                    start = true;
                    right = false;
                    left = false;
                    up = false;
                    down = false;
                    pictureBox1.Image = null;
                    pictureBox1.Image = bmp;
                    g.Clear(Color.Black);
                    pictureBox1.Refresh();
                    Drawmap();
                }
            }

            if(pause > 0)
            {
                if(pause == 48)
                {
                    WMP.Ctlcontrols.stop();
                    WMP2.Ctlcontrols.stop();
                    WMP3.URL = @"Pacman_Cutscene.wav";
                    WMP3.Ctlcontrols.play();
                }
                pause--;
                if(pause == 0)
                {
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                    pictureBox1.Image = null;
                    pictureBox1.Image = bmp;
                    g.Clear(Color.Black);
                    pictureBox1.Refresh();
                    Drawmap();
                    intro = 42;
                }
            }

            if (intro > 0)
            {
                intro--;
                if (intro == 41)
                {
                    WMP.URL = @"Pacman_Intro.wav";
                    WMP.Ctlcontrols.play();
                }
                if (intro == 0)
                {
                    WMP.Ctlcontrols.stop();
                    timer1.Start();
                    timer2.Stop();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                right = true;
                left = false;
                player.Image = Resources.Pac_Qui;

            }
            if (e.KeyData == Keys.Left)
            {
                left = true;
                right = false;
                player.Image = Resources.Pac_Izq;
            }
            if (e.KeyData == Keys.Up)
            {
                up = true;
                down = false;
                player.Image = Resources.Pac_Up;
            }
            if (e.KeyData == Keys.Down)
            {
                down = true;
                up = false;
                player.Image = Resources.Pac_Down;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                player.Image = Resources.Pac_Stdby;

            }
            if (e.KeyData == Keys.Left)
            {
                player.Image = Resources.Pac_Stdby;
            }
            if (e.KeyData == Keys.Up)
            {
                player.Image = Resources.Pac_Stdby;
            }
            if (e.KeyData == Keys.Down)
            {
                player.Image = Resources.Pac_Stdby;
            }
        }

        //Reset
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            level = 1;

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