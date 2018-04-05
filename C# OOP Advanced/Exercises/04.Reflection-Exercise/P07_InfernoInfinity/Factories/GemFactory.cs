using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(IList<string> data)
        {
            var args = data.Last().Split(" ").ToArray();

            ClarityLevel clarityLevel = Enum.Parse<ClarityLevel>(args[0]);
            var typeAsString = args[1];

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            Type type = types.FirstOrDefault(t => t.Name == typeAsString);

            if (type == null)
            {
                throw new ArgumentException("Invalid Gem Type!");
            }

            IGem gem = (IGem) Activator.CreateInstance(type, new object[] {clarityLevel});

            return gem;
        }
    }
}
