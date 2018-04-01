using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Data;

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

        [HttpGet("companies")]
        public async Task<List<CompanyDto>> GetCompanies()
        {
            return new List<CompanyDto>
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
            };
        }

        [HttpPost("question")]
        public async Task<QuestionResponse> GetQuestion([FromBody]QuestionRequest question)
        {
            return await _interviewService.GetQuestion(question);
        }
    }

    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
    }
}