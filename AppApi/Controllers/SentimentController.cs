using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using IBM.WatsonDeveloperCloud.ToneAnalyzer.v3.Model;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using Services.Data;
using Swashbuckle.AspNetCore.SwaggerGen;

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

        [SwaggerResponse((int)HttpStatusCode.OK, typeof(ToneAnalysis))]
        [SwaggerOperation(Tags = new[] { "Sentiment" })]
        [HttpGet("tone")]
        public async Task<IActionResult> AnalyzeTone([FromQuery]string text)
        {
            var toneAnalysis = _tonalityService.AnalyzeTone(text);
            return Ok(toneAnalysis);
        }
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(UtteranceAnalyses))]
        [SwaggerOperation(Tags = new []{"Sentiment"})]
        [HttpPost("chat")]
        public async Task<IActionResult> AnalyzeChat([FromBody]List<ChatMessageRequest> chat)
        {
            var chatResponse = _tonalityService.AnalyzeChat(chat);
            return Ok(chatResponse);
        }
        [SwaggerOperation(Tags = new[] { "Personality" })]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(ProfileDto))]
        [HttpPost("personality")]
        public async Task<IActionResult> ObtainProfile([FromBody]List<AnswerRequest> answers)
        {
            var personality  = _personalityService.GetProfile(answers);
            return Ok(personality);
        }
    }
}
