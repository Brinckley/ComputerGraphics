using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        double dx, dy, scl, rot;
        Font font;

        NURBS nurbs;

        public Form1()
        {
            InitializeComponent();
            picture.MouseWheel += Picture_MouseWheel;

            dx = dy = rot = 0;
            scl = 1;

            font = new Font("Arial", 12);

            nurbs = new NURBS();
        }

        private void picture_Paint(object sender, PaintEventArgs e)
        {
            double hw = e.ClipRectangle.Width * 0.5;
            double hh = e.ClipRectangle.Height * 0.5;
            double sz = scl * Math.Min(hw, hh);

            Matrix transform =
                Matrix.D(hw, hh, 0) *
                Matrix.D(dx, dy, 0) *
                Matrix.S(sz, -sz, -1) *
                Matrix.R(rot, new Matrix(0, 0, 1));

            int axis = 100;
            e.Graphics.DrawLine(Pens.Red, transform * new Matrix(-axis, 0, 0), transform * new Matrix(axis, 0, 0));
            e.Graphics.DrawLine(Pens.Lime, transform * new Matrix(0, -axis, 0), transform * new Matrix(0, axis, 0));

            for (int i = -axis + 1; i < axis; i++)
            {
                if (i == 0) continue;

                double dash = 0.05;
                e.Graphics.DrawLine(Pens.Red, transform * new Matrix(i, dash, 0), transform * new Matrix(i, -dash, 0));
                e.Graphics.DrawLine(Pens.Lime, transform * new Matrix(dash, i, 0), transform * new Matrix(-dash, i, 0));

                e.Graphics.DrawString(i.ToString(), font, Brushes.Red, transform * new Matrix(i, 0, 0));
                e.Graphics.DrawString(i.ToString(), font, Brushes.Lime, transform * new Matrix(0, i, 0));
            }
            e.Graphics.DrawString("0", font, Brushes.Black, transform * new Matrix(0, 0, 0));

            nurbs.Draw(e.Graphics, transform, font);
        }

        private int drag = 0;
        private int x = 0;
        private int y = 0;
        
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = 1;
                x = e.X;
                y = e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                drag = 2;
                x = e.X;
            }
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag == 1)
            {
                dx += (e.X - x);
                dy += (e.Y - y);
                x = e.X;
                y = e.Y;
                picture.Refresh();
            }
            else if (drag == 2)
            {
                rot += -0.01f * (e.X - x);
                x = e.X;
                picture.Refresh();
            }
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            drag = 0;
        }

        private void Picture_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) scl *= 1.25;
            else scl *= 0.8;
            picture.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            picture.Refresh();
        }

        private void UpdateMesh(object sender, EventArgs e)
        {
            nurbs.nodes[0].values[0, 0] = (double)valueax.Value;
            nurbs.nodes[0].values[1, 0] = (double)valueay.Value;
            nurbs.nodes[0].values[2, 0] = (double)valueaw.Value;

            nurbs.nodes[1].values[0, 0] = (double)valuebx.Value;
            nurbs.nodes[1].values[1, 0] = (double)valueby.Value;
            nurbs.nodes[1].values[2, 0] = (double)valuebw.Value;

            nurbs.nodes[2].values[0, 0] = (double)valuecx.Value;
            nurbs.nodes[2].values[1, 0] = (double)valuecy.Value;
            nurbs.nodes[2].values[2, 0] = (double)valuecw.Value;

            nurbs.nodes[3].values[0, 0] = (double)valuedx.Value;
            nurbs.nodes[3].values[1, 0] = (double)valuedy.Value;
            nurbs.nodes[3].values[2, 0] = (double)valuedw.Value;

            nurbs.nodes[4].values[0, 0] = (double)valueex.Value;
            nurbs.nodes[4].values[1, 0] = (double)valueey.Value;
            nurbs.nodes[4].values[2, 0] = (double)valueew.Value;

            nurbs.nodes[5].values[0, 0] = (double)valuefx.Value;
            nurbs.nodes[5].values[1, 0] = (double)valuefy.Value;
            nurbs.nodes[5].values[2, 0] = (double)valuefw.Value;

            nurbs.Generate((int)valueApprox.Value);
            picture.Refresh();
        }
    }
}
