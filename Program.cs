using Figure_in_space;

Points pnt1 = new(0, 0, 0);
Points pnt2 = new(3, 1, 0);
Points pnt3 = new(0, 1, 0);
Points pnt4 = new(3, 0, 0);

Points pnt5 = new(-2, 0, 0);
Points pnt6 = new(-1, 2, 0);
Points pnt7 = new(1, 2, 0);
Points pnt8 = new(3, 0, 0);

Points pnt9 = new(1, 1, 0);
Points pnt10 = new(1, 2, 0);
Points pnt11 = new(2, 2, 0);
Points pnt12 = new(2, 1, 0);


_4Dots Fig = new(pnt1, pnt2, pnt3, pnt4);
_4Dots Fig1 = new(pnt5, pnt6, pnt7, pnt8);
_4Dots Fig2 = new(pnt9, pnt10, pnt11, pnt12);

//Проверка на 4-угольник
if (_4Dots.Check(Fig))
{
    //Периметр
    double P = _4Dots.Perimetr(Fig);
    Console.WriteLine("Периметр = {0}", P);

    //Проверка на выпуклость
    if (_4Dots.Vipukl(Fig))
    {
        Console.WriteLine("Фигура выпуклая!");

        //Площадь фигуры
        double S = _4Dots.Square_v(Fig);
        Console.WriteLine("Площадь = {0}", S);

        //Определение типа фигуры
        _4Dots.What_is_shape(Fig);
    }
    else
    {
        Console.WriteLine("Фигура невыпуклая!");
        //Площадь для невыпуклой фигуры 
        _4Dots.Square_nev(Fig);
    }


}
else
{
    Console.WriteLine("Данная фигура не является четырехугольником!");
}

//Длины диагоналей
Console.WriteLine("Длины диагоналей равны: {0}", _4Dots.Diagonal_len(Fig));

//Лежат ли 4 точки в одной плоскости
if (_4Dots.Points_in_one_plane(Fig))
{
    Console.WriteLine("Точки лежат в одной плоскости");
}
else
{
    Console.WriteLine("Точки не лежат в одной плоскости");
}

//Проверка на пересечение фигур
if (_4Dots.Intersection_of_plane(Fig1, Fig2))
{
    Console.WriteLine("Фигуры пересекаются");
}
else
{
    Console.WriteLine("Фигуры не пересекаются");
}
