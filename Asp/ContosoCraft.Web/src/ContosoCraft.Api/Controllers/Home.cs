using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ContosoCraft.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class Home : ControllerBase
    {
        [HttpGet]
        public ActionResult Get() => Redirect("/swagger/index.html");
    }
}
