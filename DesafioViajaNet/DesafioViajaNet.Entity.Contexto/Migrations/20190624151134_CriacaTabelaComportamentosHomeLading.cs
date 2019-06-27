using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioViajaNet.Entity.Migrations
{
    public partial class CriacaTabelaComportamentosHomeLading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HOME_COMPORTAMENTO",
                columns: table => new
                {
                    CODIGO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IP = table.Column<string>(maxLength: 30, nullable: false),
                    NOME_PAGINA = table.Column<string>(maxLength: 70, nullable: false),
                    BROWSER = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOME_COMPORTAMENTO", x => x.CODIGO);
                });

            migrationBuilder.CreateTable(
                name: "LANDING_COMPORTAMENTOS",
                columns: table => new
                {
                    CODIGO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IP = table.Column<string>(maxLength: 30, nullable: false),
                    NOME_PAGINA = table.Column<string>(maxLength: 70, nullable: false),
                    BROWSER = table.Column<string>(maxLength: 70, nullable: false),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 150, nullable: false),
                    DATA_VIAGEM = table.Column<DateTime>(nullable: false),
                    DIAS_VIAGEM = table.Column<int>(maxLength: 3, nullable: false),
                    CodigoOrigem = table.Column<long>(nullable: false),
                    CodigoDestino = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANDING_COMPORTAMENTOS", x => x.CODIGO);
                    table.ForeignKey(
                        name: "FK_LANDING_CIDADES_DESTINO",
                        column: x => x.CodigoDestino,
                        principalTable: "CIDADES",
                        principalColumn: "CODIGO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LANDING_CIDADES_ORIGEM",
                        column: x => x.CodigoOrigem,
                        principalTable: "CIDADES",
                        principalColumn: "CODIGO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LANDING_COMPORTAMENTOS_CodigoDestino",
                table: "LANDING_COMPORTAMENTOS",
                column: "CodigoDestino",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LANDING_COMPORTAMENTOS_CodigoOrigem",
                table: "LANDING_COMPORTAMENTOS",
                column: "CodigoOrigem",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HOME_COMPORTAMENTO");

            migrationBuilder.DropTable(
                name: "LANDING_COMPORTAMENTOS");
        }
    }
}
