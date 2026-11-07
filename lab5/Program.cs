using System;
using System.Collections;
using lab5.part1;
using lab5.part2;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Part1();
            Part2();
            Part3();
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void Part1()
        {
            Console.WriteLine("=== часть 1 ===");

            Random rnd = new Random();
            Person[] people = new Person[10];

            for (int i = 0; i < people.Length; i++)
            {
                int type = rnd.Next(3);
                switch (type)
                {
                    case 0:
                        people[i] = new Employee();
                        people[i].RandomInit(rnd);
                        break;
                    case 1:
                        people[i] = new Worker();
                        people[i].RandomInit(rnd);
                        break;
                    case 2:
                        people[i] = new Engineer();
                        people[i].RandomInit(rnd);
                        break;
                }
            }

            Console.WriteLine("=== просмотр массива через ВИРТУАЛЬНЫЙ метод Show() ===");
            foreach (Person p in people)
            {
                p.Show();
                Console.WriteLine();
            }

            Console.WriteLine("=== разница между виртуальными и невиртуальными методами ===");
            Person pers = new Engineer("Алексей", 40, 'м', 15, "Конструктор");

            Console.WriteLine("Создан объект Engineer, ссылка имеет тип Person:");
            Console.Write("Виртуальный Show() (позднее связывание): ");
            pers.Show(); // Вызовется версия Engineer
            Console.Write("Невиртуальный GetType(): ");
            Console.WriteLine(pers.GetType().Name); // Всегда реальный тип
            Console.WriteLine("\nВывод: виртуальный метод определяется по РЕАЛЬНОМУ типу объекта во время выполнения (полиморфизм).\n");

            Console.WriteLine("=== Метод Equals() ===");
            Person p1 = new Person("Иван", 25, 'м');
            Person p2 = new Person("Иван", 25, 'м');
            Person p3 = new Person("Петр", 30, 'м');
            Console.WriteLine($"p1.Equals(p2) → {p1.Equals(p2)}"); // true
            Console.WriteLine($"p1.Equals(p3) → {p1.Equals(p3)}"); // false

            Console.WriteLine("\n=== Конструктор копирования ===");
            Engineer original = new Engineer("Мария", 32, 'ж', 8, "Технолог");
            Engineer copy = new Engineer(original);
            Console.Write("Оригинал: ");
            original.Show();
            Console.Write("Копия: ");
            copy.Show();
            Console.WriteLine($"original.Equals(copy) → {original.Equals(copy)}");

            Console.WriteLine("\n");
        }

        static void Part2()
        {
            Console.WriteLine("=== часть 2 ===");

            Random rnd = new Random();
            Person[] people = new Person[15];

            for (int i = 0; i < people.Length; i++)
            {
                int type = rnd.Next(3);
                switch (type)
                {
                    case 0:
                        people[i] = new Employee();
                        people[i].RandomInit(rnd);
                        break;
                    case 1:
                        people[i] = new Worker();
                        people[i].RandomInit(rnd);
                        break;
                    case 2:
                        people[i] = new Engineer();
                        people[i].RandomInit(rnd);
                        break;
                }
            }

            Console.WriteLine("=== Массив ===");
            foreach (Person p in people)
            {
                p.Show();
                Console.WriteLine();
            }

            // запрос 1 имена инженеров со стажем не менее заданного
            Console.Write("Введите минимальный стаж для поиска инженеров (лет): ");
            int minExp = Convert.ToInt32(Console.ReadLine() ?? "10");
            QueryExecutor.FindEngineersByExperience(people, minExp);

            // запрос 2 имена рабочих заданного разряда
            Console.Write("\nВведите разряд рабочего для поиска (1-6): ");
            int rang = Convert.ToInt32(Console.ReadLine() ?? "3");
            QueryExecutor.FindWorkersByRank(people, rang);

            // запрос 3 количество служащих в массиве
            QueryExecutor.CountEmployees(people);

            // имена всех мужчин
            QueryExecutor.FindAllMales(people);

            Console.WriteLine("\n");
        }

        static void Part3()
        {
            Console.WriteLine("=== часть 3 ===");

            Random rnd = new Random();
            Console.WriteLine("=== Интерфейс IInit реализован в классах ===");

            Console.WriteLine("=== Сортировка по имени (IComparable) ===");
            Person[] people = new Person[8];
            people[0] = new Employee("Иван", 30, 'м', "101-А", 50000);
            people[1] = new Worker("Петр", 25, 'м', 4, "Завод №3");
            people[2] = new Engineer("Мария", 35, 'ж', 10, "Технолог");
            people[3] = new Employee("Анна", 28, 'ж', "205-Б", 45000);
            people[4] = new Worker("Сергей", 40, 'м', 5, "Завод №1");
            people[5] = new Engineer("Алексей", 45, 'м', 20, "Конструктор");
            people[6] = new Employee("Ольга", 32, 'ж', "301-В", 60000);
            people[7] = new Worker("Дмитрий", 22, 'м', 2, "Завод №7");
            Console.WriteLine("До сортировки:");
            foreach (Person p in people) Console.WriteLine($"  {p.Name} (возраст: {p.Age})");
            Array.Sort(people);
            Console.WriteLine("\nПосле сортировки по имени:");
            foreach (Person p in people) Console.WriteLine($"  {p.Name} (возраст: {p.Age})");


            Console.WriteLine("\n=== Сортировка по возрасту (IComparer) ===");
            Array.Sort(people, new SortByAge());
            Console.WriteLine("После сортировки по возрасту:");
            foreach (Person p in people) Console.WriteLine($"  {p.Name} (возраст: {p.Age})");


            Console.WriteLine("\n=== бинарный поиск ===");
            // сортировка
            Array.Sort(people);
            Console.WriteLine("Массив отсортирован по имени:");
            foreach (Person p in people) Console.WriteLine($"  [{Array.IndexOf(people, p)}] {p.Name}");
            Console.Write("\nВведите имя для бинарного поиска: ");
            string nameToFind = Console.ReadLine() ?? "";

            //новый класс
            Console.WriteLine("\n=== Класс Visitor ===");
            Visitor visitor = new Visitor("Гость Иванов", "Доставка", 1234);
            visitor.Show();
            Console.WriteLine("Visitor не наследует Person, но реализует IInit.\n");

            Console.WriteLine("=== Массив IInit[] ===");
            IInit[] initArray = new IInit[6];
            initArray[0] = new Employee();
            initArray[1] = new Worker();
            initArray[2] = new Engineer();
            initArray[3] = new Visitor();
            initArray[4] = new Employee();
            initArray[5] = new Visitor();

            Console.WriteLine("Заполнение через RandomInit():");
            foreach (IInit item in initArray)
            {
                item.RandomInit(rnd);
            }

            Console.WriteLine("\nВывод массива:");
            foreach (IInit item in initArray)
            {
                if (item is Person p)
                    p.Show();
                else if (item is Visitor v)
                    v.Show();
                Console.WriteLine();
            }

            //клон
            Console.WriteLine("=== клонирование ===");
            Engineer eng = new Engineer("Алексей", 40, 'м', 15, "Конструктор");
            Console.Write("Оригинал:          ");
            eng.Show();

            // Поверхностное копирование
            Engineer shallow = (Engineer)eng.ShallowCopy();
            Console.Write("ShallowCopy:       ");
            shallow.Show();

            // Глубокое клонирование
            Engineer deep = (Engineer)eng.Clone();
            Console.Write("Clone (глубокое):  ");
            deep.Show();

            // Демонстрация независимости копий
            Console.WriteLine("\nИзменяем копии:");
            shallow.Name = "Shallow-копия";
            deep.Name = "Deep-копия";

            Console.Write("Оригинал:          ");
            eng.Show();
            Console.Write("Shallow-копия:     ");
            shallow.Show();
            Console.Write("Deep-копия:        ");
            deep.Show();

        }
    }
}