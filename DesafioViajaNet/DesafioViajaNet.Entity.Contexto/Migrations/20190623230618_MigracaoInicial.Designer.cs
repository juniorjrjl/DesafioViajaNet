﻿// <auto-generated />
using DesafioViajaNet.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioViajaNet.Entity.Migrations
{
    [DbContext(typeof(DesafioViajaNetDbContext))]
    [Migration("20190623230618_MigracaoInicial")]
    partial class MigracaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesafioViajaNet.Dominio.Cidade", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CODIGO")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DESCRICAO")
                        .HasMaxLength(150);

                    b.Property<long>("EstadoCodigo");

                    b.HasKey("Codigo");

                    b.HasIndex("EstadoCodigo");

                    b.ToTable("CIDADES");
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

            modelBuilder.Entity("DesafioViajaNet.Dominio.Cidade", b =>
                {
                    b.HasOne("DesafioViajaNet.Dominio.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoCodigo")
                        .HasConstraintName("FK_CIDADES_ESTADOS")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
