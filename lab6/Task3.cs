using System;
using System.Collections.Generic;
using System.Diagnostics;
using lab5.part1;

namespace lab6
{
    public class Task3
    {
        //4 коллекции
        public LinkedList<Employee> Collection1 { get; }
        public LinkedList<string> Collection1String { get; }
        public SortedDictionary<Person, Employee> Collection2 { get; }
        public SortedDictionary<string, Employee> Collection2String { get; }

        private Employee[] genEmpl = [];

        private void GenElem(int count)
        {
            genEmpl = new Employee[count];
            Random rnd = new Random(42);

            string[] names = { "Иван", "Петр", "Мария", "Анна", "Сергей", "Ольга", "Алексей", "Дмитрий" };
            string[] offices = { "101-А", "205-Б", "301-В", "410-Г", "512-Д" };

            for (int i = 0; i < count; i++)
            {
                string name = names[rnd.Next(names.Length)] + " " + (i + 1);
                int age = rnd.Next(20, 60);
                char gender = rnd.Next(2) == 0 ? 'м' : 'ж';
                string office = offices[rnd.Next(offices.Length)];
                double salary = rnd.Next(30000, 150000);

                genEmpl[i] = new Employee(name, age, gender, office, salary);
            }
        }

         private void FillCollections()
        {
            foreach (Employee emp in genEmpl)
            {
                // Коллекция_1<Employee>
                Collection1.AddLast(emp);

                // Коллекция_1<string>
                Collection1String.AddLast(emp.ToString()!);

                // Коллекция_2<Person, Employee>
                Collection2[emp.BasePerson] = emp;

                // Коллекция_2<string, Employee>
                Collection2String[emp.Name] = emp;
            }
        }


        public Task3(int count = 1000)
        {
            // Инициализация коллекций
            Collection1 = new LinkedList<Employee>();
            Collection1String = new LinkedList<string>();
            Collection2 = new SortedDictionary<Person, Employee>();
            Collection2String = new SortedDictionary<string, Employee>();

            // Генерация элементов
            GenElem(count);

            // Заполнение коллекций
            FillCollections();
        }

        //метод добавления
        public void AddEmployee(Employee emp)
        {
            Collection1.AddLast(emp);
            Collection1String.AddLast(emp.ToString()!);
            Collection2[emp.BasePerson] = emp;
            Collection2String[emp.Name] = emp;
        }

        //метод удаления
        public void RemoveEmployee(Employee emp)
        {
            Collection1.Remove(emp);
            Collection1String.Remove(emp.ToString()!);
            Collection2.Remove(emp.BasePerson);
            Collection2String.Remove(emp.Name);
        }
  
        //измерение времени поиска
        public void SearchTime()
        {
            if (genEmpl.Length == 0)
            {
                Console.WriteLine("Коллекции пусты");
                return;
            }

            // 4 элемента для поиска (создаем КОПИИ, а не ссылки!)
            Employee first = new Employee(
                genEmpl[0].Name,
                genEmpl[0].Age,
                genEmpl[0].Gender,
                genEmpl[0].Office,
                genEmpl[0].Salary);

            Employee middle = new Employee(
                genEmpl[genEmpl.Length / 2].Name,
                genEmpl[genEmpl.Length / 2].Age,
                genEmpl[genEmpl.Length / 2].Gender,
                genEmpl[genEmpl.Length / 2].Office,
                genEmpl[genEmpl.Length / 2].Salary);

            Employee last = new Employee(
                genEmpl[genEmpl.Length - 1].Name,
                genEmpl[genEmpl.Length - 1].Age,
                genEmpl[genEmpl.Length - 1].Gender,
                genEmpl[genEmpl.Length - 1].Office,
                genEmpl[genEmpl.Length - 1].Salary);

            Employee notFound = new Employee("Несуществующий", 99, 'м', "000", 0);

            Console.WriteLine("ИЗМЕРЕНИЕ ВРЕМЕНИ ПОИСКА\n");
            Console.WriteLine($"Количество элементов в коллекциях: {genEmpl.Length}\n");

            Contains("List<Employee>.Contains()", Collection1, first, middle, last, notFound);

            ContainsString("List<string>.Contains()", Collection1String, first, middle, last, notFound);

            ContainsKey("Dictionary<Person,Employee>.ContainsKey()", 
                Collection2, first.BasePerson, middle.BasePerson, last.BasePerson, notFound.BasePerson);

            ContainsKeyString("Dictionary<string,Employee>.ContainsKey()", 
                Collection2String, first.Name, middle.Name, last.Name, notFound.Name);

            ContainsValue("Dictionary<Person,Employee>.ContainsValue()", 
                Collection2, first, middle, last, notFound);
        }

        private void Contains(string name, LinkedList<Employee> collection,
            Employee first, Employee middle, Employee last, Employee notFound)
        {
            Console.WriteLine($"--- {name} ---");
            Stopwatch sw = new Stopwatch();

            sw.Restart();
            bool r1 = collection.Contains(first);
            sw.Stop();
            Console.WriteLine($"Первый элемент: {sw.ElapsedTicks} тиков (найдено: {r1})");

            sw.Restart();
            bool r2 = collection.Contains(middle);
            sw.Stop();
            Console.WriteLine($"Центральный элемент: {sw.ElapsedTicks} тиков (найдено: {r2})");

            sw.Restart();
            bool r3 = collection.Contains(last);
            sw.Stop();
            Console.WriteLine($"Последний элемент: {sw.ElapsedTicks} тиков (найдено: {r3})");

            sw.Restart();
            bool r4 = collection.Contains(notFound);
            sw.Stop();
            Console.WriteLine($"Отсутствующий элемент: {sw.ElapsedTicks} тиков (найдено: {r4})");

            Console.WriteLine();
        }

        private void ContainsString(string name, LinkedList<string> collection,
            Employee first, Employee middle, Employee last, Employee notFound)
        {
            Console.WriteLine($"--- {name} ---");
            Stopwatch sw = new Stopwatch();

            sw.Restart();
            bool r1 = collection.Contains(first.ToString()!);
            sw.Stop();
            Console.WriteLine($"Первый элемент: {sw.ElapsedTicks} тиков (найдено: {r1})");

            sw.Restart();
            bool r2 = collection.Contains(middle.ToString()!);
            sw.Stop();
            Console.WriteLine($"Центральный элемент: {sw.ElapsedTicks} тиков (найдено: {r2})");

            sw.Restart();
            bool r3 = collection.Contains(last.ToString()!);
            sw.Stop();
            Console.WriteLine($"Последний элемент: {sw.ElapsedTicks} тиков (найдено: {r3})");

            sw.Restart();
            bool r4 = collection.Contains(notFound.ToString()!);
            sw.Stop();
            Console.WriteLine($"Отсутствующий элемент: {sw.ElapsedTicks} тиков (найдено: {r4})");

            Console.WriteLine();
        }

        private void ContainsKey(string name, SortedDictionary<Person, Employee> collection,
            Person firstKey, Person middleKey, Person lastKey, Person notFoundKey)
        {
            Console.WriteLine($"--- {name} ---");
            Stopwatch sw = new Stopwatch();

            sw.Restart();
            bool r1 = collection.ContainsKey(firstKey);
            sw.Stop();
            Console.WriteLine($"Первый элемент: {sw.ElapsedTicks} тиков (найдено: {r1})");

            sw.Restart();
            bool r2 = collection.ContainsKey(middleKey);
            sw.Stop();
            Console.WriteLine($"Центральный элемент: {sw.ElapsedTicks} тиков (найдено: {r2})");

            sw.Restart();
            bool r3 = collection.ContainsKey(lastKey);
            sw.Stop();
            Console.WriteLine($"Последний элемент: {sw.ElapsedTicks} тиков (найдено: {r3})");

            sw.Restart();
            bool r4 = collection.ContainsKey(notFoundKey);
            sw.Stop();
            Console.WriteLine($"Отсутствующий элемент: {sw.ElapsedTicks} тиков (найдено: {r4})");

            Console.WriteLine();
        }

        private void ContainsKeyString(string name, SortedDictionary<string, Employee> collection,
            string firstName, string middleName, string lastName, string notFoundName)
        {
            Console.WriteLine($"--- {name} ---");
            Stopwatch sw = new Stopwatch();

            sw.Restart();
            bool r1 = collection.ContainsKey(firstName);
            sw.Stop();
            Console.WriteLine($"Первый элемент: {sw.ElapsedTicks} тиков (найдено: {r1})");

            sw.Restart();
            bool r2 = collection.ContainsKey(middleName);
            sw.Stop();
            Console.WriteLine($"Центральный элемент: {sw.ElapsedTicks} тиков (найдено: {r2})");

            sw.Restart();
            bool r3 = collection.ContainsKey(lastName);
            sw.Stop();
            Console.WriteLine($"Последний элемент: {sw.ElapsedTicks} тиков (найдено: {r3})");

            sw.Restart();
            bool r4 = collection.ContainsKey(notFoundName);
            sw.Stop();
            Console.WriteLine($"Отсутствующий элемент: {sw.ElapsedTicks} тиков (найдено: {r4})");

            Console.WriteLine();
        }

        private void ContainsValue(string name, SortedDictionary<Person, Employee> collection,
            Employee first, Employee middle, Employee last, Employee notFound)
        {
            Console.WriteLine($"--- {name} ---");
            Stopwatch sw = new Stopwatch();

            sw.Restart();
            bool r1 = collection.ContainsValue(first);
            sw.Stop();
            Console.WriteLine($"Первый элемент: {sw.ElapsedTicks} тиков (найдено: {r1})");

            sw.Restart();
            bool r2 = collection.ContainsValue(middle);
            sw.Stop();
            Console.WriteLine($"Центральный элемент: {sw.ElapsedTicks} тиков (найдено: {r2})");

            sw.Restart();
            bool r3 = collection.ContainsValue(last);
            sw.Stop();
            Console.WriteLine($"Последний элемент: {sw.ElapsedTicks} тиков (найдено: {r3})");

            sw.Restart();
            bool r4 = collection.ContainsValue(notFound);
            sw.Stop();
            Console.WriteLine($"Отсутствующий элемент: {sw.ElapsedTicks} тиков (найдено: {r4})");

            Console.WriteLine();
        }



    }
}
