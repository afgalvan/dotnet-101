using Microsoft.Extensions.Configuration;
using Server.Models;

namespace Server.Services
{
    public interface IConnectionService
    {
        public void StartListening(IConfigurationSection json);
        protected void ManageConnection(Connection client);
    }
}
