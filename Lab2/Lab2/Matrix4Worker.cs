using System;

namespace Lab2
{
    public static class Matrix4Worker
    {
        
        
        public static void SetTopView(ref DMatrix4 Matrix_ViewWorld, DMatrix4 Matrix_InWorld)
        {
            DMatrix4 TopView = new DMatrix4(
                1, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 1, 0, 
                0, 0, 0, 1); //y = 0
            Matrix_ViewWorld = Matrix_InWorld * TopView;
        }
        
        public static void SetSideView(ref DMatrix4 Matrix_ViewWorld, DMatrix4 Matrix_InWorld)
        {
            DMatrix4 SideView = new DMatrix4(
                0, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0, 
                0, 0, 0, 1); //x = 0
            Matrix_ViewWorld = Matrix_InWorld * SideView;
        }
        
        public static void SetFrontView(ref DMatrix4 Matrix_ViewWorld, DMatrix4 Matrix_InWorld)
        {
            DMatrix4 FrontView = new DMatrix4(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 1); //z = 0
            Matrix_ViewWorld = Matrix_InWorld * FrontView;
        }
        public static void Scale4(ref DMatrix4 matrix4, double sX, double sY, double sZ)
        {
            DMatrix4 scaleMatrix = new DMatrix4(
                sX, 0, 0, 0,
                0, sY, 0, 0,
                0, 0, sZ, 0,
                0, 0, 0, 1);
            matrix4 *= scaleMatrix;
        }
        public static void RotationX4(ref DMatrix4 matrix4, double angle)
        {
            DMatrix4 matrixRotationX = new DMatrix4(
                1, 0, 0, 0,
                0, Math.Cos(angle * (Math.PI / 180)), (-1) * Math.Sin(angle * (Math.PI / 180)), 0,
                0, Math.Sin(angle * (Math.PI / 180)), Math.Cos(angle * (Math.PI / 180)), 0,
                0, 0, 0, 1);
            matrix4 *= matrixRotationX;
        }
        
        public static  void RotationY4(ref DMatrix4 matrix4, double angle)
        {
            DMatrix4 matrixRotationY = new DMatrix4(
                Math.Cos(angle * (Math.PI / 180)), 0, Math.Sin(angle * (Math.PI / 180)), 0,
                0, 1, 0, 0,
                (-1) * Math.Sin(angle * (Math.PI / 180)), 0, Math.Cos(angle * (Math.PI / 180)), 0,
                0, 0, 0, 1);
            matrix4 *= matrixRotationY;
        }
        
        public static void RotationZ4(ref DMatrix4 matrix4, double angle)
        {
            DMatrix4 matrixRotationZ = new DMatrix4(
                Math.Cos(angle * (Math.PI / 180)), (-1) * Math.Sin(angle * (Math.PI / 180)), 0, 0,
                Math.Sin(angle * (Math.PI / 180)), Math.Cos(angle * (Math.PI / 180)), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
            matrix4 *= matrixRotationZ;
        }

        public static void Translate4(ref DMatrix4 matrix4, double oX, double oY, double oZ)
        {
            DMatrix4 matrixTranslate = new DMatrix4(
                1, 0, 0, oX,
                0, 1, 0, oY,
                0, 0, 1, oZ,
                0, 0, 0, 1);
            matrix4 *= matrixTranslate;
        }
    }
}