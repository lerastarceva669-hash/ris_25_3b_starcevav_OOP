using System;
using System.Collections;
using System.Collections.Generic;
using lab5.part1;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа\n");
            Console.WriteLine("Задание 1. ArrayList\n");

            Task1 task1 = new Task1();
            task1.FillCollection();
            task1.Menu();

            Console.WriteLine("\n\n");

            Console.WriteLine("Задание 2. Stack<T>\n");
            Task2 task2 = new Task2();
            task2.FillStack();
            task2.Menu();

            Console.WriteLine("\n\n");

            Console.WriteLine("ЗАДАНИЕ 3. Сравнение производительности коллекций\n");
            Task3 task3 = new Task3(1000);
            task3.SearchTime();


            Console.WriteLine("\nВСЕ ЗАДАНИЯ ВЫПОЛНЕНЫ");
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();


        }
    }
    
}