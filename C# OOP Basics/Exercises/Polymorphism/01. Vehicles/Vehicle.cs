namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumation;

        public Vehicle(double fuelQuantity, double fuelConsumation)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumation = fuelConsumation;
        }

        private double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }

        private double FuelConsumation
        {
            get { return this.fuelConsumation; }
            set { this.fuelConsumation = value; }
        }

        private bool Drive(double distance)
        {
            var fuelRequired = distance * this.FuelConsumation;
            if (fuelRequired <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelRequired;
                return true;
            }
            return false;
        }
        public string TryTravelDistance(double distance)
        {
            if (this.Drive(distance))
            {
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuelAmount)
            => this.FuelQuantity += fuelAmount;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}