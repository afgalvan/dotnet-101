using System;
using System.Globalization;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace Server.Models
{
    public class ServerConfiguration
    {
        public string Host { get; set; }
        public int    Port { get; set; }

        public IPEndPoint IpEndPoint => new(IPAddress.Parse(Host), Port);

        public ServerConfiguration(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public static ServerConfiguration FromJson(
            IConfigurationSection configuration)
        {
            string host = configuration["Host"];
            var    port = Convert.ToInt32(configuration["Port"], CultureInfo.CurrentCulture);
            return new ServerConfiguration(host, port);
        }
    }
}
