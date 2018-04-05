using System.Collections.Generic;

namespace P07_InfernoInfinity.Contracts
{
    public interface ICommandInterpreter
    {
        ICommand CreateCommand(IList<string> data);
    }
}
