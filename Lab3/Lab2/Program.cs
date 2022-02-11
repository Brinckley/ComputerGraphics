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
    enum Operations
    {
        None,
        Parameters, 
        Scale,
        Rotation,
        Translation
    }

    private Operations operation = Operations.None;
    
    #region Orientation

    [DisplayNumericProperty(Default: 25, Increment: 1, Name: "Horizontal approximation", Minimum: 5)]
    public int Horizontal
    {
        get;
        set;
    }
    
    
    [DisplayNumericProperty(Default: 25, Increment: 1, Name: "Vertical approximation", Minimum: 5)]
    public int Vertical
    {
        get;
        set;
    }
    //parameters of the figure
    [DisplayNumericProperty(Default: 480, Increment: 1, Name: "a", Minimum: 1)]
    public int ArgA { get; set; }
    
    [DisplayNumericProperty(Default: 200, Increment: 1, Name: "b", Minimum: 1)]
    public int ArgB { get; set; }
    
    [DisplayNumericProperty(Default: 120, Increment: 1, Name: "c", Minimum: 1)]
    public int ArgC { get; set; }
    
    [DisplayNumericProperty(Default: 0.8, Increment: 0.1, Name: "r", Minimum: 0.1)]
    public int ArgR { get; set; }

    [DisplayNumericProperty(
        Default: new[] { 0d, 0d, 0d }, 
        Increment: 1, 
        Name: "Rotation", 
        Minimum: -360,
        Maximum: 360
    )]
    public DVector3 RotationVector3 { get; set; }
    
    [DisplayNumericProperty(
        Default: new[] { 1d, 1d, 1d }, 
        Increment: 0.01, 
        Name: "Scale", 
        Minimum: 0.01,
        Maximum: 100
    )]
    public DVector3 ScaleVector3 { get; set; }
    
    [DisplayNumericProperty(
        Default: new[] { 0d, 0d, 0d }, 
        Increment: 1, 
        Name: "Translation", 
        Minimum: -400,
        Maximum: 400
    )]
    public DVector3 TranslationVector3 { get; set; }
    #endregion

    #region Material + light properties
    
    [DisplayNumericProperty(
        Default: new[] { 0.68d, 0.85d, 0.9d }, 
        Increment: 0.01, 
        Name: "Color", 
        Minimum: 0,
        Maximum: 1
    )]
    public DVector3 ColorVector3 { get; set; }
    
    [DisplayNumericProperty(
        Default: new[] { 0.14d, 0.14d, 0.2d }, 
        Increment: 0.01, 
        Name: "Ka material", 
        Minimum: 0,
        Maximum: 1
    )]
    public DVector3 Ka_MaterialVector { get; set; } //ambient properties
    
    [DisplayNumericProperty(
        Default: new[] { 1d, 1d, 0.54d }, 
        Increment: 0.01, 
        Name: "Kd material", 
        Minimum: 0,
        Maximum: 1
    )]
    public DVector3 Kd_MaterialVector { get; set; } //diffuse properties 
    
    [DisplayNumericProperty(
        Default: new[] { 0.21d, 0.21d, 1d }, 
        Increment: 0.01, 
        Name: "Ks material", 
        Minimum: 0,
        Maximum: 1
    )]
    public DVector3 Ks_MaterialVector { get; set; } //specular properties
    
    [DisplayNumericProperty(Default: 1, Increment: 0.01, Name: "p", Minimum: 0, 10)]
    public double PValue { get; set; }
    
    [DisplayNumericProperty(
        Default: new[] { 1d, 1d, 1d }, 
        Increment: 0.01, 
        Name: "Ia light", 
        Minimum: 0,
        Maximum: 1
    )]
    public DVector3 Ia_MaterialVector { get; set; } //power of ambient light
    
    [DisplayNumericProperty(
        Default: new[] { 1d, 0.5d, 0d }, 
        Increment: 0.01, 
        Name: "Il light", 
        Minimum: 0,
        Maximum: 1
    )]
    public DVector3 Il_MaterialVector { get; set; } //power of diffuse light
    
    [DisplayNumericProperty(
        Default: new[] { 200d, 100d, 150d }, 
        Increment: 1, 
        Name: "Light pos", 
        Minimum: -400,
        Maximum: 1000
    )]
    public DVector3 LightPosition { get; set; } //light source coordinates 
    
    [DisplayNumericProperty(
        Default: new[] { 0.10d, 0.35d }, 
        Increment: 0.01, 
        Name: "Md Mk", 
        Minimum: 0,
        Maximum: 1
    )]
    public DVector2 MdMkVector2 { get; set; }
    #endregion

    /////////////////////////////////////////////////////////////////
    // UNITING EVERYTHING INTO PROGRAM CLASS.....
    public enum ViewType
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
        public Color Color_PolygonLight;
        
        public Polygon()
        {
            Random random = new Random();
            Normal_InLocalSpace = new DVector4(1, 1, 1, 0);
            Normal_InGlobalSpace = new DVector4(1, 1, 1, 0);
            Color_PolygonLight = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            IsVisible = false;
            vertices = new List<Vertex>();
        }
                
        public Polygon(List<Vertex> vertices)
        {
            this.vertices = vertices;
            Random random = new Random();
            Normal_InLocalSpace = new DVector4(1, 1, 1, 0);
            Normal_InGlobalSpace = new DVector4(1, 1, 1, 0);
            Color_PolygonLight = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
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
        
        public void SetNormalGlobal()
        {
            DVector4 a = vertices[1].Point_InGlobalSpace - vertices[0].Point_InGlobalSpace;
            DVector4 b = vertices[2].Point_InGlobalSpace - vertices[0].Point_InGlobalSpace;
            Normal_InLocalSpace = Cross(b, a);
            Normal_InLocalSpace.Normalize(); //it's important to normalize the vector before any later manipulations 
        }
    }
    #endregion
    
    // fields from the Figure class
    private List<Vertex> pvertices; //all vertices 
    private List<Polygon> ppolygons; //all polygons

    private ViewType viewType;
    
    private DMatrix4 Point_Transform;
    private DMatrix4 Normal_Transform;

    private DVector3 Global_Offset;
    
    
    
    
    
    
    
    
    
    
    public void GenerateEllipsoid()
    {
        int accuracyHorizontal = Horizontal;
        int accuracyVertical = Vertical;

        double a = ArgA;
        double b = ArgB;
        double c = ArgC;
        double inner = 0.8d;
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
                polygon1.Color_PolygonLight = ppolygons[i].Color_PolygonLight;
                    
                Polygon polygon2 = new Polygon(
                    new List<Vertex>
                    {
                        ppolygons[i].vertices[2], ppolygons[i].vertices[3], ppolygons[i].vertices[0]
                    });
                polygon2.Color_PolygonLight = ppolygons[i].Color_PolygonLight;
                    
                ppolygons.RemoveAt(i);
                ppolygons.Insert(i, polygon2);
                ppolygons.Insert(i, polygon1);
            }
        }
    }
    public void Transformation()
    {
        double globalScaleX = 1;
        double globalScaleY = 1;
        double globalScaleZ = 1;
        //applying transformation for transform matrices
        Point_Transform = DMatrix4.Identity; //for point
        Matrix4Worker.Scale4(ref Point_Transform, 
            ScaleVector3.X * globalScaleX, ScaleVector3.Y * globalScaleY, ScaleVector3.Z * globalScaleZ);  
        Matrix4Worker.RotationX4(ref Point_Transform, RotationVector3.X);
        Matrix4Worker.RotationY4(ref Point_Transform, RotationVector3.Y);
        Matrix4Worker.RotationZ4(ref Point_Transform, RotationVector3.Z);
        Matrix4Worker.Translate4(ref Point_Transform, 
            TranslationVector3.X + Global_Offset.X, TranslationVector3.Y + Global_Offset.Y, TranslationVector3.Z + Global_Offset.Z);
            
        if (viewType != ViewType.Nothing)
        {
            if (viewType == ViewType.Front)
            {
                Matrix4Worker.SetFrontView(ref Point_Transform);
            }
            if (viewType == ViewType.Side)
            {
                Matrix4Worker.SetSideView(ref Point_Transform);
            }
            if (viewType == ViewType.Top)
            {
                Matrix4Worker.SetTopView(ref Point_Transform);
            }
            if (viewType == ViewType.Isometric)
            {
                Matrix4Worker.SetIsometricView(ref Point_Transform);
            }
        }
            
        //Normal_Transform = DMatrix4.Identity;
        Normal_Transform = NormalVecTransf(Point_Transform);
    }
    
    
    
    //private LightSource lighter = new LightSource(3, 0, 0, 1, 1, 1);//////////////////////////////////////////////////////////////////
    //private DVector3 ecolorVector3;

    private double Parameter_d = 0.001d; //parameter to regulate the distance in the Specular formula
    private double Parameter_K = 0.3d; //additional parameter for the Specular formula
    private DVector3 ColorLightMaterial; //field to exchange info about intensity worker result

    public void IntensityWorker(DVector4 vertex, DVector4 normal)
    {
        //MessageBox.Show(vertex.Point_InGlobalSpace.X + " " + vertex.Point_InGlobalSpace.Y + " " + vertex.Point_InGlobalSpace.Z);
        
        DVector4 L = new DVector4( //vector from point to lighter
            LightPosition4.X - vertex.X,
            LightPosition4.Y - vertex.Y,
            LightPosition4.Z - vertex.Z,
            0);//it's vector => w = 0
        double d = L.GetLength(); //distance to the lighter
        L.Normalize(); //normalizing everything
        
        //ambient vector calculation 
        // Ia = ka * ia
        //DVector3 ambientVector3 = Ka_MaterialVector * Ia_MaterialVector; 
        DVector3 ambientVector3 = new DVector3();
        ambientVector3.X = Ka_MaterialVector.X * Ia_MaterialVector.X;
        ambientVector3.Y = Ka_MaterialVector.Y * Ia_MaterialVector.Y;
        ambientVector3.Z = Ka_MaterialVector.Z * Ia_MaterialVector.Z;
        
        //diffuse
        // Id = kd * il * cos(L, N) = kd * il * (L, N)
        // Id = ((kd * il) / (d + k)) * cos(L, N) = ((kd * il) / (d + k)) * (L, N) // k = const, d = distance 
        DVector3 diffuseVector3 = new DVector3();
        diffuseVector3.X = Il_MaterialVector.X * Kd_MaterialVector.X * DVector4.DotProduct(L, normal) / (Parameter_d * d + Parameter_K);
        diffuseVector3.Y = Il_MaterialVector.Y * Kd_MaterialVector.Y * DVector4.DotProduct(L, normal) / (Parameter_d * d + Parameter_K);
        diffuseVector3.Z = Il_MaterialVector.Z * Kd_MaterialVector.Z * DVector4.DotProduct(L, normal) / (Parameter_d * d + Parameter_K);
        
        //specular
        // Is = il * ks * cos^p(R, S)
        DVector3 specularVector3 = new DVector3();
        if (DVector4.DotProduct(L, normal) > 0)
        {
            DVector4 S = new DVector4(
                Global_Offset.X - vertex.X, 
                Global_Offset.Y - vertex.Y,
                Global_Offset.Z - vertex.Z, 
                0);
            DVector4 R = new DVector4(DVector3.Reflect((DVector3)(-L), (DVector3)normal), 0);
            S.Normalize();
            R.Normalize();
            
            if (DVector4.DotProduct(R, S) > 0)
            {
                specularVector3.X = Il_MaterialVector.X * (Ks_MaterialVector.X * (Math.Pow(DVector4.DotProduct(R, S), PValue)
                    / (Parameter_d * d + Parameter_K)));
                specularVector3.Y = Il_MaterialVector.Y * (Ks_MaterialVector.Y * (Math.Pow(DVector4.DotProduct(R, S), PValue) 
                    / (Parameter_d * d + Parameter_K)));
                specularVector3.Z =  Il_MaterialVector.Z * (Ks_MaterialVector.Z * (Math.Pow(DVector4.DotProduct(R, S), PValue)
                    / (Parameter_d * d + Parameter_K)));
            }
        }
        
        ColorLightMaterial.X = ambientVector3.X + diffuseVector3.X + specularVector3.X;
        ColorLightMaterial.Y = ambientVector3.Y + diffuseVector3.Y + specularVector3.Y;
        ColorLightMaterial.Z = ambientVector3.Z + diffuseVector3.Z + specularVector3.Z;
    }

    public void LightWorker()
    {
        foreach (var p in ppolygons)
        {
            if (!p.IsVisible) continue;
            
            double x = 0, y = 0, z = 0;
            for (int i = 0; i < p.vertices.Count; ++i)
            {
                x += p.vertices[i].Point_InGlobalSpace.X;
                y += p.vertices[i].Point_InGlobalSpace.Y;
                z += p.vertices[i].Point_InGlobalSpace.Z;
            }
            x /= 3;
            y /= 3;
            z /= 3; //calculating center of the triangle polygon
            
            //MessageBox.Show("After /3");
            IntensityWorker(new DVector4(x, y, z, 1), p.Normal_InGlobalSpace);
            
            p.Color_PolygonLight = Color.FromArgb(
                (int)Math.Max(0, Math.Min(255, 255 * ColorVector3.X * ColorLightMaterial.X)), 
                (int)Math.Max(0, Math.Min(255, 255 * ColorVector3.Y * ColorLightMaterial.Y)),
                (int)Math.Max(0, Math.Min(255, 255 * ColorVector3.Z * ColorLightMaterial.Z)));
            
        }
    }

    protected override void OnMainWindowLoad(object sender, EventArgs args)
    {
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
        
        base.RenderDevice.MouseMoveWithRightBtnDown += (s, e)
            => TranslationVector3 += new DVector3(1 * Math.Abs(ScaleVector3.X) * e.MovDeltaX, 1* Math.Abs(ScaleVector3.Y) * e.MovDeltaY, 0);
        base.RenderDevice.MouseMoveWithLeftBtnDown += (s, e)
            => RotationVector3 += new DVector3(0.1 * e.MovDeltaY, 0.1 * e.MovDeltaX, 0);
        base.RenderDevice.MouseWheel += (s, e) => ScaleVector3 += new DVector3(0.001 * e.Delta, 0.001 * e.Delta, 0.001 * e.Delta);
        
        pvertices = new List<Vertex>(); //all vertices for the pyramid  
        ppolygons = new List<Polygon>(); //all polygons for the pyramid 
        Point_Transform = new DMatrix4(); // matrix for transformation of the point coordinates 
        Point_Transform = DMatrix4.Identity; 
        Normal_Transform = DMatrix4.Identity;
        Global_Offset = new DVector3((MainWindow.Width - VSPanelWidth) / 2, MainWindow.Height / 2, MainWindow.Height / 2);
        
        GenerateEllipsoid();
        SquaresToTrinagles();
    }

    private DVector4 LightPosition4;
    
    protected override void OnDeviceUpdate(object s, DeviceArgs e)
    {
        Global_Offset = new DVector3((MainWindow.Width - VSPanelWidth) / 2, MainWindow.Height / 2, MainWindow.Height / 2);
        Transformation(); 
        LightPosition4 = new DVector4(LightPosition.X, LightPosition.Y, LightPosition.Z, 1);
        LightPosition4 = Point_Transform * LightPosition4;

        foreach (var v in pvertices) //transform every point
        {
            v.Point_InGlobalSpace = Point_Transform * v.Point_InLocalSpace;
            DVector4 L = new DVector4( //vector from point to lighter
                LightPosition4.X - v.Point_InGlobalSpace.X,
                LightPosition4.Y - v.Point_InGlobalSpace.Y,
                LightPosition4.Z - v.Point_InGlobalSpace.Z,
                0);//it's vector => w = 0
            double d = L.GetLength(); //distance to the lighter4
            //MessageBox.Show(" " + d);
        }
        
        foreach (var p in ppolygons) //transform every normal + visibility check
        {
            p.SetNormal();
            p.Normal_InGlobalSpace = Normal_Transform * p.Normal_InLocalSpace;
            //if normal is more than zero we need to draw the polygon
            p.IsVisible = p.Normal_InGlobalSpace.Z > 0;
        }
        LightWorker();
        
       // ppolygons.OrderBy(p => Math.Min(p.vertices[0].Point_InGlobalSpace.Z, 
       //     Math.Min(p.vertices[1].Point_InGlobalSpace.Z, p.vertices[2].Point_InGlobalSpace.Z)));
       ppolygons.OrderBy(p => p.Normal_InGlobalSpace.Z);

        foreach (var p in ppolygons)  
        {
            if (!p.IsVisible) continue;
            //MessageBox.Show("Z: " + p.Normal_InGlobalSpace.Z);
            //MessageBox.Show("" + ColorVector3.X + " " + ColorVector3.Y + " " + ColorVector3.Z);
            e.Surface.DrawTriangle(
                p.Color_PolygonLight.ToArgb(),
                p.vertices[0].Point_InGlobalSpace.X, p.vertices[0].Point_InGlobalSpace.Y,
                p.vertices[1].Point_InGlobalSpace.X, p.vertices[1].Point_InGlobalSpace.Y,
                p.vertices[2].Point_InGlobalSpace.X, p.vertices[2].Point_InGlobalSpace.Y);
            
        }
        
        e.Graphics.DrawRectangle(new Pen(Color.Red),(float) LightPosition4.X, (float)LightPosition4.Y, (float)10, (float)10);

    }

}


// ==================================================================================
public abstract class AppMain : CGApplication
{ [STAThread] static void Main() { RunApplication(); } }