using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mapeandocontafinanceiracomusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_conta_financeira_pf_id",
                table: "contasfinanceiras");

            migrationBuilder.DropForeignKey(
                name: "fk_conta_financeira_pj_id",
                table: "contasfinanceiras");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "contasfinanceiras",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_contasfinanceiras_UsuarioId",
                table: "contasfinanceiras",
                column: "UsuarioId");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_conta_financeira_user_id",
                table: "contasfinanceiras",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contasfinanceiras_pessoasfisicas_PessoaFisicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropForeignKey(
                name: "FK_contasfinanceiras_pessoasjuridicas_PessoaJuridicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropForeignKey(
                name: "fk_conta_financeira_user_id",
                table: "contasfinanceiras");

            migrationBuilder.DropIndex(
                name: "IX_contasfinanceiras_UsuarioId",
                table: "contasfinanceiras");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "contasfinanceiras");

            migrationBuilder.AddForeignKey(
                name: "fk_conta_financeira_pf_id",
                table: "contasfinanceiras",
                column: "PessoaFisicaId",
                principalTable: "pessoasfisicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "fk_conta_financeira_pj_id",
                table: "contasfinanceiras",
                column: "PessoaJuridicaId",
                principalTable: "pessoasjuridicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
