using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab1
{
    public class Drawer
    {
        private double accuracy;
        
        private double RightBorder;
        private double LeftBorder;

        public Drawer(double RightBorder, double accuracy)
        {
            this.RightBorder = RightBorder;
            LeftBorder = 0;
            this.accuracy = accuracy;
        }
        
        public void CreateFuncPointList()
        {
            List<PointF> curve = new List<PointF>();
            for (double i = LeftBorder; i < RightBorder; i += accuracy)
            {
            }
        }
    }
}