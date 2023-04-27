using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removendorelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contasfinanceiras_pessoasfisicas_PessoaFisicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropForeignKey(
                name: "FK_contasfinanceiras_pessoasjuridicas_PessoaJuridicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropIndex(
                name: "IX_contasfinanceiras_PessoaFisicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropIndex(
                name: "IX_contasfinanceiras_PessoaJuridicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropColumn(
                name: "ContaFinanceiraId",
                table: "pessoasfisicas");

            migrationBuilder.DropColumn(
                name: "PessoaFisicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropColumn(
                name: "PessoaJuridicaId",
                table: "contasfinanceiras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaFinanceiraId",
                table: "pessoasfisicas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaFisicaId",
                table: "contasfinanceiras",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaJuridicaId",
                table: "contasfinanceiras",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_contasfinanceiras_PessoaFisicaId",
                table: "contasfinanceiras",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_contasfinanceiras_PessoaJuridicaId",
                table: "contasfinanceiras",
                column: "PessoaJuridicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_contasfinanceiras_pessoasfisicas_PessoaFisicaId",
                table: "contasfinanceiras",
                column: "PessoaFisicaId",
                principalTable: "pessoasfisicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_contasfinanceiras_pessoasjuridicas_PessoaJuridicaId",
                table: "contasfinanceiras",
                column: "PessoaJuridicaId",
                principalTable: "pessoasjuridicas",
                principalColumn: "Id");
        }
    }
}
