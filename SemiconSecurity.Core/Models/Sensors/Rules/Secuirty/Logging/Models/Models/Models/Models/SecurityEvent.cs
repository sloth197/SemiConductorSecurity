namespace SemiconSecurity.Core.Models
{
    public class SecurityEvent
    {
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; } 
    }
}