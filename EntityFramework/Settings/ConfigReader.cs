using System;
using System.IO;
using Newtonsoft.Json;

namespace Settings
{
    public static class ConfigReader
    {
        public static object ReadConfigFromFile(string filePath)
        {
            object configuration;

            try
            {
                string data = File.ReadAllText(filePath);
                configuration = JsonConvert.DeserializeObject(data);
            }
            catch (IOException exception)
            {
                LogException(exception);
                throw;
            }

            return configuration;
        }

        private static void LogException(Exception exception)
        {
            Console.WriteLine($"Exception message: {exception.Message}");
        }
    }
}
