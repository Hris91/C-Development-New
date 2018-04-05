using System;
using System.Linq;
using System.Reflection;
using P03_BarraksFactory.Core.Commands;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core
{
    public class CommandInterpeter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;
        
        public CommandInterpeter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower().StartsWith(commandName.ToLower()));

            if (type == null)
            {
                throw new ArgumentException("Invalid Command");
            }

            FieldInfo[] fieldsToInject = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                .ToArray();

            object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            object[] resultArgs = new object[]{data}.Concat(injectArgs).ToArray();

            IExecutable command = (IExecutable) Activator.CreateInstance(type, resultArgs);
          
            return command;
        }
    }
}
