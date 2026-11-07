using System;

namespace lab5.part1
{
    public class Employee : Person
    {
        private string office = ""; //кабинет
        private double salary = 20000; //зарплата

        public string Office
        {
            get{return office;}
            set
            {
                if(!string.IsNullOrEmpty(value)) office = value;
                else office = "Не указан";
            }
        }

        public double Salary
        {
            get{return salary;}
            set
            {
                if (value > 0) salary = value;
                else salary = 20000; //минимум
            }
        }

        //конструкторы
        
        //без параметров
        public Employee() : base()
        {
            office = "Не указан";
            salary = 20000;
        }

        //с параметрами
        public Employee(string name, int age, char gender, string of, double sal)
                    : base(name, age, gender)
        {
            Office = of;
            Salary = sal;
        }

        //копирования
        public Employee(Employee e) : base(e)
        {
            office = e.office;
            salary = e.salary;
        }

        //переопределение ввода
        public override void Init()
        {
            base.Init(); //метод родителя в начале
            Console.Write("Введите номер офиса: ");
            Console.Write("Введите зарплату: ");
            Salary = Convert.ToDouble(Console.ReadLine());
        }

        //переопределение случайной генерации
        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            Office = rnd.Next(100, 500).ToString() + "-A";
            Salary = rnd.Next(20000, 200000);
        }

        //переопределение вывода
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"  - Работник, Офис: {Office}, Зарплата: {Salary}");
        }

        //глубокое клонирование
        public override object Clone()
        {
            Employee clone = new Employee();
            clone.Name = this.Name;
            clone.Age = this.Age;
            clone.Gender = this.Gender;
            clone.office = this.office;
            clone.salary = this.salary;
            return clone;
        }

        //переопределение сравнения
        public override bool Equals(object? obj)
        {
            if (!base.Equals(obj)) return false;
            Employee e = (Employee)obj;
            return office == e.office && salary == e.salary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), office, salary);
        }
    }
    
}

