using System;
using System.Collections;
using lab5.part1;

namespace lab5
{
    //реализует IComparer
    public class SortByAge : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            Person p1 = (Person)x;
            Person p2 = (Person)y;

            // Сравниваем по возрасту
            return p1.Age.CompareTo(p2.Age);
        }
    }
}