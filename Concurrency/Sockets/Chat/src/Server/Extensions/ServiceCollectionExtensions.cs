using System.Collections.Generic;
using System.Net.Sockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Server.Models;
using Server.Services;

namespace Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<Server>();
        }

        public static void AddApplicationServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<Dictionary<Connection, User>>();
            services.AddScoped<IConnectionService, ConnectionService>();
            services.AddScoped<ILogger<ConnectionService>, Logger<ConnectionService>>();
            services.AddScoped<ResetEvent>();
        }
    }
}
