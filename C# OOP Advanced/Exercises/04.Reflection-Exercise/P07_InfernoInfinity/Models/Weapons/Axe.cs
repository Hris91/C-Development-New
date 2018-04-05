
using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int BASE_MIN_DMG = 5; 
        private const int BASE_MAX_DMG = 10;
        private const int BASE_SOCKET_NUMBER = 4;

        public Axe(string name, RarityLevel rarityLevel) 
            : base(BASE_MIN_DMG, BASE_MAX_DMG, BASE_SOCKET_NUMBER, name, rarityLevel)
        {
        }
    }
}
