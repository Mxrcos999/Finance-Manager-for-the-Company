using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adicionandosaldonatabelausuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaldoAtual",
                table: "contasfinanceiras");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorLancamento",
                table: "contasfinanceiras",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "AspNetUsers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorLancamento",
                table: "contasfinanceiras",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoAtual",
                table: "contasfinanceiras",
                type: "numeric",
                nullable: true);
        }
    }
}
