using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioViajaNet.DTO;
using DesafioViajaNet.RabbitManager;
using DesafioViajaNet.Servico.Interface;
using DesafioViajaNet.WebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DesafioViajaNet.WebAPI.Controller
{
    [Route("viagens")]
    [ApiController]
    public class ViagemController : ControllerBase
    {

        private readonly ISender _sender;
        private readonly IVooServico _vooService;

        public ViagemController(
            ISender sender,
            IVooServico vooService
            )
        {
            _sender = sender;
            _vooService = vooService;
        }

        [HttpPost]
        [Route("solicitar")]
        public IActionResult Post([FromBody] LandingComportamentoDTO dto)
        {
            try
            {
                _sender.Enviar(FilaEnum.LANDING.ToString(), dto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("consultar")]
        public IActionResult Get([FromQuery(Name = "data-embarque")] DateTime dataEmbarque, [FromQuery(Name = "data-desembarque")] DateTime dataDesembarque, [FromQuery(Name = "codigo-destino")] long codigoDestino)
        {
            try
            {
                IList<ViagemVooDTO> dto = _vooService.BuscarVooPeriodo(dataEmbarque, dataDesembarque, codigoDestino);
                if (dto.Any()){
                    return Ok(dto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("consultar")]
        public IActionResult PostCheckout([FromBody] CheckoutPedidoComportamentoDTO dto)
        {
            try
            {
                _sender.Enviar(FilaEnum.CHECKOUT_PEDIDO.ToString(), dto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("confirmar/{codigoVoo}")]
        public IActionResult GetConfirmacao(long codigoVoo)
        {
            try
            {
                return Ok(_vooService.BuscarDetalhes(codigoVoo));
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("confirmar")]
        public IActionResult PostConfirmacao([FromBody] ConfirmacaoPedidoComportamentoDTO dto)
        {
            try
            {
                _sender.Enviar(FilaEnum.CONFIRMACAO_PEDIDO.ToString(), dto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}