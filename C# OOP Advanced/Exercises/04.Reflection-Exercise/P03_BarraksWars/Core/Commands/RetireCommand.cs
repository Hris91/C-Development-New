using System;
using System.Collections.Generic;
using System.Text;
using P03_BarraksFactory.Core.Commands;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            this.repository.RemoveUnit(Data[1]);
            string result = $"{Data[1]} retired!";

            return result;
        }
    }
}
