using Microsoft.Extensions.Configuration;

namespace Server.Services
{
    public interface IConnectionService
    {
        public void StartListening(IConfigurationSection json);
    }
}
