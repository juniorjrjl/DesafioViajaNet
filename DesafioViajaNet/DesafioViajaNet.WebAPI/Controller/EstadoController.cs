using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioViajaNet.DTO;
using DesafioViajaNet.Servico.Interface;
using DesafioViajaNet.WebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioViajaNet.WebAPI.Controller
{
    [Route("estados")]
    [ApiController]
    public class EstadoController : ControllerBase
    {

        private readonly IEstadoServico _estadoServico;

        public EstadoController(IEstadoServico estadoServico) => _estadoServico = estadoServico;

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(201, _estadoServico.BuscarTodos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}