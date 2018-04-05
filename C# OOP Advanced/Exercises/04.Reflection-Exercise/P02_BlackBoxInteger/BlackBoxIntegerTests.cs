using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            var blackBox = (BlackBoxInteger)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.NonPublic, null,
                new object[] {0}, null, null);

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var args = input
                    .Split("_", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = args[0];
                var n = int.Parse(args[1]);

                var method = type.GetMethod(command, BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(blackBox, new object[] { n });

                Console.WriteLine(type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(blackBox));
            }                    
        }
    }
}
