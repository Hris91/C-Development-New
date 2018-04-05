
using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        private const int BASE_STRENGHT_INCREASE = 1;
        private const int BASE_AGILITY_INCREASE = 4;
        private const int BASE_VITALITY_INCREASE = 9;

        public Emerald(ClarityLevel clarityLevel)
            : base(BASE_STRENGHT_INCREASE, BASE_AGILITY_INCREASE, BASE_VITALITY_INCREASE, clarityLevel)
        {
        }
    }
}
