using SemiconSecurity.Core.Models;
using System.Diagnostics;

namespace SemiconSecurity.Agent
{
    public class AgentController
    {
        public void ExecuteResponse(SecurityEvent evt)
        {
            if (evt.Severity == "Critical")
            {
                Console.WriteLine("[Agent] Critical alert received. Stopping equipment----");
                StopEquipment();
            }
            if (evt.Type == "ProcessWarning")
            {
                Console.WriteLine("[Agent] Suspicious process detected. Attempting ti kill----");
                KillProcess(evt.Message);
            }
        }
        private void StopEquipment()
        {
            Console.WriteLine("[Agent] Equipment stop simulated");
        }

        private void KillProcess(string message)
        {
            var name = ExtractProcessName(message);
            var target = Process.GetProcessesByName(name);
            foreach (var p in targets)
            {
                try
                {
                    p.Kill();
                }
                catch
                {
                }
            }
        }
        private string ExtractProcesName(string msg)
        {
            return msg.Replace("Suspicious process detected:", "").Trim();
        }
    }
}