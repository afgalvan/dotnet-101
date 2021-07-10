using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace Files.Challenges
{
    public class Second
    {
        class SalesTotal
        {
            public double Total { get; set; }
        }

        public static void Solution()
        {
            string totalSalesDirectory = CreateDirectory("SalesTotal");
            string totalSalesFile =
                Path.Combine(totalSalesDirectory, "totals.txt");
            // File.WriteAllText(totalSalesFile, string.Empty);

            string salesPath = Path.Combine(Directory.GetCurrentDirectory(),
                "Challenges", "stores", "201", "sales.json");
            string salesJson = File.ReadAllText(salesPath);

            var salesData =
                JsonConvert.DeserializeObject<SalesTotal>(salesJson);

            File.AppendAllText(
                totalSalesFile,
                salesData?.Total.ToString(CultureInfo.CurrentCulture)
            );
        }

        private static string CreateDirectory(string directory)
        {
            string fullPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Challenges", "", directory);

            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);

            return fullPath;
        }

        private static void CreateAndWriteFile(string file, string text)
        {
            File.WriteAllText(
                Path.Combine(Directory.GetCurrentDirectory(), file), text);
        }
    }
}
