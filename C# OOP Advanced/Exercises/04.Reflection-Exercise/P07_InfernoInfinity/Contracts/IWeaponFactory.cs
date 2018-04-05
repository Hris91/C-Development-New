
using System.Collections.Generic;

namespace P07_InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(IList<string> data);
    }
}
