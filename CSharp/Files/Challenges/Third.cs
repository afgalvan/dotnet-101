using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Files.Challenges
{
    internal class SalesData
    {
        public double Total { get; set; }
    }

    public class Third
    {
        public static void Solution()
        {
            IEnumerable<string> salesFiles = GetSalesFiles();
            double              salesTotal = CalculateSalesTotal(salesFiles);

            string salesTotalDir = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Challenges", "SalesTotal");

            File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"),
                $"{salesTotal}{Environment.NewLine}");
        }

        private static double CalculateSalesTotal(
            IEnumerable<string> salesFiles) => salesFiles.Sum(GetTotalOfFile);


        private static double GetTotalOfFile(string json)
        {
            string jsonContent = File.ReadAllText(json);
            var salesData =
                JsonConvert.DeserializeObject<SalesData>(jsonContent);
            return salesData?.Total ?? 0;
        }

        private static IEnumerable<string> GetSalesFiles()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string storesPath =
                Path.Combine(currentDirectory, "Challenges", "stores");

            return Directory.EnumerateFiles(storesPath,
                "*.json", SearchOption.AllDirectories);
        }
    }
}
