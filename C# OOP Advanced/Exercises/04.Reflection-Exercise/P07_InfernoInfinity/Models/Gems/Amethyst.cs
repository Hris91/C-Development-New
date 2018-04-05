using System;
using System.Collections.Generic;
using System.Text;
using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        private const int BASE_STRENGHT_INCREASE = 2;
        private const int BASE_AGILITY_INCREASE = 8;
        private const int BASE_VITALITY_INCREASE = 4;

        public Amethyst(ClarityLevel clarityLevel)
            : base(BASE_STRENGHT_INCREASE, BASE_AGILITY_INCREASE, BASE_VITALITY_INCREASE, clarityLevel)
        {
        }
    }
}
