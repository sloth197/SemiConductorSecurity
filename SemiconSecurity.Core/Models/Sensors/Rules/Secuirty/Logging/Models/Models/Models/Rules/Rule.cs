namespace SemiconSecuirty.Core.Rules
{
    public class Rule
    {
        public string Name { get; set; }
        public Func<bool> Condition { get; set; }
        public string Severity { get; set; }
        public string Message { get; set; }
    }
}