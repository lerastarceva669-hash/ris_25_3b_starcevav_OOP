using System;
using System.Collections.Generic;


namespace Laba_3
{
    class Programm
    {
        
        static Random rnd= new Random();
        static void Main()
        {
            while(true)
            {
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("1. Двумерный массив");
                Console.WriteLine("2. Рваный массив");
                Console.WriteLine("3. Обработка строки символов");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                int choice = ReadInt();

                switch(choice)
                {
                    case 1: mass2D(); break;
                    case 2: massJag(); break;
                    case 3: pro_string(); break;
                    case 0: return;
                    default: Console.WriteLine("Нет такого пункта.");
                    break;
                }
            }

        }

        //проверка правильности ввода
        static int ReadInt()
        {
            int a;
            while(!int.TryParse(Console.ReadLine(), out a))
                Console.Write("Не число, повторите: ");
            return a;
        }

        //вопрос: вручную или рандом
        static int askMode()
        {
            Console.WriteLine("\nКак заполнить массив: ");
            Console.WriteLine("1. Вручную");
            Console.WriteLine("2. Случайные числа");
            Console.Write("Выбор: ");
            return ReadInt();
        }
        


        //работа с обычным массивом
        static void mass2D()
        {
            int rows, columns;

            Console.WriteLine("Введите количество строк: ");
            rows = ReadInt();

            Console.WriteLine("Введите количество столбцов: ");
            columns = ReadInt();

            if(rows <= 0 || columns <= 0)
            {
                Console.WriteLine("Размеры должны быть больше нуля.");
                return;
            }

            int[,] arr = new int[rows, columns];

            if(askMode() == 1) fill_m(arr);
            else fill_rand(arr);
            //исходный массив
            Print(arr);


            //18 вариант
            int[,] arr_no_zero = Rem_0_Col(arr);
            Console.WriteLine("\nЗадание для варианта 18: удалить столбцы, в которых есть 0.");
            Console.WriteLine($"После удаления столбцов с нулями (осталось {arr_no_zero.GetLength(1)} столбцов): ");
            Print(arr_no_zero);
        }

        //ЗАДАНИЕ ИЗ ВАРИАНТА
        //удаление столбцов в которых содержится хотя бы 1 ноль
        static int[,] Rem_0_Col(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);

            bool[] k = new bool[columns];
            int newColumns = 0;

            for(int j = 0; j < columns; j++)
            {
                bool flag_zero = false;
                for(int i = 0; i < rows; i++)
                {
                    if(arr[i, j] == 0)
                    {
                        flag_zero = true;
                        break;
                    }
                }

                k[j] = !flag_zero;
                if(k[j]) newColumns++;
            }

            int[,] result = new int[rows, newColumns];

            int n_j = 0;
            for(int j = 0; j < columns; j++)
            {
                if(!k[j]) continue;

                for(int i = 0; i < rows; i++)
                {
                    result[i, n_j] = arr[i, j];
                }

                n_j++;
            }

            return result;
        }




        //работа с рванным массивом
        static void massJag()
        {
            int rows;

            Console.WriteLine("Введите количество строк: ");
            rows = ReadInt();

            if(rows <= 0)
            {
                Console.WriteLine("Размеры должны быть больше нуля.");
                return;
            }

            int [][] arr = new int[rows][];

            if(askMode() == 1) fill_m(arr);

            else fill_rand(arr);

            Print(arr);

            //18 вариант
            Console.WriteLine("\nЗадание для варианта 18: добавить строку на позицию k.");
            Console.WriteLine($"Введите позицию, на которую хотите вставить новую строку: ");
            int k = ReadInt();
            arr = insertRow(arr, k);
            Console.WriteLine("Массив после вставки.");
            Print(arr);
        }

        //ЗАДАНИЕ ИЗ ВАРИАНТА 
        //ВСТАВИТЬ НОВУЮ СТРОКУ НА ПОЗИЦИЮ k
        static int[][] insertRow(int[][] arr, int k)
        {
            int rows = arr.Length;
            //проверка
            if(k < 0 || k > rows)
            {
                Console.WriteLine("Неверная строка.");
                return arr;
            }

            //новая строка
            Console.WriteLine($"Длина новой строки на позиции {k}: ");
            int len = ReadInt();
            int[] newRow = new int[len];
            Console.WriteLine($"Введите {len} элементов: ");
            for(int j = 0; j < len; j++)
            {
                Console.WriteLine($" [{k} {j}]: ");
                newRow[j] = ReadInt();
            }


            int[][] result = new int[rows+1][];

            for(int i = 0; i < k; i++)
            {
                result[i] = arr[i];
            }

            result[k] = newRow;

            for(int i = k; i < rows; i++)
            {
                result[i+1] = arr[i];
            }

            return result;
        }

        //ЗАДАНИЕ ИЗ ВАРИАНТА 
        //РАБОТА СО СТРОКОЙ
        //ПЕРЕВЕРНУТЬ ПРЕДЛОЖЕНИЕ КОТОРОЕ ЗАКАНЧИВАЕТСЯ НА !
        static void pro_string()
        {
            Console.WriteLine("\nВведите строку:");
            string text = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Пустая строка.");
                return;
            }

            string result = pro_text(text);

            Console.WriteLine("Результат.");
            Console.WriteLine(result);
        }

        //весь текст
        static string pro_text(string t)
        {
            List<string> p = split_p(t);
            
            for (int i = 0; i < p.Count; i++)
            {
                if(p[i].EndsWith("!"))
                {
                    p[i] = revers_p(p[i]);
                }
            }

            return string.Join(" ", p);
        }

        //текст разбить на предложения которые заканчиваюься на знак препинания
        static List<string> split_p(string t)
        {
            var result = new List<string>();
            int start = 0;

            for(int i = 0; i < t.Length; i++)
            {
                if(t[i] == '.' || t[i] == '!' || t[i] == '?')
                {
                    string s = t.Substring(start, i - start+1).Trim();
                    if(s.Length > 0)
                    {
                        result.Add(s);
                    }
                    start = i+1;
                }
            }

            //предложение без знака
            if(start < t.Length)
            {
                string tail = t.Substring(start).Trim();
                if(tail.Length > 0) result.Add(tail);
            }

            return result;
        }

        //переворот предложения без последнего конечного знака
        static string revers_p(string p)
        {
            //конечный знак
            char end_char = p[p.Length-1];
            string body = p.Substring(0, p.Length-1).Trim();

            //разбиваем по пробелам
            string[] words = body.Split(new[] {' ', '\t'},
            StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0) return p;

            //переворот
            Array.Reverse(words);

            //регистр
            words[0] = Cap(words[0]);
            words[words.Length-1] = low_first(words[words.Length-1]);

            return string.Join(" ", words)+end_char;
        }

        //первая буква заглавная
        static string Cap(string word)
        {
            if(string.IsNullOrEmpty(word)) return word;
            return char.ToUpper(word[0]) + word.Substring(1);
        }

        //последнее слово с маленькой буквы
        static string low_first(string word)
        {
            if(string.IsNullOrEmpty(word)) return word;
            return char.ToLower(word[0]) + word.Substring(1);
        }
            

        



        //ручное заполнение для двумерного массива
        static void fill_m(int[,] arr)
        {
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"Элемент [{i} {j}]: ");
                    arr[i, j] = ReadInt();
                }
                Console.WriteLine();
            }
        }

        //рандомное заполнение для двумерного массива
        static void fill_rand(int[,] arr, int min = 0, int max = 10)
        {
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(min, max);
                }
                Console.WriteLine();
            }
        }


        //ручное заполнение для рваного массива (перегрузка)
        static void fill_m(int[][] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Длина строки {i+1}: ");
                int len = ReadInt();
                arr[i] = new int[len];

                for(int j = 0; j < len; j++)
                {
                    Console.Write($"Элемент [{i} {j}]: ");
                    arr[i][j] = ReadInt();
                }
            }
        }

        //рандомное заполнение для рваного массива (перегрузка)
        static void fill_rand(int[][] arr, int min = 0, int max = 10)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Длина строки {i+1}: ");
                int len = ReadInt();
                arr[i] = new int[len];

                for(int j = 0; j < len; j++)
                {
                    arr[i][j] = rnd.Next(min, max);
                }
            }
        }


        //печать для двумерного массива
        static void Print(int[,] arr)
        {
            Console.WriteLine("\nМАССИВ: ");
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        //печать для рваного массива (перегрузка)
        static void Print(int[][] arr)
        {
            Console.WriteLine("\nРВАННЫЙ МАССИВ: ");
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}