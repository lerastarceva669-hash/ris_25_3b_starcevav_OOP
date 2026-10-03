using System;

namespace Laba_2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Заданная функция: y = 1/2 - pi/4 * |sin x|");
            Console.WriteLine("Диапазон изменения аргумента x: 0.1 <= x <= 0.8");
            Console.WriteLine("Заданное количество слагаемых n: 50");
            Console.WriteLine();

            double a = 0.1, b = 0.8; //диапазон
            int k = 10; //точки
            int n = 50; //количество слагаемых
            double e = 0.0001; //заданная точность

            double step = (b-a) / (k-1); // шаг для 10 точек

            for (int i = 0; i < k; i++)
            {
                double x = a + i * step;
                
                //SN - сумма n слагаемых
                double SN = 0;
                for (int j = 1; j <= n; j++)
                {
                    double An = Math.Cos(2*j*x) / (4.0*j*j - 1);
                    SN += An;
                }

                //SE - сумма с точностью е
                double SE = 0;
                for(int c = 1; ; c++)
                {
                    double An_e =  Math.Cos(2*c*x) / (4.0*c*c - 1);
                    SE += An_e;

                    if(Math.Abs(An_e) < e && c>=n) break;
                }

                //точное знач
                double y = 0.5 - Math.PI / 4 * Math.Abs(Math.Sin(x));

                //вывод
                Console.WriteLine($"{i+1}. x = {x,6:F4}  SN = {SN,10:F6}  SE = {SE,10:F6} y = {y,10:F6}");

            }

        }
    }
}





