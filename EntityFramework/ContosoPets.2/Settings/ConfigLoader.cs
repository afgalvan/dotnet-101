namespace ContosoPets._2.Settings
{
    public class ConfigLoader
    {
        private readonly dynamic _settings;

        public ConfigLoader(string fileName)
        {
            _settings = ConfigReader.ReadConfigFromFile(fileName);
        }

        public string DefaultConnection =>
            _settings["ConnectionStrings"]["DefaultConnection"];
    }
}
