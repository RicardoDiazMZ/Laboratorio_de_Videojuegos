using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace LYB
{
    public class VSolver
    {
        VPoint p1, p2;
        Vec2 axis, normal, res;
        float dis, dif;
        List<VPoint> pts;
        public int points = 0;
        public VSolver(List<VPoint> pts)
        {
            this.pts = pts;
        }
        
        public int Update(Graphics g, int Width, int Height,Point mouse, bool isMouseDown)
        {
            int id;

            id = -1;

            for (int s = 0; s < pts.Count; s++)
            {
                for (int p = s; p < pts.Count; p++)
                {
                    p1 = pts[s];
                    p2 = pts[p];

                    if (p1.Id == p2.Id)// BY ID
                        continue;

                    if (p1.IsPinned && p2.IsPinned)
                        continue;

                    axis = p1.Pos - p2.Pos;//vector de direccion
                    dis = axis.Length(); // magnitud

                    if (dis < (p1.Radius + p2.Radius))//COLLISION DETECTED
                    {
                        dif = (dis - (p1.Radius + p2.Radius)) * .5f;// dividir la fuerza para repatar entre ambas colisiones
                        normal = axis / dis; // normalizar la direccion para tener el vector unitario
                        res = dif * normal;// vector resultante

                        if (!p1.IsPinned)
                            if(p2.PigIsPinned)
                            {
                                p1.Pos -= res * 2;
                                points += 1000;
                            }
                                
                            else
                            {
                                p1.Pos -= res;
                                points += 0;
                            }

                        if (!p2.IsPinned)
                            if (p1.PigIsPinned)
                            {
                                p2.Pos += res * 2;
                                points += 10;
                            }
                            else
                            {
                                p2.Pos += res;
                                points += 0;
                            }
                    }
                }                

                if (isMouseDown)// para seleccionar el punto de masa a mover escogiendo su ID 
                    if (Math.Abs((p1.X - mouse.X) * (p1.X - mouse.X) + (p1.Y - mouse.Y) * (p1.Y - mouse.Y)) <= ((p1.Radius) * (p1.Radius)))
                        id = p1.Id;

                p1.Render(g, Width, Height);
            }
            
            return id;
        }
    }
}
