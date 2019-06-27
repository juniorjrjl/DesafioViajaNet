using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioViajaNet.Entity.Migrations
{
    public partial class CriacaoTableConfirmacaoPedidoComportamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONFIRMACAO_PEDIDO_COMPORTAMENTO",
                columns: table => new
                {
                    CODIGO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IP = table.Column<string>(maxLength: 30, nullable: false),
                    NOME_PAGINA = table.Column<string>(maxLength: 70, nullable: false),
                    BROWSER = table.Column<string>(maxLength: 70, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 150, nullable: false),
                    CODIGO_VOO = table.Column<long>(nullable: false),
                    CONFIRMOU = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONFIRMACAO_PEDIDO_COMPORTAMENTO", x => x.CODIGO);
                    table.ForeignKey(
                        name: "FK_PEDIDO_COMPORTAMENTO_VOO",
                        column: x => x.CODIGO_VOO,
                        principalTable: "VOO",
                        principalColumn: "CODIGO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONFIRMACAO_PEDIDO_COMPORTAMENTO_CODIGO_VOO",
                table: "CONFIRMACAO_PEDIDO_COMPORTAMENTO",
                column: "CODIGO_VOO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONFIRMACAO_PEDIDO_COMPORTAMENTO");
        }
    }
}
