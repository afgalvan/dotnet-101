using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ContosoCraft.Web.Services
{
    public record AddRateRequest(string Id, double Rate);

    public class RatingSubmitter
    {
        private readonly IPatcher       _patcher;
        private readonly IConfiguration _configuration;

        private string ApiUrl => _configuration.GetSection("Api")["Url"];

        private string RequestUrl => ApiUrl + "/Products/Rate";

        public RatingSubmitter(IPatcher patcher, IConfiguration configuration)
        {
            _patcher       = patcher;
            _configuration = configuration;
        }

        public async Task SubmitRating(string productId, double rating)
        {
            var         request = new AddRateRequest(productId, rating);
            HttpContent content = JsonContent.Create(request);
            await _patcher.Patch(RequestUrl, content);
        }
    }
}
