using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BunnyEscape.Handlers
{
    public class ConnectionChecker
    {
        public bool IsConnected()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}
