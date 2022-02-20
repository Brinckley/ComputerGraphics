using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CP
{
    public partial class Form1 : Form
    {
        private float moveX;
        private float moveY;
        private float scale;
        
        NURBS nurbs;

        public Form1()
        {
            InitializeComponent();

            bool press = false;
            int oldX = 0;
            int oldY = 0;
            
            moveX = -0.5f;
            moveY = 0.5f;
            scale = 0.5f;

            nurbs = new NURBS();

            textCoords.Text = Parser.ToString(nurbs.points[0]); // coordinates textbox input worker
            textWeight.Text = nurbs.weights[0].ToString(); // weight textbox input worker
            textT.Text = Parser.ToString(nurbs.T); // points textbox input worker
            
            // all mouse manipulations worker
            picture.MouseDown += (o, e) =>
            {
                press = true;
                oldX = e.X;
                oldY = e.Y;
            };
            picture.MouseMove += (o, e) =>
            {
                if (press)
                {
                    moveX += 0.02f * (e.X - oldX);
                    moveY += 0.02f * (e.Y - oldY);
                    oldX = e.X;
                    oldY = e.Y;
                    picture.Refresh();
                }
            };
            picture.MouseUp += (o, e) =>
            {
                press = false;
            };
            picture.MouseWheel += (o, e) =>
            {
                if (e.Delta > 0) scale *= 1.25f;
                else scale *= 0.75f;
                picture.Refresh();
            };
            Resize += (o, e) =>
            {
                picture.Refresh();
            };
            numericApprox.ValueChanged += (o, e) =>
            {
                picture.Refresh();
            };
            numericIndex.ValueChanged += (o, e) =>
            {
                picture.Refresh();

                int i = (int)numericIndex.Value - 1;
                textCoords.Text = Parser.ToString(nurbs.points[i]);
                textWeight.Text = nurbs.weights[i].ToString();
            };
        }

        private void Plot(object sender, PaintEventArgs e)
        {
            float minsz = Math.Min(e.ClipRectangle.Width, e.ClipRectangle.Height);
            Matrix transform =
                Matrix.RotateY(moveX) * Matrix.RotateX(moveY) *
                Matrix.Scale(minsz * scale, -minsz * scale, minsz * scale) *
                Matrix.Translate(e.ClipRectangle.Width * 0.5f, e.ClipRectangle.Height * 0.5f, 0);

            // axis drawer
            Point ZERO = transform.Multiply(new Point3D(0, 0, 0));
            e.Graphics.DrawLine(Pens.Red, ZERO, transform.Multiply(new Point3D(10, 0, 0)));
            e.Graphics.DrawLine(Pens.Green, ZERO, transform.Multiply(new Point3D(0, 10, 0)));
            e.Graphics.DrawLine(Pens.Blue, ZERO, transform.Multiply(new Point3D(0, 0, 10)));

            // surface
            int n = (int)numericApprox.Value; // approximation 
            for (int i = 0; i <= n; i++)
                for (int j = 0; j < n; j++)
                {
                    float u = (float)i / n;
                    float v = (float)j / n;
                    float v1 = (float)(j + 1) / n;

                    e.Graphics.DrawLine(Pens.Black, transform.Multiply(nurbs.GetPoint(u, v)),
                        transform.Multiply(nurbs.GetPoint(u, v1)));
                }
            for (int i = 0; i < n; i++)
                for (int j = 0; j <= n; j++)
                {
                    float u = (float)i / n;
                    float u1 = (float)(i + 1) / n;
                    float v = (float)j / n;

                    e.Graphics.DrawLine(Pens.Black, transform.Multiply(nurbs.GetPoint(u, v)),
                        transform.Multiply(nurbs.GetPoint(u1, v)));
                }

            // point drawer
            for (int i = 0; i < 12; i++)
            {
                e.Graphics.DrawLine(Pens.Red, transform.Multiply(nurbs.points[i]),
                    transform.Multiply(nurbs.points[(i + 1) % 12]));
            }
            
            Point3D selected = nurbs.points[(int)numericIndex.Value - 1]; // editing selected point
            foreach (Point3D point in nurbs.points)
            {
                Point p = transform.Multiply(point);

                if (point == selected)
                    e.Graphics.FillRectangle(Brushes.Crimson, p.X - 5, p.Y - 5, 10, 10);
                else
                    e.Graphics.FillRectangle(Brushes.Crimson, p.X - 3, p.Y - 3, 6, 6);
            }
        }

        private void applyPoint_Click(object sender, EventArgs e)
        {
            int i = (int)numericIndex.Value - 1;

            Point3D point = Parser.ParsePoint(textCoords.Text); // points setting
            if (point != null)
            {
                nurbs.points[i] = point;
                picture.Refresh();
            }
            else
            {
                MessageBox.Show("COORDINATE ERROR!");
                textCoords.Text = Parser.ToString(nurbs.points[i]);
            }

            float[] weight = Parser.Parse(textWeight.Text, 1); // weights setting
            if (weight != null)
            {
                nurbs.weights[i] = weight[0];
                picture.Refresh();
            }
            else
            {
                MessageBox.Show("WEIGHT ERROR!");
                textWeight.Text = nurbs.weights[i].ToString();
            }
            
            float[] t = Parser.Parse(textT.Text, 8); // nodal vector setting
            if (t != null)
            {
                nurbs.T = t;
                picture.Refresh();
            }
            else
            {
                MessageBox.Show("NODAL VECTOR ERROR!");
                textT.Text = Parser.ToString(nurbs.T);
            }
            
        }
    }
}
