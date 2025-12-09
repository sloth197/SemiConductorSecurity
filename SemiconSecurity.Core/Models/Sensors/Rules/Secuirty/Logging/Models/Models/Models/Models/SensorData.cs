namespace SemiconSecurity.Core.Models
{
    public class SensorData
    {
        public DateTime TimeStamp { get; set; }
        public double Temparature {get; set; }
        public double Pressure { get; set; }
        public double Rpn { get; set; }
        public double GasFlow  { get;  set; } 
    }
}