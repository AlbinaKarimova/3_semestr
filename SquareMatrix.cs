using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Matrix
{
    public class SquareMatrix : Matrix
    {

        // Вызов коструктора с рандомными элементами матрицы предка 
        public SquareMatrix(int n) : base(n, n)
        {
        }

        // Конструктор для матрицы, введенной с клавиатуры 
        public SquareMatrix()
        {
        }
        
        // Коснтрутор для матрицы из файла
        public SquareMatrix(string filename) : base(filename)
        {
            if (n != m)
            {
                Console.WriteLine("Матрица, считанная с файла не является квадратной:(");
            }
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            sb.Append(matr[i, j]);
        //            sb.Append(" ");
        //        }
        //        sb.Append("\n");
        //    }
        //    return sb.ToString();
        //}


        // Удаление столбца
        public static Matrix CreateMatrixWithoutColumn(Matrix A, int column)
        {
            if (column < 0 || column >= A.m)
            {
                throw new ArgumentException("invalid column index");
            }

            else
            {
                Matrix m_res = new (A.n, A.m - 1);
                for (int i = 0; i < A.n; i++)
                {
                    for (int j = 0; j < A.m; j++)
                    {
                        if (j < column)
                        {
                            m_res.matr[i, j] = A.matr[i, j];
                        }
                        if (j > column)
                        {
                            m_res.matr[i, j - 1] = A.matr[i, j];
                        }

                    }
                }
                return m_res;
            }
        }


        // Удаление строки
        public static Matrix CreateMatrixWithoutRow(Matrix A, int row)
        {
            if (row < 0 || row >= A.n)
            {
                throw new ArgumentException("invalid rows index");
            }

            else
            {
                Matrix m_res = new (A.n - 1, A.m);
                for (int i = 0; i < A.n; i++)
                {
                    for (int j = 0; j < A.m; j++)
                    {
                        if (i < row)
                        {
                            m_res.matr[i, j] = A.matr[i, j];
                        }
                        if (i > row)
                        {
                            m_res.matr[i - 1, j] = A.matr[i, j];
                        }

                    }
                }
                return m_res;
            }
        }

        public static SquareMatrix Get_Minor_matr(SquareMatrix A, int row, int col)
        {
            Matrix m_without_row_and_col = CreateMatrixWithoutRow(A, row);
            m_without_row_and_col = CreateMatrixWithoutColumn(m_without_row_and_col, col);
            SquareMatrix m_res = SquareMatrix.Copy_matrix(m_without_row_and_col);
            return m_res;
        }


        public bool IsSquare { get => this.M == this.N; }

        public static double Deter(SquareMatrix m_det, int n)
        {
            if (!m_det.IsSquare)
            {
                throw new InvalidOperationException(
                    "determinant can be calculated only for square matrix");
            }

            if (m_det.n == 1) return m_det.matr[0, 0];
            else if (m_det.n == 2) return m_det.matr[0, 0] * m_det.matr[1, 1] - m_det.matr[0, 1] * m_det.matr[1, 0];

            double det = 0;
            int k = 1;

            for (int i = 0; i < m_det.n; i++)
            {
                SquareMatrix m_for_minor = Get_Minor_matr(m_det, i, 0);
                det += k * m_det.matr[i, 0] * Deter(m_for_minor, n - 1);
                k *= -1;
            }
            return det;
        }

        // Переопределенный метод предка по созданию копии матрицы
        public static new SquareMatrix Copy_matrix(Matrix m)
        {
            SquareMatrix matrix = new(m.n);
            for (int i = 0; i < m.n; i++)
            {
                for (int j = 0; j < m.m; j++)
                {
                    matrix.matr[i, j] = m.matr[i, j];
                }
            }
            return matrix;
        }

        // Осталось: находить индексы нулевых строк, и создать метод который возвр прямоуг м-цу без строк, которым соответствуют эти индексы 
        public static Matrix Without_depended_rows(SquareMatrix M, List<int> index)
        {
            Matrix m_without_row = Matrix.Copy_matrix(M);

            foreach (var elem in index)
            {
                m_without_row = CreateMatrixWithoutRow(m_without_row, elem);
            }
            return m_without_row;
        }

        // Метод для поиска индексов нулевых строк матрицы, которая после Гаусса 
        public static List<int> Index_of_null_rows(SquareMatrix M)
        {
            List<int> index = new(); // список с индексами нудевых строк
            int count = 0;
            double E = 1E-9;
            for (int i = 0; i < M.n; i++)
            {
                for(int j = 0; j < M.n; j++)
                {
                    if (Math.Abs(M.matr[i, j]) < E)
                        count++;
                }
                if (count == M.n) index.Add(i);
                count = 0;
            }
            return index;
        }


        // Метод по созданию верхнетреугольной матрицы
        public static SquareMatrix Triangulation(SquareMatrix M, int n)
        {
            SquareMatrix m_res = SquareMatrix.Copy_matrix(M);
            double E = 1E-9;
            for (int i = 0; i < n - 1; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    if (Math.Abs(m_res.matr[i, i]) > E)
                    {
                        double t = -m_res.matr[j, i] / m_res.matr[i, i];
                        for (int k = i; k < M.n; ++k)
                        {
                            m_res.matr[j, k] += m_res.matr[i, k] * t;
                        }
                    }
                }
            }
            return m_res;
        }

        // Транспонирование матрицы
        public static SquareMatrix Transposition(SquareMatrix m)
        {
            if (m.IsSquare)
            {
                SquareMatrix m_copy = SquareMatrix.Copy_matrix(m);
                double temp;
                for (int i = 0; i < m.n; ++i)
                {
                    for (int j = i; j < m.n; ++j)
                    {
                        temp = m_copy.matr[i, j];
                        m_copy.matr[i, j] = m_copy.matr[j, i];
                        m_copy.matr[j, i] = temp;
                    }
                }
                return m_copy;
            }
            else
            {
                throw new InvalidSizeofmatrix();
            }
        }

        // Определитель методом Гаусса
        //public double DetGauss(SquareMatrix M)
        //{
        //    double det = 1; // Хранит определитель, который вернёт функция
        //    int n = M.n; // Размерность матрицы
        //    int k = 0;
        //    const double E = 1E-9; // Погрешность вычислений

        //    for (int i = 0; i < n; i++)
        //    {
        //        k = i;
        //        for (int j = i + 1; j < n; j++)
        //            if (Math.Abs(M.matr[j,i]) >= Math.Abs(M.matr[k,i]))
        //                k = j; // Ищем индексы наибольшего элемента в столбце

        //        if (Math.Abs(M.matr[k, i]) < E)
        //        {
        //            det = 0;
        //            break;
        //        }
        //        Swap(ref M, i, k); // Меняем 2 строки местами (первую и строку с наиб первым числом)

        //        if (i != k) det *= -1;

        //        det *= M.matr[i,i];

        //        for (int j = i + 1; j < n; j++)
        //            M.matr[i,j] /= M.matr[i, i];

        //        for (int j = 0; j < n; j++)
        //            if ((j != i) && (Math.Abs(M.matr[j, i]) > E))
        //                for (k = i + 1; k < n; k++)
        //                    M.matr[j, k] -= M.matr[i, k] * M.matr[j, i];
        //        M.Show();
        //        Console.WriteLine();
        //    }
        //    return det;
        //}


    }
}



