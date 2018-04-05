using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(IList<string> data)
        {
            var args = data[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var rarity = Enum.Parse<RarityLevel>(args[0]);
            var typeAsString = args[1];
            var weaponName = data[2];

            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();

            Type type = types.FirstOrDefault(t => t.Name == typeAsString);

            if (type == null)
            {
                throw new ArgumentException("Invalid Weapon Type!");
            }

            IWeapon weapon = (IWeapon) Activator.CreateInstance(type, new object[] {weaponName, rarity});

            return weapon;
        }
    }
}
