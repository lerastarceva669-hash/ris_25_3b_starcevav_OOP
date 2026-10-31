using System;

namespace lab4
{
    class Point
    {
        private double x;
        private double y;

        //статический счетчик объектов
        public static int count_obj {get; private set;} = 0;

        //свойства
        public double X
        {
            get => x;
            set => x = value;
        }
        public double Y
        {
            get => y;
            set => y = value;
        }

        //конструктор без параметров
        public Point()
        {
            x = 0;
            y = 0;
            count_obj++;
        }
        
        //конструктор с парметрами
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
            count_obj++;
        }

        // расстояние между точками (метод класса)
        public double Distance(Point p)
        {
            double dx = this.x - p.x;
            double dy = this.y - p.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        //расстояние между точками (статическая функция)
        public static double get_Distance(Point p1, Point p2)
        {
            return p1.Distance(p2);
        }

        //расстояние до центра
        public double Distance_c()
        {
            return Math.Sqrt(x * x + y * y);
        }

        //перегрузка

        //унарный --
        public static Point operator --(Point p)
        {
            return new Point(p.x-1, p.y);
        }

        //унарный ++
        public static Point operator ++(Point p)
        {
            return new Point(p.x+1, p.y);
        }

        //приведение типа int явное
        public static explicit operator int(Point p)
        {
            return (int)p.x;
        }

        //приведение типа double неявное
        public static implicit operator double(Point p)
        {
            return p.y;
        }

        //бинарный + (расстояние между точками)
        public static double operator +(Point p1, Point p2)
        {
            return p1.Distance(p2);
        }

        //бинарный + (увеличить х справа)
        public static Point operator +(Point p, int v)
        {
            return new Point(p.x + v, p.y);
        }

        //бинарный + (увеличить х слева)
        public static Point operator +(int v, Point p)
        {
            return new Point(p.x + v, p.y);
        }
    }
}