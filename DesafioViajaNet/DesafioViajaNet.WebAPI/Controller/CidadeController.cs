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
    [Route("cidades")]
    [ApiController]
    public class CidadeController : ControllerBase
    {

        private readonly ICidadeServico _cidadeServico;

        public CidadeController(ICidadeServico cidadeServico) => _cidadeServico = cidadeServico;

        [HttpGet]
        [Route("{codigoEstado}")]
        public IActionResult Get(long codigoEstado)
        {
            try
            {
                return StatusCode(201, codigoEstado > 0 ? _cidadeServico.BuscarPorEstado(codigoEstado) : new List<CidadeComboDTO>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}