using System;

namespace lab4
{
    class PointArray
    {
        private Point[] arr; //одномерный массив элементов
        public int len => arr.Length;
        
        public PointArray() //конструктор без параметров
        {
            arr = new Point[0];
        }
        public PointArray(int size, int min = -10, int max = 10) //конструктор с параметрами + рандом элементы
        {
            Random rnd = new Random();
            arr = new Point[size];
            for(int i = 0; i < size; i++)
            {
                arr[i] = new Point(rnd.Next(min, max), rnd.Next(min, max));
            }
        }

        //конструкто для ввода с клавы
        public PointArray(int size, bool a)
        {
            arr = new Point[size];
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine($"Введите координаты для точки [{i}]:");
                double px = UI.ReadDouble("X = ");
                double py = UI.ReadDouble("Y = ");
                arr[i] = new Point(px, py);
            }
        }


        //индексатор с проверкой границ
        public Point this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length) 
                    throw new ArgumentException("Индекс выходит за пределы массива");
                return arr[index];
            }

            set
            {
                if (index < 0 || index >= arr.Length) 
                    throw new ArgumentException("Индекс выходит за пределы массива");
                arr[index] = value;
            }
        }

        //метод ждя просмотра элементов
        public void Print()
        {
            for(int i = 0; i<arr.Length; i++)
            {
                Console.Write($"[{i}] ");
                UI.PrintPoint(arr[i]);
            }
        }

    }
}