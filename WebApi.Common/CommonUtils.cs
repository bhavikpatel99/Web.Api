using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using System.Net.Sockets;
namespace WebApi.Common
{
    public class CommonUtils
    {
        /// <summary>
        /// Get the client's IP address from HttpContext.
        /// </summary>
        public static string GetClientIp(HttpContext httpContext)
        {
            var ip = httpContext.Connection.RemoteIpAddress?.ToString();

            // If behind a proxy or load balancer
            if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                ip = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            }

            return ip ?? "Unknown";
        }

        /// <summary>
        /// Get the server's IP address.
        /// </summary>
        public static string GetServerIp()
        {
            string localIp = "Unknown";
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) // Get IPv4
                {
                    localIp = ip.ToString();
                    break;
                }
            }

            return localIp;
        }

        /// <summary>
        /// Get the hostname of the server machine.
        /// </summary>
        public static string GetServerHostName()
        {
            return Dns.GetHostName();
        }

        /// <summary>
        /// Get the hostname of the client based on IP.
        /// </summary>
        public static string GetClientHostName(HttpContext httpContext)
        {
            try
            {
                string clientIp = GetClientIp(httpContext);
                if (string.IsNullOrEmpty(clientIp) || clientIp == "Unknown")
                    return "Unknown";

                IPHostEntry hostEntry = Dns.GetHostEntry(clientIp);
                return hostEntry.HostName;
            }
            catch
            {
                return "Unknown";
            }
        }

    }
}
