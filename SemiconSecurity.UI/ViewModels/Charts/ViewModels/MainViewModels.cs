public class MainViewModel
{
    public ObservableCollection<string> EventLogs { get; set; }
    = new();

     private readonly SensorSimulator _sim = new();
     private readonly SensorFaultDetector _fault = new();
     private readonly ProcessMonitor _proc = new();
     private readonly FileIntegrityChecker _file = new();
     private readonly RuleEngine _rules = new();
     private readonly AgentController _agent = new();
     private readonly DispatcherTimer _timer = new();

     public SensorChartControl ChartControl { get; set; }

     public MainViewModel()
     {
        _rules.Rule.Add(new Rule
        {
            Name = "RecipeChange + HighTemp",
            Severity = "Critical",
            Message = "Recipe changed while Temperature > 200",
            Condition = () => LastRecipeChanged && LastTemperature > 200
        });

        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += TimerTick();
        _timer.Start();
     }

     private double LastTemperature = 0;
     private bool LastRecipeChanged = false;

     private void TimerTick(object sender, EventArgs e)
     {
        var data = _sim.Generate();
        LastTemperature = data.Temperature;
        ChartControl.AddTemperature(data.Temperature);

        if (_fault.Isfault(data))
        {
            Log("[FAULT] Sensot abnormal detected");
        }

        foreach (var evt int _proc.ChectSyspicious())
        {
            HandleSecurityEvent(evt);
        } 
        foreach (var evt int _file.CheckFile("recipe.txt"))
        {
            LastRecipeChanged = true;
            HandleSecurityEvent(evt);
        }     
        foreach (var evt int _rules.Evalaute())
        {
            HandleSecurityEvent(evt);
        }
    }

    private void HandleSecurityEvent(SecurityEvent evt)
    {
        Log($"[{evt.Severity}] {evt.Message}");
        _agent.ExecuteResponse(evt); 
    }

    private void Log(string msg)
    {
        EventLogs.Add($"{DateTime.Now: HH:mm:ss} {msg}");
        if (EventLogs.Count > 200)
        {
            EventLogs.RemoveAt(0);
        }
    }
}
