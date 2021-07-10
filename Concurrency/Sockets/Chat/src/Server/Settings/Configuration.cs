using System;
using Microsoft.Extensions.Configuration;

namespace Server.Settings
{
    public static class Configuration
    {
        public static IConfiguration Startup =>
            new ConfigurationBuilder()
                .AddJsonFile(LoadConfigFile(), false, true)
                .Build();

        public static string LoadConfigFile()
        {
#nullable enable
            string? args = Environment.GetEnvironmentVariable("ENVIRONMENT");
#nullable disable
            return $"appsettings.{args ?? ""}json";
        }
    }
}
