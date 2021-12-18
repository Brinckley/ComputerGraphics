using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Lab1
{
    //solve:
    // 1. jumping line                         --- (fixed)
    // 2. write my own matrix operations      
    // 3. form resize operation fix

    public partial class Form1 : Form
    {
        private float accuracy = 0.01f; //approximation
        private float a = 59.0f; //parameter а
        private float b = 60.0f; //parameter В
        
        private List<PointF> points;
        private PointF[] pointsArray;

        private float scaleX = 0; //X compression
        private float scaleY = 0; //Y compression

        private float dx; //delta x
        private float dy; //delta y
        private float gSizeX;
        private float gSizeY;

        private float formSizeX; //form resize parameters
        private float formSizeY;

        private float rotateAngle = 0; //angel of graphic rotation

        public Form1()
        {
            InitializeComponent();
            scaleX = 1;
            scaleY = 1;
            rotateAngle = 0;
            
            dx = 0;
            dy = 0;
            UpdateDeltas();
            this.pictureBox1.MouseWheel += Zoom_Wheel;
            numericUpdateX.Maximum = pictureBox1.Width / 2;
            numericUpDown1.Maximum = pictureBox1.Height / 2;
            numericUpdateX.Minimum = -pictureBox1.Width / 2;
            numericUpDown1.Minimum = -pictureBox1.Height / 2;
        }

        private void Zoom_Wheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                scaleX += 0.01f;
                scaleY += 0.01f;
            }
            else
            {
                if (scaleX > 0.01f && scaleY > 0.01f)
                {
                    scaleX -= 0.01f;
                    scaleY -= 0.01f;
                }
            }
            numericXScale.Value = (decimal) scaleX;
            numericYScale.Value = (decimal) scaleY;
            
            pictureBox1.Refresh();
        }

        private void UpdatePanelSize() //new value of form size
        {
            formSizeX = pictureBox1.Width;
            formSizeY = pictureBox1.Height;
        }
        private void UpdateDeltas() //new value of axis offset
        {//
            gSizeX = formSizeX / 2 + dx;
            gSizeY = formSizeY / 2 + dy;
        }

        private void BuildGraph()
        {
            points = new List<PointF>();
            //y^2 = x^3 / (a - x)        0 < x <= B
            float border = Math.Min(a, b) - accuracy;

            for (float i = border; i >= 0; i -= accuracy)
            {
                float y = (float)Math.Sqrt(Math.Pow(i, 3) / (a - i));
                points.Add(new PointF(i, y));
            }
            for (float i = 0; i < border; i += accuracy)
            {
                float y = (float)Math.Sqrt(Math.Pow(i, 3) / (a - i));
                points.Add(new PointF(i, -y));
            }
            
            pointsArray = points.ToArray();
            
            Matrix transformMatrix = new Matrix();
            transformMatrix.Scale(scaleX, scaleY, MatrixOrder.Append);
            transformMatrix.Rotate(rotateAngle, MatrixOrder.Append);
            transformMatrix.Translate(gSizeX, gSizeY, MatrixOrder.Append);
            transformMatrix.TransformPoints(pointsArray);
        }

        private void DrawGraph(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 1; i < pointsArray.Length; ++i)
            {
                e.Graphics.DrawLine(pen, pointsArray[i], pointsArray[i - 1]);
            }
        }

        private void DrawAxis(object sender, PaintEventArgs e)
        { 
            Matrix transformMatrix = new Matrix();
            transformMatrix.Scale(formSizeX, formSizeY, MatrixOrder.Append);
            transformMatrix.Rotate(rotateAngle, MatrixOrder.Append);
            transformMatrix.Translate(gSizeX, gSizeY, MatrixOrder.Append);
            
            List<PointF> xAxisList = new List<PointF>();
            xAxisList.Add(new PointF(1, 0));
            xAxisList.Add(new PointF(-1, 0));
            PointF[] xAxisArray = xAxisList.ToArray();
            transformMatrix.TransformPoints(xAxisArray);
            
            List<PointF> yAxisList = new List<PointF>();
            yAxisList.Add(new PointF(0, 1));
            yAxisList.Add(new PointF(0, -1));
            PointF[] yAxisArray = yAxisList.ToArray();
            transformMatrix.TransformPoints(yAxisArray);
            
            Pen pen = new Pen(Color.Crimson);
            for (int i = 1; i < xAxisArray.Length; ++i)
            {
                e.Graphics.DrawLine(pen, xAxisArray[i - 1], xAxisArray[i]);
                e.Graphics.DrawLine(pen, yAxisArray[i - 1], yAxisArray[i]);
            }
        }
        
        private void DrawFunctionUpdate(object sender, PaintEventArgs paintEventArgs)
        {
            UpdatePanelSize();
            UpdateDeltas();
            BuildGraph();
            DrawAxis(sender, paintEventArgs);
            DrawGraph(sender, paintEventArgs);
        }

        private void numericA_ValueChanged(object sender, EventArgs e)
        { //upd value а
            a = (float)numericA.Value;
            pictureBox1.Refresh();
            Invalidate();
        }
        
        private void numericB_ValueChanged(object sender, EventArgs e)
        { //upd value В
            b = (float)numericB.Value;
            pictureBox1.Refresh();
            Invalidate();
        }
        
        private void numericAccuracy_ValueChanged(object sender, EventArgs e)
        {
            accuracy = (float) numericAccuracy.Value;
            pictureBox1.Refresh();
            Invalidate();
        }

        private void numericXScale_ValueChanged(object sender, EventArgs e)
        { //upd Х scale
            scaleX = (float) numericXScale.Value;
            pictureBox1.Refresh();
            Invalidate();
        }

        private void numericYScale_ValueChanged(object sender, EventArgs e)
        {//upd Y scale
            scaleY = (float) numericYScale.Value;
            pictureBox1.Refresh();
            Invalidate();
        }

        private void numericUpdateX_ValueChanged(object sender, EventArgs e)
        {//Х offset
            dx = (float) numericUpdateX.Value;
            pictureBox1.Refresh();
            Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {//Y offset
            dy = (float) numericUpDown1.Value;
            pictureBox1.Refresh();
            Invalidate();
        }

        private void numericAngle_ValueChanged(object sender, EventArgs e)
        {//upd rotation
            if (numericAngle.Value == (decimal) -0.1)
            {
                numericAngle.Value = (decimal) 359.9;
            }
            if (numericAngle.Value == (decimal) 360.1)
            {
                numericAngle.Value = (decimal) 0.1;
            }

            rotateAngle = (float) numericAngle.Value;
            pictureBox1.Refresh();
            Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawFunctionUpdate(sender, e);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            numericUpdateX.Maximum = pictureBox1.Width / 2;
            numericUpDown1.Maximum = pictureBox1.Height / 2;
            numericUpdateX.Minimum = -pictureBox1.Width / 2;
            numericUpDown1.Minimum = -pictureBox1.Height / 2;
            pictureBox1.Refresh();
        }
        
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {}
        private void splitContainer1_Paint(object sender, PaintEventArgs e)
        {}
    }
}