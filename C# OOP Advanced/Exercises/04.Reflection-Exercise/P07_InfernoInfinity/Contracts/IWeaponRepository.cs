
namespace P07_InfernoInfinity.Contracts
{
    public interface IWeaponRepository
    {
        void AddWeapon(IWeapon weapon);
        IWeapon GetWeapon(string name);
    }
}
