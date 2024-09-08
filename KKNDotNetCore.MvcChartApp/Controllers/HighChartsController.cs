using Microsoft.AspNetCore.Mvc;

namespace KKNDotNetCore.MvcChartApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }

        public IActionResult LineChart()
        {
            return View();
        }
    }
}
