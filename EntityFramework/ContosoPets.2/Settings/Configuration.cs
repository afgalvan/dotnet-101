using System.Collections.Generic;

namespace ContosoPets._2.Settings
{
    public static class Configuration
    {
        private const string DefaultConfigFile = @"appsettings.json";

        private static ConfigLoader _configLoader =
            new ConfigLoader(DefaultConfigFile);

        public static string ConnectionString =>
            _configLoader.DefaultConnection;

        public static void Load(string[] args) =>
            _configLoader = AreValidArgs(args)
                ? new ConfigLoader(args[0])
                : new ConfigLoader(DefaultConfigFile);

        private static bool AreValidArgs(IReadOnlyList<string> args) =>
            args != null && args.Count != 0 &&
            !string.IsNullOrEmpty(args[0]);
    }
}
