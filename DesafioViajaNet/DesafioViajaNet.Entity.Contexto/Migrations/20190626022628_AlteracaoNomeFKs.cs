using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioViajaNet.Entity.Migrations
{
    public partial class AlteracaoNomeFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ViagemCodigo",
                table: "VOO",
                newName: "CODIGO_VIAGEM");

            migrationBuilder.RenameIndex(
                name: "IX_VOO_ViagemCodigo",
                table: "VOO",
                newName: "IX_VOO_CODIGO_VIAGEM");

            migrationBuilder.RenameColumn(
                name: "OrigemCodigo",
                table: "VIAGEM",
                newName: "CODIGO_ORIGEM");

            migrationBuilder.RenameColumn(
                name: "DestinoCodigo",
                table: "VIAGEM",
                newName: "CODIGO_DESTINO");

            migrationBuilder.RenameIndex(
                name: "IX_VIAGEM_OrigemCodigo",
                table: "VIAGEM",
                newName: "IX_VIAGEM_CODIGO_ORIGEM");

            migrationBuilder.RenameIndex(
                name: "IX_VIAGEM_DestinoCodigo",
                table: "VIAGEM",
                newName: "IX_VIAGEM_CODIGO_DESTINO");

            migrationBuilder.RenameColumn(
                name: "CodigoOrigem",
                table: "LANDING_COMPORTAMENTOS",
                newName: "CODIGO_ORIGEM");

            migrationBuilder.RenameColumn(
                name: "CodigoDestino",
                table: "LANDING_COMPORTAMENTOS",
                newName: "CODIGO_DESTINO");

            migrationBuilder.RenameIndex(
                name: "IX_LANDING_COMPORTAMENTOS_CodigoOrigem",
                table: "LANDING_COMPORTAMENTOS",
                newName: "IX_LANDING_COMPORTAMENTOS_CODIGO_ORIGEM");

            migrationBuilder.RenameIndex(
                name: "IX_LANDING_COMPORTAMENTOS_CodigoDestino",
                table: "LANDING_COMPORTAMENTOS",
                newName: "IX_LANDING_COMPORTAMENTOS_CODIGO_DESTINO");

            migrationBuilder.RenameColumn(
                name: "EstadoCodigo",
                table: "CIDADES",
                newName: "CODIGO_ESTADO");

            migrationBuilder.RenameIndex(
                name: "IX_CIDADES_EstadoCodigo",
                table: "CIDADES",
                newName: "IX_CIDADES_CODIGO_ESTADO");

            migrationBuilder.RenameColumn(
                name: "VooCodigo",
                table: "CHECKOUT_COMPORTAMENTO",
                newName: "CODIGO_VOO");

            migrationBuilder.RenameIndex(
                name: "IX_CHECKOUT_COMPORTAMENTO_VooCodigo",
                table: "CHECKOUT_COMPORTAMENTO",
                newName: "IX_CHECKOUT_COMPORTAMENTO_CODIGO_VOO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CODIGO_VIAGEM",
                table: "VOO",
                newName: "ViagemCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_VOO_CODIGO_VIAGEM",
                table: "VOO",
                newName: "IX_VOO_ViagemCodigo");

            migrationBuilder.RenameColumn(
                name: "CODIGO_ORIGEM",
                table: "VIAGEM",
                newName: "OrigemCodigo");

            migrationBuilder.RenameColumn(
                name: "CODIGO_DESTINO",
                table: "VIAGEM",
                newName: "DestinoCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_VIAGEM_CODIGO_ORIGEM",
                table: "VIAGEM",
                newName: "IX_VIAGEM_OrigemCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_VIAGEM_CODIGO_DESTINO",
                table: "VIAGEM",
                newName: "IX_VIAGEM_DestinoCodigo");

            migrationBuilder.RenameColumn(
                name: "CODIGO_ORIGEM",
                table: "LANDING_COMPORTAMENTOS",
                newName: "CodigoOrigem");

            migrationBuilder.RenameColumn(
                name: "CODIGO_DESTINO",
                table: "LANDING_COMPORTAMENTOS",
                newName: "CodigoDestino");

            migrationBuilder.RenameIndex(
                name: "IX_LANDING_COMPORTAMENTOS_CODIGO_ORIGEM",
                table: "LANDING_COMPORTAMENTOS",
                newName: "IX_LANDING_COMPORTAMENTOS_CodigoOrigem");

            migrationBuilder.RenameIndex(
                name: "IX_LANDING_COMPORTAMENTOS_CODIGO_DESTINO",
                table: "LANDING_COMPORTAMENTOS",
                newName: "IX_LANDING_COMPORTAMENTOS_CodigoDestino");

            migrationBuilder.RenameColumn(
                name: "CODIGO_ESTADO",
                table: "CIDADES",
                newName: "EstadoCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_CIDADES_CODIGO_ESTADO",
                table: "CIDADES",
                newName: "IX_CIDADES_EstadoCodigo");

            migrationBuilder.RenameColumn(
                name: "CODIGO_VOO",
                table: "CHECKOUT_COMPORTAMENTO",
                newName: "VooCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_CHECKOUT_COMPORTAMENTO_CODIGO_VOO",
                table: "CHECKOUT_COMPORTAMENTO",
                newName: "IX_CHECKOUT_COMPORTAMENTO_VooCodigo");
        }
    }
}
