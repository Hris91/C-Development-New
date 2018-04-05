
using P06_TrafficLights.Enums;

namespace P06_TrafficLights.Contracts
{
    public interface ITrafficLight
    {
        LightState LightState { get; }
        void ChangeCurrentLight();
    }
}
