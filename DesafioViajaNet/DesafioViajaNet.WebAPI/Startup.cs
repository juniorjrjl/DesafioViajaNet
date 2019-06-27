using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioViajaNet.Entity;
using DesafioViajaNet.Entity.Repositorio.Implementacao;
using DesafioViajaNet.RabbitManager;
using DesafioViajaNet.Servico.Interface;
using DesafioViajaNet.Servico.Implementacao;
using DesafioViajaNet.WebAPI.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using HomeComportamentoEntity = DesafioViajaNet.Entity.Repositorio.Implementacao.HomeComportamentoRepositorio;
using HomeComportamentoCouchDB = DesafioViajaNet.CouchDB.Repositorio.Implementacao.HomeComportamentoRepositorio;
using LandingComportamentoEntity = DesafioViajaNet.Entity.Repositorio.Implementacao.LandingComportamentoRepositorio;
using LandingComportamentoCouchDB = DesafioViajaNet.CouchDB.Repositorio.Implementacao.LandingComportamentoRepositorio;
using CheckoutPedidoComportamentoEntity = DesafioViajaNet.Entity.Repositorio.Implementacao.CheckoutPedidoComportamentoRepositorio;
using CheckoutPedidoComportamentoCouchDB = DesafioViajaNet.CouchDB.Repositorio.Implementacao.CheckoutPedidoComportamentoRepositorio;
using ConfirmacaoPedidoComportamentoEntity = DesafioViajaNet.Entity.Repositorio.Implementacao.ConfirmacaoPedidoComportamentoRepositorio;
using ConfirmacaoPedidoComportamentoCouchDB = DesafioViajaNet.CouchDB.Repositorio.Implementacao.ConfirmacaoPedidoComportamentoRepositorio;
using Couchbase.Core;
using DesafioViajaNet.CouchDB;

namespace DesafioViajaNet.WebAPI
{
    public class Startup
    {

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddMvc().AddJsonOptions(options => 
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });
            string connectionString = Configuration["DbContextSettings:ConnectionString"];
            services.AddTransient<ISender>(s => new Sender("localhost"));
            DbContextOptions<DesafioViajaNetDbContext> contextOptions = new DbContextOptionsBuilder<DesafioViajaNetDbContext>().UseSqlServer(connectionString).Options;
            DesafioViajaNetDbContext dbContext = new DesafioViajaNetDbContext(contextOptions);

            string servidorCouchDB = Configuration["CouchDBSettings:server"];
            string usuarioCouchDB = Configuration["CouchDBSettings:user"];
            string senhaCouchDB = Configuration["CouchDBSettings:password"];
            IBucket bucket = Conexao.GetConexao(servidorCouchDB, usuarioCouchDB, senhaCouchDB).OpenBucket();

            services.AddDbContext<DesafioViajaNetDbContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<ICidadeServico>(c => new CidadeServico(new CidadeRepositorio(dbContext)));
            services.AddTransient<IEstadoServico>(c => new EstadoServico(new EstadoRepositorio(dbContext)));
            services.AddTransient<IUsuarioServico>(c => new UsuarioServico(new UsuarioRepositorio(dbContext)));
            services.AddTransient<IUsuarioVooServico>(c => new UsuarioVooServico(new UsuarioVooRepositorio(dbContext)));
            services.AddTransient<IViagemServico>(c => new ViagemServico(new ViagemRepositorio(dbContext)));
            services.AddTransient<IVooServico>(c => new VooServico(new VooRepositorio(dbContext)));
            services.AddTransient<IHomeComportamentoServico>(c => new HomeComportamentoServico(new HomeComportamentoEntity(dbContext), new HomeComportamentoCouchDB(bucket)));
            services.AddTransient<ILandingComportamentoServico>(c => new LandingComportamentoServico(new LandingComportamentoEntity(dbContext), new LandingComportamentoCouchDB(bucket)));
            services.AddTransient<ICheckoutPedidoComportamentoServico>(c => new CheckoutPedidoComportamentoServico(new CheckoutPedidoComportamentoEntity(dbContext), new CheckoutPedidoComportamentoCouchDB(bucket)));
            services.AddTransient<IConfirmacaoPedidoComportamentoServico>(c => new ConfirmacaoPedidoComportamentoServico(new ConfirmacaoPedidoComportamentoEntity(dbContext), new ConfirmacaoPedidoComportamentoCouchDB(bucket)));
            services.AddTransient<InitDB>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, InitDB initDB)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");
            app.UseMvc();
            initDB.Seed();
        }
    }
}
