using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        //private Pyramid pyramid;
        private View viewState;
        
        public Form1()
        {
            InitializeComponent();
            
            viewState = View.Nothing;
            
           // pyramid = new Pyramid();
           // pyramid.Generate();
        }

        public void PyramidBuilder() //eight-sided truncated pyramid
        {
            //Pyramid pyramid = new Pyramid();
            //pyramid.Generate();
        }

        private void MatrixValueChangedWorker()
        {
            //pyramid.Generate();
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Crimson), new Point(22, 33), new Point(60, 44));
           // pyramid.PyramidPaint(sender, e, viewState);
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
        }

        private void radioTop_CheckedChanged(object sender, EventArgs e)
        {
            viewState = View.Top;
        }

        private void radioSide_CheckedChanged(object sender, EventArgs e)
        {
            viewState = View.Side;
        }

        private void radioFront_CheckedChanged(object sender, EventArgs e)
        {
            viewState = View.Front;
        }

        private void radioIsometric_CheckedChanged(object sender, EventArgs e)
        {
            viewState = View.Isometric;
        }     
        #endregion

        #region Rotation Scale Translation 
        private void NumericRotationX_ValueChanged(object sender, EventArgs e)
        {
            if (NumericRotationX.Value == 360)
            {
                NumericRotationX.Value = 0;
            }
            //pyramid.angleX = (double) NumericRotationX.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericRotationY_ValueChanged(object sender, EventArgs e)
        {
            if (NumericRotationY.Value == 360)
            {
                NumericRotationY.Value = 0;
            }
          //  pyramid.angleY = (double) NumericRotationY.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericRotationZ_ValueChanged(object sender, EventArgs e)
        {
            if (NumericRotationZ.Value == 360)
            {
                NumericRotationZ.Value = 0;
            }
           // pyramid.angleZ = (double) NumericRotationZ.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericScaleX_ValueChanged(object sender, EventArgs e)
        {
         //   pyramid.scaleX = (double) NumericScaleX.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericScaleY_ValueChanged(object sender, EventArgs e)
        {
        //    pyramid.scaleY = (double) NumericScaleY.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericScaleZ_ValueChanged(object sender, EventArgs e)
        {
         //   pyramid.scaleZ = (double) NumericScaleZ.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericTranslationX_ValueChanged(object sender, EventArgs e)
        {
          //  pyramid.offsetX = (double) NumericTranslationX.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericTranslationY_ValueChanged(object sender, EventArgs e)
        {
          //  pyramid.offsetY = (double) NumericTranslationY.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }

        private void NumericTranslationZ_ValueChanged(object sender, EventArgs e)
        {
        //    pyramid.offsetZ = (double) NumericTranslationZ.Value;
            pictureBox1.Refresh();
            this.Invalidate();
        }
        
        #endregion
    }
}