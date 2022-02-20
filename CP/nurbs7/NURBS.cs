using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public class NURBS
    {
        public Point3D[] points;
        public float[] weights;
        public float[] T;

        public NURBS()
        {
            points = new Point3D[12];
            weights = new float[12];
            T = new float[8] { 0, 0, 0.2f, 0.4f, 0.6f, 0.8f, 1, 1 };

            for (int i = 0; i < 12; i++) weights[i] = 1;

            for (int i = 0; i < 3; i++)
            {
                points[i] = new Point3D(-0.75f + 0.5f * i, i % 2 * 0.2f, -0.75f);
                points[i + 3] = new Point3D(0.75f, i % 2 * 0.2f, -0.75f + 0.5f * i);
                points[i + 6] = new Point3D(0.75f - 0.5f * i, i % 2 * 0.2f, 0.75f);
                points[i + 9] = new Point3D(-0.75f, i % 2 * 0.2f, 0.75f - 0.5f * i);
            }
        }

        private const float DELTA = 0.001f;
        private const float ZERO = DELTA * DELTA;

        private float Div(float a, float b)
        {
            if (Math.Abs(b) < ZERO) return 0;
            return a / b;
        }
        private float B(float t, int i, int k)
        {
            if (k == 1)
            {
                if (t >= T[i] && t < T[i + 1]) return 1;
                return 0;
            }

            return Div((t - T[i]) * B(t, i, k - 1), T[i + k - 1] - T[i]) +
                Div((T[i + k] - t) * B(t, i + 1, k - 1), T[i + k] - T[i + 1]);
        }
        private Point3D GetNurbs(int[] indexes, float t1)
        {
            Point3D res = new Point3D(0, 0, 0);
            float sum = 0;
            float t = DELTA + t1 * (1 - 2 * DELTA);

            for (int i = 0; i < 4; i++)
            {
                float bi = B(t, i, 4) * weights[indexes[i]];
                res += points[indexes[i]] * bi;
                sum += bi;
            }
            res *= 1 / sum;
            return res;
        }

        public Point3D GetPoint(float u, float v)
        {
            return 
                    (1 - u) * GetNurbs(new int[] { 0, 11, 10, 9 }, v) +
                    u * GetNurbs(new int[] { 3, 4, 5, 6 }, v) +
                    (1 - v) * GetNurbs(new int[] { 0, 1, 2, 3 }, u) +
                    v * GetNurbs(new int[] { 9, 8, 7, 6 }, u) +
                    (-1) * ((1 - u) * (1 - v) * points[0] 
                            + u * (1 - v) * points[3] + (1 - u) * v * points[9] + u * v * points[6]);
        }
    }
}
