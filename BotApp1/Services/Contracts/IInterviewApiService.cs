using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BotApp1.Models;
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

        public async Task ProcessUser(InterviewModel state, string name, string email)
        {
            var data = new InterviewModelDto();
            data.CompanyName = state.CompanyName;
            data.Q1 = state.Q1;
            data.Q2 = state.Q2;
            data.Q3 = state.Q3;

            data.Q4 = state.Q4;
            //data.Q5 = state.Q5;
            //data.Q6 = state.Q6;

            //data.Q7 = state.Q7;
            //data.Q8 = state.Q8;
            //data.Q9 = state.Q9;

            //data.Q10 = state.Q10;
            //data.Q11= state.Q11;

            //data.Q12 = state.Q12;
            //data.Q13 = state.Q13;

            data.CandidateName = name;
            data.CandidateEmail = email;
            
            var request = new RestRequest("api/interview/personality/analysis", Method.POST) { RequestFormat = DataFormat.Json }.AddBody(data);

            var response = await _apiClient.ExecuteTaskAsync<InterviewModel>(request);
        }
    }

    public class InterviewModelDto : InterviewModel
    {
        public string CandidateName { get; set; }
        public string CandidateEmail { get; set; }
    }
}