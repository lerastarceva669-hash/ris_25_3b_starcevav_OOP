using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using lab5.part1;
using static lab6.Task1;

namespace lab6
{
    public class Task2
    {
        private Stack<Person> stack;
        private Random rnd;

        public Task2()
        {
            stack = new Stack<Person>();
            rnd = new Random();
        }

        //заполнение стека
        public void FillStack()
        {
            Console.WriteLine("\nЗаполнение стека");

            stack.Push(new Employee("Иван", 30, 'м', "101-А", 50000));
            stack.Push(new Worker("Петр", 35, 'м', 4, "Завод №3"));
            stack.Push(new Engineer("Мария", 32, 'ж', 10, "Технолог"));
            stack.Push(new Employee("Анна", 28, 'ж', "205-Б", 45000));
            stack.Push(new Worker("Сергей", 40, 'м', 5, "Завод №1"));
            stack.Push(new Engineer("Алексей", 45, 'м', 20, "Конструктор"));
            stack.Push(new Employee("Ольга", 32, 'ж', "301-В", 60000));
            stack.Push(new Worker("Дмитрий", 22, 'м', 2, "Завод №7"));

            Console.WriteLine($"Добавлено {stack.Count} объектов в стек.");
            Console.WriteLine($"Верхний элемент: {stack.Peek().Name}");
        }

        //перебор элементов foreach (с верху вниз)
        public void DisplayAll()
        {
            Console.WriteLine("\nВсе элементы стека");

            int position = 1;
            foreach (Person person in stack)
            {
                Console.Write($"[{position}] ");
                person.Show();
                position++;
            }

            Console.WriteLine($"\nВсего элементов: {stack.Count}");
        }

        //добавление элемента (наверх)
        private void PushObject()
        {
            Console.WriteLine("\nДобавление элемента");
            Console.WriteLine("1.Employee (Служащий)");
            Console.WriteLine("2.Worker (Рабочий)");
            Console.WriteLine("3.Engineer (Инженер)");
            Console.Write("Выберите тип: ");

            string type = Console.ReadLine() ?? "";

            switch (type)
            {
                case "1":
                    Employee emp = new Employee();
                    emp.Init();
                    stack.Push(emp);
                    Console.WriteLine("Служащий добавлен на вершину стека");
                    break;
                case "2":
                    Worker wrk = new Worker();
                    wrk.Init();
                    stack.Push(wrk);
                    Console.WriteLine("Рабочий добавлен на вершину стека");
                    break;
                case "3":
                    Engineer eng = new Engineer();
                    eng.Init();
                    stack.Push(eng);
                    Console.WriteLine("Инженер добавлен на вершину стека");
                    break;
                default:
                    Console.WriteLine("Неверный тип");
                    break;
            }
        }

        //удаление элемента (сверху)
        private void PopObject()
        {
            Console.WriteLine("\nУдаление верхнего элемента");

            if (stack.Count == 0)
            {
                Console.WriteLine("Стек пуст");
                return;
            }

            Person top = stack.Peek();
            Console.Write("Верхний элемент: ");
            top.Show();

            Person removed = stack.Pop();
            Console.Write("Удален: ");
            removed.Show();
            Console.WriteLine($"Осталось элементов: {stack.Count}");
        }


        //просмотр верх элемента
        private void PeekObject()
        {
            Console.WriteLine("\nВерхний элемент стека");

            if (stack.Count == 0)
            {
                Console.WriteLine("Стек пуст");
                return;
            }

            Person top = stack.Peek();
            Console.Write("Верхний элемент: ");
            top.Show();
        }

        //клонирование
        private void CloneStack()
        {
            Console.WriteLine("\nКлонирование стека");

            Stack<Person> clone = new Stack<Person>(stack);

            Console.WriteLine($"Оригинал: {stack.Count} элементов");
            Console.WriteLine($"Клон: {clone.Count} элементов");

            // независимость коллекций
            Console.WriteLine("\nДобавляем объект в клон...");
            clone.Push(new Person("Тест", 99, 'м'));

            Console.WriteLine($"Оригинал после изменения клона: {stack.Count} элементов");
            Console.WriteLine($"Клон после добавления: {clone.Count} элементов");
        }

        //сортировка и поиск
        // стек не имеет методов сортировки и поиска
        // стек преобразуем в массив и сортируем ищем и показываем результат
        private void SortAndSearch()
        {
            Console.WriteLine("\nСортировка и поиск");
            Console.WriteLine("Конвертируем стек в массив для сортировки\n");

            //ToArray сохраняет порядок сверху вниз
            Person[] array = stack.ToArray();

            Console.WriteLine("Массив до сортировки:");
            foreach (Person p in array)
            {
                Console.WriteLine($" {p.Name} (возраст: {p.Age})");
            }

            // Сортировка по имени
            Console.WriteLine("\nСортировка по имени...");
            Array.Sort(array, new PersonNameComp());

            Console.WriteLine("\nПосле сортировки по имени:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"  [{i}] {array[i].Name} (возраст: {array[i].Age})");
            }

            // Бинарный поиск
            Console.Write("\nВведите имя для бинарного поиска: ");
            string name = Console.ReadLine() ?? "";

            Person searchKey = new Person(name, 0, 'м');
            int index = Array.BinarySearch(array, searchKey, new PersonNameComp());

            Console.WriteLine($"\nРезультат поиска '{name}':");
            if (index >= 0)
            {
                Console.WriteLine($"Найден на позиции {index}:");
                array[index].Show();
            }
            else
            {
                Console.WriteLine($"Имя '{name}' не найдено.");
            }
        }

        



        //запросы
        //показать всех инженеров
        private void FindEng()
        {
            Console.WriteLine("\nВсе инженеры в стеке");
            bool found = false;

            foreach (Person person in stack)
            {
                if (person is Engineer eng)
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

        //посчитать количество служащих
        private void CountEmpl()
        {
            int count = 0;

            foreach (Person person in stack)
            {
                if (person is Employee)
                {
                    count++;
                }
            }

            Console.WriteLine($"\nКоличество служащих в стеке: {count}");
        }

        //найти по имени
        private void FindName()
        {
            Console.Write("\nВведите имя для поиска: ");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine($"\nРезультаты поиска '{name}'");
            bool found = false;

            foreach (Person person in stack)
            {
                if (person.Name == name)
                {
                    person.Show();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Человек с именем '{name}' не найден.");
            }
        }




        //меню запросов
        private void Queries()
        {
            Console.WriteLine("\nЗАПРОСЫ");
            Console.WriteLine("1.Показать всех инженеров");
            Console.WriteLine("2.Посчитать количество служащих");
            Console.WriteLine("3.Найти человека по имени");
            Console.Write("Выберите запрос: ");

            string query = Console.ReadLine() ?? "";

            switch (query)
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
            while (true)
            {
                Console.WriteLine("\nМЕНЮ ПРОГРАММЫ");
                Console.WriteLine("1.Добавить объект");
                Console.WriteLine("2.Удалить верхний объект");
                Console.WriteLine("3.Посмотреть верхний объект");
                Console.WriteLine("4.Показать все");
                Console.WriteLine("5.Запросы");
                Console.WriteLine("6.Клонирование");
                Console.WriteLine("7.Сортировка и поиск");
                Console.WriteLine("0.Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        PushObject();
                        break;
                    case "2":
                        PopObject();
                        break;
                    case "3":
                        PeekObject();
                        break;
                    case "4":
                        DisplayAll();
                        break;
                    case "5":
                        Queries();
                        break;
                    case "6":
                        CloneStack();
                        break;
                    case "7":
                        SortAndSearch();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }



    }
}


