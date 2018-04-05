using System;
using System.Collections.Generic;
using P07_InfernoInfinity.Contracts;

namespace P07_InfernoInfinity.Core.Commands
{
    public class PrintCommand : Command
    {
        [Inject]
        private IWeaponRepository weaponRepository;

        public PrintCommand(IWeaponRepository weaponRepository, IList<string> data)
            : base(data)
        {      
            this.weaponRepository = weaponRepository;
        }

        public override void ExecuteCommand()
        {
            var weaponName = data[1];
            IWeapon weapon = this.weaponRepository.GetWeapon(weaponName);

            Console.WriteLine(weapon);
        }
    }
}
