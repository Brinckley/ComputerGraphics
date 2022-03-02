using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Lab2
{
    enum View
    {
        Nothing, Top, Side, Front, Isometric
    }
# region Vertices and Polygon classes
public class Vertex 
    {
        public List<Polygon> polygons; //list of connected polygons
                
        public DVector4 Point_InLocalSpace;
        public DVector4 Point_InGlobalSpace;
        
        public Vertex()
        {
            Point_InLocalSpace = new DVector4(1, 1, 1,1);
            Point_InGlobalSpace = new DVector4();
            polygons = new List<Polygon>();
        }
        
        public Vertex(float x, float y, float z, float w)
        {
            Point_InLocalSpace = new DVector4(x, y, z, w);
            Point_InGlobalSpace = new DVector4();
            polygons = new List<Polygon>();
        }
    }

    public class Polygon 
    {
        public List<Vertex> vertices; //included vertices 
                
        public DVector4 Normal_InLocalSpace;
        public DVector4 Normal_InGlobalSpace;
        
        public bool IsVisible;
        public Color Color;
        
        public Polygon()
        {
            Random random = new Random();
            Normal_InLocalSpace = new DVector4(1, 1, 1, 0);
            Normal_InGlobalSpace = new DVector4(1, 1, 1, 0);
            Color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            IsVisible = false;
            vertices = new List<Vertex>();
        }
                
        public Polygon(List<Vertex> vertices)
        {
            this.vertices = vertices;
            Random random = new Random();
            Normal_InLocalSpace = new DVector4(1, 1, 1, 0);
            Normal_InGlobalSpace = new DVector4(1, 1, 1, 0);
            Color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            IsVisible = false;
        }
        
        DVector4 Cross(DVector4 v1, DVector4 v2)
        {
            double x, y, z;
            x = v1.Y * v2.Z - v2.Y * v1.Z;
            y = (v1.X * v2.Z - v2.X * v1.Z) * -1;
            z = v1.X * v2.Y - v2.X * v1.Y;

            var rtnvector = new DVector4(x, y, z, 0);
            return rtnvector;
        }
        public void SetNormal()
        {
            DVector4 a = vertices[1].Point_InLocalSpace - vertices[0].Point_InLocalSpace;
            DVector4 b = vertices[2].Point_InLocalSpace - vertices[0].Point_InLocalSpace;
            Normal_InLocalSpace = Cross(b, a);
        }
    }
    #endregion
    class Pyramid
    {
        public bool Grid = false;

        public List<Vertex> pvertices; //all vertices 
        public List<Polygon> ppolygons; //all polygons
        public void Generate()
        {
            //bottom side coordinates
            pvertices = new List<Vertex>();
            pvertices.Add(new Vertex(100f, 0,-10f, 1f));                                      //0
            pvertices.Add(new Vertex(50f, - (float)Math.Sin(Math.PI / 3) * 100f, -10f, 1f));    //1
            pvertices.Add(new Vertex(- 50f, - (float)Math.Sin(Math.PI / 3) * 100f, -10f, 1f));  //2
            pvertices.Add(new Vertex(- 100f, 0, -10f, 1f));                                     //3
            pvertices.Add(new Vertex(- 50f, (float)Math.Sin(Math.PI / 3) * 100f, -10f, 1f));    //4
            pvertices.Add(new Vertex(50f, (float)Math.Sin(Math.PI / 3) * 100f, -10f, 1f));      //5
            //upper side coordinates
            pvertices.Add(new Vertex(40f, 0, 70f, 1f));                                       //6   --0
            pvertices.Add(new Vertex(20f, - (float)Math.Sin(Math.PI / 3) * 40f, 70f, 1f));     //7   --1
            pvertices.Add(new Vertex(- 20f, - (float)Math.Sin(Math.PI / 3) * 40f, 70f, 1f));   //8   --2
            pvertices.Add(new Vertex(- 40f, 0, 70f, 1f));                                     //9   --3
            pvertices.Add(new Vertex(- 20f, (float)Math.Sin(Math.PI / 3) * 40f, 70f, 1f));     //10  --4
            pvertices.Add(new Vertex(20f, (float)Math.Sin(Math.PI / 3) * 40f, 70f, 1f));       //11  --5

            ppolygons = new List<Polygon>(); //creating templates for later filling
            for (int i = 0; i < 8; ++i)
            {
                ppolygons.Add(new Polygon());
            }
            //fill in the poly with vertices          match vertices with their polygons
            //bottom polygon
            ppolygons[0] = new Polygon();
            ppolygons[0].Color = Color.DarkOrange;
            ppolygons[0].vertices.Add(pvertices[5]); pvertices[0].polygons.Add(ppolygons[0]);
            ppolygons[0].vertices.Add(pvertices[4]); pvertices[1].polygons.Add(ppolygons[0]);
            ppolygons[0].vertices.Add(pvertices[3]); pvertices[2].polygons.Add(ppolygons[0]);
            ppolygons[0].vertices.Add(pvertices[2]); pvertices[3].polygons.Add(ppolygons[0]);
            ppolygons[0].vertices.Add(pvertices[1]); pvertices[4].polygons.Add(ppolygons[0]);
            ppolygons[0].vertices.Add(pvertices[0]); pvertices[5].polygons.Add(ppolygons[0]);
          //  ppolygons[0].Normal_InLocalSpace = new DVector4(0, 0, -5, 0);
            //side polygon #1
            ppolygons[1] = new Polygon();
            ppolygons[1].Color = Color.Chartreuse;
            ppolygons[1].vertices.Add(pvertices[0]); pvertices[0].polygons.Add(ppolygons[1]);
            ppolygons[1].vertices.Add(pvertices[1]); pvertices[1].polygons.Add(ppolygons[1]);
            ppolygons[1].vertices.Add(pvertices[7]); pvertices[7].polygons.Add(ppolygons[1]);
            ppolygons[1].vertices.Add(pvertices[6]); pvertices[6].polygons.Add(ppolygons[1]);
          //  ppolygons[1].Normal_InLocalSpace = new DVector4(17320508076,-10000000000,12990381057,0);
            //side polygon #2
            ppolygons[2] = new Polygon();
            ppolygons[2].Color = Color.Crimson;
            ppolygons[2].vertices.Add(pvertices[1]); pvertices[1].polygons.Add(ppolygons[2]);
            ppolygons[2].vertices.Add(pvertices[2]); pvertices[2].polygons.Add(ppolygons[2]);
            ppolygons[2].vertices.Add(pvertices[8]); pvertices[8].polygons.Add(ppolygons[2]);
            ppolygons[2].vertices.Add(pvertices[7]); pvertices[7].polygons.Add(ppolygons[2]);
           // ppolygons[2].Normal_InLocalSpace = new DVector4(0, -20000000000, 12990381057,0);
            //side polygon #3
            ppolygons[3] = new Polygon();
            ppolygons[3].Color = Color.White;
            ppolygons[3].vertices.Add(pvertices[2]); pvertices[2].polygons.Add(ppolygons[3]);
            ppolygons[3].vertices.Add(pvertices[3]); pvertices[3].polygons.Add(ppolygons[3]);
            ppolygons[3].vertices.Add(pvertices[9]); pvertices[9].polygons.Add(ppolygons[3]);
            ppolygons[3].vertices.Add(pvertices[8]); pvertices[8].polygons.Add(ppolygons[3]);
          //  ppolygons[3].Normal_InLocalSpace = new DVector4(-17320508076,-10000000000,12990381057,0);
            //side polygon #4
            ppolygons[4] = new Polygon();
            ppolygons[4].Color = Color.Aqua;
            ppolygons[4].vertices.Add(pvertices[3]); pvertices[3].polygons.Add(ppolygons[4]);
            ppolygons[4].vertices.Add(pvertices[4]); pvertices[4].polygons.Add(ppolygons[4]);
            ppolygons[4].vertices.Add(pvertices[10]);pvertices[10].polygons.Add(ppolygons[4]);
            ppolygons[4].vertices.Add(pvertices[9]); pvertices[9].polygons.Add(ppolygons[4]);
           // ppolygons[4].Normal_InLocalSpace = new DVector4(-17320508076,10000000000,12990381057,0);
            //side polygon #5
            ppolygons[5] = new Polygon();
            ppolygons[5].Color = Color.Fuchsia;
            ppolygons[5].vertices.Add(pvertices[4]); pvertices[4].polygons.Add(ppolygons[5]);
            ppolygons[5].vertices.Add(pvertices[5]); pvertices[5].polygons.Add(ppolygons[5]);
            ppolygons[5].vertices.Add(pvertices[11]);pvertices[11].polygons.Add(ppolygons[5]);
            ppolygons[5].vertices.Add(pvertices[10]);pvertices[10].polygons.Add(ppolygons[5]);
           // ppolygons[5].Normal_InLocalSpace = new DVector4(0, 20000000000, 12990381057, 0);
            //side polygon #6
            ppolygons[6] = new Polygon();
            ppolygons[6].Color = Color.Gold;
            ppolygons[6].vertices.Add(pvertices[6]); pvertices[0].polygons.Add(ppolygons[6]);
            ppolygons[6].vertices.Add(pvertices[11]); pvertices[5].polygons.Add(ppolygons[6]);
            ppolygons[6].vertices.Add(pvertices[5]);pvertices[11].polygons.Add(ppolygons[6]);
            ppolygons[6].vertices.Add(pvertices[0]); pvertices[6].polygons.Add(ppolygons[6]);
           // ppolygons[6].Normal_InLocalSpace = new DVector4(17320508076, 10000000000, 12990381057,0);
            //top polygon
            ppolygons[7] = new Polygon();
            ppolygons[7].Color = Color.Indigo;
            ppolygons[7].vertices.Add(pvertices[6]); pvertices[6].polygons.Add(ppolygons[0]);
            ppolygons[7].vertices.Add(pvertices[7]); pvertices[7].polygons.Add(ppolygons[0]);
            ppolygons[7].vertices.Add(pvertices[8]); pvertices[8].polygons.Add(ppolygons[0]);
            ppolygons[7].vertices.Add(pvertices[9]); pvertices[9].polygons.Add(ppolygons[0]);
            ppolygons[7].vertices.Add(pvertices[10]); pvertices[10].polygons.Add(ppolygons[0]);
            ppolygons[7].vertices.Add(pvertices[11]); pvertices[11].polygons.Add(ppolygons[0]);
            //ppolygons[7].Normal_InLocalSpace = new DVector4(0, 0, 70f, 0);
            //MessageBox.Show("vert Length   " + pvertices.Count.ToString() + " \n  Polygon Length   " + ppolygons.Count.ToString());
        }

        public DMatrix4 Point_Transform;
        public DMatrix4 Normal_Transform;
        public DMatrix4 Point_Viewport;
        public DMatrix4 Normal_Viewport;

        public double angleX = 0; //rotation angles 
        public double angleY = 0;
        public double angleZ = 0;

        public double offsetX = 0; //offset for every axis
        public double offsetY = 0;
        public double offsetZ = 0;

        public double scaleX = 1; //scale for all axis
        public double scaleY = 1;
        public double scaleZ = 1;
        public Pyramid()
        {//initialization 
            pvertices = new List<Vertex>(); //all vertices for the pyramid  
            ppolygons = new List<Polygon>(); //all polygons for the pyramid 
            Point_Transform = new DMatrix4(); // matrix for transformation of the point coordinates 
            Point_Viewport = new DMatrix4(); // matrix for point view changing ---
            Normal_Transform = new DMatrix4(); // matrix for transformation of the normal coordinates 
            Normal_Viewport = new DMatrix4(); // matrix for point view changing ---
            Point_Transform = DMatrix4.Identity; 
            Normal_Transform = DMatrix4.Identity;
            Generate(); //generating an object according to the task
        }
        
        public DMatrix4 NormalVecTransf(DMatrix4 matrix) { //doesn't want to work from the Math class????????
            return new DMatrix4(
                matrix.M33 * matrix.M22 - matrix.M23 * matrix.M32, 
                matrix.M23 * matrix.M31 - matrix.M21 * matrix.M33, 
                matrix.M21 * matrix.M32 - matrix.M31 * matrix.M22, 0,
                matrix.M13 * matrix.M32 - matrix.M33 * matrix.M12,
                matrix.M33 * matrix.M11 - matrix.M13 * matrix.M31,
                matrix.M31 * matrix.M12 - matrix.M11 * matrix.M32, 0,
                matrix.M23 * matrix.M12 - matrix.M13 * matrix.M22,
                matrix.M21 * matrix.M13 - matrix.M23 * matrix.M11,
                matrix.M11 * matrix.M22 - matrix.M21 * matrix.M12, 0,
                0,   0,   0,   0);
        }
        
        
        
        public double globalScaleX = 1; //scaling parameters for form resize
        public double globalScaleY = 1;
        public double globalScaleZ = 1;
        public double globalOffsetX = 0; //offset parameters for form resize
        public double globalOffsetY = 0;
        public double globalOffsetZ = 0;


        public void Transformation(View view)
        {
            //applying transformation for transform matrices
            Point_Transform = DMatrix4.Identity; //for point
            Matrix4Worker.Scale4(ref Point_Transform, scaleX * globalScaleX, scaleY * globalScaleY, scaleZ * globalScaleZ);  
            Matrix4Worker.RotationX4(ref Point_Transform, angleX);
            Matrix4Worker.RotationY4(ref Point_Transform, angleY);
            Matrix4Worker.RotationZ4(ref Point_Transform, angleZ);
            Matrix4Worker.Translate4(ref Point_Transform, offsetX + globalOffsetX, offsetY + globalOffsetY, offsetZ + globalOffsetZ);
            
            if (view != View.Nothing)
            {
                if (view == View.Front)
                {
                    Matrix4Worker.SetFrontView(ref Point_Transform);
                }
                if (view == View.Side)
                {
                    Matrix4Worker.SetSideView(ref Point_Transform);
                }
                if (view == View.Top)
                {
                    Matrix4Worker.SetTopView(ref Point_Transform);
                }
                if (view == View.Isometric)
                {
                    Matrix4Worker.SetIsometricView(ref Point_Transform);
                }
            }
            
            //Normal_Transform = DMatrix4.Identity;
            Normal_Transform = NormalVecTransf(Point_Transform);
        }
        

        public void PyramidPaint(object sender, PaintEventArgs e, View view)
        {
            Transformation(view);
            bool checkVisibility = true;

            foreach (var v in pvertices) //transform every point
            {
                v.Point_InGlobalSpace = Point_Transform * v.Point_InLocalSpace;
            }

            foreach (var p in ppolygons) //transform every normal + visibility check
            {
                p.SetNormal();
                p.Normal_InGlobalSpace = Normal_Transform * p.Normal_InLocalSpace;
                //if normal is more than zero we need to draw the polygon
                p.IsVisible = p.Normal_InGlobalSpace.Z > 0;
                
                /*if (p.Color == Color.DarkOrange)
                {
                    MessageBox.Show("Normal X:" + p.Normal_InGlobalSpace.X + " Y: " + p.Normal_InGlobalSpace.Y + " Z: " +
                                    p.Normal_InGlobalSpace.Z);
                }*/
            }
            
            /*
            pvertices.Sort(delegate(Vertex v1, Vertex v2)
            {
                if (v1.Point_InGlobalSpace.Z < v2.Point_InGlobalSpace.Z)
                {
                    return 1;
                }
                return -1;
            }); //sorting according to the camera direction*/
            
            foreach (var p in ppolygons)
            {
                if (!p.IsVisible && checkVisibility) continue;
                //MessageBox.Show("Z: " + p.Normal_InGlobalSpace.Z);
                
                List<PointF> pointFs = new List<PointF>();
                
                for (int i = 0; i < p.vertices.Count; ++i)
                {
                    pointFs.Add(new PointF((float) p.vertices[i].Point_InGlobalSpace.X,
                        (float) p.vertices[i].Point_InGlobalSpace.Y));
                }

                if (!Grid)
                {
                    e.Graphics.FillPolygon(new SolidBrush(p.Color), pointFs.ToArray()); //filling with color 
                }
                e.Graphics.DrawPolygon(new Pen(Color.Black), pointFs.ToArray()); //drawing borders
                
            }
        }
    }
}