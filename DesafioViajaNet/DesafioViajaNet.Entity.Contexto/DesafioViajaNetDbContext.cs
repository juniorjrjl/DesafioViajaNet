using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity.TypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity
{
    public class DesafioViajaNetDbContext: DbContext
    {

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioVoo> UsuariosVoos { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Voo> Voos { get; set; }

        public DbSet<HomeComportamento> HomeComportamentos { get; set; }
        public DbSet<LandingComportamento> LandingComportamentos { get; set; }
        public DbSet<CheckoutPedidoComportamento> CheckoutPedidoComportamentos { get; set; }
        public DbSet<ConfirmacaoPedidoComportamento> ConfirmacaoPedidoComportamentos { get; set; }

        public DesafioViajaNetDbContext(DbContextOptions<DesafioViajaNetDbContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CidadeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VooTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ViagemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioVooTypeConfiguration());
            modelBuilder.ApplyConfiguration(new HomeComportamentoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LandingComportamentoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CheckoutPedidoComportamentoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ConfirmacaoPedidoComportamentoTypeConfiguration());
        }

    }
}
