using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LIVE_DEMO
{
    public partial class MAIN_FORM : Form
    {
        Rasterization raster;
        Random random;

        int modelIndex;
        int transform;
        bool animate;
        int initialFrame;
        int finalFrame;

        public MAIN_FORM()
        {
            InitializeComponent();
        }

        private void MAIN_FORM_Load(object sender, EventArgs e)
        {

            random = new Random();
            transform = 0;
            animate = false;
            initialFrame = -1;
            finalFrame = -1;
            TB_TIME.Maximum = (10000 / TIMER.Interval) + 1;
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            if (raster == null)
                return;
            if (animate)
                raster.Animate(TB_TIME.Value, initialFrame);
            raster.Render();
            PCT_CANVAS.Invalidate();
            if (animate)
            {
                if (TB_TIME.Value==TB_TIME.Maximum)
                    TB_TIME.Value = 0;
                else
                    TB_TIME.Value++;
                Time_L.Text = "Time";
            }
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            if(OpenObj.ShowDialog() == DialogResult.OK)
            { 
                string filePath = OpenObj.FileName;
                List<Vertex> vertexes = new List<Vertex>();
                List<Triangle> triangles = new List<Triangle>();
                StreamReader streamReader = new StreamReader(filePath);
                //String[] lines = streamReader.ReadToEnd().Split('\n');
                using (streamReader) {
                    string line;
                    while((line = streamReader.ReadLine()) != null)
                    {
                        List<int> indexes = new List<int>();
                        if (line.StartsWith("v "))
                        {
                            string[] tokens = line.Split(' ');
                            float x = float.Parse(tokens[1]);
                            float y = float.Parse(tokens[2]);
                            float z = float.Parse(tokens[3]);
                            Vertex ver = new Vertex(x, y, z);
                            vertexes.Add(ver);
                            
                        }
                        else if (line.StartsWith("f "))
                        {
                            
                            string[] aux = line.Split(' ');
                            for(int i=1; i<aux.Length; i++)
                            {
                                indexes.Add(int.Parse(aux[i].Split('/')[0])-1);
                            }
                            Triangle triangle = new Triangle(indexes[0], indexes[1], indexes[2],GetRandomColor());
                            
                            triangles.Add(triangle);
                            
                        }
                    }
                }
                if(raster == null)
                {
                    raster = new Rasterization(PCT_CANVAS.Size, vertexes, triangles);
                    PCT_CANVAS.Image = raster.Canvas;
                    TreeNode node = new TreeNode(GetFileName(filePath));
                    node.Tag = 0;
                    modelIndex = 0;
                    Tree.Nodes.Add(node);
                }
                else
                {
                    TreeNode node = new TreeNode(GetFileName(filePath));
                    node.Tag = raster.AddModel(vertexes, triangles);
                    modelIndex = (int)node.Tag;
                    Tree.Nodes.Add(node);
                    
                    
                }
            }
        }

        public string GetFileName(string filePath)
        {
            int lastSlashIndex = filePath.LastIndexOf('\\');
            int lastBackslashIndex = filePath.LastIndexOf('/');

            int lastIndex = Math.Max(lastSlashIndex, lastBackslashIndex);

            if (lastIndex == -1)
            {
                return filePath;
            }
            else
            {
                return filePath.Substring(lastIndex + 1);
            }
        }


        public Color GetRandomColor()
            {
            
                 int randomNumber = random.Next(0, 8);

                switch (randomNumber)
                {
                    case 0:
                        return Color.Gray;
                    case 1:
                        return Color.DarkGray;
                    case 2:
                        return Color.DarkSlateGray;
                    case 3:
                        return Color.DimGray;
                    case 4:
                        return Color.LightGray;
                    case 5:
                        return Color.LightSlateGray;
                    case 6:
                        return Color.Black;
                    case 7:
                        return Color.SlateGray;
                    default:
                        throw new InvalidOperationException("Unexpected random number.");
                }
        }

        private void BTN_EXE_Click(object sender, EventArgs e)
        {
            animate = !animate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (raster == null)
                return;
            if(initialFrame == -1)
            {
                initialFrame= TB_TIME.Value;
                raster.SaveFrame(TB_TIME.Value);

            }
            else if (finalFrame == -1)
            {
                finalFrame= TB_TIME.Value;
                raster.SaveFrame(TB_TIME.Value);
                for (int i = 0; i < raster.instances.Count; i++)
                {
                    Instance ints = raster.instances[i];
                    for (int j = 0; j < ints.transformations.Count; j++)
                    {
                        Info.Text = "Frame Saved";

                    }
                }
                raster.CalculateSteps(initialFrame, finalFrame);


            }
        }

        private void TREE_AfterSelect(object sender, TreeViewEventArgs e)
        {
            modelIndex = (int)Tree.SelectedNode.Tag;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(raster != null) {
                Vertex t = new Vertex(TB_Trans_X.Value, TB_Trans_Y.Value, TB_Trans_Z.Value);
                switch (transform)
                {
                    case 1:
                        raster.Rotate(t, modelIndex);
                        break;
                    case 2:
                        raster.Translate(t, modelIndex);
                        break;
                    case 3:
                        float value = ((float)TB_Trans_X.Value) / 100;
                        raster.Scales(value, modelIndex);
                        break;
                    default: 
                        break;
                }
            }
              
        }

        private void CB_TRANSLATE_CheckedChanged(object sender, EventArgs e)
        {
            RotateCB.Checked = false;
            ScaleCB.Checked = false;
            int maximum = 10;
            int minimum = -10;
            int value = 0;
            TB_Trans_X.Maximum = maximum;
            TB_Trans_Y.Maximum = maximum;
            TB_Trans_Z.Maximum = maximum;
            TB_Trans_X.Minimum = minimum;
            TB_Trans_Y.Minimum = minimum;
            TB_Trans_Z.Minimum = minimum;
            TB_Trans_X.Value = value;
            TB_Trans_Y.Value = value;
            TB_Trans_Z.Value = value;
            TB_Trans_Y.Visible = true;
            TB_Trans_Z.Visible = true;
            transform = 2;
            X_L.Text = "Translate X";
            Y_L.Text = "Translate Y";
            Z_L.Text = "Translate Z";
        }

        private void CB_ROTATE_CheckedChanged(object sender, EventArgs e)
        {
            ScaleCB.Checked = false;
            TranslateCB.Checked = false;
            int maximum = 360;
            int minimum = 0;
            int value = 0;
            TB_Trans_X.Maximum = maximum;
            TB_Trans_Y.Maximum = maximum;
            TB_Trans_Z.Maximum = maximum;
            TB_Trans_X.Minimum = minimum;
            TB_Trans_Y.Minimum = minimum;
            TB_Trans_Z.Minimum = minimum;
            TB_Trans_X.Value = value;
            TB_Trans_Y.Value = value;
            TB_Trans_Z.Value = value;
            TB_Trans_Y.Visible = true;
            TB_Trans_Z.Visible = true;
            transform = 1;
            X_L.Text = "Rotate X";
            Y_L.Text = "Rotate Y";
            Z_L.Text = "Rotate Z";
        }

        private void CB_SCALE_CheckedChanged(object sender, EventArgs e)
        {
            RotateCB.Checked = false;
            TB_Trans_Y.Visible = false;
            TB_Trans_Z.Visible = false;
            TranslateCB.Checked = false;
            TB_Trans_X.Maximum = 200;
            TB_Trans_X.Minimum = 0;
            TB_Trans_X.Value = 100;
            transform = 3;
            X_L.Text = "Scale";
            Y_L.Text = "";
            Z_L.Text = "";
        }
    }
}
