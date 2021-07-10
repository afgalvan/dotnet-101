using Microsoft.Extensions.DependencyInjection;

namespace Files.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection ConfigureRepository(
            this IServiceCollection services)
        {
            return services;
        }
    }
}
