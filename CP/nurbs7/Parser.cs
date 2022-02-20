using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public static class Parser // working with string values to set the points
    {
        public static float[] Parse(string text, int n)
        {
            float[] values = new float[n];
            string[] texts = text.Split(' ');

            if (texts.Length != n) return null;

            for (int i = 0; i < n; i++)
                try
                {
                    values[i] = (float)Convert.ToDouble(texts[i]);
                }
                catch
                {
                    return null;
                }
            return values;
        }
        public static Point3D ParsePoint(string text)
        {
            float[] coords = Parse(text, 3);
            if (coords == null) return null;
            return new Point3D(coords[0], coords[1], coords[2]);
        }

        public static string ToString(float[] values)
        {
            string text = "";
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) text += " ";
                text += values[i].ToString();
            }
            return text;
        }
        public static string ToString(Point3D point) =>
            ToString(new float[] { point.x, point.y, point.z });
    }
}
