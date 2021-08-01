using Microsoft.AspNetCore.Mvc;

namespace ContosoCraft.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class Home : ControllerBase
    {
        [HttpGet]
        public ActionResult Get() => Redirect("/swagger/index.html");

        [HttpGet("/{x:regex(^doc)}")]
        public ActionResult GetDocumentation(string x) => Redirect("/swagger/index.html");
    }
}
