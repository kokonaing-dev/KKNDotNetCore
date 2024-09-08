namespace KKNDotNetCore.MvcChartApp.Models
{
    public class DumbbellChartModel
    {
        public List<ChartData> Series { get; set; }
    }

    public class ChartData
    {
        public string X { get; set; }
        public List<int> Y { get; set; }
    }
}
