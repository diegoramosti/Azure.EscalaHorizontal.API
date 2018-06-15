using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Azure.EscalaHorizontal.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure.EscalaHorizontal.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Server")]
    public class ServerController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var nameIp = "";
            await Task.Run(() => { nameIp = GetIpAddress(); });
            return Ok(new ItemMessage { Message = nameIp });
        }

        private string GetIpAddress()
        {
            var ipv4Addresses = Array.FindAll(Dns.GetHostEntry(string.Empty).AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);
            return Environment.MachineName + " - " + ipv4Addresses[0].ToString();
        }
    }
}
