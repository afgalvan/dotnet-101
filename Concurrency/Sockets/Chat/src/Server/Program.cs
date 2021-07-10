using Microsoft.Extensions.Hosting;
using Server.Settings;

namespace Server
{
    internal static class Program
    {
        private static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                    new Startup(Configuration.Startup).ConfigureServices(services)
                );
    }
}
