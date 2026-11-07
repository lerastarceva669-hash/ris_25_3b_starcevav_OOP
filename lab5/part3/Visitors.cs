using System;

namespace lab5
{
    // Класс НЕ наследует Person, но реализует IInit
    public class Visitor : IInit
    {
        private string fullName = "";
        private string purpose = "";  // Цель визита
        private int passNumber = 0;   // Номер пропуска

        public string FullName
        {
            get {return fullName;}
            set {fullName = string.IsNullOrEmpty(value) ? "Неизвестно" : value;}
        }

        public string Purpose
        {
            get {return purpose;}
            set {purpose = string.IsNullOrEmpty(value) ? "Не указана" : value;}
        }

        public int PassNumber
        {
            get {return passNumber;}
            set {passNumber = value > 0 ? value : 1;}
        }

        public Visitor()
        {
            fullName = "Неизвестно";
            purpose = "Не указана";
            passNumber = 1;
        }

        public Visitor(string fullName, string purpose, int passNumber)
        {
            FullName = fullName;
            Purpose = purpose;
            PassNumber = passNumber;
        }

        // Реализация IInit.Init()
        public void Init()
        {
            Console.Write("Введите ФИО посетителя: ");
            FullName = Console.ReadLine() ?? "";
            Console.Write("Введите цель визита: ");
            Purpose = Console.ReadLine() ?? "";
            Console.Write("Введите номер пропуска: ");
            string passStr = Console.ReadLine() ?? "1";
            PassNumber = Convert.ToInt32(passStr);
        }

        // Реализация IInit.RandomInit()
        public void RandomInit(Random rnd)
        {
            string[] names = { "Гость Иванов", "Посетитель Петров", "Клиент Сидоров", "Курьер Смирнов" };
            string[] purposes = { "Доставка", "Проверка", "Собеседование", "Встреча" };
            FullName = names[rnd.Next(names.Length)];
            Purpose = purposes[rnd.Next(purposes.Length)];
            PassNumber = rnd.Next(1000, 9999);
        }

        public void Show()
        {
            Console.WriteLine($"Посетитель: {FullName}, Цель: {Purpose}, Пропуск №{PassNumber}");
        }
    }
}