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
            polygons = new List<Polygon>();
        }
        
        public Vertex(float x, float y, float z, float w)
        {
            Point_InLocalSpace = new DVector4(x, y, z, w);
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
            Color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
            IsVisible = false;
            vertices = new List<Vertex>();
        }
                
        public Polygon(List<Vertex> vertices)
        {
            Random random = new Random();
            Color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
            IsVisible = false;
            this.vertices = vertices;
        }
        
        public void SetNormalAndVisibility()
        {
            if(vertices.Count < 3) return;
        
            Normal_InLocalSpace = DVector4.Multiply(vertices[1].Point_InGlobalSpace - vertices[0].Point_InGlobalSpace, 
                vertices[2].Point_InGlobalSpace - vertices[0].Point_InGlobalSpace); //setting normal
            IsVisible = Normal_InLocalSpace > DVector4.Zero; //if normal is more than zero we need to draw the polygon
        }
    }
    #endregion
    class Pyramid : Form1
    {

        public List<Vertex> pvertices;
        public List<Polygon> ppolygons;
        
        public void Generate() 
        {
            pvertices = new List<Vertex>();
            //bottom side coordinates
            pvertices.Add(new Vertex(10f, 0f, 0f, 0f));                                     //0
            pvertices.Add(new Vertex(5f, - (float)Math.Sin(Math.PI / 3) * 10f, 0f, 1f));    //1
            pvertices.Add(new Vertex(- 5f, - (float)Math.Sin(Math.PI / 3) * 10f, 0f, 1f));  //2
            pvertices.Add(new Vertex(- 10f, 0f, 0f, 1f));                                   //3
            pvertices.Add(new Vertex(- 5f, (float)Math.Sin(Math.PI / 3) * 10f, 0f, 1f));    //4
            pvertices.Add(new Vertex(5f, (float)Math.Sin(Math.PI / 3) * 10f, 0f, 1f));      //5
            //upper side coordinates
            pvertices.Add(new Vertex(4f, 0f, 7f, 0f));                                      //6   --0
            pvertices.Add(new Vertex(2f, - (float)Math.Sin(Math.PI / 3) * 4f, 7f, 1f));     //7   --1
            pvertices.Add(new Vertex(- 2f, - (float)Math.Sin(Math.PI / 3) * 4f, 7f, 1f));   //8   --2
            pvertices.Add(new Vertex(- 4f, 0f, 7f, 1f));                                    //9   --3
            pvertices.Add(new Vertex(- 2f, (float)Math.Sin(Math.PI / 3) * 4f, 7f, 1f));     //10  --4
            pvertices.Add(new Vertex(2f, (float)Math.Sin(Math.PI / 3) * 4f, 7f, 1f));       //11  --5

            ppolygons = new List<Polygon>(); //creating templates for later filling
            for (int i = 0; i < 8; ++i)
            {
                ppolygons.Add(new Polygon());
            }
            //fill in the poly with vert             coordinate vert with their poly
            //bottom polygon
            ppolygons[0].vertices.Add(pvertices[0]); pvertices[0].polygons.Add(ppolygons[0]);
            ppolygons[0].vertices.Add(pvertices[1]); pvertices[1].polygons.Add(ppolygons[0]);
            ppolygons[0].vertices.Add(pvertices[2]); pvertices[2].polygons.Add(ppolygons[0]);
            ppolygons[0].vertices.Add(pvertices[3]); pvertices[3].polygons.Add(ppolygons[0]);
            ppolygons[0].vertices.Add(pvertices[4]); pvertices[4].polygons.Add(ppolygons[0]);
            ppolygons[0].vertices.Add(pvertices[5]); pvertices[5].polygons.Add(ppolygons[0]);
            //side polygon #1
            ppolygons[1].vertices.Add(pvertices[0]); pvertices[0].polygons.Add(ppolygons[1]);
            ppolygons[1].vertices.Add(pvertices[1]); pvertices[1].polygons.Add(ppolygons[1]);
            ppolygons[1].vertices.Add(pvertices[7]); pvertices[7].polygons.Add(ppolygons[1]);
            ppolygons[1].vertices.Add(pvertices[6]); pvertices[6].polygons.Add(ppolygons[1]);
            //side polygon #2
            ppolygons[2].vertices.Add(pvertices[1]); pvertices[1].polygons.Add(ppolygons[2]);
            ppolygons[2].vertices.Add(pvertices[2]); pvertices[2].polygons.Add(ppolygons[2]);
            ppolygons[2].vertices.Add(pvertices[8]); pvertices[8].polygons.Add(ppolygons[2]);
            ppolygons[2].vertices.Add(pvertices[7]); pvertices[7].polygons.Add(ppolygons[2]);
            //side polygon #3
            ppolygons[3].vertices.Add(pvertices[2]); pvertices[2].polygons.Add(ppolygons[3]);
            ppolygons[3].vertices.Add(pvertices[3]); pvertices[3].polygons.Add(ppolygons[3]);
            ppolygons[3].vertices.Add(pvertices[9]); pvertices[9].polygons.Add(ppolygons[3]);
            ppolygons[3].vertices.Add(pvertices[8]); pvertices[8].polygons.Add(ppolygons[3]);
            //side polygon #4
            ppolygons[4].vertices.Add(pvertices[3]); pvertices[3].polygons.Add(ppolygons[4]);
            ppolygons[4].vertices.Add(pvertices[4]); pvertices[4].polygons.Add(ppolygons[4]);
            ppolygons[4].vertices.Add(pvertices[10]);pvertices[10].polygons.Add(ppolygons[4]);
            ppolygons[4].vertices.Add(pvertices[9]); pvertices[9].polygons.Add(ppolygons[4]);
            //side polygon #5
            ppolygons[5].vertices.Add(pvertices[4]); pvertices[4].polygons.Add(ppolygons[5]);
            ppolygons[5].vertices.Add(pvertices[5]); pvertices[5].polygons.Add(ppolygons[5]);
            ppolygons[5].vertices.Add(pvertices[11]);pvertices[11].polygons.Add(ppolygons[5]);
            ppolygons[5].vertices.Add(pvertices[10]);pvertices[10].polygons.Add(ppolygons[5]);
            //side polygon #6
            ppolygons[6].vertices.Add(pvertices[5]); pvertices[5].polygons.Add(ppolygons[6]);
            ppolygons[6].vertices.Add(pvertices[0]); pvertices[0].polygons.Add(ppolygons[6]);
            ppolygons[6].vertices.Add(pvertices[6]); pvertices[6].polygons.Add(ppolygons[6]);
            ppolygons[6].vertices.Add(pvertices[11]);pvertices[11].polygons.Add(ppolygons[6]);
            //top polygon
            ppolygons[7].vertices.Add(pvertices[6]); pvertices[6].polygons.Add(ppolygons[0]);
            ppolygons[7].vertices.Add(pvertices[7]); pvertices[7].polygons.Add(ppolygons[0]);
            ppolygons[7].vertices.Add(pvertices[8]); pvertices[8].polygons.Add(ppolygons[0]);
            ppolygons[7].vertices.Add(pvertices[9]); pvertices[9].polygons.Add(ppolygons[0]);
            ppolygons[7].vertices.Add(pvertices[10]); pvertices[10].polygons.Add(ppolygons[0]);
            ppolygons[7].vertices.Add(pvertices[11]); pvertices[11].polygons.Add(ppolygons[0]);
        }

        public DMatrix4 Point_Transform;
        public DMatrix4 Normal_Transform;
        public DMatrix4 Point_Viewport;
        public DMatrix4 Normal_Viewport;

        public DMatrix4 Matrix_InWorld;
        public DMatrix4 Matrix_ViewWorld;

        public double angleX;
        public double angleY;
        public double angleZ;

        public double offsetX;
        public double offsetY;
        public double offsetZ;

        public double scaleX;
        public double scaleY;
        public double scaleZ;

        

        public void Transformation()
        {
            Point_Transform = DMatrix4.Identity;
            Matrix4Worker.Scale4(ref Point_Transform, scaleX, scaleY, scaleZ);
            Matrix4Worker.RotationX4(ref Point_Transform, angleX);
            Matrix4Worker.RotationY4(ref Point_Transform, angleY);
            Matrix4Worker.RotationZ4(ref Point_Transform, angleZ);
            Matrix4Worker.Translate4(ref Point_Transform, offsetX, offsetY, offsetZ);
            
            Normal_Transform = DMatrix4.Identity;
            Matrix4Worker.Scale4(ref Normal_Transform, scaleX, scaleY, scaleZ);
            Matrix4Worker.RotationX4(ref Normal_Transform, angleX);
            Matrix4Worker.RotationY4(ref Normal_Transform, angleY);
            Matrix4Worker.RotationZ4(ref Normal_Transform, angleZ);
            Matrix4Worker.Translate4(ref Normal_Transform, offsetX, offsetY, offsetZ);
        }

        public void PyramidPaint(object sender, PaintEventArgs e, View view)
        {
            Transformation();
            foreach (var v in pvertices)
            {
                v.Point_InGlobalSpace = Point_Transform * v.Point_InLocalSpace;
            }

            foreach (var p in ppolygons)
            {
                p.Normal_InGlobalSpace = Normal_Transform * p.Normal_InLocalSpace;
                p.IsVisible = p.Normal_InGlobalSpace > DVector4.Zero;
            }
            
            pvertices.OrderBy(v => -v.Point_InGlobalSpace.Z).ToArray();

            foreach (var p in ppolygons)
            {
                if(!p.IsVisible) continue;
                
                List<PointF> pointFs = new List<PointF>();
                for (int i = 0; i < p.vertices.Count; ++i)
                {
                    pointFs.Add(new PointF((float) p.vertices[0].Point_InGlobalSpace.X, (float) p.vertices[0].Point_InGlobalSpace.Y));
                }
                e.Graphics.DrawPolygon(new Pen(p.Color), pointFs.ToArray());
            }
        }
    }
}