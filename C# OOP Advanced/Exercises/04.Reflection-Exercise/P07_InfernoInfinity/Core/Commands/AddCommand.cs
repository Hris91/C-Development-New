
using System.Collections.Generic;
using P07_InfernoInfinity.Contracts;

namespace P07_InfernoInfinity.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IGemFactory gemFactory;
        [Inject]
        private IWeaponRepository weaponRepository;

        public AddCommand(IGemFactory gemFactory, IWeaponRepository weaponRepository, IList<string> data)
            : base(data)
        {
            this.gemFactory = gemFactory;
            this.weaponRepository = weaponRepository;
        }

        public override void ExecuteCommand()
        {
            var weaponName = data[1];
            IWeapon weapon = weaponRepository.GetWeapon(weaponName);
            int socket = int.Parse(data[2]);
            IGem gem = gemFactory.CreateGem(data);

            weapon.AddGem(gem, socket);
        }
    }
}
