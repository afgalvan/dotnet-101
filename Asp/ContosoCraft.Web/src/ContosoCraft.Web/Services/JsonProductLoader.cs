using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ContosoCraft.Models;
using Microsoft.Extensions.Configuration;

namespace ContosoCraft.Web.Services
{
    public class JsonProductLoader
    {
        private readonly UrlFetcher     _fetcher;
        private readonly IConfiguration _configuration;

        private string ApiUrl => _configuration.GetSection("Api")["Url"];

        private string JsonUrl => ApiUrl + "/Products";
        // @"https://gist.githubusercontent.com/bradygaster/3d1fcf43d1d1e73ea5d6c1b5aab40130/raw/e0bced80b7672a15e57383c2df61690db037db2c/products.json";

        public JsonProductLoader(UrlFetcher fetcher,
            IConfiguration configuration)
        {
            _fetcher       = fetcher;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Product>> GetProductList()
        {
            string jsonData = await _fetcher.Fetch(JsonUrl);
            return JsonSerializer.Deserialize<Product[]>(jsonData,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
