using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Класс для хранения одного элемента матрицы
namespace Sparse_matrix
{
    public class MatrixElement<T>
    {
        private int i;
        private int j;
        private T elem;

        // Конструктор элемента матрицы
        public MatrixElement(int i, int j, T elem)
        {
            this.i = i;
            this.j = j;
            this.elem = elem;
        }

        // Свойство для получения индекса строки элемента матрицы
        public int I
        {
            get { return i; }
        }

        // Свойство для получения индекса столбца элемента матрицы
        public int J
        {
            get { return j; }
        }

        //Свойство для получения и установки значения элемента
        public T Elem
        {
            get { return elem; }
            set { elem = value; }
        }
    }
}
