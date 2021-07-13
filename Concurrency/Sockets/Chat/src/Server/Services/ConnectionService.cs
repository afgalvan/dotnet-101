using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Server.Models;

namespace Server.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly Socket                     _socket;
        private readonly ResetEvent                 _connectionEvent;
        private readonly ILogger<ConnectionService> _logger;
        private readonly IUserService               _userService;

        public ConnectionService(ILogger<ConnectionService> logger,
            ResetEvent connectionEvent, IUserService userService)
        {
            _socket          = CreateSocket();
            _logger          = logger;
            _connectionEvent = connectionEvent;
            _userService     = userService;
        }

        private static Socket CreateSocket()
        {
            return new(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
        }

        public void StartListening(IConfigurationSection json)
        {
            ServerConfiguration configuration =
                ServerConfiguration.FromJson(json);

            try
            {
                _socket.Bind(configuration.IpEndPoint);
                _socket.Listen();
                _logger.Log(LogLevel.Information,
                    $"Server started listening at {DateTime.Now}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Task.Run(ManageConnection);
            Task.Run(ManageClosedConnection);
        }

        private void ManageConnection()
        {
            try
            {
                while (true)
                {
                    _connectionEvent.Reset();
                    _socket.BeginAccept(AcceptSocket, _socket);
                    _connectionEvent.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void AcceptSocket(IAsyncResult result)
        {
            _connectionEvent.Set();
            var connection = new Connection(_socket.EndAccept(result));
            _userService.Add(connection);
            _logger.Log(LogLevel.Information,
                $"Client {connection.Socket.RemoteEndPoint} connected");
        }

        private void ManageClosedConnection()
        {

        }

        private void CloseClient(Connection client)
        {
            _logger.Log(LogLevel.Information,
                $"Client {client.Socket.RemoteEndPoint} disconect.");
            _userService.Remove(client);
            client.Close();
        }
    }
}
