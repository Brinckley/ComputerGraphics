using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public class Matrix
    {
        protected float[,] matrix;

        public Matrix()
        {
            matrix = new float[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        public Point Multiply(float x, float y, float z)
        {
            float[] vector = new float[4] { x, y, z, 1.0f };
            float[] ret = new float[4] { 0, 0, 0, 0 };

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    ret[i] += vector[j] * matrix[j, i];

            return new Point((int)(ret[0] / ret[3]), (int)(ret[1] / ret[3]));
        }
        public Point Multiply(Point3D v) => Multiply(v.x, v.y, v.z);

        public static Matrix operator * (Matrix a, Matrix b)
        {
            Matrix ret = new Matrix();

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        ret.matrix[i, j] += a.matrix[i, k] * b.matrix[k, j];

            return ret;
        }

        public static Matrix Identity()
        {
            Matrix m = new Matrix();

            for (int i = 0; i < 4; i++)
                m.matrix[i, i] = 1;

            return m;
        }
        public static Matrix Translate(float tx, float ty, float tz)
        {
            Matrix m = Identity();

            m.matrix[3, 0] = tx;
            m.matrix[3, 1] = ty;
            m.matrix[3, 2] = tz;

            return m;
        }
        public static Matrix Scale(float sx, float sy, float sz)
        {
            Matrix m = new Matrix();

            m.matrix[0, 0] = sx;
            m.matrix[1, 1] = sy;
            m.matrix[2, 2] = sz;
            m.matrix[3, 3] = 1;

            return m;
        }
        private static Matrix Rotation(float angle, int i, int j)
        {
            Matrix m = Identity();

            m.matrix[i, i] = m.matrix[j, j] = (float)Math.Cos(angle);
            m.matrix[i, j] = (float)Math.Sin(angle);
            m.matrix[j, i] = -m.matrix[i, j];

            return m;

        }
        public static Matrix RotateX(float angle) => Rotation(angle, 1, 2);
        public static Matrix RotateY(float angle) => Rotation(angle, 2, 0);
        public static Matrix RotateZ(float angle) => Rotation(angle, 0, 1);
    }

    public class Point3D
    {
        public float x, y, z;
        public Point3D(float x_, float y_, float z_)
        {
            x = x_;
            y = y_;
            z = z_;
        }

        public static Point3D operator +(Point3D a, Point3D b) =>
            new Point3D(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Point3D operator *(float k, Point3D v) =>
            new Point3D(k * v.x, k * v.y, k * v.z);
        public static Point3D operator *(Point3D v, float k) =>
            new Point3D(k * v.x, k * v.y, k * v.z);
    }
}
