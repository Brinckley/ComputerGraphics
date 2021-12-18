using System;
using System.Drawing;

namespace Lab1
{
    public class MyMatrix
    {
        public double mx;
        public double my;

        // [ Mx   0 ]
        // [ 0    My]
        
        public MyMatrix()
        {
            mx = 1;
            my = 1;
        }

        public MyMatrix(double mx, double my)
        {
            this.mx = mx;
            this.my = my;
        }

        public void Scale(double px, double py)
        {
            mx *= px;
            my *= py;
        }

        public void Rotate(double angle)
        {
            double tmpX = mx;
            double tmpY = my;
            mx = tmpX * Math.Cos(angle) - tmpY * Math.Sin(angle);
            my = tmpX * Math.Sin(angle) + tmpY * Math.Cos(angle);
        }

        public void Translate(double offsetX, double offsetY)
        {
            mx += offsetX;
            my += offsetY;
        }

        public void TransformPoints(ref PointF[] pointsArray)
        {
            for (int i = 0; i < pointsArray.Length; ++i)
            {
                pointsArray[i].X *= (float)mx;
                pointsArray[i].Y *= (float)my;
            }
        }
    }
}