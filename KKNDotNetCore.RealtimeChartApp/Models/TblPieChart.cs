using System;
using System.Collections.Generic;

namespace KKNDotNetCore.RealtimeChartApp.Models;

public partial class TblPieChart
{
    public int PieChartId { get; set; }

    public string PieChartName { get; set; } = null!;

    public decimal? PieChartValue { get; set; }
}
