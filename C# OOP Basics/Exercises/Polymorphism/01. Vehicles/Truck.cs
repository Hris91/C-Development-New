namespace _01.Vehicles
{
    internal class Truck : Vehicle
    {
        private const double AcConsumptionMod = 1.6;
        private const double PercentModifier = 0.95;

        public Truck(double fuelQuantity, double fuelConsumation) 
            : base(fuelQuantity, fuelConsumation + AcConsumptionMod)
        {
        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * PercentModifier);
        }
    }
}