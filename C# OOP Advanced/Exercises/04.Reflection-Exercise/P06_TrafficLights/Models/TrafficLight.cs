using System;
using P06_TrafficLights.Contracts;
using P06_TrafficLights.Enums;

namespace P06_TrafficLights.Models
{
    public class TrafficLight : ITrafficLight
    {
        public TrafficLight(LightState lightState)
        {
            this.LightState = lightState;
        }

        public LightState LightState { get; private set; }

        public void ChangeCurrentLight()
        {
            var changedLigthState = (int) this.LightState;
            changedLigthState++;

            if (changedLigthState > 3)
            {
                changedLigthState = 1;
            }

            this.LightState = (LightState)changedLigthState;
        }

        public override string ToString()
        {
            return this.LightState.ToString();
        }
    }
}
