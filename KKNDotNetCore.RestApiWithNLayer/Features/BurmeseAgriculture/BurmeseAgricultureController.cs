using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KKNDotNetCore.RestApiWithNLayer.Features.BurmeseAgriculture
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurmeseAgricultureController : ControllerBase
    {
        private async Task<List<Class1>> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("BurmeseAgriculture.json");
            var models = JsonConvert.DeserializeObject<List<Class1>>(jsonStr);
            return models;
        }

        // Get : api/BurmeseAgriculture/Agricultures
        [HttpGet]
        public async Task<IActionResult> Agricultures()
        {
            var models = await GetDataAsync();
            return Ok(models);
        }

        // Get : api/BurmeseAgriculture/TreePlantingGuide/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> TreePlantingGuide(string id)
        {
            var models = await GetDataAsync();
            var model = models.FirstOrDefault(t => t.Id.Equals(id));
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
