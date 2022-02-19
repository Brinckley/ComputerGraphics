using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class NURBS
    {
        public Matrix[] nodes;
        Matrix[] vertices;
        double[] T;

        public NURBS()
        {
            T = new double[10];
            for (int i = 0; i < 10; i++) T[i] = (double)i / 9;

            nodes = new Matrix[]
            {
                new Matrix(-1.5, 0, 1),
                new Matrix(-0.5, -0.5, 1),
                new Matrix(0, -1, 1),
                new Matrix(0, 1, 1),
                new Matrix(0.5, 0.5, 1),
                new Matrix(1.5, 0, 1)
            };
            Generate(50);
        }

        private double Div(double a, double b)
        {
            if (Math.Abs(b) < 0.000001) return 0;
            return a / b;
        }
        private double B(int i, int k, double t)
        {
            if (k == 1)
            {
                if (t >= T[i] && t < T[i + 1]) return 1;
                return 0;
            }

            return Div((t - T[i]) * B(i, k - 1, t), T[i + k - 1] - T[i]) +
                Div((T[i + k] - t) * B(i + 1, k - 1, t), T[i + k] - T[i + 1]);
        }
        public void Generate(int approx)
        {
            vertices = new Matrix[approx + 1];

            for (int v = 0; v <= approx; v++)
            {
                double t = (double)v / approx * 0.9998 + 0.0001;
                double hsum = 0;

                vertices[v] = new Matrix(0, 0, 0);
                for (int i = 0; i < nodes.Length; i++)
                {
                    double hB = nodes[i].values[2, 0] * B(i, 4, t);
                    vertices[v].values[0, 0] += nodes[i].values[0, 0] * hB;
                    vertices[v].values[1, 0] += nodes[i].values[1, 0] * hB;
                    hsum += hB;
                }
                vertices[v] /= hsum;
            }
        }

        public void Draw(Graphics gfx, Matrix transform, Font font)
        {
            for (int i = 0; i < vertices.Length - 1; i++)
                gfx.DrawLine(Pens.Black, transform * vertices[i], transform * vertices[i + 1]);

            string[] names = new string[] { "A", "B", "C", "D", "E", "F" };
            for (int i = 0; i < nodes.Length; i++)
            {
                Point p = transform * nodes[i];
                if (i < nodes.Length - 1)
                    gfx.DrawLine(Pens.Purple, p, transform * nodes[i + 1]);

                gfx.FillRectangle(Brushes.Purple, p.X - 5, p.Y - 5, 10, 10);
                gfx.DrawString(names[i], font, Brushes.Purple, p);
            }
        }
    }
}
