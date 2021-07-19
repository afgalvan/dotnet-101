using System.Net;
using ContosoCraft.Web.Data;
using ContosoCraft.Web.Repositories;
using ContosoCraft.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContosoCraft.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("MySQL"))
            );
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<UrlFetcher>();
            services.AddScoped<JsonProductService>();
            services.AddScoped<IProductRepository, MySqlProductRepository>();
        }

        public static void ConfigureProxy(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownProxies.Add(IPAddress.Parse("192.168.1.17"));
                options.KnownProxies.Add(IPAddress.Parse("127.0.10.1"));
            });
        }
    }
}
