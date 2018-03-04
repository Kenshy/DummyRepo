using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Data;

namespace AppApi.Controllers
{
    [Route("api/analyze")]
    public class SentimentController : Controller
    {
        private readonly ITonalityService _tonalityService;
        private readonly IPersonalityService _personalityService;

        public SentimentController(ITonalityService tonalityService, IPersonalityService personalityService)
        {
            _tonalityService = tonalityService;
            _personalityService = personalityService;
        }

        [HttpGet("tone")]
        public async Task<IActionResult> AnalyzeTone([FromQuery]string text)
        {
            var toneAnalysis = _tonalityService.AnalyzeTone(text);
            return Ok(toneAnalysis);
        }

        [HttpPost("chat")]
        public async Task<IActionResult> AnalyzeChat([FromBody]List<ChatMessageRequest> chat)
        {
            var chatResponse = _tonalityService.AnalyzeChat(chat);
            return Ok(chatResponse);
        }

        [HttpPost("personality")]
        public async Task<IActionResult> ObtainProfile([FromQuery]string text)
        {
            var rez1 = _personalityService.GetProfile();
            return Ok(rez1);
        }
    }
}
