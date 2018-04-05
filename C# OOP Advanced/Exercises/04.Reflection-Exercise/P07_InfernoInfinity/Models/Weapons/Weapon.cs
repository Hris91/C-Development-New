
using P07_InfernoInfinity.Attributes;
using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Models.Weapons
{
    [Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", new string[]{ "Pesho", "Svetlio" })]
    public abstract class Weapon : IWeapon
    {
       
        protected Weapon(int baseMinDmg, int baseMaxDmg, int socketNumber, string name, RarityLevel rarityLevel)
        {
            this.Name = name;
            this.BaseMinDmg = baseMinDmg;
            this.BaseMaxDmg = baseMaxDmg;
            this.RarityLevel = rarityLevel;
            SetDmg();          
            this.Gems = new IGem[socketNumber];                      
        }

        public string Name { get; }

        private int BaseMinDmg { get; }

        private int BaseMaxDmg { get; }
       
        public int MinDmg { get ; private set; }

        public int MaxDmg { get; private set; }

        public IGem[] Gems { get; protected set; }

        public int Strenght { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitality { get; protected set; }

        public RarityLevel RarityLevel { get; }

        private void SetDmg()
        {
            this.MinDmg = this.BaseMinDmg * (int)this.RarityLevel + (this.Strenght * 2) + this.Agility;
            this.MaxDmg = this.BaseMaxDmg * (int)this.RarityLevel + (this.Strenght * 3) + (this.Agility * 4);
        }

        public void AddGem(IGem gem, int socket)
        {
            if (this.Gems[socket] != null)
            {
                this.RemoveGem(socket);
            }

            this.Gems[socket] = gem;

            this.Strenght += gem.StrenghtIncrease;
            this.Agility += gem.AgilityIncrease;
            this.Vitality += gem.VitalityIncrease;      
            
            SetDmg();
        }
        
        public void RemoveGem(int socket)
        {
            var gem = this.Gems[socket];

            this.Strenght -= gem.StrenghtIncrease;
            this.Agility -= gem.AgilityIncrease;
            this.Vitality -= gem.VitalityIncrease;

            SetDmg();
        }        
        
        public override string ToString()
        {
            return
                $"{this.Name}: {this.MinDmg}-{this.MaxDmg} Damage, +{this.Strenght} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }
    }
}
