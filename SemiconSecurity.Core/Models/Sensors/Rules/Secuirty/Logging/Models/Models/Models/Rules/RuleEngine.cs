using SemiconSecuirty.Core.Models;

namespace SemiconSecuirty.Core.Rules
{
    public class RuleEngine
    {
        public List<Rule> Rules = new();
        public List<SecurityEvent> = Evaluate()
        {
            var events = new List<SecurityEvent>();
            foreach (var r in Rules)
            {
                if ( r.Condition())
                {
                    events.Add(new SecurityEvent
                    {
                        Timestamp = DateTime.Now,
                        Type = "RuleAlert",
                        Message = r.Message,
                        Severity = r.Severity
                    });
                }
            }
            return events;
        }
    }
}