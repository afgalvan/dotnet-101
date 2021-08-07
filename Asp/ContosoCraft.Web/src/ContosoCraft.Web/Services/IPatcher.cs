using System.Net.Http;
using System.Threading.Tasks;

namespace ContosoCraft.Web.Services
{
    public interface IPatcher
    {
        public Task Patch(string url, HttpContent body);
    }
}
