using System.Collections.Generic;
using P07_InfernoInfinity.Contracts;

namespace P07_InfernoInfinity.Core.Commands
{
    public class RemoveCommand : Command
    {
        [Inject]
        private IWeaponRepository weaponRepository;

        public RemoveCommand(IWeaponRepository weaponRepository, IList<string> data)
            : base(data)
        {          
            this.weaponRepository = weaponRepository;
        }

        public override void ExecuteCommand()
        {
            var weaponName = data[1];
            IWeapon weapon = this.weaponRepository.GetWeapon(weaponName);
            var socket = int.Parse(data[2]);

            weapon.RemoveGem(socket);
        }
    }
}
