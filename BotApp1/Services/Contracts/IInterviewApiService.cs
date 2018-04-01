using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BotApp1.Services.Data;
using RestSharp;

namespace BotApp1.Services.Contracts
{
    public class InterviewApiService
    {
        private readonly RestClient _apiClient;
        
        public InterviewApiService(string url)
        {
            _apiClient = new RestClient(url);
        }

        public async Task<List<CompanyDto>> GetCompanies()
        {
            var request = new RestRequest("api/interview/companies", Method.GET);
            var response = await _apiClient.ExecuteTaskAsync<List<CompanyDto>>(request);

            return response.Data;
        }

        public async Task<string> GetQuestion(string companyName, int questionId)
        {
            var payload = new QuestionDto
            {
                CompanyName = companyName,
                QuestionId = questionId 
            };
            var request = new RestRequest("api/interview/question", Method.POST){RequestFormat = DataFormat.Json}.AddBody(payload);

            var response = await _apiClient.ExecuteTaskAsync<QuestionResponse>(request);
            var responseData = response.Data;
            return responseData.StatusCode == HttpStatusCode.NotFound ? "Tell me more about yourself" : response.Data.Question;
        }
    }
}