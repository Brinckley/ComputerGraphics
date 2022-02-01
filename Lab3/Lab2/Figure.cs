using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Lab2
{
    public enum View
    {
        Nothing, Top, Side, Front, Isometric
    }
# region Vertices and Polygon classes
public class Vertex 
    {
        public List<Polygon> polygons; //list of connected polygons
                
        public DVector4 Point_InLocalSpace;
        public DVector4 Point_InGlobalSpace;

        public Color Color;
        
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
            Normal_InLocalSpace.Normalize(); //it's important to normalize the vector before any later manipulations 
        }
    }
    #endregion

    public class Figure
    {

        public List<Vertex> pvertices; //all vertices 
        public List<Polygon> ppolygons; //all polygons

        public double a;
        public double b;
        public double c;
        public double r;
        public double inner;
        public int accuracyVertical;
        public int accuracyHorizontal;

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

        public Figure(double a, double b, double c, double r, double inner,int accuracyVertical, int accuracyHorizontal)
        {//initialization for ellipsoid
            pvertices = new List<Vertex>(); //all vertices for the pyramid  
            ppolygons = new List<Polygon>(); //all polygons for the pyramid 
            Point_Transform = new DMatrix4(); // matrix for transformation of the point coordinates 
            Point_Viewport = new DMatrix4(); // matrix for point view changing ---
            Normal_Transform = new DMatrix4(); // matrix for transformation of the normal coordinates 
            Normal_Viewport = new DMatrix4(); // matrix for point view changing ---
            Point_Transform = DMatrix4.Identity; 
            Normal_Transform = DMatrix4.Identity;
            this.a = a;
            this.b = b;
            this.c = c;
            this.r = r;
            this.inner = inner;
            this.accuracyVertical = accuracyVertical;
            this.accuracyHorizontal = accuracyHorizontal;
            GenerateEllipsoid(); //generating an object according to the task
        }
        
        public void GenerateEllipsoid()
        {
            // Standard equation: (x/a)^2 + (y/b)^2 + (z/c)^2 = r
            // Parameterization:                                      ----------
            // x = a * sin(theta) * cos(phi)                        /            \
            // y = b * sin(theta) * sin(phi)                        \            /
            // z = c * cos(theta)                                     ----------
            // 0 <= theta <= pi    0 <= phi < 2pi
            // that means: theta is for vertical lines, phi - for horizontal (we draw a circle as a 2pi angle)

            pvertices.Add(new Vertex(0f, 0f, (float) (c * inner), 1f));
                
            for (int i = 1; i <= accuracyHorizontal * inner; ++i)
            {
                float theta = (float) (i * Math.PI / (1 + accuracyHorizontal));
                for (int j = 0; j < accuracyVertical; ++j)
                {
                    float phi = (float) (j * 2 * Math.PI / accuracyVertical);
                    pvertices.Add(new Vertex(
                        (float) (a * Math.Sin(theta) * Math.Cos(phi)),
                        (float) (b * Math.Sin(theta) * Math.Sin(phi)),
                        (float) (c * Math.Cos(theta)),
                        1f));
                }
            }
            pvertices.Add(new Vertex(0f, 0f, (float) - (c * inner), 1f)); //hear comes the line

            for (int i = 1; i < accuracyVertical; ++i)
            {
                ppolygons.Add(new Polygon(new List<Vertex>
                {
                    pvertices[0],
                    pvertices[i + 1],
                    pvertices[i]
                }));
            }
            
            ppolygons.Add(new Polygon(new List<Vertex>
            {
                pvertices[0],
                pvertices[1], 
                pvertices[accuracyVertical - 1]
            }));
            
            for (int i = 0; i < accuracyHorizontal * inner- 1; ++i)
            {
                int shiftOnParralel = 1 + i * accuracyVertical;
                for (int j = 0; j < accuracyVertical - 1; ++j)
                {
                    ppolygons.Add(new Polygon(new List<Vertex>{
                        pvertices[shiftOnParralel + j], 
                        pvertices[shiftOnParralel + j + 1], 
                        pvertices[shiftOnParralel + accuracyVertical + j + 1], 
                        pvertices[shiftOnParralel + accuracyVertical + j]}));
                }
                ppolygons.Add(new Polygon(new List<Vertex>{
                    pvertices[shiftOnParralel + accuracyVertical - 1], 
                    pvertices[shiftOnParralel], 
                    pvertices[shiftOnParralel + accuracyVertical], 
                    pvertices[shiftOnParralel + accuracyVertical + accuracyVertical - 1]}));
            }
            
            for (int i = pvertices.Count - accuracyVertical - 1; i < pvertices.Count - 2; ++i) //upper side
            {
                ppolygons.Add(new Polygon(new List<Vertex>
                {
                    pvertices[pvertices.Count - 1],
                    pvertices[i],
                    pvertices[i + 1]
                }));
            }
            
            ppolygons.Add(new Polygon(new List<Vertex> //last part
            {
                pvertices[pvertices.Count - 1],
                pvertices[pvertices.Count - 2],
                pvertices[pvertices.Count - accuracyVertical - 1]
            }));
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

        public void FigurePaint(object sender, PaintEventArgs e, View view)
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
            }
            
            
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

                e.Graphics.DrawPolygon(new Pen(Color.Black), pointFs.ToArray()); //drawing borders
                e.Graphics.FillPolygon(new SolidBrush(p.Color), pointFs.ToArray()); //filling with color 
            }
        }
    }
}
