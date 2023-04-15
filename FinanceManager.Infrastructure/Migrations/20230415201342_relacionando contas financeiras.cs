using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relacionandocontasfinanceiras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaFinanceiraId",
                table: "pessoasjuridicas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContaFinanceiraId",
                table: "pessoasfisicas",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "contasfinanceiras",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_pessoasjuridicas_ContaFinanceiraId",
                table: "pessoasjuridicas",
                column: "ContaFinanceiraId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoasfisicas_ContaFinanceiraId",
                table: "pessoasfisicas",
                column: "ContaFinanceiraId");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoasfisicas_contasfinanceiras_ContaFinanceiraId",
                table: "pessoasfisicas",
                column: "ContaFinanceiraId",
                principalTable: "contasfinanceiras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoasjuridicas_contasfinanceiras_ContaFinanceiraId",
                table: "pessoasjuridicas",
                column: "ContaFinanceiraId",
                principalTable: "contasfinanceiras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoasfisicas_contasfinanceiras_ContaFinanceiraId",
                table: "pessoasfisicas");

            migrationBuilder.DropForeignKey(
                name: "FK_pessoasjuridicas_contasfinanceiras_ContaFinanceiraId",
                table: "pessoasjuridicas");

            migrationBuilder.DropIndex(
                name: "IX_pessoasjuridicas_ContaFinanceiraId",
                table: "pessoasjuridicas");

            migrationBuilder.DropIndex(
                name: "IX_pessoasfisicas_ContaFinanceiraId",
                table: "pessoasfisicas");

            migrationBuilder.DropColumn(
                name: "ContaFinanceiraId",
                table: "pessoasjuridicas");

            migrationBuilder.DropColumn(
                name: "ContaFinanceiraId",
                table: "pessoasfisicas");

            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "contasfinanceiras");
        }
    }
}
