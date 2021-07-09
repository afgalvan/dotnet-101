using System;
using ContosoPets._1.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContosoPets._1
{
    public class Startup
    {
        public Startup()
        {
#nullable enable
            string? args = Environment.GetEnvironmentVariable("ENVIRONMENT");
#nullable disable
            string configFile =
                $"appsettings.{args ?? ""}json";
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(configFile, false, true)
                .Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRepositories();
            services.ConfigureDbContext(Configuration);
        }
    }
}
