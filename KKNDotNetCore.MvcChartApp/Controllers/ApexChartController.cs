using KKNDotNetCore.MvcChartApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KKNDotNetCore.MvcChartApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult SimplePieChart()
        {
            PieChartModel model = new PieChartModel();
            model.Lables = new List<string>() { "Team A", "Team B", "Team C", "Team D", "Team E" };
            model.Series = new List<int> { 44, 55, 13, 43, 22 };

            return View(model);
        }

        public IActionResult DumbbellChart()
        {
            var model = new DumbbellChartModel
            {
                Series = new List<ChartData>
                {
                    new ChartData { X = "Operations", Y = new List<int> { 2800, 4500 } },
                    new ChartData { X = "Customer Success", Y = new List<int> { 3200, 4100 } },
                    new ChartData { X = "Engineering", Y = new List<int> { 2950, 7800 } },
                    new ChartData { X = "Marketing", Y = new List<int> { 3000, 4600 } },
                    new ChartData { X = "Product", Y = new List<int> { 3500, 4100 } },
                    new ChartData { X = "Data Science", Y = new List<int> { 4500, 6500 } },
                    new ChartData { X = "Sales", Y = new List<int> { 4100, 5600 } }
                }
            };
            return View(model);
        }
    }
}
