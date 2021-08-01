using ContosoCraft.Api.Data;
using ContosoCraft.Api.Repositories;
using ContosoCraft.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ContosoCraft.Api.Extensions
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
            services.AddScoped<ProductService>();
            services.AddScoped<IProductRepository, MySqlProductRepository>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1",
                    new OpenApiInfo {Title = "ContosoCraft.Api", Version = "v1"}
                )
            );
        }
    }
}
