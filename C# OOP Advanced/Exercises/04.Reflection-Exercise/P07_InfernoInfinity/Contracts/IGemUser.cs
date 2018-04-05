
namespace P07_InfernoInfinity.Contracts
{
    public interface IGemUser
    {
        IGem[] Gems { get; }
        void AddGem(IGem gem, int socket);
        void RemoveGem(int socket);
    }
}
