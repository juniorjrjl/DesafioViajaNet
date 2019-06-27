using AutoMapper;
using DesafioViajaNet.Entity;
using DesafioViajaNet.RabbitManager;
using DesafioViajaNet.Robo.AutoMapper;
using DesafioViajaNet.Robo.RabbitReceiver;
using DesafioViajaNet.Servico.Interface;
using DesafioViajaNet.Servico.Implementacao;
using DesafioViajaNet.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using DesafioViajaNet.CouchDB;
using Couchbase;
using HomeComportamentoEntity = DesafioViajaNet.Entity.Repositorio.Implementacao.HomeComportamentoRepositorio;
using HomeComportamentoCouchDB = DesafioViajaNet.CouchDB.Repositorio.Implementacao.HomeComportamentoRepositorio;
using LandingComportamentoEntity = DesafioViajaNet.Entity.Repositorio.Implementacao.LandingComportamentoRepositorio;
using LandingComportamentoCouchDB = DesafioViajaNet.CouchDB.Repositorio.Implementacao.LandingComportamentoRepositorio;
using CheckoutPedidoComportamentoEntity = DesafioViajaNet.Entity.Repositorio.Implementacao.CheckoutPedidoComportamentoRepositorio;
using CheckoutPedidoComportamentoCouchDB = DesafioViajaNet.CouchDB.Repositorio.Implementacao.CheckoutPedidoComportamentoRepositorio;
using ConfirmacaoPedidoComportamentoEntity = DesafioViajaNet.Entity.Repositorio.Implementacao.ConfirmacaoPedidoComportamentoRepositorio;
using ConfirmacaoPedidoComportamentoCouchDB = DesafioViajaNet.CouchDB.Repositorio.Implementacao.ConfirmacaoPedidoComportamentoRepositorio;
using Couchbase.Core;
using DesafioViajaNet.Entity.Repositorio.Implementacao;

namespace DesafioViajaNet.Robo
{
    public class Container
    {

        public ServiceProvider ServiceProvider { get; private set; }

        public Container()
        {

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            DbContextOptions<DesafioViajaNetDbContext> contextOptions = new DbContextOptionsBuilder<DesafioViajaNetDbContext>().UseSqlServer(configuration["DbContextSettings:ConnectionString"]).Options;
            DesafioViajaNetDbContext dbContext = new DesafioViajaNetDbContext(contextOptions);

            string servidorCouchDB = configuration["CouchDBSettings:server"];
            string usuarioCouchDB = configuration["CouchDBSettings:user"];
            string senhaCouchDB = configuration["CouchDBSettings:password"];
            IBucket bucket = Conexao.GetConexao(servidorCouchDB, usuarioCouchDB, senhaCouchDB).OpenBucket();

            ServiceProvider = new ServiceCollection()
                .AddTransient<HomeComportamentoReceiver>()
                .AddSingleton<Receiver<HomeComportamentoDTO>>(c => new HomeComportamentoReceiver("localhost"))
                .AddSingleton<Receiver<LandingComportamentoDTO>>(c => new LandingComportamentoReceiver("localhost"))
                .AddSingleton<Receiver<CheckoutPedidoComportamentoDTO>>(c => new CheckoutPedidoComportamentoReceiver("localhost"))
                .AddSingleton<Receiver<ConfirmacaoPedidoComportamentoDTO>>(c => new ConfirmacaoPedidoComportamentoReceiver("localhost"))
                .AddTransient<IHomeComportamentoServico>(c => new HomeComportamentoServico(new HomeComportamentoEntity(dbContext), new HomeComportamentoCouchDB(bucket)))
                .AddTransient<ILandingComportamentoServico>(c => new LandingComportamentoServico(new LandingComportamentoEntity(dbContext), new LandingComportamentoCouchDB(bucket)))
                .AddTransient<ICheckoutPedidoComportamentoServico>(c => new CheckoutPedidoComportamentoServico(new CheckoutPedidoComportamentoEntity(dbContext), new CheckoutPedidoComportamentoCouchDB(bucket)))
                .AddTransient<IConfirmacaoPedidoComportamentoServico>(c => new ConfirmacaoPedidoComportamentoServico(new ConfirmacaoPedidoComportamentoEntity(dbContext), new ConfirmacaoPedidoComportamentoCouchDB(bucket)))
                .AddTransient<IUsuarioServico>(c => new UsuarioServico(new UsuarioRepositorio(dbContext)))
                .AddTransient<IVooServico>(c => new VooServico(new VooRepositorio(dbContext)))
                .AddTransient<IUsuarioVooServico>(c => new UsuarioVooServico(new UsuarioVooRepositorio(dbContext)))
                .AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperManager)))
                .BuildServiceProvider();
            
        }

    }
}
