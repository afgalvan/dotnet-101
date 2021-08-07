using System.Net.Http;
using System.Threading.Tasks;

namespace ContosoCraft.Web.Services
{
    public class HttpRequester : IFetcher, IPatcher
    {
        public HttpClient Client { get; }

        public HttpRequester(HttpClient client)
        {
            Client = client;
        }

        public async Task<string> Fetch(string url) =>
            await Client.GetStringAsync(url);

        public async Task Patch(string url, HttpContent body)
        {
            using HttpResponseMessage httpResponse = await Client.PatchAsync(url, body);
            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
