using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.EqualityLogic
{
    public class Program
    {
        public static void Main()
        {
            var person1 = new Person("Gosho", 15);
            var person2 = new Person("Gosho", 15);

            Console.WriteLine(person1 == person2);
            Console.WriteLine(person1.Equals(person2));

            Console.WriteLine(person1.GetHashCode());
            Console.WriteLine(person2.GetHashCode());

            //var n = int.Parse(Console.ReadLine());

            //var peopleSet1 = new HashSet<Person>();
            //var peopleSet2 = new SortedSet<Person>();

            //for (int i = 0; i < n; i++)
            //{
            //    var args = Console.ReadLine()
            //        .Split(" ")
            //        .ToArray();

            //    var name = args[0];
            //    var age = int.Parse(args[1]);

            //    var person = new Person(name, age);

            //    peopleSet1.Add(person);
            //    peopleSet2.Add(person);
            //}

            //Console.WriteLine(peopleSet1.Count);
            //Console.WriteLine(peopleSet2.Count);

        }
    }
}
