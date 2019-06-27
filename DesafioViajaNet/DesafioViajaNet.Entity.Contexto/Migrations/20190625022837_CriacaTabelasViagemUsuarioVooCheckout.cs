using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioViajaNet.Entity.Migrations
{
    public partial class CriacaTabelasViagemUsuarioVooCheckout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Codigo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "VIAGEM",
                columns: table => new
                {
                    CODIGO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrigemCodigo = table.Column<long>(nullable: false),
                    DestinoCodigo = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIAGEM", x => x.CODIGO);
                    table.ForeignKey(
                        name: "FK_VIAGENS_DESTINOS",
                        column: x => x.DestinoCodigo,
                        principalTable: "CIDADES",
                        principalColumn: "CODIGO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VIAGENS_ORIGENS",
                        column: x => x.OrigemCodigo,
                        principalTable: "CIDADES",
                        principalColumn: "CODIGO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VOO",
                columns: table => new
                {
                    CODIGO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PRECO = table.Column<decimal>(type: "decimal(15, 2)", nullable: false),
                    DATA_HORA_EMBARQUE = table.Column<DateTime>(nullable: false),
                    DATA_HORA_DESEMBARQUE = table.Column<DateTime>(nullable: false),
                    ViagemCodigo = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VOO", x => x.CODIGO);
                    table.ForeignKey(
                        name: "FK_VOOS_VIAGENS",
                        column: x => x.ViagemCodigo,
                        principalTable: "VIAGEM",
                        principalColumn: "CODIGO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHECKOUT_COMPORTAMENTO",
                columns: table => new
                {
                    CODIGO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IP = table.Column<string>(maxLength: 30, nullable: false),
                    NOME_PAGINA = table.Column<string>(maxLength: 70, nullable: false),
                    BROWSER = table.Column<string>(maxLength: 70, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 150, nullable: false),
                    VooCodigo = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHECKOUT_COMPORTAMENTO", x => x.CODIGO);
                    table.ForeignKey(
                        name: "FK_CHECKOUT_COMPORTAMENTO_VOO",
                        column: x => x.VooCodigo,
                        principalTable: "VOO",
                        principalColumn: "CODIGO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS_VOOS",
                columns: table => new
                {
                    CODIGO_USUARIO = table.Column<long>(nullable: false),
                    CODIGO_VOO = table.Column<long>(nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(15, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS_VOOS", x => new { x.CODIGO_USUARIO, x.CODIGO_VOO });
                    table.ForeignKey(
                        name: "FK_USUARIOS_USUARIOS_VOOS",
                        column: x => x.CODIGO_USUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VOOS_USUARIOS_VOOS",
                        column: x => x.CODIGO_VOO,
                        principalTable: "VOO",
                        principalColumn: "CODIGO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHECKOUT_COMPORTAMENTO_VooCodigo",
                table: "CHECKOUT_COMPORTAMENTO",
                column: "VooCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_VOOS_CODIGO_VOO",
                table: "USUARIOS_VOOS",
                column: "CODIGO_VOO");

            migrationBuilder.CreateIndex(
                name: "IX_VIAGEM_DestinoCodigo",
                table: "VIAGEM",
                column: "DestinoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_VIAGEM_OrigemCodigo",
                table: "VIAGEM",
                column: "OrigemCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_VOO_ViagemCodigo",
                table: "VOO",
                column: "ViagemCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHECKOUT_COMPORTAMENTO");

            migrationBuilder.DropTable(
                name: "USUARIOS_VOOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "VOO");

            migrationBuilder.DropTable(
                name: "VIAGEM");
        }
    }
}
