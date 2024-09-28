using Microsoft.AspNetCore.Mvc;

namespace KKNDotNetCore.MvcChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult ExmapleChart()
        {
            return View();
        }
        
        public IActionResult InterpolationLineChart()
        {
            return View();
        }



    }
}
