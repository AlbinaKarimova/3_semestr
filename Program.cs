using DZ_Matrix;
/*
Class Matrix
Сложение и вычитание матриц+
Умножение и деление на константу+
Умножение матриц с проверкой размерностей+ 
Транспонировать матрицу+
Выводить конкретный+

Наследник SquareMatrix
Вычислить определитель+
Избавляться от линейно зависимых строк или столбцов-когда определитель = 0 +

Наследник от SquareMatrix - InverseMatrix
Вычислять обратную матрицу - с проверкой+
*/

//Matrix m_random = new(3, 3);
//Console.WriteLine("Матрица с рандомными элементами:");
//m_random.Show();
//Console.WriteLine();

//Matrix m_random2 = new(3, 3);
//Console.WriteLine("Матрица с рандомными элементами:");
//m_random2.Show();
//Console.WriteLine();

//Matrix m_keyboard = new();
//Console.WriteLine();
//m_keyboard.Show();
//Console.WriteLine();

//Matrix m_infile = new("Matrix.txt");
//Console.WriteLine("Матрица, считанная из файла:");
//m_infile.Show();
//Console.WriteLine();

// Сумма двух матриц
//Console.WriteLine("Сумма двух матриц: ");
//Matrix? m_add = m_random + m_random2;
//m_add?.Show();
//Console.WriteLine();

// Разность двух матриц
//Console.WriteLine("Разность двух матриц: ");
//Matrix? m_sub = m_random - m_random2;
//m_sub?.Show();
//Console.WriteLine();

//Сложение матрицы и числа
//double a = 5;
//Matrix? m_add_toconst = Matrix.Add_to_const(m_random, a);
//Console.WriteLine("Матрица + число: ");
//m_add_toconst?.Show();
//Console.WriteLine();

//Умножение матрицы на число
//double c = 4;
//Matrix? m_myltiply_to_const = Matrix.Myltiply_const_to_matrix(m_random, c);
//Console.WriteLine("Матрица * число:");
//m_myltiply_to_const?.Show();
//Console.WriteLine();


//Деление матрицы на число
//double b = 2;
//Matrix? m_division_to_const = Matrix.Division_const_to_matrix(m_random, b);
//Console.WriteLine("Матрица / число:");
//m_division_to_const?.Show();
//Console.WriteLine();

//Транспонирование матриц
//Matrix m_trans = Matrix.Transposition(m_random2);
//Console.WriteLine("Транспонированная матрица:");
//m_trans.Show();
//Console.WriteLine();

//Matrix m_random3 = new(9, 3);
//Console.WriteLine("Матрица с рандомными элементами:");
//m_random3.Show();
//Console.WriteLine();

//Умножение матриц
//Matrix m_mul = Matrix.Matrix_Multiplication(m_random3, m_random2);
//Console.WriteLine("Умноженные матрицы:");
//m_mul.Show();
//Console.WriteLine();

// Создаем квадратную матрицу
//SquareMatrix m_square = new SquareMatrix();
//m_square.Show();
//Console.WriteLine();

//// Определитель квадратной матрицы
//double det = SquareMatrix.Deter(m_square, m_square.n);
//Console.WriteLine($"Определитель матрицы = {det}");
//Console.WriteLine();

////Проверка на линейную зависимость/независимость строк в матрице
//if (Math.Abs(det) < Double.Epsilon)
//{
//    // Сначала преобразовываем матрицу к верхнетреугольному виду 
//    SquareMatrix m_tr = SquareMatrix.Triangulation(m_square, m_square.n);

//    // Создаем список из индексов нулевых строк матрицы
//    List<int> index = SquareMatrix.Index_of_null_rows(m_tr);

//    // Удаляем линейно зависимые строки из исходной матрицы
//    Matrix m_undep = SquareMatrix.Without_depended_rows(m_square, index);
//    Console.WriteLine("Матрица без линейно зависимых строк: ");
//    m_undep.Show();
//}

// Квадратная матрица из файла
//SquareMatrix sq_matr_from_file = new SquareMatrix("Sq_matr.txt");
//sq_matr_from_file.Show();

InverseMatrix m_inv = new("Sq_matr.txt");
m_inv.Show();
Console.WriteLine();
InverseMatrix? m = InverseMatrix.Create_Inverse_Matrix(m_inv);
Console.WriteLine("Обратная матрица: ");
m?.Show();

