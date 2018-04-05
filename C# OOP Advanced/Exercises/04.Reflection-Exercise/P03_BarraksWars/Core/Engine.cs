﻿using P03_BarraksWars.Core;

namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;

    class Engine : IRunnable
    { 
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "fight")
            {
                try
                {                  
                    string[] data = input.Split();
                    string commandName = data[0];
                    IExecutable command = this.commandInterpreter.InterpretCommand(data, commandName);
                    Console.WriteLine(command.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
