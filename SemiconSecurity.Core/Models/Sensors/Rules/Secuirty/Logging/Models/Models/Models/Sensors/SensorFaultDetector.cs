namespace SemiconSecuirty.Core.Sensors
{
    public class SensorFaultDetector
    {
        public bool IsFault(SensorData d)
        {
            return d.Temperature > 220 ||
                   d.Pressure < 0.9 ||
                   d.Rpm > 1800 ||
                   d.GasFlow < 15;
        }
    }
}