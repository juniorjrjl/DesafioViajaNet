using AutoMapper;
using DesafioViajaNet.RabbitManager;
using DesafioViajaNet.Servico.Interface;
using DesafioViajaNet.DTO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioViajaNet.Robo
{
    public class Startup
    {

        public static async Task Main()
        {
            Console.WriteLine("Iniciando robo para persistencia dos dados");
            CancellationTokenSource source = new CancellationTokenSource();
            Container container = new Container();
            ProcessamentoDados processamento = new ProcessamentoDados(
                source.Token,
                container.ServiceProvider.GetRequiredService<IMapper>(),
                container.ServiceProvider.GetRequiredService<Receiver<HomeComportamentoDTO>>(),
                container.ServiceProvider.GetRequiredService<Receiver<LandingComportamentoDTO>>(),
                container.ServiceProvider.GetRequiredService<Receiver<CheckoutPedidoComportamentoDTO>>(),
                container.ServiceProvider.GetRequiredService<Receiver<ConfirmacaoPedidoComportamentoDTO>>(),
                container.ServiceProvider.GetRequiredService<IHomeComportamentoServico>(),
                container.ServiceProvider.GetRequiredService<ILandingComportamentoServico>(),
                container.ServiceProvider.GetRequiredService<ICheckoutPedidoComportamentoServico>(),
                container.ServiceProvider.GetRequiredService<IConfirmacaoPedidoComportamentoServico>(),
                container.ServiceProvider.GetRequiredService<IUsuarioServico>(),
                container.ServiceProvider.GetRequiredService<IVooServico>(),
                container.ServiceProvider.GetRequiredService<IUsuarioVooServico>());
            Task task = Task.Run(processamento.Processar(), source.Token);
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("kill", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Para terminar o processo do robo digite 'kill' e pressione 'ENTER'");
                }
            }
            source.Cancel();
            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("O robo foi finalizado.");
            }
            finally
            {
                source.Dispose();
            }
        }
    }
}
