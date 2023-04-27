using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mudandomapeamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_conta_financeira_pf_id",
                table: "contasfinanceiras");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaFisicaId",
                table: "contasfinanceiras",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_conta_financeira_pf_id",
                table: "contasfinanceiras",
                column: "PessoaFisicaId",
                principalTable: "pessoasfisicas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_conta_financeira_pf_id",
                table: "contasfinanceiras");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaFisicaId",
                table: "contasfinanceiras",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_conta_financeira_pf_id",
                table: "contasfinanceiras",
                column: "PessoaFisicaId",
                principalTable: "pessoasfisicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
