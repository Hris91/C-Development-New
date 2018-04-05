using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using P06_TrafficLights.Contracts;
using P06_TrafficLights.Enums;
using P06_TrafficLights.Models;

namespace P06_TrafficLights
{
    public class StartUp
    {
        public static void Main()
        {
            var args = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var n = int.Parse(Console.ReadLine());

            IList<ITrafficLight> trafficLights = new List<ITrafficLight>();

            AddTrafficLights(args, trafficLights);

            for (int i = 0; i < n; i++)
            {
                ChangeLights(trafficLights);
                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }

        private static void ChangeLights(IList<ITrafficLight> trafficLights)
        {
            foreach (var trafficLight in trafficLights)
            {
                trafficLight.ChangeCurrentLight();
            }
        }

        private static void AddTrafficLights(string[] args, IList<ITrafficLight> trafficLights)
        {
            foreach (var element in args)
            {
                LightState lightState = Enum.Parse<LightState>(element);
                ITrafficLight trafficLight = new TrafficLight(lightState);
                trafficLights.Add(trafficLight);
            }
        }
    }
}
