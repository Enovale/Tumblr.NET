using System.Net;
using NetCoreServer;

namespace TumblrNET.Tests
{
    public class AuthServer : HttpServer
    {
        public AuthServer(IPAddress address, int port) : base(address, port)
        {
        }

        public AuthServer(string address, int port) : base(address, port)
        {
        }

        public AuthServer(DnsEndPoint endpoint) : base(endpoint)
        {
        }

        public AuthServer(IPEndPoint endpoint) : base(endpoint)
        {
        }

        protected override TcpSession CreateSession()
        {
            return new AuthSession(this);
        }
    }
}