﻿namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double AcConsumptionMod = 0.9;

        public Car(double fuelQuantity, double fuelConsumation)
            : base(fuelQuantity, fuelConsumation + AcConsumptionMod)
        {
        }

       
    }
}