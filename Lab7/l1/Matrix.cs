using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Matrix
    {
        public double[,] values;
        public readonly int n, m;

        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            values = new double[n, m];
        }
        public Matrix(double x, double y, double z)
        {
            n = 3;
            m = 1;
            values = new double[3, 1];
            values[0, 0] = x;
            values[1, 0] = y;
            values[2, 0] = z;
        }

        public static Matrix operator *(double k, Matrix a)
        {
            Matrix b = new Matrix(a.n, a.m);
            for (int i = 0; i < a.n; i++)
                for (int j = 0; j < a.m; j++)
                    b.values[i, j] = a.values[i, j] * k;
            return b;
        }
        public static Matrix operator *(Matrix a, double k) => k * a;
        public static Matrix operator /(Matrix a, double k) => (1 / k) * a;
        public static Matrix operator -(Matrix a) => (-1) * a;

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.n != b.n || a.m != b.m) return null;
            Matrix c = new Matrix(a.n, a.m);
            for (int i = 0; i < a.n; i++)
                for (int j = 0; j < a.m; j++)
                    c.values[i, j] = a.values[i, j] + b.values[i, j];
            return c;
        }
        public static Matrix operator -(Matrix a, Matrix b) => a + -b;

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.m == b.n)
            {
                Matrix c = new Matrix(a.n, b.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < b.m; j++)
                        for (int k = 0; k < a.m; k++)
                            c.values[i, j] += a.values[i, k] * b.values[k, j];
                return c;
            }
            if (a.m == b.n + 1)
            {
                Matrix c1 = new Matrix(a.n, b.m);
                for (int i = 0; i < a.n; i++)
                    for (int j = 0; j < b.m; j++)
                    {
                        for (int k = 0; k < b.n; k++)
                            c1.values[i, j] += a.values[i, k] * b.values[k, j];

                        c1.values[i, j] += a.values[i, b.n];
                    }
                Matrix c = new Matrix(a.n - 1, b.m);
                for (int i = 0; i < a.n - 1; i++)
                    for (int j = 0; j < b.m; j++)
                        c.values[i, j] = c1.values[i, j] / c1.values[a.n - 1, j];
                return c;
            }
            return null;
        }
        public static Matrix operator &(Matrix a, Matrix b)
        {
            if (a.n != b.n || a.m != b.m) return null;
            Matrix c = new Matrix(a.n, a.m);
            for (int i = 0; i < a.n; i++)
                for (int j = 0; j < a.m; j++)
                    c.values[i, j] = a.values[i, j] * b.values[i, j];
            return c;
        }

        public static double Dot(Matrix a, Matrix b)
        {
            if (a.n != b.n || a.m != b.m) return 0;
            double dot = 0;
            for (int i = 0; i < a.n; i++)
                for (int j = 0; j < a.m; j++)
                    dot += a.values[i, j] * b.values[i, j];
            return dot;
        }
        public static Matrix Vector(Matrix a, Matrix b)
        {
            if (a.n == 3 && a.m == 1 && b.n == 3 && b.m == 1)
            {
                return new Matrix(
                    a.values[1, 0] * b.values[2, 0] - a.values[2, 0] * b.values[1, 0],
                    a.values[2, 0] * b.values[0, 0] - a.values[0, 0] * b.values[2, 0],
                    a.values[0, 0] * b.values[1, 0] - a.values[1, 0] * b.values[0, 0]
                    );
            }
            return null;
        }

        public double Length() => Math.Sqrt(Dot(this, this));
        public Matrix Normalized() => this / Length();

        public static implicit operator Point(Matrix a) =>
            new Point((int)a.values[0, 0], (int)a.values[1, 0]);

        public static implicit operator PointF(Matrix a) =>
            new PointF((float)a.values[0, 0], (float)a.values[1, 0]);

        public static implicit operator Color(Matrix a) =>
            Color.FromArgb(
                Math.Max(0, Math.Min((int)(255 * a.values[0, 0]), 255)),
                Math.Max(0, Math.Min((int)(255 * a.values[1, 0]), 255)),
                Math.Max(0, Math.Min((int)(255 * a.values[2, 0]), 255))
                );

        public static Matrix I()
        {
            Matrix a = new Matrix(4, 4);
            a.values[0, 0] = a.values[1, 1] = a.values[2, 2] = a.values[3, 3] = 1;
            return a;
        }
        public static Matrix D(double dx, double dy, double dz)
        {
            Matrix a = I();
            a.values[0, 3] = dx;
            a.values[1, 3] = dy;
            a.values[2, 3] = dz;
            return a;
        }
        public static Matrix S(double sx, double sy, double sz)
        {
            Matrix a = new Matrix(4, 4);
            a.values[0, 0] = sx;
            a.values[1, 1] = sy;
            a.values[2, 2] = sz;
            a.values[3, 3] = 1;
            return a;
        }
        public static Matrix R(double angle, Matrix axis)
        {
            Matrix a = new Matrix(4, 4);
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            double x = axis.values[0, 0];
            double y = axis.values[1, 0];
            double z = axis.values[2, 0];

            a.values[0, 0] = c + (1 - c) * x * x;
            a.values[0, 1] = (1 - c) * x * y - s * z;
            a.values[0, 2] = (1 - c) * x * z + s * y;

            a.values[1, 0] = (1 - c) * y * x + s * z;
            a.values[1, 1] = c + (1 - c) * y * y;
            a.values[1, 2] = (1 - c) * y * z - s * x;

            a.values[2, 0] = (1 - c) * z * x - s * y;
            a.values[2, 1] = (1 - c) * z * y + s * x;
            a.values[2, 2] = c + (1 - c) * z * z;

            a.values[3, 3] = 1;
            return a;
        }
    }
}
