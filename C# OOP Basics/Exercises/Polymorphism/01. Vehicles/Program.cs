using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var carInput = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var truckInput = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            var commandsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsNumber; i++)
            {
                var commandTokens = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var vehicleType = commandTokens[1];

                if (vehicleType == "Car")
                {
                    ExecuteAction(car, commandTokens[0], double.Parse(commandTokens[2]));
                }
                else
                {
                    ExecuteAction(truck, commandTokens[0], double.Parse(commandTokens[2]));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ExecuteAction(Vehicle vehicle, string command, double parameter)
        {
            switch (command)
            {
                case "Drive":
                    var result = vehicle.TryTravelDistance(parameter);
                    Console.WriteLine(result);
                    break;
                case "Refuel":
                    vehicle.Refuel(parameter);
                    break;
            }
        }
    }
}
