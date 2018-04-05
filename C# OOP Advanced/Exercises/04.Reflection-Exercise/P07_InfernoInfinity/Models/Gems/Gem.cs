
using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        protected Gem(int strenghtIncrease, int agilityIncrease, int vitalityIncrease, ClarityLevel clarityLevel)
        {
            this.Modifier = (int)clarityLevel;
            this.StrenghtIncrease = strenghtIncrease + this.Modifier;
            this.AgilityIncrease = agilityIncrease + this.Modifier;
            this.VitalityIncrease = vitalityIncrease + this.Modifier;
        }

        public int Modifier { get; }
        public int StrenghtIncrease { get; }
        public int AgilityIncrease { get; }
        public int VitalityIncrease { get; }
    }
}
