
using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int BASE_MIN_DMG = 3;
        private const int BASE_MAX_DMG = 4;
        private const int BASE_SOCKET_NUMBER = 2;

        public Knife(string name, RarityLevel rarityLevel)
            : base(BASE_MIN_DMG, BASE_MAX_DMG, BASE_SOCKET_NUMBER, name, rarityLevel)
        {
        }
    }
}
