using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;

namespace Semiconsecurity.UI.Charts
{
    public partial class SensorChartControl : UserControl
    {
        public ObservableCollection<double> TemperatureValues { get; set; } = nnew ObservableCollection<double>();

        public SensorChartControl()
        {
            InitializeComponent();
            SensorChart.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = TemperatureValues,
                    LineSmoothness = 0.2
                }
            };
        }

        public void AddTemperature(double value)
        {
            if (TemperatureValues.Count > 60)
            {
                TemperatureValues.RemoveAt(0);
            }
            TemperatureValues.Add(value);
        }
    }
}