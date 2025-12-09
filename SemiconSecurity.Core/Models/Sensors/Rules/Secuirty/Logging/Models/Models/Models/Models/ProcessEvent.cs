namespace SemiconSecurity.Core.Models
{
    public class ProcessEvent
    {
        public DateTime Timestamp { get; set; }
        public string ProcessName { get; set; }
        public string Action { get; set; }
        public string Detail { get; set;}
    }
}