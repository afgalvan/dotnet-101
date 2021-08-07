using System.Threading.Tasks;

namespace ContosoCraft.Web.Services
{
    public interface IFetcher
    {
        Task<string> Fetch(string url);
    }
}
