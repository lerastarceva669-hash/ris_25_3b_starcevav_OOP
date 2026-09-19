using System;

namespace Laba_1
{
    class Program
    {
        static void Main()
        {
            SolveTask1();
            SolveTask2();
            SolveTask3();
        }

        static void SolveTask1()
        {
            Console.WriteLine("Задача 1");

            int n = 0, m = 0;
            double x = 0;
            bool f_n = false, f_m = false, f_x = false;

            do
            {
                Console.WriteLine("Введите число n: ");
                f_n = int.TryParse(Console.ReadLine(), out n);
                if (!f_n)
                    Console.WriteLine("Ошибка! Неккоректный ввод числа n. Напишите число заново.");
            } while (!f_n);

            do
            {
                Console.WriteLine("Введите число m: ");
                f_m = int.TryParse(Console.ReadLine(), out m);
                if (!f_m)
                    Console.WriteLine("Ошибка! Неккоректный ввод числа m. Напишите число заново.");
            } while (!f_m);

            do
            {
                Console.WriteLine("Введите число x: ");
                f_x = double.TryParse(Console.ReadLine(), out x);
                if (!f_x)
                    Console.WriteLine("Ошибка! Неккоректный ввод числа x. Напишите число заново.");
            } while (!f_x);

            if (m == 0 || m == 1)
            {
                Console.WriteLine("Ошибка! Деление на 0: m равен 0 или 1!");
            }
            else
            {
                int res_1 = n++ / --m;
                Console.WriteLine($"1. m = {m}, n = {n}, n++/--m = {res_1}");

                int temp = n / m++;
                bool res_2 = n-- > temp;
                Console.WriteLine($"2. m = {m}, n = {n}, n-- > n/m++ = {res_2}");

                bool res_3 = m < n++;
                Console.WriteLine($"3. m = {m}, n = {n}, m < n++ = {res_3}");

                double res_4 = 1 + x * Math.Pow(Math.Cos(x), 2) + Math.Pow(Math.Sin(x), 3);
                Console.WriteLine($"4. x = {x}, 1 + x * cos^2(x) + sin^3(x) = {res_4}");
            }
        }

        static void SolveTask2()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Задача 2");

            double x1 = 0, y1 = 0;
            bool f_x1 = false, f_y1 = false;

            do
            {
                Console.WriteLine("Введите координату x1: ");
                f_x1 = double.TryParse(Console.ReadLine(), out x1);
                if (!f_x1)
                    Console.WriteLine("Ошибка! Неправильно набрано число!");
            } while (!f_x1);

            do
            {
                Console.WriteLine("Введите координату y1: ");
                f_y1 = double.TryParse(Console.ReadLine(), out y1);
                if (!f_y1)
                    Console.WriteLine("Ошибка! Неправильно набрано число!");
            } while (!f_y1);

            bool result = !((x1 > 0) && (y1 > 0)) && (x1 * x1 + y1 * y1 <= 1);
            Console.WriteLine($"Точка с координатами ({x1}; {y1}) принадлежит области: {result}");
        }

        static void SolveTask3()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Задача 3");

            float a_f = 1000f, b_f = 0.0001f;

            float temp_num = (float)Math.Pow(a_f, 4) - 4 * b_f * (float)Math.Pow(a_f, 3);
            float num_f = (float)Math.Pow(a_f - b_f, 4) - temp_num;

            float temp_den = 6 * (float)Math.Pow(a_f, 2) * (float)Math.Pow(b_f, 2);
            float den_f =  temp_den - 4 * a_f * (float)Math.Pow(b_f, 3) + (float)Math.Pow(b_f, 4);

            float result_f = num_f / den_f;



            double a_d = 1000, b_d = 0.0001;
            double temp_num = Math.Pow(a_d, 4) - 4 * b_d * Math.Pow(a_d, 3);
            double num_d = Math.Pow(a_d - b_d, 4) - temp_num;

            double temp_den = 6 * Math.Pow(a_d, 2) * Math.Pow(b_d, 2);
            double den_d = temp_den - 4 * a_d * Math.Pow(b_d, 3) + Math.Pow(b_d, 4);

            double result_d = num_d / den_d;

            Console.WriteLine($"Результат с типом float: {result_f}");
            Console.WriteLine($"Результат с типом double: {result_d}");
        }
    }
}