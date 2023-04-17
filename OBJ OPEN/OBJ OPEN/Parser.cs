using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIVE_DEMO
{
    public class ObjParser
    {
        public List<float[]> Vertices { get; private set; }
        public List<int[]> Faces { get; private set; }

        public ObjParser(string filename)
        {
            Vertices = new List<float[]>();
            Faces = new List<int[]>();

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (tokens[0] == "v")
                    {
                        float[] vertex = new float[3];

                        for (int i = 0; i < 3; i++)
                        {
                            vertex[i] = float.Parse(tokens[i + 1]);
                        }

                        Vertices.Add(vertex);
                    }
                    else if (tokens[0] == "f")
                    {
                        int[] face = new int[3];

                        for (int i = 0; i < 3; i++)
                        {
                            string[] subtokens = tokens[i + 1].Split('/');
                            face[i] = int.Parse(subtokens[0]) - 1;  // subtract 1 to convert to zero-based indexing
                        }

                        Faces.Add(face);
                    }
                }
            }
        }
    }
}
