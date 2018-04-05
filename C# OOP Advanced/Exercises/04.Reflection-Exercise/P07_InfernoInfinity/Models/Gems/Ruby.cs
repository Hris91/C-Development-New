
using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int BASE_STRENGHT_INCREASE = 7;
        private const int BASE_AGILITY_INCREASE = 2;
        private const int BASE_VITALITY_INCREASE = 5;

        public Ruby(ClarityLevel clarityLevel) 
            : base(BASE_STRENGHT_INCREASE, BASE_AGILITY_INCREASE, BASE_VITALITY_INCREASE, clarityLevel)
        {
        }
    }
}
