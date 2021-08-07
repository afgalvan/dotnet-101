using ContosoCraft.Web.Components;
using ContosoCraft.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContosoCraft.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddHttpClient<HttpRequester>();
            services.AddScoped<IFetcher, HttpRequester>();
            services.AddScoped<IPatcher, HttpRequester>();
            services.AddScoped<ILogger<ProductList>, Logger<ProductList>>();
            services.AddScoped<JsonProductLoader>();
            services.AddScoped<RatingSubmitter>();
        }
    }
}
