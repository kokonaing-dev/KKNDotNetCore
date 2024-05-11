using KKNDotNetCore.RestApiWithNLayer.Models;
using Newtonsoft.Json;

namespace KKNDotNetCore.RestApiWithNLayer.Features.LatHtaukBayDin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatHtaukBayDinController : ControllerBase
    {
        private async Task<LatHtaukBayDinModel> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<LatHtaukBayDinModel>(jsonStr);
            return model;
        }

        //api/LatHtaukBayDin/Questions
        [HttpGet("questions")]
        public async Task<IActionResult> Questions()
        {
            var model = await GetDataAsync();
            return Ok(model.questions);
        }


        //api/LatHtaukBayDin/NumberList
        [HttpGet]
        public async Task<IActionResult> NumberList()
        {
            var model = await GetDataAsync();
            return Ok(model.numberList);
        }


        //api/LatHtaukBayDin/Answer
        [HttpGet("{questionNo}/{no}")]
        public async Task<IActionResult> Answer(int questionNo, int no)
        {
            var model = await GetDataAsync();
            return Ok(model.answers.FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == no ));
        }

    }
}
