using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Sparse_matrix
{
    // Класс ошибок
    public class InvalidIndex : Exception
    {
        public InvalidIndex() : base("Некорректный индекс!") { }
    }

    // Перечисляемый класс, хранящий в себе список элементов матрицы
    public class MatrixList<T> : IEnumerable
    {
        // Список элементов матрицы
        List<MatrixElement<T>> matrix;

        // Размеры матрицы
        int n, m;

        // Количество ненулевых элементов матрицы
        int count;


        // Конструктор разреженной матрицы из нулевых элементов
        public MatrixList(int N, int M)
        {
            matrix = new List<MatrixElement<T>>();
            n = N;
            m = M;
            count = 0;
        }

        // Индексатор для доступа к элементу матрицы по его индексам
        public T? this[int i, int j]
        {
            // получение значения элемента матрицы 
            get
            {

                // поиск позиции искомого элемента в списке
                int index = 0;

                // пропускаем элементы, находящиеся 
                // в строках с меньшим номером
                while (index < count && i > matrix[index].I)
                    index++;

                if (index < count && i == matrix[index].I)
                {
                    // пропускаем элементы, находящиеся в той же 
                    // строке, но в столбцах с меньшим номером
                    while (index < count && i == matrix[index].I && j > matrix[index].J)
                        index++;
                }

                // если элемент в заданной позиции уже 
                // имеется, возвращаем его значение
                if (index < count && i == matrix[index].I && j == matrix[index].J)
                    return matrix[index].Elem;

                // если элемента в списке нет, его значение равно 0
                return default(T);
            }
            // установка значения элемента матрицы
            set
            {
                bool insert = false;
                // проверка корректности позиции устанавливаемого элемента
                if (i < m && j < n)
                {
                    // если новое значение элемента нулевое, 
                    // удаляем элемент из списка
                    if (value == null)
                    {
                        DeleteElem(i, j);
                        return;
                    }

                    // поиск позиции устанавливаемого элемента
                    int index = 0;

                    // пропускаем элементы, находящиеся 
                    // в строках с меньшим номером
                    while (index < count && i > matrix[index].I)
                        index++;

                    if (index < count && i == matrix[index].I)
                    {
                        // пропускаем элементы, находящиеся в той же 
                        // строке, но в столбцах с меньшим номером
                        while (index < count && i == matrix[index].I && j > matrix[index].J)
                            index++;
                    }

                    // если элемент в заданной позиции уже 
                    // имеется, изменяем его значение
                    if (index < count && i == matrix[index].I && j == matrix[index].J)
                    {
                        matrix[index].Elem = value;
                        insert = true;
                    }

                    // если элемента с такими индексами в списке не было,
                    // вставляем новый элемент в список
                    if (!insert)
                    {
                        MatrixElement<T> element = new(i, j, value);
                        matrix.Insert(index, element);
                        count++;
                    }
                }
                else
                    // Если задана некорректная позиция вставляемого элемента
                    throw new InvalidIndex();
            }
        }

        // Метод для удаления элемента из списка
        public void DeleteElem(int i, int j)
        {
            if (count == 0)
              return;

            // поиск позиции в списке удаляемого элемента 
            int index = 0;

            // пропускаем элементы, находящиеся 
            // в строках с меньшим номером
            while (index < count && i > matrix[index].I)
                index++;
            if (index < count && i == matrix[index].I)
            {
                // пропускаем элементы, находящиеся в той же 
                // строке, но в столбцах с меньшим номером
                while (index < count && i == matrix[index].I &&
               j > matrix[index].J)
                    index++;
            }
            // если элемент в заданной позиции уже 
            // имеется, удаляем его из списка
            if (index < count && i == matrix[index].I && j == matrix[index].J)
            {
                matrix.RemoveAt(index);
                count--;
            }

        }

        // Метод для реализации цикла foreach
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.n; i++)
                for (int j = 0; j < this.m; j++)
                {
                    yield return this[i, j];
                }
        }
        public void Show()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    Console.Write("{0} ", this[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
