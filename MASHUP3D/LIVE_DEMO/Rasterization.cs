using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace LIVE_DEMO
{
    public class Rasterization
    {
        // Scene setup.
        float viewport_size = 1;
        float projection_plane_z = 1;
        Bitmap canvas;
        Graphics canvas_context;
        int canvas_width;
        int canvas_height;
        public List<Model> models;
        int pixelFormatSize, stride;
        public byte[] bits;
        public float[,] zbuffer;
       
        Model cube;
        Camera camera   = new Camera(new Vertex(0,0, 2), Mtx.RotY(0));
       // float s2        = (float)Math.Sqrt(2);

        public List<Instance> instances;

        public Bitmap Canvas
        {
            get { return canvas; }
        }

        Vertex[] vertices = new Vertex[] {
                                            new Vertex(1, 1, 1),
                                            new Vertex(-1, 1, 1),
                                            new Vertex(-1, -1, 1),
                                            new Vertex(1, -1, 1),
                                            new Vertex(1, 1, -1),
                                            new Vertex(-1, 1, -1),
                                            new Vertex(-1, -1, -1),
                                            new Vertex(1, -1, -1)
                                        };


        Triangle[] triangulos = new Triangle[] {             
                                            new Triangle(0, 1, 2, Color.Red),
                                            new Triangle(0, 2, 3, Color.Red),
                                            new Triangle(4, 0, 3, Color.Green),
                                            new Triangle(4, 3, 7, Color.Green),
                                            new Triangle(5, 4, 7, Color.Blue),
                                            new Triangle(5, 7, 6, Color.Blue),
                                            new Triangle(1, 5, 6, Color.Yellow),
                                            new Triangle(1, 6, 2, Color.Yellow),
                                            new Triangle(4, 5, 1, Color.Purple),
                                            new Triangle(4, 1, 0, Color.Purple),
                                            new Triangle(2, 6, 7, Color.Cyan),
                                            new Triangle(2, 7, 3, Color.Cyan)
                                           };

        public Rasterization(Size size)
        {
            Init(size);
        }
        public Rasterization(Size size, List<Vertex> vertexes, List<Triangle> triangles) { 
            this.vertices = vertexes.ToArray();
            this.triangulos = triangles.ToArray();
            Init(size);
        }
        public void White()
        {
            canvas_context.Clear(Color.White);
        }
        public void Resize(Size size)
        {
            canvas = new Bitmap(size.Width, size.Height);
            canvas_context = Graphics.FromImage(canvas);
            canvas_width = canvas.Width;
            canvas_height = canvas.Height;
        }
        private void Init(Size size)
        {
            PixelFormat format;
            GCHandle handle; //puntero
            IntPtr bitPtr; // puntero the two previous pointers are to protect the images and the bits from being deleted
            format = PixelFormat.Format32bppArgb;
            int padding;
            pixelFormatSize = Image.GetPixelFormatSize(format) / 8;
            canvas = new Bitmap(size.Width, size.Height);
            zbuffer= new float[size.Width,size.Height];
            canvas_width = canvas.Width;
            canvas_height = canvas.Height;
            stride = canvas_width * pixelFormatSize;
            padding = (stride % 4);
            
            stride += padding == 0 ? 0 : 4 - padding; //4 byte multiple Alpha, Red, Green, Blue
            bits = new byte[stride * canvas_height]; //Total pixels (width) times ARGB (4) times height
            handle = GCHandle.Alloc(bits, GCHandleType.Pinned);
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            canvas = new Bitmap(canvas_width, canvas_height, stride, format, bitPtr);

            canvas_context = Graphics.FromImage(canvas);
            for (int i = 0 ; i < size.Width; i++)
            {
                for (int j = 0 ;j< size.Height; j++)
                {
                    zbuffer[i,j] = float.MaxValue;  
                }
            }
            models = new List<Model>();
            models.Add(new Model(vertices, triangulos, new Vertex(0, 0, 0), (float)Math.Sqrt(3)));
            
            instances = new List<Instance> {
                 new Instance(models[0], new Vertex(     0,     0, 7.5f ), Mtx.RotY(0))};
       

            // here is not implemented the FOV in the view only the planes at that angle
            // to implement the FOV in the canvas we need to create also that matrix
            // of the camera with that same angle
            ComputePlanes(120);//degrees

            
        }
        public int AddModel(List<Vertex> vertexes, List<Triangle> triangles)
        {
            Model model = new Model(vertexes.ToArray(), triangles.ToArray(), new Vertex(0, 0, 0), (float)Math.Sqrt(3));
            models.Add(model);
            instances.Add(new Instance(model, new Vertex(0, 0, 7.5f), Mtx.RotY(0)));
            return models.IndexOf(model);
        }
       

        

        public void ComputePlanes(float fov)
        {
            Vertex left, right, bottom, top;
            float aspect = 1f;
            float near = 0.1f;

            float tanFov = (float)Math.Tan(fov * 0.5f * Math.PI / 180f);
            float height = 2f * tanFov * near;
            float width = height * aspect;

            // Left plane
            float sx = 1f * (width / 2f);
            float sy = 0f;
            float sz = near;

            left = new Vertex(sx, sy, sz);
            left = left.Normalize();

            // Right plane
            sx = -width / 2f;
            sy = 0f;
            sz = near;
            right = new Vertex(sx, sy, sz);
            right = right.Normalize();

            // Bottom plane
            sx = 0f;
            sy = -1f * (height / 2f);
            sz = near;
            bottom = new Vertex(sx, sy, sz);
            bottom = bottom.Normalize();

            // Top plane
            sx = 0f;
            sy = height / 2f;
            sz = near;
            top = new Vertex(sx, sy, sz);
            top = top.Normalize();
            
            camera.clipping_planes.Add(new Plane(new Vertex(0, 0, 1), 0));   // near
            camera.clipping_planes.Add(new Plane(left,0));  // left
            camera.clipping_planes.Add(new Plane(right, 0));  // right
            camera.clipping_planes.Add(new Plane(top, 0));  // top
            camera.clipping_planes.Add(new Plane(bottom, 0));  // bottom
        }

        public void Render()
        {
            FastClear();
            ClearZBuffer();
            RenderScene(camera, instances.ToArray());
            
        }

        // The PutPixel() function.
        private void PutPixel(int x, int y, float z, Color color)
        {
            
            x = canvas_width / 2 + x;
            y = canvas_height / 2 - y - 1;

            if (x < 0 || x >= canvas_width || y < 0 || y >= canvas_height)
                return;
           
                setPixel(x, y, color);
                
            
            
                
            
        }
        private void PutPixelBuffer(int x, int y, float z, Color color)
        {

            x = canvas_width / 2 + x;
            y = canvas_height / 2 - y - 1;

            if (x < 0 || x >= canvas_width || y < 0 || y >= canvas_height)
                return;
            if (z < zbuffer[(int)x, y])
            {
                //Console.WriteLine("zbuffer: " + zbuffer[(int)x, y] + " z: " + z);
                setPixel(x, y, color);
                zbuffer[(int)x, y] = z;
            }



        }

        List<float> Interpolate(float i0, float d0, float i1, float d1)
        {
            List<float> values = new List<float>();
            if (i0 == i1)
            {
                values.Add(d0);
                return values;
            }
            float a = ((float)d1 - (float)d0) / ((float)i1 - (float)i0);
            float d = d0;
            for (int i = (int)i0; i <= i1; i++)
            {
                values.Add(d);
                d = d + a;
            }
            return values;
        }

        private void Swap(ref Vertex a, ref Vertex b)
        {
            Vertex temp = a;
            a = b;
            b = temp;
        }
       
        

        void DrawLine(Vertex p0, Vertex p1, Color color)
        {
            
            var dx = p1.x - p0.x;
            var dy = p1.y - p0.y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                // The line is horizontal-ish. Make sure it's left to right.
                if (dx < 0)
                {                    
                    Swap(ref p0, ref p1);
                }

                // Compute the Y values and draw.
                var ys = Interpolate((int)p0.x, p0.y, (int)p1.x, p1.y);
                for (var x = (int)p0.x; x <= p1.x; x++)
                {
                    PutPixel(x, (int)ys[(x - (int)p0.x)],0.0f, color);
                }
            }
            else
            {
                // The line is vertical-ish. Make sure it's bottom to top.
                if (dy < 0)
                {
                    Swap(ref p0, ref p1);
                }

                // Compute the X values and draw.
                var xs = Interpolate((int)p0.y, p0.x, (int)p1.y, p1.x);
                
                for (var y = (int)p0.y; y <= p1.y; y++)
                {
                    PutPixel((int)xs[(y - (int)p0.y)], y,0.0f, color);
                }
            }
        }


        void DrawTriangle(Vertex p0, Vertex p1, Vertex p2, Color color, Camera camera)
        {
            if (IsFrontFace(p0, p1, p2, camera))
            {
                
                DrawBufferTriangle(p0, p1, p2, color);
            }


        }
        //create a method that uses backfacing culling to determine if a triangle is visible
        bool IsFrontFace(Vertex p0, Vertex p1, Vertex p2, Camera camera)
        {
            Vertex v0 = new Vertex(p1.x - p0.x, p1.y - p0.y, p1.z - p0.z);
            Vertex v1 = new Vertex(p2.x - p0.x, p2.y - p0.y, p2.z - p0.z);
            Vertex normal = Vertex.Cross(v0, v1);
            Vertex cameraVector =  camera.position -p0 ;
            float dot = Vertex.Dot(normal, cameraVector);

            if (dot >= 0)
                return true;
            return false;

        }


        // Converts 2D viewport coordinates to 2D canvas coordinates.
        Vertex ViewportToCanvas(Vertex p2d)
        {
            float vW = (float)canvas.Width / canvas.Height;
            return new Vertex((p2d.x * canvas.Width / vW), (p2d.y * canvas.Height / viewport_size), p2d.z);
        }

        Vertex ProjectVertex(Vertex v)
        {
            Vertex p = new Vertex(v.x * projection_plane_z / v.z, v.y * projection_plane_z / v.z, v.z);
            
            return ViewportToCanvas(p);
        }

        void RenderTriangle(Triangle triangle, List<Vertex> projected, Camera camera)
        {
            DrawTriangle(projected[triangle.v0], projected[triangle.v1], projected[triangle.v2], triangle.color, camera);
            

        }
        public void FillTriangle(Vertex p0, Vertex p1, Vertex p2, Color c)
        {
            List<float> x_left;
            List<float> x_right;

            if (p1.Y < p0.Y)
            {
                Vertex p = p0;
                p0 = p1;
                p1 = p;
            }
            if (p2.Y < p0.Y)
            {
                Vertex p = p0;
                p0 = p2;
                p2 = p;
            }
            if (p2.Y < p1.Y)
            {
                Vertex p = p2;
                p2 = p1;
                p1 = p;
            }

            List<float> x01 = Interpolate(p0.Y, p0.X, p1.Y, p1.X);
            List<float> x12 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            List<float> x02 = Interpolate(p0.Y, p0.X, p2.Y, p2.X);

            //x01.RemoveAt(x01.Count - 1);
            List<float> x012 = new List<float>();
            x01.RemoveAt(x01.Count - 1);
            x012.AddRange(x01);
            x012.AddRange(x12);

            int m = x02.Count / 2;
            if (m >= 0 && m < x02.Count && m < x012.Count)
            {
                if (x02[m] < x012[m])
                {
                    x_left = x02;
                    x_right = x012;
                }
                else
                {
                    x_left = x012;
                    x_right = x02;
                }

                for (var y = (int)p0.Y; y < p2.Y; y++)
                {
                    int index = y - (int)p0.Y;
                    if (index >= 0 && index < x_left.Count && index < x_right.Count)
                    {
                        for (var x = x_left[index]; x < x_right[index]; x++)
                        {
                            PutPixel((int)x, y,0, c);
                        }
                    }
                }
            }
        }
       

        public void DrawBufferTriangle(Vertex a, Vertex b, Vertex d, Color c)
        {
            Point p0 = new Point((int)a.x, (int)a.y);
            int z0 = (int)a.Z;
            Point p1 = new Point((int)b.x, (int)b.y);
            int z1 = (int)b.Z;
            Point p2 = new Point((int)d.x, (int)d.y);
            int z2 = (int)d.Z;
            if (p1.Y < p0.Y)
            {
                Point p = p0;
                p0 = p1;
                p1 = p;
            }
            if (p2.Y < p0.Y)
            {
                Point p = p0;
                p0 = p2;
                p2 = p;
            }
            if (p2.Y < p1.Y)
            {
                Point p = p2;
                p2 = p1;
                p1 = p;
            }
            List<float> x01 = Interpolate(p0.Y, p0.X, p1.Y, p1.X);
            List<float> h01 = Interpolate(p0.Y, (float)1/z0, p1.Y, (float)1/z1);


            List<float> x12 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            List<float> h12 = Interpolate(p1.Y, (float)1/z1, p2.Y,(float)1/z2);
            //Inverse(h12);
            List<float> x02 = Interpolate(p0.Y, p0.X, p2.Y, p2.X);
            List<float> h02 = Interpolate(p0.Y,  (float)1 / z0, p2.Y, (float)1/ z2);
            //Inverse(h02);
            List<float> x012 = new List<float>();
            List<float> h012 = new List<float>();
            x01.RemoveAt(x01.Count - 1);
            h01.RemoveAt(h01.Count - 1);
            x012.AddRange(x01);
            x012.AddRange(x12);
            h012.AddRange(h01);
            h012.AddRange(h12);
            int m = x02.Count / 2;
            if (m >= 0 && m < x02.Count && m < x012.Count)
            {
                List<float> x_left, x_right, h_left, h_right;
                if (x02[m] < x012[m])
                {
                    x_left = x02;
                    h_left = h02;

                    x_right = x012;
                    h_right = h012;
                }
                else
                {
                    x_left = x012;
                    h_left = h012;

                    x_right = x02;
                    h_right = h02;
                }
                for (int y = p0.Y; y <p2.Y; y++)
                {
                    int index = y - p0.Y;
                    float x_l = x_left[index];
                    float x_r = x_right[index];
                    List<float> h_segment = Interpolate(x_l, h_left[index], x_r, h_right[index]);
                    Inverse(h_segment);
                    for (float x = x_l; x <= x_r; x++) { 
                        int auxIndex = (int)Math.Round(x - x_l);
                        if(auxIndex>=0 && auxIndex < h_segment.Count)
                        {
                            float z = h_segment[auxIndex];
                            PutPixelBuffer((int)x, y, z, c);

                        }
                    }
                }

            }
        }

            // Clips a triangle against a plane. Adds output to triangles and vertices.
            private List<Triangle> ClipTriangle(Triangle triangle, Plane plane, List<Triangle> triangles, List<Vertex> vertexes)
        {
            
            Vertex v0 = vertexes[triangle.v0];
            Vertex v1 = vertexes[triangle.v1];
            Vertex v2 = vertexes[triangle.v2];

            // vertexes in front of the camera
            bool in0 = ((plane.normal * v0) + plane.Distance) > 0;
            bool in1 = ((plane.normal * v1) + plane.Distance) > 0;
            bool in2 = ((plane.normal * v2) + plane.Distance) > 0;

            int in_count = (in0 ? 1 : 0) + (in1 ? 1 : 0) + (in2 ? 1 : 0);

            if (in_count == 0)
            {
                //Console.WriteLine("count zero");
                // Nothing to do - the triangle is fully clipped out.
            }
            else if (in_count == 3)
            {
                // The triangle is fully in front of the plane.
                triangles.Add(triangle);
            }
            else if (in_count == 1)// one positive  
            {
                //Console.WriteLine("count one");
                // The triangle has one vertex in. Output is one clipped triangle.
            }
            else if (in_count == 2)// one negative
            {
                //Console.WriteLine("count two");
                // The triangle has two vertices in. Output is two clipped triangles.
            }

            return triangles;
        }

        private Model TransformAndClip(Plane[] clipping_planes, Model model, float scale, Mtx transform)
        {
            // Transform the bounding sphere, and attempt early discard.
            Vertex center = transform * model.bounds_center;
            float radius = model.bounds_radius * scale;
            for (int p = 0; p < clipping_planes.Length; p++)
            {
                float distance = (clipping_planes[p].normal * center) + clipping_planes[p].Distance;
                if (distance < -radius)
                {
                    return null;
                }
            }

            // Apply modelview transform.
            List<Vertex> vertices = new List<Vertex>();
            for (int i = 0; i < model.vertices.Length; i++)
            {
                vertices.Add(transform * model.vertices[i]);
            }

            // Clip the entire model against each successive plane.
            List<Triangle> triangles = new List<Triangle>(model.triangles);
            for (int p = 0; p < clipping_planes.Length; p++)
            {
                List<Triangle> new_triangles = new List<Triangle>();
                for (int i = 0; i < triangles.Count; i++)
                {
                    new_triangles = (ClipTriangle(triangles[i], clipping_planes[p], new_triangles, vertices));
                }
                triangles.AddRange(new_triangles);
            }

            return new Model(vertices.ToArray(), triangles.ToArray(), center, model.bounds_radius);
        }

        private void RenderModel(Model model)
        {
            // we would have to test here the best fit to
            // translate this to the GPU for massive parallelism
            List<Vertex> projected = new List<Vertex>();
            
            for (int i = 0; i < model.vertices.Length; i++)
            {
                projected.Add(ProjectVertex(model.vertices[i]));
            }

            for (int i = 0; i < model.triangles.Length; i++)
            {
                RenderTriangle(model.triangles[i], projected,camera);
            }
        }
        public void ShowZBuffer()
        {
            for (int i = 0; i < zbuffer.GetLength(0); i++)
            {
                for (int j = 0; j < zbuffer.GetLength(1); j++)
                {
                    if (zbuffer[i, j] != float.MaxValue)
                        Console.Write(zbuffer[i, j] + "\t");
                    else
                    { Console.Write("\t"); }
                }
                Console.WriteLine();

            }
        }
        public void ClearZBuffer()
        {
            for (int i = 0; i < zbuffer.GetLength(0); i++)
            {
                for (int j = 0; j < zbuffer.GetLength(1); j++)
                {
                    zbuffer[i, j] = float.MaxValue;
                }
            }
        }

        public void RenderScene(Camera camera, Instance[] instances)
        {
            Mtx cameraMatrix;
            Mtx transform;
            Model clipped;

            // if we want to use FOV here we also need to add the FOV matrix of the camera
            cameraMatrix = (camera.orientation.Transposed()) * Mtx.MakeTranslationMatrix(-camera.position);
            for (int i = 0; i < instances.Length; i++)
            {
                transform   = (cameraMatrix * instances[i].transform);
                clipped     = TransformAndClip(camera.clipping_planes.ToArray(), instances[i].model, instances[i].scale, transform);

                if (clipped != null)
                {
                    RenderModel(clipped);
                }
            }

        }
        public void FastClear()
        {
            unsafe
            {
                BitmapData bitmapData = canvas.LockBits(new Rectangle(0, 0, canvas.Width, canvas.Height), ImageLockMode.ReadWrite, canvas.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(canvas.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* bits = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0;// (byte)oldBlue;
                        bits[x + 1] = 0;// (byte)oldGreen;
                        bits[x + 2] = 0;// (byte)oldRed;
                        bits[x + 3] = 0;// (byte)oldRed;
                    }
                });
                canvas.UnlockBits(bitmapData);
            }
        }
        //make a method that scales the instances for a scale s
        public void Scales(float scale, int index)
        {
            float s = scale / instances[index].scalation;
               instances[index].transform *= Mtx.MakeScalingMatrix(s);
            instances[index].scalation = scale;
            
        }
        public void Rotate(Vertex angle, int index)
        {
            
            Vertex rot = angle - instances[index].angle;
            instances[index].transform *= Mtx.Rotate(rot);
            instances[index].angle = angle;
        }
        public void Translate(Vertex translation, int index)
        {
            Vertex tras= translation- instances[index].translation;
             instances[index].transform *= Mtx.MakeTranslationMatrix(tras) ;
            instances[index].translation = translation;

        }
        public void Inverse(List<float> numbers)
        {
            for (int i =0; i < numbers.Count; i++)
            {
                numbers[i] = 1.0f / numbers[i];
            }
        }
        public void PrintList(List<float> numbers)
        {
            String text = "";
            for (int i = 0; i < numbers.Count; i++)
            {
               text+= numbers[i] + ", ";
            }
            Console.WriteLine(text);
        }
        public void setPixel(int x, int y, Color c)
        {
            long res = (int)((x * pixelFormatSize) + (y * stride));

            bits[res + 0] = c.B;// (byte)Blue;
            bits[res + 1] = c.G;// (byte)Green;
            bits[res + 2] = c.R;// (byte)Red;
            bits[res + 3] = c.A;// (byte)Alpha;
            
        }
        public void Animate(int frame, int initialFrame)
        {
            //Console.WriteLine(frame + "|" + initialFrame);
            for(int i = 0; i < instances.Count; i++)
            {
                MtxTransform transformation = instances[i].FindTransformation(frame);
                if (transformation == null)
                {
                    continue;
                }else if (frame==initialFrame) {
                    instances[i].transform = instances[i].initialTransform;
                    return;
                }
                else
                {
                    instances[i].transform=transformation.Mtx;
                }

            }
        }
        public void SaveFrame(int frame)
        {
            for (int i = 0;i < instances.Count;i++)
            {
                //Console.WriteLine(instances[i].transform.ToString());
                instances[i].SaveTransformations(frame);
            }
            Console.WriteLine("-------------------------------------");
        }
        public void CalculateSteps(int initialFrame, int finalFrame)
        {
            
            for (int i = 0; i < instances.Count; i++)
                instances[i].CalculateSteps(initialFrame, finalFrame);
        }
       



    }
}
