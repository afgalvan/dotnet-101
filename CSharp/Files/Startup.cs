using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Files
{
    public class Startup
    {
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

        }
    }
}
