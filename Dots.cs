using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points_in_three_dimensional_space
{
    internal class Dots
    {
        private double x;
        private double y;
        private double z;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public Dots(double X = 0, double Y = 0, double Z = 0)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
        }

        //расстояние между точками
        public static double Distance(Dots A, Dots B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2) + Math.Pow(A.Z - B.Z, 2));
        }

        //уравнение прямой через 2 точки
        public static string Equation_of_line(Dots A, Dots B)
        {
            double v1 = B.X - A.X;
            double v2 = B.Y - A.Y;
            double v3 = B.Z - A.Z;

            string s1, s2, s3, x, y, z;
            s1 = Convert.ToString(v1);
            s2 = Convert.ToString(v2);
            s3 = Convert.ToString(v3);

            if (A.X > 0) x = "+" + Convert.ToString(A.X);
            else x = Convert.ToString(A.X);
            if (A.Y > 0) y = "+" + Convert.ToString(A.Y);
            else y = Convert.ToString(A.Y);
            if (A.Z > 0) z = "+" + Convert.ToString(A.Z);
            else z = Convert.ToString(A.Z);

            return "\n" + "x = " + s1 + "t" + x + "\n" +
                "y = " + s2 + "t" + y + "\n" +
                "z = " + s3 + "t" + z;
        }


        //уравнение плоскости через 3 точки
        public static string Equation_of_plane(Dots A, Dots B, Dots C)
        {
            Dots v1 = new(B.X - A.X, B.Y - A.Y, B.Z - A.Z);
            Dots v2 = new(C.X - A.X, C.Y - A.Y, C.Z - A.Z);
            double a = v1.Y * v2.Z - v2.Y * v1.Z;
            double b = v2.X * v1.Z - v1.X * v2.Z;
            double c = v1.X * v2.Y - v1.Y * v2.X;
            double d = (-a * A.X - b * A.Y - c * A.Z);
            string s1, s2, s3, s4;
            s1 = Convert.ToString(a);
            s2 = Convert.ToString(b);
            s3 = Convert.ToString(c);
            s4 = Convert.ToString(d);
            return s1 + "x + " + s2 + "y + " + s3 + "z + " + d + " = 0";
        }

        //сложение точек(векторов)
        public Dots Plus(Dots other) =>
            new(X + other.X, Y + other.Y, Z + other.Z);

        //скалярное произведение
        public static double Skal_pr(Dots A, Dots B, Dots C)
        {
            Dots v1 = new(A.X - B.X, A.Y - B.Y, A.Z - B.Z);
            Dots v2 = new(B.X - C.X, B.Y - C.Y, B.Z - C.Z);
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        //векторное произведение
        public static string Vek_pr(Dots A, Dots B)
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            sb.Append(X);
            sb.Append(";");
            sb.Append(Y);
            sb.Append(";");
            sb.Append(Z);
            sb.Append(")");
            return sb.ToString();
        }
    }
}