using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private Pyramid pyramid;
        private View viewState;

        private double oldMouseX = 0;
        private double oldMouseY = 0;

        private bool IsClicked = false;
        
        public Form1()
        {
            InitializeComponent();
            
            viewState = View.Nothing; //default view
            
            //creating new figure
            pyramid = new Pyramid();
            pyramid.offsetX = pictureBox1.Width / 2; //default offsets for each axis
            pyramid.offsetY = pictureBox1.Height / 2;
            pyramid.offsetZ = pictureBox1.Height / 2;

            radioNothing.Checked = true;
            pictureBox1.MouseWheel += Zoom_Wheel;
        }
        
        private void Zoom_Wheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                pyramid.scaleX += 0.01f;
                pyramid.scaleY += 0.01f;
                pyramid.scaleZ += 0.01f;
            }
            else
            {
                if (pyramid.scaleX > 0.01f && pyramid.scaleY > 0.01f && pyramid.scaleZ > 0.01f)
                {
                    pyramid.scaleX -= 0.01f;
                    pyramid.scaleY -= 0.01f;
                    pyramid.scaleZ -= 0.01f;
                }
            }
            NumericScaleX.Value = (decimal) pyramid.scaleX;
            NumericScaleY.Value = (decimal) pyramid.scaleY;
            NumericScaleZ.Value = (decimal) pyramid.scaleZ;

            pictureBox1.Refresh();
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pyramid.PyramidPaint(sender, e, viewState); //calling method for painting the figure from the class
            NumericRotationX.Value = (decimal) pyramid.angleX;
            NumericRotationY.Value = (decimal) pyramid.angleY;
            NumericRotationZ.Value = (decimal) pyramid.angleZ;
        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsClicked = true;
                oldMouseX = e.X;
                oldMouseY = e.Y;   
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsClicked)
            {
                double newMouseX = e.X;
                double newMouseY = e.Y;
                pyramid.angleY += (newMouseX - oldMouseX);
                pyramid.angleX += (oldMouseY - newMouseY);
                if (pyramid.angleX < 0)
                {
                    pyramid.angleX += 360;
                }
                if (pyramid.angleY < 0)
                {
                    pyramid.angleY += 360;
                }
                if (pyramid.angleX > 360)
                {
                    pyramid.angleX -= 360;
                }
                if (pyramid.angleY > 360)
                {
                    pyramid.angleY -= 360;
                }
                oldMouseX = newMouseX;
                oldMouseY = newMouseY;
                pictureBox1.Refresh();
                pictureBox1.Invalidate();
            }
            

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsClicked = false;
        }

        #region Matrix Input
        private void numeric11_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric12_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric13_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric14_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric21_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric22_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric23_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric24_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric31_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric32_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric33_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric34_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        private void numeric41_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric42_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric43_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void numeric44_ValueChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Radio buttons
        private void radioNothing_CheckedChanged(object sender, EventArgs e)
        {
            viewState = View.Nothing;
            NumericRotationX.Value = (decimal) 0;
            NumericRotationY.Value = (decimal) 0;
            NumericRotationZ.Value = (decimal) 0;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void radioTop_CheckedChanged(object sender, EventArgs e)
        {
            viewState = View.Top;
            NumericRotationX.Value = (decimal) 90;
            NumericRotationY.Value = (decimal) 0;
            NumericRotationZ.Value = (decimal) 0;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void radioSide_CheckedChanged(object sender, EventArgs e)
        {
            viewState = View.Side;
            NumericRotationX.Value = (decimal) 0;
            NumericRotationY.Value = (decimal) 90;
            NumericRotationZ.Value = (decimal) 0;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void radioFront_CheckedChanged(object sender, EventArgs e)
        {
            viewState = View.Front;
            NumericRotationX.Value = (decimal) 0;
            NumericRotationY.Value = (decimal) 0;
            NumericRotationZ.Value = (decimal) 0;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void radioIsometric_CheckedChanged(object sender, EventArgs e)
        {
            viewState = View.Isometric;
            pictureBox1.Refresh();
            this.Invalidate();
        }     
        #endregion

        #region Rotation Scale Translation 
        private void NumericRotationX_ValueChanged(object sender, EventArgs e)
        {
            if (NumericRotationX.Value == 360)
            {
                NumericRotationX.Value = 0;
            }
            if (NumericRotationX.Value == -1)
            {
                NumericRotationX.Value = 359;
            }
            pyramid.angleX = (double) NumericRotationX.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericRotationY_ValueChanged(object sender, EventArgs e)
        {
            if (NumericRotationY.Value == 360)
            {
                NumericRotationY.Value = 0;
            }
            if (NumericRotationY.Value == -1)
            {
                NumericRotationY.Value = 359;
            }
            pyramid.angleY = (double) NumericRotationY.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericRotationZ_ValueChanged(object sender, EventArgs e)
        {
            if (NumericRotationZ.Value == 360)
            {
                NumericRotationZ.Value = 0;
            }
            if (NumericRotationZ.Value == -1)
            {
                NumericRotationZ.Value = 359;
            }
            pyramid.angleZ = (double) NumericRotationZ.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericScaleX_ValueChanged(object sender, EventArgs e)
        {
            pyramid.scaleX = (double) NumericScaleX.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericScaleY_ValueChanged(object sender, EventArgs e)
        {
            pyramid.scaleY = (double) NumericScaleY.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericScaleZ_ValueChanged(object sender, EventArgs e)
        {
            pyramid.scaleZ = (double) NumericScaleZ.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericTranslationX_ValueChanged(object sender, EventArgs e)
        {
            pyramid.offsetX = (double) NumericTranslationX.Value + pictureBox1.Width / 2;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericTranslationY_ValueChanged(object sender, EventArgs e)
        {
            pyramid.offsetY = (double) NumericTranslationY.Value + pictureBox1.Height / 2;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericTranslationZ_ValueChanged(object sender, EventArgs e)
        {
            pyramid.offsetZ = (double) NumericTranslationZ.Value + pictureBox1.Width / 2;
            pictureBox1.Refresh();
            this.Invalidate();
        }
        
        #endregion
    }
}