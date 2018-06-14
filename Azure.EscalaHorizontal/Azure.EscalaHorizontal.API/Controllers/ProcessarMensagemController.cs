using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.EscalaHorizontal.Core;
using Azure.EscalaHorizontal.Core.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure.EscalaHorizontal.API.Controllers
{
    [Produces("application/json")]
    [Route("api/ProcessarMensagem")]
    public class ProcessarMensagemController : Controller
    {
        [HttpGet]
        public string Get()
        {
            //return "Versão: 1.0.0.0" ;
            return Util.GetIpAddress();
        }

        [HttpPost]
        public void Post([FromBody]ItemMessagem mensagem)
        {
        }
    }
}
