using System;

namespace lab4
{
    class Program
    {
        static void Main()
        {
            while(true)
            {
                UI.PrintMenu();
                int choice = UI.ReadInt("");
                switch(choice)
                {
                    case 1: Part1(); break;
                    case 2: Part2(); break;
                    case 3: Part3(); break;
                    case 0: return;
                    default: UI.PrintMessage("Нет такого пункта"); break;
                }
            }
        }

        static void Part1()
        {
            UI.PrintLine();
            UI.PrintMessage("ЧАСТЬ 1. Базовый класс Point");

            Point p1 = new Point(3, 4);
            Point p2 = new Point(6, 8);

            UI.PrintMessage("Точка 1:");
            UI.PrintPoint(p1);
            UI.PrintMessage("Точка 2:");
            UI.PrintPoint(p2);

            UI.PrintMessage($"Расстояние между точками (метод класса): {p1.Distance(p2):F2}");
            UI.PrintMessage($"Расстояние между точками (статическая функция): {Point.get_Distance(p1, p2):F2}");

            UI.PrintMessage($"Всего создано объектов Point: {Point.count_obj}");
            UI.PrintLine();
        }

        static void Part2()
        {
            UI.PrintLine();
            UI.PrintMessage("ЧАСТЬ 2. Перегрузка операций");
            Point p = new Point(5.5, 8.9);
            UI.PrintMessage("Исходная точка:");
            UI.PrintPoint(p);

            p = ++p; // унарный ++
            UI.PrintMessage("После унарного ++ (x+1):");
            UI.PrintPoint(p);

            p = --p; // унарный --
            UI.PrintMessage("После унарного -- (x-1):");
            UI.PrintPoint(p);

            int intx = (int)p; // явное в int
            UI.PrintMessage($"Явное преобразование в int (целая часть X): {intx}");

            double doubley = p; // неявное в double
            UI.PrintMessage($"Неявное преобразование в double (Y): {doubley}");

            Point p2 = new Point(0, 0);
            double dist = p + p2; // между точками
            UI.PrintMessage($"Расстояние между точками: {dist:F2}");

            Point p_x1 = p + 2; // Point + int
            UI.PrintMessage("После (Point + 2) [увеличился X]:");
            UI.PrintPoint(p_x1);

            Point p_bin2 = 3 + p; // int + Point
            UI.PrintMessage("После (3 + Point) [увеличился X]:");
            UI.PrintPoint(p_bin2);

            UI.PrintLine();

        }

        static void Part3()
        {
            UI.PrintLine();
            UI.PrintMessage("ЧАСТЬ 3. Коллекция PointArray. Задание: Самая удаленная точка от центра координат.");

            UI.PrintMessage("Создание массива из 5 случайных точек:");
            PointArray arr = new PointArray(5);
            arr.Print();

            Point k = find_point(arr);

            UI.PrintMessage("\nСамая удаленная точка:");
            UI.PrintPoint(k);
            UI.PrintMessage($"Расстояние до центра: {k.Distance_c():F2}");
            UI.PrintMessage($"\nВсего создано объектов Point: {Point.count_obj}");
            UI.PrintLine();
        }

        //функция для поиска самой удаленной от центра координат точки
        public static Point find_point(PointArray arr)
        {
            if (arr.len == 0) throw new ArgumentException("Массив пуст!");
            Point max_point = arr[0];
            double max_dist = max_point.Distance_c();

            for(int i = 1; i < arr.len; i++)
            {
                double cur_dist = arr[i].Distance_c();
                if(cur_dist > max_dist)
                {
                    max_dist = cur_dist;
                    max_point = arr[i];
                }
            }
            return max_point;
        }
    }
}