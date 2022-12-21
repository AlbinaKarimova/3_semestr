﻿using Sparse_matrix;

/*
1) Написать набор классов для работы с разреженными матрицами.
Класс позволяет хранить разреженную матрицу в виде коллекции, в которой 
не расходуется память под нулевые элементы.
Элементами матрицы могут быть элементы произвольного типа
При обращении к коллекции по индексам строки и столбца должны выдаваться элементы матрицы,
в том числе и реально не хранящиеся в коллекции элементы по умолчанию.
2) Реализовать интерфейс IEnumerable для перебора элементов матрицы ы цикле foreach
 */

int a = 4;
MatrixElement<int> x = new(1, 1, a);
MatrixList<int> l = new(3, 3);
l[0, 1] = 6;
l[x.I, x.J] = a;
l[0, 1] = 9;
l.Show();
Console.WriteLine();

// Матрица в виде списка
foreach(var elem in l)
{
    Console.Write("{0} ", elem);
}