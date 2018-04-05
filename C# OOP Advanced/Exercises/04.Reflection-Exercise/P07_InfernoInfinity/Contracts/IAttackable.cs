using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IAttackable
    {
        int MinDmg { get; }
        int MaxDmg { get; }
    }
}
