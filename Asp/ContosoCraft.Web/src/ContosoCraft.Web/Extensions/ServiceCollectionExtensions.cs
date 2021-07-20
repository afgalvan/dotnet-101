using System.Net;
using ContosoCraft.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;

namespace ContosoCraft.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<UrlFetcher>();
            services.AddScoped<JsonProductLoader>();
        }
    }
}
