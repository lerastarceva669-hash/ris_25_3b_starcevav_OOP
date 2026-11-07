using System;

namespace lab5.part1
{
    public class Person : IInit, IComparable, ICloneable
    {
        //закрытые поля
        private string name = "";
        private int age = 18;
        private char gender = 'м';

        //свойства
        public string Name
        {
            get {return name;}
            set
            {
                if (!string.IsNullOrEmpty(value)) name = value;
                else name = "Неизвестно";
            }
        }

        public int Age
        {
            get {return age;}
            set
            {
                if(value > 0 && value < 100) age = value;
                else age = 19; //по умолчанию 19 лет
            }
        }

        public char Gender
        {
            get {return gender;}
            set
            {
                if(value == 'м' || value == 'ж') gender = value;
                else gender = 'м'; //по умолчанию м
            }
        }

        //конструкторы
        
        //без параметров
        public Person()
        {
            name = "Неизвестно";
            age = 18;
            gender = 'м';
        }

        //с параметрами
        public Person(string n, int a, char g)
        {
            Name = n;
            Age = a;
            Gender = g;
        }

        //копирования
        public Person(Person p)
        {
            name = p.name;
            age = p.age;
            gender = p.gender;
        }

        //методы

        //ввод с клавы
        public virtual void Init()
        {
            Console.Write("Введите имя: ");
            Name = Console.ReadLine() ?? "";

            Console.Write("Введите возраст: ");
            Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите пол(м/ж): ");
            string genderStr = Console.ReadLine() ?? "м";
            Gender = Convert.ToChar(genderStr);
        }

        //случайные данные
        public virtual void RandomInit(Random rnd)
        {
            string[] malenames = {"Иван", "Григорий", "Петр", "Кирилл"};
            string[] femalenames = {"Мария", "Валерия", "Владислава", "Карина"};
            
            Gender = rnd.Next(2) == 0 ? 'м' : 'ж';
            
            if(Gender == 'м') Name = malenames[rnd.Next(malenames.Length)];
            else Name = femalenames[rnd.Next(femalenames.Length)];
          
            Age = rnd.Next(18, 70);
            
        }

        //вывод на экран виртуальный метод
        public virtual void Show()
        {
            Console.WriteLine($"Персона: {Name}, Возраст: {Age}, Пол: {Gender}");
        }

        //сортировка по имени (реализация IComparable)
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            if (obj is Person other)
            {
                // Сравниваем по имени
                return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
            }
            throw new ArgumentException("Объект не является Person");
        }


        //поверхностное клонирование (реализация ICloneable)
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        //глубокое клогнирование
        public virtual object Clone()
        {
            // Создаём новый объект и копируем все поля
            Person clone = new Person();
            clone.name = this.name;
            clone.age = this.age;
            clone.gender = this.gender;
            return clone;
        }

        //сравнение объектов
        public override bool Equals(object? obj)
        {
            if(obj == null || GetType() != obj.GetType()) return false;

            Person p = (Person)obj;
            return name == p.name && age == p.age && gender == p.gender;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, age, gender);
        }
    }
}


