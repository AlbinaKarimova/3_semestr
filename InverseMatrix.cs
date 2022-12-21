using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Matrix
{
    public class InvalidMatrix : Exception
    {
        public InvalidMatrix() : base("У матрицы определитель равен нулю => она не обратима") { }
    }
    public class InverseMatrix : SquareMatrix
    {
        // Вызов коструктора с рандомными элементами матрицы предка 
        public InverseMatrix(int n) : base(n)
        {
            if (Math.Abs(SquareMatrix.Deter(this, n)) < Double.Epsilon)
                throw new InvalidMatrix();
        }

        // Конструктор для матрицы, введенной с клавиатуры 
        public InverseMatrix()
        {
            if (Math.Abs(SquareMatrix.Deter(this, n)) < Double.Epsilon)
                throw new InvalidMatrix();
        }

        // Коснтрутор для матрицы из файла
        public InverseMatrix(string filename) : base(filename)
        {
            if (Math.Abs(SquareMatrix.Deter(this, n)) < Double.Epsilon)
                throw new InvalidMatrix();
        }

        public static double Get_algebraic_dopol(SquareMatrix M, int row, int col)
        {
            SquareMatrix m_minor = SquareMatrix.Get_Minor_matr(M, row, col);
            // Знак
            int i = 1;
            if ((row + col + 2) % 2 == 1) i = -1;
            return i * SquareMatrix.Deter(m_minor, m_minor.n);
        }

        public static InverseMatrix Transposition(InverseMatrix m)
        {
            InverseMatrix m_res = m;
            double temp;
            for (int i = 0; i < m.n; ++i)
            {
                for (int j = i; j < m.n; ++j)
                {
                    temp = m_res.matr[i, j];
                    m_res.matr[i, j] = m_res.matr[j, i];
                    m_res.matr[j, i] = temp;
                }
            }
            return m_res;
        }

        public static InverseMatrix? Create_Inverse_Matrix(InverseMatrix M)
        {
            double det = SquareMatrix.Deter(M, M.n);
            if (Math.Abs(det) < Double.Epsilon) throw new InvalidMatrix();

            InverseMatrix m_res = new(M.n);
            for (int i = 0; i < M.n; i++)
            {
                for(int j = 0; j < M.n; j++)
                {
                    double a = Get_algebraic_dopol(M, i, j);
                    m_res.matr[i, j] = Get_algebraic_dopol(M, i, j) / det;
                    double b = m_res.matr[i, j];
                }
            }
            return InverseMatrix.Transposition(m_res);
        }
    }
}
