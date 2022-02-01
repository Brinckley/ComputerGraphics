using System;
using CGLabPlatform;

namespace Lab2
{
    public static class Matrix4Worker
    {
        public static void SetTopView(ref DMatrix4 Matrix_ViewWorld)
        {//y = 0
            DMatrix4 TopView = new DMatrix4(
                1, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 1, 0, 
                0, 0, 0, 1);
            Matrix_ViewWorld *= TopView;
            //Scale4(ref Matrix_ViewWorld, 1, 0, 1);
        }
        
        public static void SetSideView(ref DMatrix4 Matrix_ViewWorld)
        {//x = 0
            DMatrix4 SideView = new DMatrix4(
                0, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0, 
                0, 0, 0, 1);
            Matrix_ViewWorld *= SideView;
            //Scale4(ref Matrix_ViewWorld, 0, 1, 1);
            //RotationY4(ref Matrix_ViewWorld, 90);
        }
        
        public static void SetFrontView(ref DMatrix4 Matrix_ViewWorld)
        {//z = 0
            DMatrix4 FrontView = new DMatrix4(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 1); 
            Matrix_ViewWorld *= FrontView;
            //Scale4(ref Matrix_ViewWorld, 1, 1, 0);
        }
        
        public static void SetIsometricView(ref DMatrix4 Matrix_ViewWorld)
        {
            //Matrix_ViewWorld *= DMatrix4.Identity;
            RotationX4(ref Matrix_ViewWorld, 35);
            RotationY4(ref Matrix_ViewWorld, 45);
        }
        
        public static void Scale4(ref DMatrix4 matrix4, double sX, double sY, double sZ)
        {
            /*DMatrix4 scaleMatrix = new DMatrix4(
                sX, 0, 0, 0,
                0, sY, 0, 0,
                0, 0, sZ, 0,
                0, 0, 0, 1);
            matrix4 *= scaleMatrix;*/
            matrix4.M11 = sX;
            matrix4.M22 = sY;
            matrix4.M33 = sZ;
            matrix4.M44 = 1;
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
            /*DMatrix4 matrixTranslate = new DMatrix4(
                1, 0, 0, oX,
                0, 1, 0, oY,
                0, 0, 1, oZ,
                0, 0, 0, 1);
            matrix4 *= matrixTranslate;*/
            matrix4.M14 = oX;
            matrix4.M24 = oY;
            matrix4.M34 = oZ;
            matrix4.M44 = 1;
        }
    }
}