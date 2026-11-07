using System;

namespace lab5.part1
{
    public class Worker : Person
    {
        private int rang = 1; //разряд (1-6)
        private string plant = ""; //завод

        public int Rang
        {
            get {return rang;}
            set
            {
                if(value >= 1 && value <= 6) rang = value;
                else rang = 1; //по умолч
            }
        }

        public string Plant
        {
            get{return plant;}
            set
            {
                if(!string.IsNullOrEmpty(value)) plant = value;
                else plant = "Не указан";
            }
        }

        //конструкторы

        //без параметров
        public Worker() : base()
        {
            rang = 1;
            plant = "Не указан";
        }

        //с параметрами
        public Worker(string name, int age, char gender, int r, string p) 
                : base(name, age, gender)
        {
            Rang = rang;
            Plant = plant;
        }

        //копирования
        public Worker(Worker w) : base(w)
        {
            rang = w.rang;
            plant = w.plant;
        }

        //переопределение ввода
        public override void Init()
        {
            base.Init();
            Console.Write("Введите разряд (1-6): ");
            Rang = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите номер завода: ");
            Plant = Console.ReadLine() ?? "";
        }

        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Rang = rnd.Next(1, 7);
            Plant = "Завод №" + rnd.Next(1, 11);
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"  - Рабочий, Разряд: {Rang}, {Plant}");
        }

        //глубокое клонирование
        public override object Clone()
        {
            Worker clone = new Worker();
            clone.Name = this.Name;
            clone.Age = this.Age;
            clone.Gender = this.Gender;
            clone.rang = this.rang;
            clone.plant = this.plant;
            return clone;
        }


        public override bool Equals(object? obj)
        {
            if (!base.Equals(obj)) return false;
            Worker w = (Worker)obj;
            return rang == w.rang && plant == w.plant;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), rang, plant);
        }

    }
}


