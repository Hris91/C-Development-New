using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using P07_InfernoInfinity.Contracts;

namespace P07_InfernoInfinity.Core
{
    public class CommandIntepreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandIntepreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(IList<string> data)
        {
            var typeAsString = data[0];

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            Type type = types.FirstOrDefault(t => t.Name == typeAsString + "Command");

            if (type == null)
            {
                throw new ArgumentException("Invalid Command Type!");
            }

            FieldInfo[] fieldsToInject = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                .ToArray();

            ConstructorInfo[] ctors = type.GetConstructors();

            object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();
            
            object[] resultArgs = injectArgs.Concat(new object[]{data}).ToArray();

            ICommand command = (ICommand) ctors.FirstOrDefault().Invoke(resultArgs);

            return command;
        }
    }
}
