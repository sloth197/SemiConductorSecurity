using SemiconSecuirty.Core.Models;

namespace SemiconSecuirty.Core.Sensors
{
    public class SensorSimulator 
    {
        privcate readonly Random _rand = new();
        public SensorData Generate()
        {
            return new SensorData
            {
                Timestamp = DateTime.Now,
                Temperature = 180 + _rand.NextDouble() *  40,
                Pressure = 0.9 + _rand.NextDouble() * 0.3,
                Rpm = 1000 + _rand.Next(0, 800),
                GasFlow = 20 + _rand.NextDouble() * 10
            };
        }
    }
}