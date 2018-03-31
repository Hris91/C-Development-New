using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StrategyPattern
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var sortedSet1 = new SortedSet<Person>(new PersonsNameComperator());
            var sortedSet2 = new SortedSet<Person>(new PersonAgeComperator());

            AddPeople(sortedSet1, sortedSet2, n);
            
            PrintResult(sortedSet1, sortedSet2);
        }

        private static void PrintResult(SortedSet<Person> sortedSet1, SortedSet<Person> sortedSet2)
        {
            foreach (var person in sortedSet1)
            {
                Console.WriteLine(person);
            }

            foreach (var person in sortedSet2)
            {
                Console.WriteLine(person);
            }
        }

        private static void AddPeople(SortedSet<Person> sortedSet1, SortedSet<Person> sortedSet2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = args[0];
                var age = int.Parse(args[1]);

                var person = new Person(name, age);

                sortedSet1.Add(person);
                sortedSet2.Add(person);
            }
        }
    }
}
