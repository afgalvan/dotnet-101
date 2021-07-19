using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ContosoCraft.Web.Services
{
    public class UrlFetcher
    {
        private WebRequest  Request  { get; set; }
        private WebResponse Response { get; set; }

        public async Task<string> Fetch(string url)
        {
            Request  = WebRequest.Create(url);
            Response = await Request.GetResponseAsync();

            await using Stream stream = Response.GetResponseStream();
            using var reader = new StreamReader(
                stream ?? throw new InvalidOperationException(),
                Encoding.UTF8
            );

            return await reader.ReadToEndAsync();
        }
    }
}
