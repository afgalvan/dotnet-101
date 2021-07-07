using System;

namespace ContosoPets.Settings
{
    public static class Configuration
    {
        private const string DefaultFileConfig = @"appsettings.json";

        private static ConfigLoader _configLoader;

        public static string ConnectionString => _configLoader.DefaultConnection;

        public static void Load(string[] args)
        {
            if (args == null || args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                _configLoader = new ConfigLoader(DefaultFileConfig);
            }
            else
            {
                _configLoader = new ConfigLoader(args[0]);
            }
        }
    }
}
