using System;
using lab5.part1;

namespace lab5.part2
{
    public class QueryExecutor
    {
        // запрос: Имена инженеров со стажем не менее заданного
        public static void FindEngineersByExperience(Person[] people,
                                                    int minExperience)
        {
            Console.WriteLine($"\n инженеры со стажем >= {minExperience} лет ");
            bool found = false;

            foreach (Person person in people)
            {
                //является ли инженером
                if (person is Engineer eng)
                {
                    //стаж
                    if (eng.Experience >= minExperience)
                    {
                        Console.WriteLine($"  → {eng.Name}, Стаж: {eng.Experience} лет, Специализация: {eng.Specialty}");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("  Инженеры с таким стажем не найдены.");
            }
        }

        // запрос имена рабочих заданного разряда
        public static void FindWorkersByRank(Person[] people, int rank)
        {
            Console.WriteLine($"\nрабочие {rank}-го разряда");
            bool found = false;

            foreach (Person person in people)
            {
                //as для приведения типа
                Worker? worker = person as Worker;
                
                if (worker != null && worker.Rang == rank)
                {
                    Console.WriteLine($"  → {worker.Name}, Завод: {worker.Plant}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"  Рабочие {rank}-го разряда не найдены.");
            }
        }

        // запрос количество служащих в массиве
        public static int CountEmployees(Person[] people)
        {
            Console.WriteLine("\nподсчет служащих");
            int count = 0;

            foreach (Person person in people)
            {
                if (person is Employee)
                {
                    count++;
                }
            }

            Console.WriteLine($"  Всего служащих в массиве: {count}");
            return count;
        }

        //доп запрос имена всех мужчин
        public static void FindAllMales(Person[] people)
        {
            Console.WriteLine("\nвсе мужчины");
            int count = 0;

            foreach (Person person in people)
            {
                if (person.Gender == 'м')
                {
                    Console.WriteLine($"  → {person.Name} ({person.GetType().Name})");
                    count++;
                }
            }

            Console.WriteLine($"  Всего мужчин: {count}");
        }
    }
}