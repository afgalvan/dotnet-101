using Server.Models;

namespace Server.Services
{
    public interface IUserService
    {
        public void Add(Connection connection);
        public void Remove(Connection connection);

    }
}
