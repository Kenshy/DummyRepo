using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Data;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppApi.Controllers
{
    [Route("api/interview")]
    public class InterviewController : Controller
    {
        private readonly IInterviewService _interviewService;

        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }

        [SwaggerOperation(Tags = new[] { "Interview" })]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(List<CompanyDto>))]
        [HttpGet("companies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _interviewService.GetCompanies();

            return Ok(companies);
        }

        [SwaggerOperation(Tags = new[] { "Interview" })]
        [SwaggerResponse((int)HttpStatusCode.OK, typeof(QuestionResponse))]
        [HttpPost("question")]
        public async Task<IActionResult> GetQuestion([FromBody]QuestionRequest question)
        {
            var response = await _interviewService.GetQuestion(question);
            return Ok(response);
        }

        [SwaggerOperation(Tags = new[] {"Interview"})]
        [SwaggerResponse((int) HttpStatusCode.OK)]
        [HttpPost("personality/analysis")]
        public async Task<IActionResult> GetAnalysis([FromBody]InterviewModelRequest request)
        {
            await _interviewService.AnalyzeAnswers(request);
            return Accepted();
        }
    }
}