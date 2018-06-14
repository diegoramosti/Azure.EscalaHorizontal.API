using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Azure.EscalaHorizontal.Core
{
    public class Util
    {
        public static string GetIpAddress()  
        {
            var ipv4Addresses = Array.FindAll(Dns.GetHostEntry(string.Empty).AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);

            return Environment.MachineName + " - " + ipv4Addresses[0].ToString();

        }
    }
}
