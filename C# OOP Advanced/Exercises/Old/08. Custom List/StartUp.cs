using System;
using System.Linq;

namespace _08.Custom_List
{
    public class StartUp
    {
        public static void Main()
        {
            CustumList<string> custum = new CustumList<string>();

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine
                    .Split(' ')
                    .ToList();

                var command = tokens[0];

                tokens.RemoveAt(0);

                switch (command)
                {
                    case "Add":
                        custum.Add(tokens[0]);
                        break;

                    case "Remove":
                        custum.Remove(int.Parse(tokens[0]));
                        break;

                    case "Contains":
                        Console.WriteLine(custum.Contains(tokens[0]));
                        break;

                    case "Swap":
                        custum.Swap(int.Parse(tokens[0]), int.Parse(tokens[1]));
                        break;

                    case "Greater":
                        Console.WriteLine(custum.CountGreaterThan(tokens[0]));
                        break;

                    case "Max":
                        Console.WriteLine(custum.Max());
                        break;

                    case "Min":
                        Console.WriteLine(custum.Min());
                        break;

                    case "Print":
                        foreach (var list in custum)
                        {
                            Console.WriteLine(list);
                        }
                        break;

                    case "Sort":
                        custum = Sorter.Sort(custum);
                        break;
                }
            }
        }
    }
}