using System;

namespace lab4
{
    class UI
    {
        public static void PrintMessage(string msg) => Console.WriteLine(msg);
        public static void PrintLine() => Console.WriteLine(new string('-', 40));

        public static double ReadDouble(string p)
        {
            double val;
            Console.Write(p);
            while (!double.TryParse(Console.ReadLine(), out val))
            {
                Console.Write("Ошибка ввода. Повторите: ");
            }
            return val;
        }

        public static int ReadInt(string p)
        {
            int val;
            Console.Write(p);
            while (!int.TryParse(Console.ReadLine(), out val))
            {
                Console.Write("Ошибка ввода. Повторите: ");
            }
            return val;
        }

        public static void PrintPoint(Point p)
        {
            Console.WriteLine($"Точка: X = {p.X:F2}, Y = {p.Y:F2}");
        }

        public static void PrintMenu()
        {
            Console.WriteLine("\nМЕНЮ");
            Console.WriteLine("1.Базовый класс Point");
            Console.WriteLine("2.Перегрузка операций");
            Console.WriteLine("3.Коллекция PointArray");
            Console.WriteLine("0.Выход");
            Console.Write("Ваш выбор: ");
        }

    }
}
