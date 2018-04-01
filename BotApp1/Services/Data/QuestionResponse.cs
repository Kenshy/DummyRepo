using System.Net;

namespace BotApp1.Services.Data
{
    public class QuestionResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Question { get; set; }
        public string ErrorMessage { get; set; }
    }
}