using System;
using System.Collections.Generic;
using P07_InfernoInfinity.Contracts;

namespace P07_InfernoInfinity.Core.Commands
{
    public abstract class Command : ICommand
    {
        protected IList<string> data;

        protected Command(IList<string> data)
        {
            this.data = data;
        }

        public abstract void ExecuteCommand();

    }
}
