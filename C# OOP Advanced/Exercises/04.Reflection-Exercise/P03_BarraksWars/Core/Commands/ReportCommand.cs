using System;
using P03_BarraksFactory.Core.Commands;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
