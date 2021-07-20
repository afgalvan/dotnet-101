using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ContosoCraft.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class Home : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public Home(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpGet]
        public ActionResult Get()
        {
            if (env.IsDevelopment())
                return Redirect("/swagger/index.html");

            return Ok(new
            {
                Title = "Contoso Crafts API",
                Version = "1.0"
            });
        }
    }
}
