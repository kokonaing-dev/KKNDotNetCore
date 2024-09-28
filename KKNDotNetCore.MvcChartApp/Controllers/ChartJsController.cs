using Microsoft.AspNetCore.Mvc;

namespace KKNDotNetCore.MvcChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult ExampleChart()
        {
            return View();
        }
        
        public IActionResult InterpolationLineChart()
        {
            return View();
        }
        
        public IActionResult PolarAreaChart()
        {
            return View();
        }



    }
}
