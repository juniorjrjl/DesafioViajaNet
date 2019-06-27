using AutoMapper;
using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using DesafioViajaNet.RabbitManager;
using DesafioViajaNet.Servico.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioViajaNet.Robo
{
    public class ProcessamentoDados
    {
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;
        private readonly Receiver<CheckoutPedidoComportamentoDTO> _checkoutPedidoComportamentoReceiver;
        private readonly Receiver<ConfirmacaoPedidoComportamentoDTO> _confirmacaoPedidoComportamentoReceiver;
        private readonly Receiver<LandingComportamentoDTO> _landingComportamentoReceiver;
        private readonly Receiver<HomeComportamentoDTO> _homeComportamentoReceiver;
        private readonly IHomeComportamentoServico _homeComportamentoServico;
        private readonly ILandingComportamentoServico _landingComportamentoServico;
        private readonly ICheckoutPedidoComportamentoServico _checkoutPedidoComportamentoServico;
        private readonly IConfirmacaoPedidoComportamentoServico _confirmacaoPedidoComportamentoServico;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IVooServico _vooServico;
        private readonly IUsuarioVooServico _usuarioVooServico;

        public ProcessamentoDados(
            CancellationToken cancellationToken,
            IMapper mapper,
            Receiver<HomeComportamentoDTO> homeComportamentoReceiver,
            Receiver<LandingComportamentoDTO> landingComportamentoReceiver,
            Receiver<CheckoutPedidoComportamentoDTO> checkoutPedidoComportamentoReceiver,
            Receiver<ConfirmacaoPedidoComportamentoDTO> confirmacaoPedidoComportamentoReceiver,
            IHomeComportamentoServico homeComportamentoServico,
            ILandingComportamentoServico landingComportamentoServico,
            ICheckoutPedidoComportamentoServico checkoutPedidoComportamentoServico,
            IConfirmacaoPedidoComportamentoServico confirmacaoPedidoComportamentoServico,
            IUsuarioServico usuarioServico,
            IVooServico vooServico,
            IUsuarioVooServico usuarioVooServico)
        {
            _cancellationToken = cancellationToken;
            _mapper = mapper;
            _homeComportamentoReceiver = homeComportamentoReceiver;
            _landingComportamentoReceiver = landingComportamentoReceiver;
            _checkoutPedidoComportamentoReceiver = checkoutPedidoComportamentoReceiver;
            _confirmacaoPedidoComportamentoReceiver = confirmacaoPedidoComportamentoReceiver;
            _homeComportamentoServico = homeComportamentoServico;
            _landingComportamentoServico = landingComportamentoServico;
            _checkoutPedidoComportamentoServico = checkoutPedidoComportamentoServico;
            _confirmacaoPedidoComportamentoServico = confirmacaoPedidoComportamentoServico;
            _usuarioServico = usuarioServico;
            _vooServico = vooServico;
            _usuarioVooServico = usuarioVooServico;
        }

        public Func<Task> Processar() => () =>
        {
            while (true)
            {
                ProcessarComportamentoHome();
                ProcessarComportamentoLanding();
                ProcessarComportamentoCheckoutPedido();
                ProcessarComportamentoConfirmacaoPedido();
                if (_cancellationToken.IsCancellationRequested)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }
            }

        };

        public void ProcessarComportamentoHome()
        {
            HomeComportamentoDTO dto = new HomeComportamentoDTO();
            try
            {
                while (dto != null)
                {
                    dto = _homeComportamentoReceiver.Receber(FilaEnum.HOME.ToString());
                    if (dto != null)
                    {
                        _homeComportamentoServico.Inserir(_mapper.Map<HomeComportamento>(dto));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro no processamento do Comportamento Home : {e.StackTrace}");
            }
        }

        public void ProcessarComportamentoLanding()
        {
            LandingComportamentoDTO dto = new LandingComportamentoDTO();
            try
            {
                while (dto != null)
                {
                    dto = _landingComportamentoReceiver.Receber(FilaEnum.LANDING.ToString());
                    _landingComportamentoServico.Inserir(_mapper.Map<LandingComportamento>(dto));
                    _usuarioServico.Inserir(_mapper.Map<Usuario>(dto));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro no processamento do Comportamento Home : {e.StackTrace}");
            }
        }

        public void ProcessarComportamentoCheckoutPedido()
        {
            CheckoutPedidoComportamentoDTO dto = new CheckoutPedidoComportamentoDTO();
            try
            {
                while (dto != null)
                {
                    dto = _checkoutPedidoComportamentoReceiver.Receber(FilaEnum.CHECKOUT_PEDIDO.ToString());
                    try
                    {
                        _usuarioServico.BuscarCodigoPeloEmail(dto.Email);
                    }
                    catch (ArgumentNullException)
                    {
                        _checkoutPedidoComportamentoServico.Inserir(_mapper.Map<CheckoutPedidoComportamento>(dto));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro no processamento do Comportamento Checkout Pedido : {e.StackTrace}");
            }
        }

        public void ProcessarComportamentoConfirmacaoPedido()
        {
            ConfirmacaoPedidoComportamentoDTO dto = new ConfirmacaoPedidoComportamentoDTO();
            try
            {
                while (dto != null)
                {
                    dto = _confirmacaoPedidoComportamentoReceiver.Receber(FilaEnum.CONFIRMACAO_PEDIDO.ToString());
                    _confirmacaoPedidoComportamentoServico.Inserir(_mapper.Map<ConfirmacaoPedidoComportamento>(dto));
                    if (dto.Confirmou)
                    {
                        try
                        {
                            UsuarioVoo usuarioVoo = new UsuarioVoo()
                            {
                                CodigoUsuario = _usuarioServico.BuscarCodigoPeloEmail(dto.Email),
                                CodigoVoo = dto.CodigoVoo,
                                Preco = _vooServico.BuscarPreco(dto.CodigoVoo)
                            };
                            _usuarioVooServico.Inserir(usuarioVoo);
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.Write($"erro ao adicionar usuário ao voo {ex.StackTrace}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro no processamento do Comportamento Checkout Pedido : {e.StackTrace}");
            }
        }

    }
}
