using Microsoft.AspNetCore.Mvc;

namespace KKNDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        private readonly ILogger<CanvasJsController> _logger;

        public CanvasJsController(ILogger<CanvasJsController> logger)
        {
            _logger = logger;
        }

        public IActionResult LineChart()
        {
            _logger.LogInformation("Line Chart in Canvas");
            return View();
        } 
        
        public IActionResult ScatterChart()
        {
            _logger.LogInformation("Scatter Chart in Canvas");
            return View();
        }


    }
}
