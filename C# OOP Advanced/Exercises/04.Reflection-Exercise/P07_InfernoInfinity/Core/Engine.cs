using System;
using System.Linq;
using P07_InfernoInfinity.Contracts;

namespace P07_InfernoInfinity.Core
{
    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var data = input
                        .Split(";", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    ICommand command = commandInterpreter.CreateCommand(data);

                    command.ExecuteCommand();
                }
                catch (Exception e)
                {
                    continue;
                }
            }
        }
    }
}
