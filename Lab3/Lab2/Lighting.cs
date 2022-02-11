using System;
using System.Collections.Generic;
using System.Drawing;
using CGLabPlatform;

namespace Lab2
{
    public class LightSource
    {
        public DVector4 Position; //coordinates of the source on the screen
        public DVector3 Intensity; // source intensity
        public DVector3 ambient; 
        
        public double md;
        public double mk;

    }

}