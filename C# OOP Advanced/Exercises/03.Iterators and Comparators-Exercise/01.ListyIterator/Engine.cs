using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class Engine
    {
        private ListyIterator<string> listyIterator;
        private bool engineRuns;

        public Engine()
        {
            engineRuns = true;
        }

        public void Run()
        {          
            while (engineRuns)
            {
                var args = Console.ReadLine()
                    .Split(" ")
                    .ToList();

                var command = args[0];

                args = args.Skip(1).ToList();

                try
                {
                    switch (command)
                    {
                        case "Create":
                            this.listyIterator = new ListyIterator<string>(args);
                            break;
                        case "HasNext":
                            Console.WriteLine(this.listyIterator.HasIndex());
                            break;
                        case "Move":
                            Console.WriteLine(this.listyIterator.Move());
                            break;
                        case "Print":
                            this.listyIterator.Print();
                            break;
                        case "PrintAll":
                            foreach (var iteator in this.listyIterator)
                            {
                                Console.Write(iteator + " ");
                            }
                            Console.WriteLine();
                            break;
                        case "END":
                            engineRuns = false;
                            break;                       
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);                    
                }
            }
        }
    }
}
