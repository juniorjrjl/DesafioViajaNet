﻿// <auto-generated />
using System;
using DesafioViajaNet.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioViajaNet.Entity.Migrations
{
    [DbContext(typeof(DesafioViajaNetDbContext))]
    partial class DesafioViajaNetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesafioViajaNet.Dominio.CheckoutPedidoComportamento", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CODIGO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Browser")
                        .IsRequired()
                        .HasColumnName("BROWSER")
                        .HasMaxLength(70);

                    b.Property<long>("CodigoVoo")
                        .HasColumnName("CODIGO_VOO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(150);

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnName("IP")
                        .HasMaxLength(30);

                    b.Property<string>("NomePagina")
                        .IsRequired()
                        .HasColumnName("NOME_PAGINA")
                        .HasMaxLength(70);

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoVoo");

                    b.ToTable("CHECKOUT_COMPORTAMENTO");
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.Cidade", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CODIGO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CodigoEstado")
                        .HasColumnName("CODIGO_ESTADO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DESCRICAO")
                        .HasMaxLength(150);

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoEstado");

                    b.ToTable("CIDADES");
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.ConfirmacaoPedidoComportamento", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CODIGO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Browser")
                        .IsRequired()
                        .HasColumnName("BROWSER")
                        .HasMaxLength(70);

                    b.Property<long>("CodigoVoo")
                        .HasColumnName("CODIGO_VOO");

                    b.Property<bool>("Confirmou")
                        .HasColumnName("CONFIRMOU");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(150);

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnName("IP")
                        .HasMaxLength(30);

                    b.Property<string>("NomePagina")
                        .IsRequired()
                        .HasColumnName("NOME_PAGINA")
                        .HasMaxLength(70);

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoVoo");

                    b.ToTable("CONFIRMACAO_PEDIDO_COMPORTAMENTO");
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.Estado", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CODIGO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DESCRICAO")
                        .HasMaxLength(150);

                    b.HasKey("Codigo");

                    b.ToTable("ESTADOS");
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.HomeComportamento", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CODIGO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Browser")
                        .IsRequired()
                        .HasColumnName("BROWSER")
                        .HasMaxLength(70);

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnName("IP")
                        .HasMaxLength(30);

                    b.Property<string>("NomePagina")
                        .IsRequired()
                        .HasColumnName("NOME_PAGINA")
                        .HasMaxLength(70);

                    b.HasKey("Codigo");

                    b.ToTable("HOME_COMPORTAMENTO");
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.LandingComportamento", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CODIGO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Browser")
                        .IsRequired()
                        .HasColumnName("BROWSER")
                        .HasMaxLength(70);

                    b.Property<long>("CodigoDestino")
                        .HasColumnName("CODIGO_DESTINO");

                    b.Property<long>("CodigoOrigem")
                        .HasColumnName("CODIGO_ORIGEM");

                    b.Property<DateTime>("DataViagem")
                        .HasColumnName("DATA_VIAGEM");

                    b.Property<int>("DiasVagem")
                        .HasColumnName("DIAS_VIAGEM")
                        .HasMaxLength(3);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(150);

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnName("IP")
                        .HasMaxLength(30);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasMaxLength(150);

                    b.Property<string>("NomePagina")
                        .IsRequired()
                        .HasColumnName("NOME_PAGINA")
                        .HasMaxLength(70);

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoDestino")
                        .IsUnique();

                    b.HasIndex("CodigoOrigem")
                        .IsUnique();

                    b.ToTable("LANDING_COMPORTAMENTOS");
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.Usuario", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(150);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasMaxLength(150);

                    b.HasKey("Codigo");

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.UsuarioVoo", b =>
                {
                    b.Property<long>("CodigoUsuario")
                        .HasColumnName("CODIGO_USUARIO");

                    b.Property<long>("CodigoVoo")
                        .HasColumnName("CODIGO_VOO");

                    b.Property<decimal>("Preco")
                        .HasColumnName("PRECO")
                        .HasColumnType("decimal(15, 2)");

                    b.HasKey("CodigoUsuario", "CodigoVoo");

                    b.HasIndex("CodigoVoo");

                    b.ToTable("USUARIOS_VOOS");
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.Viagem", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CODIGO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CodigoDestino")
                        .HasColumnName("CODIGO_DESTINO");

                    b.Property<long>("CodigoOrigem")
                        .HasColumnName("CODIGO_ORIGEM");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoDestino");

                    b.HasIndex("CodigoOrigem");

                    b.ToTable("VIAGEM");
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.Voo", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CODIGO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CodigoViagem")
                        .HasColumnName("CODIGO_VIAGEM");

                    b.Property<DateTime>("DataHoraDesembarque")
                        .HasColumnName("DATA_HORA_DESEMBARQUE");

                    b.Property<DateTime>("DataHoraEmbarque")
                        .HasColumnName("DATA_HORA_EMBARQUE");

                    b.Property<decimal>("Preco")
                        .HasColumnName("PRECO")
                        .HasColumnType("decimal(15, 2)");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoViagem");

                    b.ToTable("VOO");
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.CheckoutPedidoComportamento", b =>
                {
                    b.HasOne("DesafioViajaNet.Dominio.Voo", "Voo")
                        .WithMany("CheckoutPedidoComportamentos")
                        .HasForeignKey("CodigoVoo")
                        .HasConstraintName("FK_CHECKOUT_COMPORTAMENTO_VOO")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.Cidade", b =>
                {
                    b.HasOne("DesafioViajaNet.Dominio.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("CodigoEstado")
                        .HasConstraintName("FK_CIDADES_ESTADOS")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.ConfirmacaoPedidoComportamento", b =>
                {
                    b.HasOne("DesafioViajaNet.Dominio.Voo", "Voo")
                        .WithMany("ConfirmacaoPedidoComportamentos")
                        .HasForeignKey("CodigoVoo")
                        .HasConstraintName("FK_PEDIDO_COMPORTAMENTO_VOO")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.LandingComportamento", b =>
                {
                    b.HasOne("DesafioViajaNet.Dominio.Cidade", "Destino")
                        .WithOne("LandingComportamentoDestino")
                        .HasForeignKey("DesafioViajaNet.Dominio.LandingComportamento", "CodigoDestino")
                        .HasConstraintName("FK_LANDING_CIDADES_DESTINO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DesafioViajaNet.Dominio.Cidade", "Origem")
                        .WithOne("LandingComportamentoOrigem")
                        .HasForeignKey("DesafioViajaNet.Dominio.LandingComportamento", "CodigoOrigem")
                        .HasConstraintName("FK_LANDING_CIDADES_ORIGEM")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.UsuarioVoo", b =>
                {
                    b.HasOne("DesafioViajaNet.Dominio.Usuario", "Usuario")
                        .WithMany("UsuariosVoos")
                        .HasForeignKey("CodigoUsuario")
                        .HasConstraintName("FK_USUARIOS_USUARIOS_VOOS")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DesafioViajaNet.Dominio.Voo", "Voo")
                        .WithMany("UsuariosVoos")
                        .HasForeignKey("CodigoVoo")
                        .HasConstraintName("FK_VOOS_USUARIOS_VOOS")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.Viagem", b =>
                {
                    b.HasOne("DesafioViajaNet.Dominio.Cidade", "Destino")
                        .WithMany("Destinos")
                        .HasForeignKey("CodigoDestino")
                        .HasConstraintName("FK_VIAGENS_DESTINOS")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DesafioViajaNet.Dominio.Cidade", "Origem")
                        .WithMany("Origens")
                        .HasForeignKey("CodigoOrigem")
                        .HasConstraintName("FK_VIAGENS_ORIGENS")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DesafioViajaNet.Dominio.Voo", b =>
                {
                    b.HasOne("DesafioViajaNet.Dominio.Viagem", "Viagem")
                        .WithMany("Voos")
                        .HasForeignKey("CodigoViagem")
                        .HasConstraintName("FK_VOOS_VIAGENS")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
