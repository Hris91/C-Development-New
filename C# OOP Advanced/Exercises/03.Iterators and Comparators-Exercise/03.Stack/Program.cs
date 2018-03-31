using System;
using System.Linq;

namespace _03.Stack
{
    public class Program
    {
        public static void Main()
        {
            var custumStack = new CustumStack();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var args = input
                    .Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = args[0];

                args = args
                    .Skip(1)
                    .ToArray();

                try
                {
                    switch (command)
                    {
                        case "Push":                       
                            custumStack.Push(args.Select(int.Parse).ToArray());
                            break;
                        case "Pop":
                            custumStack.Pop();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }

            Print(custumStack);
        }

        public static void Print(CustumStack custumStack)
        {
            foreach (var element in custumStack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in custumStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
