using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Prometheus.Core.Utility
{
    /// <summary>
    ///     Utility class for managing IP network interfaces available at the host machine.
    /// </summary>
    public static class NetworkUtility
    {
        /// <summary>
        ///     The default IP Address list returned when no network is available.
        /// </summary>
        static readonly IPAddress[] NoIPAddressList = new IPAddress[] { };

        /// <summary>
        ///     Gets indication if network interface is present.
        /// </summary>
        public static bool IsAnyNetworkAvailable
        {
            get
            {
                return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            }
        }

        /// <summary>
        ///     Retrieves a list of all host IP interfaces. Returns an empty array if no
        ///     interfaces are available.
        /// </summary>
        public static IPAddress[] GetAllHostIPInterfaces()
        {
            if (!IsAnyNetworkAvailable)
            {
                return NoIPAddressList;
            }
            else
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());

                if (host.AddressList == null)
                {
                    return NoIPAddressList;
                }
                else
                {
                    return host.AddressList
                        .Where(
                            a => a.AddressFamily == AddressFamily.InterNetwork ||
                            a.AddressFamily == AddressFamily.InterNetworkV6)
                        .ToArray();
                }
            }
        }

        /// <summary>
        ///     Retrieves a list of all IP4 interfaces. Returns an empty array if no
        ///     interfaces are available.
        /// </summary>
        public static IPAddress[] GetHostIPv4Interfaces()
        {
            return GetAllHostIPInterfaces()
                .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                .ToArray();
        }

        /// <summary>
        ///     Retrieves a list of all IP6 interfaces. Returns an empty array if no
        ///     interfaces are available.
        /// </summary>
        public static IPAddress[] GetHostIPv6Interfaces()
        {
            return GetAllHostIPInterfaces()
                .Where(a => a.AddressFamily == AddressFamily.InterNetworkV6)
                .ToArray();
        }
    }
}