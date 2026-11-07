using System;

namespace lab5.part1
{
    public class Engineer : Person
    {
        private int experience = 0; //опыт
        private string specialty = ""; //специальность

        public int Experience
        {
            get {return experience;}
            set
            {
                if(value >= 0 && value <= 50) experience = value;
                else experience = 0; //по умолч
            }
        }

        public string Specialty
        {
            get{return specialty;}
            set
            {
                if(!string.IsNullOrEmpty(value)) specialty = value;
                else specialty = "Не указана";
            }
        }

        //конструкторы

        //без параметров
        public Engineer() : base()
        {
            experience = 0;
            specialty = "Не указана";
        }

        //с параметрами
        public Engineer(string name, int age, char gender, int e, string s) 
                : base(name, age, gender)
        {
            Experience = e;
            Specialty = s;
        }

        //копирования
        public Engineer(Engineer e) : base(e)
        {
            experience = e.experience;
            specialty = e.specialty;
        }

        //переопределение ввода
        public override void Init()
        {
            base.Init();
            Console.Write("Введите стаж (лет): ");
            Experience = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите специализацию: ");
            Specialty = Console.ReadLine() ?? "";
        }

        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Experience = rnd.Next(0, 40);
            string[] spec = {"Конструктор", "Технолог", "Проектировщик", "Программист"};
            Specialty = spec[rnd.Next(spec.Length)];
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($" - Инженер, Стаж: {Experience} лет, Специализация: {Specialty}");
        }

        //глубокое клонирование 
        public override object Clone()
        {
            Engineer clone = new Engineer();
            clone.Name = this.Name;
            clone.Age = this.Age;
            clone.Gender = this.Gender;
            clone.experience = this.experience;
            clone.specialty = this.specialty;
            return clone;
        }

        public override bool Equals(object? obj)
        {
            if (!base.Equals(obj)) return false;
            Engineer w = (Engineer)obj;
            return experience == w.experience && specialty == w.specialty;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), experience, specialty);
        }

    }
}


