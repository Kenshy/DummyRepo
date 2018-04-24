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
            return Ok(new List<CompanyDto>
            {
                new CompanyDto
                {
                    CompanyId = 1,
                    CompanyName = "Company1",
                    ShortName = "c1"
                },
                new CompanyDto
                {
                    CompanyId = 2,
                    CompanyName = "Company2",
                    ShortName = "c2"
                }
            });
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

    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
    }
}