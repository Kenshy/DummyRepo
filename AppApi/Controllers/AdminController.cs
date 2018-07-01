using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        [Produces("text/html")]
        public string Get()
        {
            string responseString = @" 
            <title>My report</title>
            <style type='text/css'>
            button{
                color: green;
            }
            </style>
            <h1> Header </h1>
            <p>Hello There <button>click me</button></p>
            <p style='color:blue;'>I am blue</p>
            ";
            return responseString;
        }
    }
}
