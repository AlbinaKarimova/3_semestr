using Практика_26._09._2022_точки_в_трехмерном_пр_ве;

Dots point1 = new (-1, -2, -3);
Dots point2 = new (5, 1, 1);

//Расстояние между точками
double dist = Dots.Distance(point1, point2);
Console.WriteLine("Расстояние между точками = {0}", dist);

//Расстояние от точки до точки (0;0;0)
Dots point3 = new (0, 0, 0);
double _dist = Dots.Distance(point2, point3);
Console.WriteLine("Расстояние от заданной точки до точки (0;0;0) = {0}", _dist);

//Сложение точек(векторов)-покоординатно
Dots sum = point1.Plus(point2);
Console.WriteLine("Сумма точек = {0}", sum);

//Скалярное произведение
Dots point6 = new(1, 1, 1);
double _skal_pr = Dots.Skal_pr(point1, point2, point6);
Console.WriteLine("Скалярное произведение = {0}", _skal_pr);

//Векторное произведение
string str = Dots.Vek_pr(point1, point2);
Console.WriteLine("Векторное произведение = {0}", str);

//Уранение плоскости
Dots point4 = new Dots(4, 5, 6);
string _equation_of_plane = Dots.Equation_of_plane(point1, point2, point4);
Console.WriteLine("Уранение плоскости : {0}", _equation_of_plane);

//Уравнение прямой
string _equation_of_line = Dots.Equation_of_line(point1, point2);
Console.WriteLine("Уравнение прямой: {0}", _equation_of_line);