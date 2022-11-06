using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure_in_space
{
    internal class Points
    {
        private double x;
        private double y;
        private double z;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public Points(double X = 0, double Y = 0, double Z = 0)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
        }




        //Скалярное произведение
        public static double Skal_pr(Points A, Points B, Points C)
        {
            Points v1 = new(A.X - B.X, A.Y - B.Y, A.Z - B.Z);
            Points v2 = new(B.X - C.X, B.Y - C.Y, B.Z - C.Z);
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }


        //Метод для вычисления длины вектора
        public static double Vektor_length(Points A, Points B)
        {
            return Math.Pow(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2) + Math.Pow(A.Z - B.Z, 2), 0.5);
        }


        public static string Vek_pr(Points A, Points B)
        {
            string _vek_pr, s1, s2;
            double a, b, c;
            a = A.Y * B.Z - B.Y * A.Z;
            b = A.X * B.Z - B.X * A.Z;
            if (b < 0) b = Math.Abs(b);
            c = A.X * B.Y - B.X * A.Y;
            _vek_pr = Convert.ToString(a) + "*i";
            s1 = "+" + Convert.ToString(b) + "*j";
            s2 = Convert.ToString(c) + "*k";
            if (c > 0) s2 = "+" + s2;
            return _vek_pr + s1 + s2;
        }

        //Вычисление вектора
        public Points Vektor(Points other) =>
            new(X - other.X, Y - other.Y, Z - other.Z);

        //Вычиление угла между векторами
        public static double Ygol(Points A, Points B, Points C)
        {
            double ab = Points.Vektor_length(A, B);
            double bc = Points.Vektor_length(C, B);
            double cos_b = Points.Skal_pr(A, B, C) / (ab * bc);
            return Math.Acos(cos_b) * 180 / Math.PI;
        }

        public static double Vek_pr(Points A, Points B, Points C)
        {
            double ab = Points.Vektor_length(A, B);
            double bc = Points.Vektor_length(B, C);
            //Высичлем синус угла через косинус
            double phi_1 = Math.Pow(1 - Math.Pow(Points.Skal_pr(A, B, C) / (ab * bc), 2), 0.5);
            return ab * bc * phi_1;
        }

        //Площадь треугольника
        public static double Sq_3(Points A, Points B, Points C)
        {
            double ab = Points.Vektor_length(A, B);
            double bc = Points.Vektor_length(B, C);
            double phi = Math.Sin(Points.Ygol(A, B, C));
            return 1 / 2 * ab * bc * phi;
        }
    }
}
