using System;
using lab5.part1;

namespace lab5
{
    public class QueryExecutorPart3
    {
        // Бинарный поиск
        public static int BinarySearchByName(Person[] sortedArray, string nameToFind)
        {
            Person searchKey = new Person(nameToFind, 0, 'м');
            
            int index = Array.BinarySearch(sortedArray, searchKey);
            return index;
        }
    }
}