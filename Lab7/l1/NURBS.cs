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
        public Matrix[] nodes; //control points
        Matrix[] vertices;
        double[] T;

        public NURBS()
        {
            T = new double[10];
            for (int i = 0; i < 10; i++) T[i] = (double)i / 9;

            nodes = new Matrix[] // start point values
            {
                new Matrix(-1.5, 0, 1),
                new Matrix(-1.0, -1.0, 1),
                new Matrix(0, -1, 1),
                new Matrix(0, 1, 1),
                new Matrix(1.0, 1.0, 1),
                new Matrix(1.5, 0, 1)
            };
            Generate(50);
        }

        private double Div(double a, double b)
        {
            if (Math.Abs(b) < 0.000001) return 0; // / 0 exception 
            return a / b;
        }
        private double B(int i, int k, double t) // number, grade, approx
        {
            if (k == 1)
            {
                if (t >= T[i] && t < T[i + 1]) return 1;
                return 0;
            }
            return Div((t - T[i]) * B(i, k - 1, t), 
                       T[i + k - 1] - T[i]) 
                   +
                   Div((T[i + k] - t) * B(i + 1, k - 1, t),
                       T[i + k] - T[i + 1]);
        }
        public void Generate(int approx)
        {
            vertices = new Matrix[approx + 1]; // array init for the NURB

            for (int v = 0; v <= approx; v++)
            {
                double t = (double)v / approx * 0.9998 + 0.0001; // creating point for approx movement (0.0001 for zero exception)
                
                double sum = 0;
                vertices[v] = new Matrix(0, 0, 0);
                for (int i = 0; i < nodes.Length; i++) // correcting NURB point location according to the data from global points 
                {
                    double hB = nodes[i].values[2, 0] * B(i, 4, t);         // weight   (k = 4 from task)
                    vertices[v].values[0, 0] += nodes[i].values[0, 0] * hB;   // x
                    vertices[v].values[1, 0] += nodes[i].values[1, 0] * hB;   // y
                    sum += hB;
                }
                vertices[v] /= sum; // correcting 
            }
        }

        public void DrawNURB(Graphics g, Matrix transform)
        {
            for (int i = 0; i < vertices.Length - 1; i++) // drawing lines for global points
            {
                g.DrawLine(Pens.Black, transform * vertices[i], transform * vertices[i + 1]);
            }
            
            for (int i = 0; i < nodes.Length; i++)
            {
                Point p = transform * nodes[i];
                if (i < nodes.Length - 1)
                {
                    g.DrawLine(Pens.Black, p, transform * nodes[i + 1]);
                }

                g.FillRectangle(Brushes.Black, p.X - 5, p.Y - 5, 10, 10);
            }
        }
    }
}
