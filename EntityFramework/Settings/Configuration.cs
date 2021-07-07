namespace Settings
{
    public static class Configuration
    {
        public static void Load(string[] args)
        {
            if (args == null || args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                _configLoader = new ConfigLoader(DefaultConfigFile);
            }
            else
            {
                _configLoader = new ConfigLoader(args[0]);
            }
        }

        private const string DefaultConfigFile = @"appsettings.json";

        private static ConfigLoader _configLoader = new ConfigLoader(DefaultConfigFile);

        public static string ConnectionString => _configLoader.DefaultConnection;
    }
}
