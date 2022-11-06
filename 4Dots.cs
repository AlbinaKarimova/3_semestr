using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure_in_space
{
    class _4Dots : Points
    {
        private Points A;
        private Points B;
        private Points C;
        private Points D;

        public _4Dots(Points A, Points B, Points C, Points D)
        {
            //double test = a.X;
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
        }

        //Проверка на 4-угольник
        public static bool Check(_4Dots Fig)
        {
            if (Points.Vektor_length(Fig.A, Fig.B) >= Points.Vektor_length(Fig.B, Fig.C) + Points.Vektor_length(Fig.C, Fig.D) + Points.Vektor_length(Fig.D, Fig.A) ||
                Points.Vektor_length(Fig.B, Fig.C) >= Points.Vektor_length(Fig.A, Fig.B) + Points.Vektor_length(Fig.C, Fig.D) + Points.Vektor_length(Fig.D, Fig.A) ||
                Points.Vektor_length(Fig.C, Fig.D) >= Points.Vektor_length(Fig.A, Fig.B) + Points.Vektor_length(Fig.B, Fig.C) + Points.Vektor_length(Fig.D, Fig.A) ||
                Points.Vektor_length(Fig.D, Fig.A) >= Points.Vektor_length(Fig.A, Fig.B) + Points.Vektor_length(Fig.B, Fig.C) + Points.Vektor_length(Fig.C, Fig.D))
                return false;
            else return true;
        }


        //Периметр
        public static double Perimetr(_4Dots Fig)
        {
            double P = Points.Vektor_length(Fig.A, Fig.B);
            P += Points.Vektor_length(Fig.B, Fig.C);
            P += Points.Vektor_length(Fig.C, Fig.D);
            P += Points.Vektor_length(Fig.D, Fig.A);
            return P;
        }

        //Площадь для невыпуклого
        public static void Square_nev(_4Dots Fig)
        {
            //сначала считаем площадь всей фигуры, затем вычтем лишний треугольник с невыпуклой вершиной
            double S = _4Dots.Square_v(Fig);
            double vek_pr1 = Points.Vek_pr(Fig.A, Fig.B, Fig.C);
            double vek_pr2 = Points.Vek_pr(Fig.B, Fig.C, Fig.D);
            double vek_pr3 = Points.Vek_pr(Fig.C, Fig.D, Fig.A);
            double vek_pr4 = Points.Vek_pr(Fig.D, Fig.A, Fig.B);
            double v = 0;
            if (vek_pr1 >= 0 && vek_pr2 >= 0 && vek_pr3 >= 0 && vek_pr4 <= 0) v = 4;
            else if (vek_pr1 >= 0 && vek_pr2 >= 0 && vek_pr3 <= 0 && vek_pr4 >= 0) v = 3;
            else if (vek_pr1 >= 0 && vek_pr2 <= 0 && vek_pr3 >= 0 && vek_pr4 >= 0) v = 2;
            else if (vek_pr1 <= 0 && vek_pr2 >= 0 && vek_pr3 >= 0 && vek_pr4 >= 0) v = 1;

            if (vek_pr1 <= 0 && vek_pr2 <= 0 && vek_pr3 <= 0 && vek_pr4 >= 0) v = 4;
            else if (vek_pr1 <= 0 && vek_pr2 <= 0 && vek_pr3 >= 0 && vek_pr4 <= 0) v = 3;
            else if (vek_pr1 <= 0 && vek_pr2 >= 0 && vek_pr3 <= 0 && vek_pr4 <= 0) v = 2;
            else if (vek_pr1 >= 0 && vek_pr2 <= 0 && vek_pr3 <= 0 && vek_pr4 <= 0) v = 1;
            //то векторное произведение, которое отличается по знаку, будет задавать вершину невыпуклости
            switch (v)
            {
                case 1:
                    Console.WriteLine("Площадь = {0}", S - Points.Sq_3(Fig.A, Fig.B, Fig.C));
                    break;
                case 2:
                    Console.WriteLine("Площадь = {0}", S - Points.Sq_3(Fig.B, Fig.C, Fig.D));
                    break;
                case 3:
                    Console.WriteLine("Площадь = {0}", S - Points.Sq_3(Fig.C, Fig.D, Fig.A));
                    break;
                case 4:
                    Console.WriteLine("Площадь = {0}", S - Points.Sq_3(Fig.D, Fig.A, Fig.B));
                    break;
                default:
                    break;
            }

        }

        //Проверка на выпуклость

        public static bool Vipukl(_4Dots Fig)
        {
            double vek_pr1 = Points.Vek_pr(Fig.A, Fig.B, Fig.C);
            double vek_pr2 = Points.Vek_pr(Fig.B, Fig.C, Fig.D);
            double vek_pr3 = Points.Vek_pr(Fig.C, Fig.D, Fig.A);
            double vek_pr4 = Points.Vek_pr(Fig.D, Fig.A, Fig.B);
            if ((vek_pr1 >= 0 && vek_pr2 >= 0 && vek_pr3 >= 0 && vek_pr4 >= 0) ||
               (vek_pr1 <= 0 && vek_pr2 <= 0 && vek_pr3 <= 0 && vek_pr4 <= 0))
                return true;
            else return false;
        }

        //Площадь для выпуклого
        public static double Square_v(_4Dots Fig)
        {
            double p = _4Dots.Perimetr(Fig) / 2;
            double S = Math.Pow((p - Points.Vektor_length(Fig.A, Fig.B)) * (p - Points.Vektor_length(Fig.B, Fig.C))
                * (p - Points.Vektor_length(Fig.C, Fig.D)) * (p - Points.Vektor_length(Fig.D, Fig.A)), 0.5);
            return S;
        }

        //Проверка на параллелограм
        public static bool Parall(_4Dots Fig)
        {
            //Вычисляем углы между векторами
            double phi_a = Points.Ygol(Fig.B, Fig.A, Fig.D);
            double phi_b = Points.Ygol(Fig.A, Fig.B, Fig.C);
            double phi_c = Points.Ygol(Fig.B, Fig.C, Fig.D);
            double phi_d = Points.Ygol(Fig.C, Fig.D, Fig.A);

            //Длины сторон
            double ab = Points.Vektor_length(Fig.A, Fig.B);
            double bc = Points.Vektor_length(Fig.B, Fig.C);
            double cd = Points.Vektor_length(Fig.C, Fig.D);
            double da = Points.Vektor_length(Fig.D, Fig.A);

            //проверка на равенство против-х углов
            if ((phi_a == phi_c && phi_b == phi_d) || (phi_a == phi_b && phi_c == phi_d))
            {
                //Добавим проверку на равенство прот-х сторон
                if ((Math.Abs(ab - cd) < Double.Epsilon && Math.Abs(bc - da) < Double.Epsilon) ||
                    (Math.Abs(ab - bc) < Double.Epsilon && Math.Abs(cd - da) < Double.Epsilon))
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }

        //Проверка на ромб
        public static bool Romb(_4Dots Fig)
        {
            //Сначало проверка на равентсво всех сторон
            if (_4Dots.Pavnost(Fig))
            {
                //проверка парал-ти прот-х сторон через условие парал-ма
                if (_4Dots.Parall(Fig))
                {
                    return true;
                }
                else return false;
            }

            else return false;
        }


        //Проверка на прямоугольник
        public static bool Pryam(_4Dots Fig)
        {
            //Вычисляем углы между векторами
            double phi_a = Points.Ygol(Fig.B, Fig.A, Fig.D);
            double phi_b = Points.Ygol(Fig.A, Fig.B, Fig.C);
            double phi_c = Points.Ygol(Fig.B, Fig.C, Fig.D);
            double phi_d = Points.Ygol(Fig.C, Fig.D, Fig.A);

            //Достаточно проверить, что фигура- пар-м и углы по 90 градусов
            if (_4Dots.Parall(Fig))
            {
                //проверяем углы
                if (phi_a == phi_b && phi_b == phi_c && phi_c == phi_d)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public static bool Kvadrat(_4Dots Fig)
        {
            //сначала проверяем равенство сторон 
            if (_4Dots.Pavnost(Fig))
            {
                //проверяем углы
                if (_4Dots.Pryam(Fig))
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }

        public static bool Trapez(_4Dots Fig)
        {
            double phi_a = Points.Ygol(Fig.B, Fig.A, Fig.D);
            double phi_b = Points.Ygol(Fig.A, Fig.B, Fig.C);
            double phi_c = Points.Ygol(Fig.B, Fig.C, Fig.D);
            double phi_d = Points.Ygol(Fig.C, Fig.D, Fig.A);
            if (!_4Dots.Parall(Fig))
            {
                if ((Math.Abs(phi_b + phi_c - 180) < Double.Epsilon && Math.Abs(phi_a + phi_d - 180) < Double.Epsilon && (phi_b + phi_a) != 180 && (phi_c + phi_d) != 180) ||
                    (Math.Abs(phi_b + phi_a - 180) < Double.Epsilon && Math.Abs(phi_c + phi_d - 180) < Double.Epsilon && (phi_b + phi_c) != 180 && (phi_a + phi_d) != 180))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public static bool Trapez_ravnobok(_4Dots Fig)
        {
            //Длины сторон
            double ab = Points.Vektor_length(Fig.A, Fig.B);
            double bc = Points.Vektor_length(Fig.B, Fig.C);
            double cd = Points.Vektor_length(Fig.C, Fig.D);
            double da = Points.Vektor_length(Fig.D, Fig.A);

            if (!_4Dots.Parall(Fig))
            {
                if (_4Dots.Trapez(Fig))
                {
                    //Добавим проверку на равенство прот-х сторон
                    if ((Math.Abs(ab - cd) < Double.Epsilon && bc != da) ||
                        (Math.Abs(ab - bc) < Double.Epsilon && cd != da))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        //Длины диагоналей
        public static string Diagonal_len(_4Dots Fig)
        {
            double ab = Points.Vektor_length(Fig.A, Fig.B);
            double ac = Points.Vektor_length(Fig.A, Fig.C);
            double ad = Points.Vektor_length(Fig.A, Fig.D);
            double d1 = 0, d2;

            if (ab > ac && ab > ad) d1 = ab;
            if (ac > ab && ac > ad) d1 = ac;
            if (ad > ab && ad > ac) d1 = ad;

            if (_4Dots.Trapez_ravnobok(Fig) || _4Dots.Parall(Fig))
            {
                d2 = d1;
            }
            else
            {
                if (d1 == ab)
                {
                    d2 = Points.Vektor_length(Fig.C, Fig.D);
                }
                else if (d1 == ac)
                {
                    d2 = Points.Vektor_length(Fig.B, Fig.D);
                }
                else //if (d1 == ad)
                {
                    d2 = Points.Vektor_length(Fig.B, Fig.C);
                }
            }

            string s = Convert.ToString(d1);
            s = s + " и " + Convert.ToString(d2);
            return s;
        }

        //Лежат ли 4 точки в одной плоскости
        public static bool Points_in_one_plane(_4Dots Fig)
        {
            Points v1 = Fig.B.Vektor(Fig.A);
            Points v2 = Fig.C.Vektor(Fig.A);
            double a = v1.Y * v2.Z - v2.Y * v1.Z;
            double b = v2.X * v1.Z - v1.X * v2.Z;
            double c = v1.X * v2.Y - v1.Y * v2.X;
            double d = (-a * Fig.A.X - b * Fig.A.Y - c * Fig.A.Z);

            double yr1 = a * Fig.A.X + b * Fig.A.Y + c * Fig.A.Z + d;
            double yr2 = a * Fig.B.X + b * Fig.B.Y + c * Fig.B.Z + d;
            double yr3 = a * Fig.C.X + b * Fig.C.Y + c * Fig.C.Z + d;
            double yr4 = a * Fig.D.X + b * Fig.D.Y + c * Fig.D.Z + d;

            if (Math.Abs(yr1) < Double.Epsilon && Math.Abs(yr2) < Double.Epsilon && Math.Abs(yr3) < Double.Epsilon && Math.Abs(yr4) < Double.Epsilon)
            {
                return true;
            }
            else return false;
        }

        //Пересекаются ли фигуры
        public static bool Intersection_of_plane(_4Dots Fig1, _4Dots Fig2)
        {
            Points v1 = Fig1.B.Vektor(Fig1.A);
            Points v2 = Fig1.C.Vektor(Fig1.A);
            double a1 = v1.Y * v2.Z - v2.Y * v1.Z;
            double b1 = v2.X * v1.Z - v1.X * v2.Z;
            double c1 = v1.X * v2.Y - v1.Y * v2.X;

            Points v3 = Fig2.B.Vektor(Fig2.A);
            Points v4 = Fig2.C.Vektor(Fig2.A);
            double a2 = v1.Y * v2.Z - v2.Y * v1.Z;
            double b2 = v2.X * v1.Z - v1.X * v2.Z;
            double c2 = v1.X * v2.Y - v1.Y * v2.X;

            double det1 = a1 * b2 - b1 * a2;
            double det2 = a1 * c2 - c1 * a2;
            double det3 = b1 * c2 - c1 * b2;

            if (det1 != 0 || det2 != 0 || det3 != 0)
            {
                return true;
            }
            else return false;
        }

        //Определение фигуры
        public static void What_is_shape(_4Dots Fig)
        {

            if (_4Dots.Trapez(Fig))
            {
                if (_4Dots.Trapez_ravnobok(Fig))
                {
                    Console.WriteLine("Данная фигура является равнобокой трапецией!");
                }
                else
                {
                    Console.WriteLine("Данная фигура является трапецией!");
                }
            }

            if (_4Dots.Parall(Fig))
            {
                if (_4Dots.Romb(Fig))
                {
                    Console.WriteLine("Данная фигура является ромбом!");
                }

                else if (_4Dots.Pryam(Fig))
                {
                    Console.WriteLine("Данная фигура является прямоугольником!");
                }

                else if (_4Dots.Kvadrat(Fig))
                {
                    Console.WriteLine("Данная фигура является квадратом!");
                }
                else
                {
                    Console.WriteLine("Данная фигура является параллелограмом!");
                }
            }
        }

        //Узнаем равносторонний ли 4-угольник
        public static bool Pavnost(_4Dots Fig)
        {
            double ab = Points.Vektor_length(Fig.A, Fig.B);
            double bc = Points.Vektor_length(Fig.C, Fig.B);
            double cd = Points.Vektor_length(Fig.C, Fig.D);
            double da = Points.Vektor_length(Fig.A, Fig.D);

            if (Math.Abs(ab - bc) < Double.Epsilon && Math.Abs(bc - cd) < Double.Epsilon && Math.Abs(cd - da) < Double.Epsilon && Math.Abs(da - ab) < Double.Epsilon)
            {
                return true;
            }
            else return false;
        }

    }
}

