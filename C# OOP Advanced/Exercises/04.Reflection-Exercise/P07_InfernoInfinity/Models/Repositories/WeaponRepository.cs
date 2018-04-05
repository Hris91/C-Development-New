
using System;
using System.Collections.Generic;
using System.Linq;
using P07_InfernoInfinity.Contracts;

namespace P07_InfernoInfinity.Models.Repositories
{
    class WeaponRepository : IWeaponRepository
    {
        private readonly IList<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public IWeapon GetWeapon(string name)
        {
            IWeapon weapon = this.weapons.FirstOrDefault(w => w.Name == name);

            if (weapon == null)
            {
                throw new ArgumentException("Invalid Weapon Name");
            }

            return weapon;
        }
    }
}
