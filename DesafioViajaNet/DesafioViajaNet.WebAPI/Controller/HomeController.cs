using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioViajaNet.DTO;
using DesafioViajaNet.RabbitManager;
using DesafioViajaNet.WebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DesafioViajaNet.WebAPI.Controller
{
    [Route("acessos")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ISender _sender;

        public HomeController(ISender sender) => _sender = sender;

        [HttpPost]
        public IActionResult Post([FromBody] HomeComportamentoDTO dto)
        {
            try
            {
                _sender.Enviar(FilaEnum.HOME.ToString(), dto);
                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}