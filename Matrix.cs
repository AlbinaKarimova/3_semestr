using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Matrix
{
    // Класс ошибок
    public class InvalidValue : Exception
    {
        public InvalidValue() : base("Некорректно введенное значение") { }
    }

    public class InvalidSizeofmatrix : Exception
    {
        public InvalidSizeofmatrix() : base("Несоответствующие размеры матриц") { }
    }
       

    public class Matrix
    {
        public int n;//количество строк
        public int m;//количество столбцов
        public double[,] matr;

        //если поля класса типа private, то нужно написать эти свойства
        protected int N
        {
            get => n;
            set => n = value;
        }
        protected int M
        {
            get => m;
            set => m = value;
        }
        protected double[,] Matr 
        {
            get => matr;
            set => matr = value;
        }

        //Конструктор для матрицы с рандомными элементами
        public Matrix(int n = 0, int m = 0)
        {
            Random random = new ();
            this.n = n;
            this.m = m;
            double[,] matr = new double[n, m];
            for (int i = 0;i < n; i++)
            {
                for (int j = 0;j < m; j++)
                {
                    matr[i, j] = Convert.ToInt64(random.NextDouble() * 10000) / 100.0;
                    //matr[i,j] = random.NextDouble(); // этот рандом выводит числа между 0 и 1
                }
            }
            this.matr = matr;
        }

        //Конструктор для ввода матрицы с клавиатуры
        public Matrix()
        {
            Console.WriteLine("Введите количество строк матрицы: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0) throw new InvalidValue();

            Console.WriteLine("Введите количество столбцов матрицы: ");
            int m = Convert.ToInt32(Console.ReadLine());
            if (m <= 0) throw new InvalidValue();

            this.n = n;
            this.m = m;
            double[,] matr = new double[n, m];

            Console.WriteLine("Введите поочередно элементы матрицы: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matr[i,j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            this.matr = matr;
        }

        //Конструктор для чтения матрицы из файла
        public Matrix(string filename)
        {
            string[] str;
            str = File.ReadAllLines(filename);
            this.n = Convert.ToInt32(Splitter(str[0], 0));
            try
            {
                this.m = Convert.ToInt32(Splitter(str[0], 1));
            }
            catch
            {
                this.m = this.n;
            }
            if (n <= 0 && m <= 0) throw new InvalidValue();
            this.matr = new double[this.n, this.m];
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    matr[i, j] = Convert.ToDouble(Splitter(str[i + 1], j));
                }
            }
        }
        //Метод для разделения чисел в файле
        private static string Splitter(string str, int pos)
        {
            string[] str_split;
            str_split = str.Split(" ");
            return str_split[pos];
        }

        // Сложение прямоугольных матриц
        public static Matrix? operator +(Matrix m1, Matrix m2)
        {
            if (m1.n == m2.n && m1.m == m2.m)
            {
                Matrix matrix_res = Matrix.Copy_matrix(m1);
                for (int i = 0; i < m2.n; i++)
                {
                    for (int j = 0; j < m1.m; j++)
                    {
                        matrix_res.matr[i, j] = m1.matr[i, j] + m2.matr[i, j];
                    }
                }
                return matrix_res;
            }
            else 
            {
                throw new InvalidSizeofmatrix();
                //return null;
            }
        }

        // Разность прямоугольных матриц
        public static Matrix? operator -(Matrix m1, Matrix m2)
        {
            if (m1.n == m2.n && m1.m == m2.m)
            {
                Matrix matrix_res = Matrix.Copy_matrix(m1);
                for (int i = 0; i < m2.n; i++)
                {
                    for (int j = 0; j < m1.m; j++)
                    {
                        matrix_res.matr[i, j] = m1.matr[i, j] - m2.matr[i, j];
                    }
                }
                return matrix_res;
            }
            else
            {
                throw new InvalidSizeofmatrix();
                //return null;
            }
        }

        // Сложение матрицы и числа
        public static Matrix? Add_to_const(Matrix matrix, double c)
        {
            if (matrix.n == matrix.m)
            {
                // Создаем копию матрицы для вычисления на ней результата, чтобы исходная матрица не изменялась
                Matrix m_copy = Matrix.Copy_matrix(matrix);
                // Создаем матрицу, на основе которой будем строить диагональную
                Matrix for_result = new(matrix.n, matrix.m);
                // Создаем диагональную матрицу из числе
                Matrix matrix_res = Matrix.One_matrix(for_result, c);
                for (int i = 0; i < matrix.n; i++)
                {
                   m_copy.matr[i, i] = matrix.matr[i, i] + matrix_res.matr[i,i];
                }
                return m_copy;
            }
            else
            {
                return null;
            }
        }

        // Умножение матрицы на число
        public static Matrix? Myltiply_const_to_matrix(Matrix matrix, double c)
        {
            if (matrix != null)
            {
                Matrix m_copy = Matrix.Copy_matrix(matrix);
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        m_copy.matr[i, j] = matrix.matr[i, j] * c;
                    }
                }
               return m_copy;
            }
            else
            {
                return null;
            }
        }

        // Деление матрицы на число
        public static Matrix? Division_const_to_matrix(Matrix matrix, double c)
        {
            try
            {
                if (matrix != null)
                {
                    Matrix m_copy = Matrix.Copy_matrix(matrix);
                    for (int i = 0; i < matrix.n; i++)
                    {
                        for (int j = 0; j < matrix.m; j++)
                        {
                           // double b = matrix.matr[i, j];
                            m_copy.matr[i, j] = matrix.matr[i, j] / c;
                            //double a = matrix.matr[i, j];
                        }
                    }
                    return m_copy;
                }
                else
                {
                    return null;
                }
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Попытка деления на 0");
                return null;
            }
        }

        // Умножение матриц
        public static Matrix Matrix_Multiplication(Matrix m1, Matrix m2)
        {
            if (m1.m == m2.n)
            {
                Matrix m_copy = Matrix.Copy_matrix(m1);
                for (int i = 0; i < m1.m; i++)
                {
                    for(int j = 0; j < m1.m; j++)
                    {
                        m_copy.matr[i, j] = 0;
                        for(int l = 0; l < m1.m; l++)
                        {
                            m_copy.matr[i, j] += m1.matr[i, l] * m2.matr[l, j];
                        }
                    }
                }
                return m_copy;
            }
            else
            {
                throw new InvalidSizeofmatrix();
            }
        }

        //Метод создания единичная матрицы
        public static Matrix One_matrix(Matrix matrix, double a)
        {
            for(int i = 0; i < matrix.n; i++)
            {
                for(int j=0;j< matrix.m; j++)
                {
                    if (i == j)
                    {
                        matrix.matr[i, j] = a;
                    }
                    else
                    {
                        matrix.matr[i, j] = 0;
                    }
                    
                }
            }
            return matrix;
        }

        // Метод создания копии матрицы(нужно для умножения и деления на число)
        public static Matrix Copy_matrix(Matrix m)
        {
            Matrix matrix = new Matrix(m.n, m.m);
            for(int i = 0; i < m.n; i++)
            {
                for(int j = 0; j < m.m; j++)
                {
                    matrix.matr[i, j] = m.matr[i, j];
                }
            }
            return matrix;
        }



        //Вывод матрицы на консоль
        public void Show()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    Console.Write("{0} ", this.matr[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
