using SemiconSecuirty.Core.Models;
using System.Diagnostics;

namespace SemiconSecuirty.Core.SecurityEvent{
    public class ProcessMonitor
    {
        public List<SecurityEvent> CheckSuspicious()
        {
            var list = new List<SecurityEvent>();
            var process = Process.GetProcesses();

            foreach(var p in process)
            {
                if (p.ProcesName.Contains("cmd") || p.ProcessName.Contains("PowerShell"))
                {
                    list.Add(new SecurityEvent
                    {
                        Timestamp = DateTime.Now,
                        Type = "ProcessWarning",
                        Message = $"Suspicious process detected: {p.ProcessName}",
                        Severity = "High"
                    });
                }
            }
            return list;
        }
    }
}