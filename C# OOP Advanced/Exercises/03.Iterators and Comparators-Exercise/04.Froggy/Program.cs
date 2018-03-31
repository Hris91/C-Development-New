using System;
using System.Linq;

namespace _04.Froggy
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var lake = new Lake(input);
            
            Console.WriteLine(string.Join(", ", lake));          
        }
    }
}
