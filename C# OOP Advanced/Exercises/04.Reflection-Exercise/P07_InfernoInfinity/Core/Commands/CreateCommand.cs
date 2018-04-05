using System;
using System.Collections.Generic;
using System.Text;
using P07_InfernoInfinity.Contracts;

namespace P07_InfernoInfinity.Core.Commands
{
    public class CreateCommand : Command
    {
        [Inject]
        private IWeaponFactory weaponFactory;
        [Inject]
        private IWeaponRepository weaponRepository;

        public CreateCommand(IWeaponFactory weaponFactory, IWeaponRepository weaponRepository, IList<string> data) 
            : base(data)
        {
            this.weaponFactory = weaponFactory;
            this.weaponRepository = weaponRepository;
        }

        public override void ExecuteCommand()
        {
            IWeapon weapon = weaponFactory.CreateWeapon(data);
            this.weaponRepository.AddWeapon(weapon);
        }
    }
}
