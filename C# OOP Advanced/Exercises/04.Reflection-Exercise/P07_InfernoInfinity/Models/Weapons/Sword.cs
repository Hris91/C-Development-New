
using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Models.Weapons
{
    class Sword : Weapon
    {
        private const int BASE_MIN_DMG = 4;
        private const int BASE_MAX_DMG = 6;
        private const int BASE_SOCKET_NUMBER = 3;

        public Sword(string name, RarityLevel rarityLevel)
            : base(BASE_MIN_DMG, BASE_MAX_DMG, BASE_SOCKET_NUMBER, name, rarityLevel)
        {
        }
    }
}
