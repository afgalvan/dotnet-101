using System.Collections.Generic;
using Server.Models;

namespace Server.Services
{
    public class UserService : IUserService
    {
        private readonly Dictionary<Connection, User> _users;

        public UserService(Dictionary<Connection, User> users)
        {
            _users = users;
        }

        public void Add(Connection connection)
        {
            _users.Add(connection, new User());
        }

        public void Remove(Connection connection)
        {
            _users.Remove(connection);
        }
    }
}
