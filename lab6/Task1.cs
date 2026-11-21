using System;
using System.Collections;
using lab5.part1;

namespace lab6
{
    public class Task1
    {
        private ArrayList collection;
        private Random rnd;

        public Task1()
        {
            collection = new ArrayList();
            rnd = new Random();
        }

        //заполнение коллекции объяектами иерархии
        public void FillCollection()
        {
            Console.WriteLine("\nЗаполнение коллекции ArrayList");

            //доб объекты разных типов
            collection.Add(new Employee("Иван", 30, 'м', "101-А", 50000));
            collection.Add(new Worker("Петр", 35, 'м', 4, "Завод №3"));
            collection.Add(new Engineer("Мария", 32, 'ж', 10, "Технолог"));
            collection.Add(new Employee("Анна", 28, 'ж', "205-Б", 45000));
            collection.Add(new Worker("Сергей", 40, 'м', 5, "Завод №1"));
            collection.Add(new Engineer("Алексей", 45, 'м', 20, "Конструктор"));
            collection.Add(new Employee("Ольга", 32, 'ж', "301-В", 60000));
            collection.Add(new Worker("Дмитрий", 22, 'м', 2, "Завод №7"));

            Console.WriteLine($"Добавлено {collection.Count} объектов в коллекцию.");
        }

        //перебор элементов через foreach
        public void DisplayAll()
        {
            Console.WriteLine("\nВсе элементы коллекции (foreach)");

            foreach (object obj in collection)
            {
                //приведение к персон и вызов
                if(obj is Person person) person.Show();
            }

            Console.WriteLine($"\nВсего элементов: {collection.Count}");
        }


        //добавление
        private void AddObject()
        {
            Console.WriteLine("\nДобавление объекта");
            Console.WriteLine("1. Employee (Служащий)");
            Console.WriteLine("2. Worker (Рабочий)");
            Console.WriteLine("3. Engineer (Инженер)");
            Console.Write("Выберите тип: ");

            string type = Console.ReadLine() ?? "";

            switch(type)
            {
                case "1":
                    Employee emp = new Employee();
                    emp.Init();
                    collection.Add(emp);
                    Console.WriteLine("Служащий добавлен.");
                    break;
                case "2":
                    Worker wrk = new Worker();
                    wrk.Init();
                    collection.Add(wrk);
                    Console.WriteLine("Рабочий добавлен.");
                    break;
                case "3":
                    Engineer eng = new Engineer();
                    eng.Init();
                    collection.Add(eng);
                    Console.WriteLine("Инженер добавлен.");
                    break;
                default:
                    Console.WriteLine("Неверный тип.");
                    break;
            }
        }


        //удаление
        private void RemoveObject()
        {
            Console.WriteLine("\n Удаление элемента");
            Console.Write($"Введите индекс для удаления от 1 до {collection.Count - 1}: ");

            if(int.TryParse(Console.ReadLine(), out int index))
            {
                if(index >= 0 && index < collection.Count)
                {
                    collection.RemoveAt(index);
                    Console.WriteLine($"Объект с индексом {index} удален");
                }
                else
                {
                    Console.WriteLine("Индекс вне диапазона");
                }
            }
            else Console.WriteLine("Неверный ввод.");
        }


        //клонирование
        private void CloneCol()
        {
            Console.WriteLine("\nКлонирование коллекции");

            ArrayList clone = (ArrayList)collection.Clone();
            Console.WriteLine($"Оригинал: {collection.Count} элементов");
            Console.WriteLine($"Клон: {clone.Count} элементов");

            Console.WriteLine("\nДобавляем к коду объект");
            clone.Add(new Person("Клон", 100, 'м'));

            Console.WriteLine($"Оригинал после добавления клона: {collection.Count} элементов");
            Console.WriteLine($"Клон после добавления: {collection.Count} элементов");
        }


        //сортировка и поиск
        private void SortSearch()
        {
            Console.WriteLine("\nСортировка и поиск");

            //сортировка
            Console.WriteLine("Сортировка по имени");
            collection.Sort(new PersonNameComp());

            Console.WriteLine("\nПосле сортировки: ");
            DisplayAll();

            //поиск
            Console.Write("Введите имя для бинарного поиска: ");
            string name = Console.ReadLine() ?? "";

            Person key = new Person(name, 0, 'м');
            int index = collection.BinarySearch(key, new PersonNameComp());

            if(index >= 0 && index < collection.Count)
            {
                Person? found = collection[index] as Person;
                if(found != null)
                {
                    Console.WriteLine($"Найден на позиции {index}");
                    found.Show();
                }
                else
                {
                    Console.WriteLine("Элемент найден, но не является Person");
                }
            }
            else
            {
                Console.WriteLine($"Имя '{name}' не найдено");
            }
        }


        //компарер для сортировки
        public class PersonNameComp : IComparer
        {
            public int Compare(object? x, object? y)
            {
                if(x == null && y == null) return 0;
                if(x == null) return -1;
                if(y == null) return 1;

                Person? p1 = x as Person;
                Person? p2 = y as Person;

                if(p1 != null && p2 != null)
                {
                    return string.Compare(p1.Name, p2.Name, StringComparison.Ordinal);
                }

                return 0;
            } 
        }

        

        //запросы
        private void FindEng()
        {
            Console.WriteLine("Все инженеры");
            bool found = false;

            foreach(object obj in collection)
            {
                if(obj is Engineer eng)
                {
                    eng.Show();
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Инженеры не найдены");
            }
        }

        private void CountEmpl()
        {
            int count = 0;

            foreach(object obj in collection)
            {
                if(obj is Employee)
                {
                    count++;
                }
            }
            Console.WriteLine($"\nКоличество служащих {count}");
        }

        private void FindName()
        {
            Console.Write("\nВведите имя для поиска: ");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine($"\nРезультаты поиска '{name}': ");
            
            bool found = false;

            foreach(object obj in collection)
            {
                if(obj is Person person && person.Name == name)
                {
                    person.Show();
                    found = true;
                }
            }
            if(!found)
            {
                Console.WriteLine("Имя не найдено");
            }
        }


        //меню для запросов
        private void Queries()
        {
            Console.WriteLine("\nЗапросы");
            Console.WriteLine("1. Показать всех инженеров");
            Console.WriteLine("2. Посчитать количество служащих");
            Console.WriteLine("3. Найти человека по имни");
            Console.Write("Выберите запрос: ");

            string query = Console.ReadLine() ?? "";

            switch(query)
            {
                case "1":
                    FindEng();
                    break;
                case "2":
                    CountEmpl();
                    break;
                case "3":
                    FindName();
                    break;
                default:
                    Console.WriteLine("Неверный запрос");
                    break;
            }
        }


        //меню программы
        public void Menu()
        {
            while(true)
            {
                Console.WriteLine("\n МЕНЮ РАБОТЫ С КОЛЛЕКЦИЕЙ ");
                Console.WriteLine("1. Добавить объект");
                Console.WriteLine("2. Удалить объект");
                Console.WriteLine("3. Показать все");
                Console.WriteLine("4. Запросы");
                Console.WriteLine("5. Клонирование");
                Console.WriteLine("6. Сортировка и поиск");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine() ?? "";

                switch(choice)
                {
                    case "1":
                        AddObject();
                        break;
                    case "2":
                        RemoveObject();
                        break;
                    case "3":
                        DisplayAll();
                        break;
                    case "4":
                        Queries();
                        break;
                    case "5":
                        CloneCol();
                        break;
                    case "6":
                        SortSearch();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
    }
}