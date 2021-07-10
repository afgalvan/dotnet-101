using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Server.Services;

namespace Server
{
    public sealed class Server : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IConnectionService       _serverConnection;
        private readonly IConfiguration           _configuration;

        public Server(IHostApplicationLifetime appLifetime,
            IConnectionService serverConnection, IConfiguration configuration)
        {
            _appLifetime      = appLifetime;
            _serverConnection = serverConnection;
            _configuration    = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(() =>
                Task.Run(() =>
                    _serverConnection.StartListening(_configuration.GetSection("Server"))
                )
            );

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
