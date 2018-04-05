
namespace P07_InfernoInfinity.Contracts
{
    public interface IWeapon : IAttackable, IGemUser, IMagicStatsUser
    { 
        string Name { get; }
    }
}
