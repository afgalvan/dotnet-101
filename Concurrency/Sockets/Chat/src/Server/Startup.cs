using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Extensions;

namespace Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedServices();
            services.AddApplicationServices(Configuration);
        }
    }
}
