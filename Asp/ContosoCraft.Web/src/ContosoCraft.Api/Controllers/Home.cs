using Microsoft.AspNetCore.Mvc;

namespace ContosoCraft.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class Home : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Api";
        }
    }
}
