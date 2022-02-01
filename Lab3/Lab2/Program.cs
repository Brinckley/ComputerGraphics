//#define UseOpenGL // Раскомментировать для использования OpenGL
#if (!UseOpenGL)
using Device     = CGLabPlatform.GDIDevice;
using DeviceArgs = CGLabPlatform.GDIDeviceUpdateArgs;
#else
using Device     = CGLabPlatform.OGLDevice;
using DeviceArgs = CGLabPlatform.OGLDeviceUpdateArgs;
using SharpGL;
#endif

using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Windows.Forms;
using CGLabPlatform;
using Lab2;
// ==================================================================================


using CGApplication = Main;
using View = System.Windows.Forms.View;

public abstract class Main : CGApplicationTemplate<CGApplication, Device, DeviceArgs>
{
    #region Properties

    [DisplayNumericProperty(Default: 50, Increment: 1, Name: "Horizontal approximation", Minimum: 5)]
    public abstract int  Horizontal { get; set; }
    
    [DisplayNumericProperty(Default: 50, Increment: 1, Name: "Vertical approximation", Minimum: 5)]
    public abstract int  Vertical { get; set; }
    
    [DisplayNumericProperty(Default: 120, Increment: 1, Name: "a", Minimum: 1)]
    public abstract int  ArgA { get; set; }
    [DisplayNumericProperty(Default: 50, Increment: 1, Name: "b", Minimum: 1)]
    public abstract int  ArgB { get; set; }
    [DisplayNumericProperty(Default: 30, Increment: 1, Name: "c", Minimum: 1)]
    public abstract int  ArgC { get; set; }

    [DisplayNumericProperty(
        Default: new[] { 0d, 0d, 0d }, 
        Increment: 1, 
        Name: "Rotation", 
        Minimum: 0,
        Maximum: 360
    )]
    public abstract DVector3 Rotation { get; set; }
    
    [DisplayNumericProperty(
        Default: new[] { 1d, 1d, 1d }, 
        Increment: 0.01, 
        Name: "Scale", 
        Minimum: 0.01,
        Maximum: 100
    )]
    public abstract DVector3 Scale { get; set; }
    
    [DisplayNumericProperty(
        Default: new[] { 0d, 0d, 0d }, 
        Increment: 1, 
        Name: "Translation", 
        Minimum: 0,
        Maximum: 100
    )]
    public abstract DVector3 Translation { get; set; }
    #endregion
    
    public enum ViewType
    {
        Nothing, Top, Side, Front, Isometric
    }
    
    public class PolyVertColor
    {
        private int Arg1;
        private int Arg2;
        private int Arg3;

        public Color Color;

        public PolyVertColor()
        {
            Arg1 = 255;
            Arg2 = 0;
            Arg3 = 0;
            Color = Color.FromArgb(Arg1, Arg2, Arg3);
        }

        public PolyVertColor(int arg1, int arg2, int arg3)
        {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Color = Color.FromArgb(Arg1, Arg2, Arg3);
        } 
    }
    
    # region Vertices and Polygon classes
    public class Vertex 
    {
        public List<Polygon> vpolygons; //list of connected polygons
                
        public DVector4 Point_InLocalSpace;
        public DVector4 Point_InGlobalSpace;
        
        public DVector4 Normal_InLocalSpace;

        public PolyVertColor vcolor;
        
        public Vertex()
        {
            Point_InLocalSpace = new DVector4(1, 1, 1,1);
            Point_InGlobalSpace = new DVector4();
            vpolygons = new List<Polygon>();
        }
        
        public Vertex(float x, float y, float z, float w)
        {
            Point_InLocalSpace = new DVector4(x, y, z, w);
            Point_InGlobalSpace = new DVector4();
            vpolygons = new List<Polygon>();
        }
        
        public void SetNormal() //calculating normal for the point according to the connected polygons
        {
            Normal_InLocalSpace = DVector4.Zero;
            
            foreach (Polygon polygon in vpolygons)
            {
                polygon.SetNormal();
                Normal_InLocalSpace += polygon.Normal_InLocalSpace / vpolygons.Count;
            }
        }
    }

    public class Polygon 
    {
        public List<Vertex> vertices; //included vertices 
                
        public DVector4 Normal_InLocalSpace;
        public DVector4 Normal_InGlobalSpace;
        
        public bool IsVisible;
        public PolyVertColor pcolor;
        
        public Polygon()
        {
            Random random = new Random();
            Normal_InLocalSpace = new DVector4(1, 1, 1, 0);
            Normal_InGlobalSpace = new DVector4(1, 1, 1, 0);
            pcolor = new PolyVertColor(55, 0, 55);
            IsVisible = false;
            vertices = new List<Vertex>();
        }
                
        public Polygon(List<Vertex> vertices)
        {
            this.vertices = vertices;
            Random random = new Random();
            Normal_InLocalSpace = new DVector4(1, 1, 1, 0);
            Normal_InGlobalSpace = new DVector4(1, 1, 1, 0);
            pcolor = new PolyVertColor(55, 0, 55);
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

    public List<Vertex> pvertices; //all vertices 
    public List<Polygon> ppolygons; //all polygons

    public ViewType vt;

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

    public void Generate()
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
    
    public double globalScaleX = 1; //scaling parameters for form resize
    public double globalScaleY = 1;
    public double globalScaleZ = 1;
    public double globalOffsetX = 0; //offset parameters for form resize
    public double globalOffsetY = 0;
    public double globalOffsetZ = 0;
    
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
    
    public void Transformation()
    {
        SquaresToTrinagles();
        //applying transformation for transform matrices
        Point_Transform = DMatrix4.Identity; //for point
        Matrix4Worker.Scale4(ref Point_Transform, scaleX * globalScaleX, scaleY * globalScaleY, scaleZ * globalScaleZ);  
        Matrix4Worker.RotationX4(ref Point_Transform, angleX);
        Matrix4Worker.RotationY4(ref Point_Transform, angleY);
        Matrix4Worker.RotationZ4(ref Point_Transform, angleZ);
        Matrix4Worker.Translate4(ref Point_Transform, offsetX + globalOffsetX, offsetY + globalOffsetY, offsetZ + globalOffsetZ);
            
        if (vt != ViewType.Nothing)
        {
            if (vt == ViewType.Front)
            {
                Matrix4Worker.SetFrontView(ref Point_Transform);
            }
            if (vt == ViewType.Side)
            {
                Matrix4Worker.SetSideView(ref Point_Transform);
            }
            if (vt == ViewType.Top)
            {
                Matrix4Worker.SetTopView(ref Point_Transform);
            }
            if (vt == ViewType.Isometric)
            {
                Matrix4Worker.SetIsometricView(ref Point_Transform);
            }
        }
        
        Normal_Transform = NormalVecTransf(Point_Transform);
    }
    
    public void SquaresToTrinagles()
    {
        for (int i = 0; i < ppolygons.Count; ++i)
        {
            if (ppolygons[i].vertices.Count == 4)
            {
                //separating square polygon into two triangles for better usage later in lighting calculating
                Polygon polygon1 = new Polygon(new List<Vertex>
                {
                    ppolygons[i].vertices[0], ppolygons[i].vertices[1], ppolygons[i].vertices[2]
                });
                polygon1.pcolor = ppolygons[i].pcolor;
                    
                Polygon polygon2 = new Polygon(
                    new List<Vertex>
                    {
                        ppolygons[i].vertices[2], ppolygons[i].vertices[3], ppolygons[i].vertices[0]
                    });
                polygon2.pcolor = ppolygons[i].pcolor;
                    
                ppolygons.RemoveAt(i);
                ppolygons.Insert(i, polygon2);
                ppolygons.Insert(i, polygon1);
            }
        }
    }
    /////////////////////////////////////////////////////////////////

    protected override void OnMainWindowLoad(object sender, EventArgs args)
    {
        // TODO: Инициализация данных
        // Созданное приложение имеет два основных элемента управления:
        // base.RenderDevice - левая часть экрана для рисования
        // base.ValueStorage - правая панель для отображения и редактирования свойств

        // Пример изменения внешниго вида элементов управления (необязательный код)
        base.RenderDevice.BufferBackCol = 0x20;
        base.ValueStorage.Font = new Font("Arial", 12f);
        base.ValueStorage.ForeColor = Color.Firebrick;
        base.ValueStorage.RowHeight = 30;
        base.ValueStorage.BackColor = Color.BlanchedAlmond;
        base.MainWindow.BackColor = Color.DarkGoldenrod;
        base.ValueStorage.RightColWidth = 50;
        base.VSPanelWidth = 400;
        base.VSPanelLeft = true;
        base.MainWindow.Size = new Size(2500, 1380);
        base.MainWindow.StartPosition = FormStartPosition.Manual;
        base.MainWindow.Location = Point.Empty;

        base.RenderDevice.GraphicsHighSpeed = false;
        
        
        pvertices = new List<Vertex>(); //all vertices for the pyramid  
        ppolygons = new List<Polygon>(); //all polygons for the pyramid 
        Point_Transform = new DMatrix4(); // matrix for transformation of the point coordinates 
        Point_Viewport = new DMatrix4(); // matrix for point view changing ---
        Normal_Transform = new DMatrix4(); // matrix for transformation of the normal coordinates 
        Normal_Viewport = new DMatrix4(); // matrix for point view changing ---
        Point_Transform = DMatrix4.Identity; 
        Normal_Transform = DMatrix4.Identity;
        a = 120;
        b = 50;
        c = 30;
        r = 80;
        inner = 0.8;
        accuracyVertical = 50;
        accuracyHorizontal = 50;
        Generate();  //generating an object according to the task
        //MessageBox.Show("Here");
    }


    protected override void OnDeviceUpdate(object s, DeviceArgs e)
    {
        MessageBox.Show("Before Transformation");
        Transformation();
        MessageBox.Show("After Transformation");
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

        MessageBox.Show("Before Drawing");
        foreach (var p in ppolygons)
        {
            if (!p.IsVisible) continue;
            //MessageBox.Show("Z: " + p.Normal_InGlobalSpace.Z);

            e.Surface.DrawTriangle(
                255,
                p.vertices[0].Point_InGlobalSpace.X, 
                p.vertices[0].Point_InGlobalSpace.Y,
                255,
                p.vertices[1].Point_InGlobalSpace.X, 
                p.vertices[1].Point_InGlobalSpace.Y,
                255,
                p.vertices[2].Point_InGlobalSpace.X, 
                p.vertices[2].Point_InGlobalSpace.Y); //drawing borders
        }

        MessageBox.Show("end");
    }

}


// ==================================================================================
public abstract class AppMain : CGApplication
{ [STAThread] static void Main() { RunApplication(); } }