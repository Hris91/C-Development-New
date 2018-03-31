using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main()
        {
            var people = new List<Person>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var args = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = args[0];
                var age = int.Parse(args[1]);
                var town = args[2];

                var person = new Person(name, age, town);
                people.Add(person);
            }

            var index = int.Parse(Console.ReadLine()) - 1;

            var personToCompare = people[index];
            

            try
            {
                GetResults(people, personToCompare);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }           
        }

        private static void GetResults(List<Person> people, Person personToCompare)
        {
            var numberOfEqualPeople = people.Count(p => p.CompareTo(personToCompare) == 0);

            if (numberOfEqualPeople == 1)
            {
                throw new ArgumentException("No matches");
            }

            var numberOfNotEqulaPeople = people.Count(p => p.CompareTo(personToCompare) != 0);
            var totalNumberOfPeople = people.Count;

            PrintResult(numberOfEqualPeople, numberOfNotEqulaPeople, totalNumberOfPeople);
        }

        private static void PrintResult(int numberOfEqualPeople, int numberOfNotEqulaPeople, int totalNumberOfPeople)
        {
            Console.WriteLine($"{numberOfEqualPeople} {numberOfNotEqulaPeople} {totalNumberOfPeople}");
        }
    }
}
