using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mudandoentidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoasfisicas_contasfinanceiras_ContaFinanceiraId",
                table: "pessoasfisicas");

            migrationBuilder.DropForeignKey(
                name: "FK_pessoasjuridicas_contasfinanceiras_ContaFinanceiraId",
                table: "pessoasjuridicas");

            migrationBuilder.DropTable(
                name: "entradas");

            migrationBuilder.DropTable(
                name: "saidas");

            migrationBuilder.DropIndex(
                name: "IX_pessoasjuridicas_ContaFinanceiraId",
                table: "pessoasjuridicas");

            migrationBuilder.DropIndex(
                name: "IX_pessoasfisicas_ContaFinanceiraId",
                table: "pessoasfisicas");

            migrationBuilder.DropColumn(
                name: "ContaFinanceiraId",
                table: "pessoasjuridicas");

            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "contasfinanceiras",
                newName: "ValorLancamento");

            migrationBuilder.AddColumn<int>(
                name: "CategoriasId",
                table: "contasfinanceiras",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datalancamento",
                table: "contasfinanceiras",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PessoaFisicaId",
                table: "contasfinanceiras",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaJuridicaId",
                table: "contasfinanceiras",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoAtual",
                table: "contasfinanceiras",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoLancamento",
                table: "contasfinanceiras",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_contasfinanceiras_CategoriasId",
                table: "contasfinanceiras",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_contasfinanceiras_PessoaFisicaId",
                table: "contasfinanceiras",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_contasfinanceiras_PessoaJuridicaId",
                table: "contasfinanceiras",
                column: "PessoaJuridicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_contasfinanceiras_categorias_CategoriasId",
                table: "contasfinanceiras",
                column: "CategoriasId",
                principalTable: "categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_conta_financeira_pf_id",
                table: "contasfinanceiras",
                column: "PessoaFisicaId",
                principalTable: "pessoasfisicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_conta_financeira_pj_id",
                table: "contasfinanceiras",
                column: "PessoaJuridicaId",
                principalTable: "pessoasjuridicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contasfinanceiras_categorias_CategoriasId",
                table: "contasfinanceiras");

            migrationBuilder.DropForeignKey(
                name: "fk_conta_financeira_pf_id",
                table: "contasfinanceiras");

            migrationBuilder.DropForeignKey(
                name: "fk_conta_financeira_pj_id",
                table: "contasfinanceiras");

            migrationBuilder.DropIndex(
                name: "IX_contasfinanceiras_CategoriasId",
                table: "contasfinanceiras");

            migrationBuilder.DropIndex(
                name: "IX_contasfinanceiras_PessoaFisicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropIndex(
                name: "IX_contasfinanceiras_PessoaJuridicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropColumn(
                name: "CategoriasId",
                table: "contasfinanceiras");

            migrationBuilder.DropColumn(
                name: "Datalancamento",
                table: "contasfinanceiras");

            migrationBuilder.DropColumn(
                name: "PessoaFisicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropColumn(
                name: "PessoaJuridicaId",
                table: "contasfinanceiras");

            migrationBuilder.DropColumn(
                name: "SaldoAtual",
                table: "contasfinanceiras");

            migrationBuilder.DropColumn(
                name: "TipoLancamento",
                table: "contasfinanceiras");

            migrationBuilder.RenameColumn(
                name: "ValorLancamento",
                table: "contasfinanceiras",
                newName: "Saldo");

            migrationBuilder.AddColumn<int>(
                name: "ContaFinanceiraId",
                table: "pessoasjuridicas",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "entradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoriasId = table.Column<int>(type: "integer", nullable: false),
                    ContaFinanceiraId = table.Column<int>(type: "integer", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteração = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entradas_categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entradas_contasfinanceiras_ContaFinanceiraId",
                        column: x => x.ContaFinanceiraId,
                        principalTable: "contasfinanceiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "saidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoriasId = table.Column<int>(type: "integer", nullable: false),
                    ContaFinanceiraId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraAlteração = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_saidas_categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_saidas_contasfinanceiras_ContaFinanceiraId",
                        column: x => x.ContaFinanceiraId,
                        principalTable: "contasfinanceiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pessoasjuridicas_ContaFinanceiraId",
                table: "pessoasjuridicas",
                column: "ContaFinanceiraId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoasfisicas_ContaFinanceiraId",
                table: "pessoasfisicas",
                column: "ContaFinanceiraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entradas_CategoriasId",
                table: "entradas",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_entradas_ContaFinanceiraId",
                table: "entradas",
                column: "ContaFinanceiraId");

            migrationBuilder.CreateIndex(
                name: "IX_saidas_CategoriasId",
                table: "saidas",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_saidas_ContaFinanceiraId",
                table: "saidas",
                column: "ContaFinanceiraId");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoasfisicas_contasfinanceiras_ContaFinanceiraId",
                table: "pessoasfisicas",
                column: "ContaFinanceiraId",
                principalTable: "contasfinanceiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pessoasjuridicas_contasfinanceiras_ContaFinanceiraId",
                table: "pessoasjuridicas",
                column: "ContaFinanceiraId",
                principalTable: "contasfinanceiras",
                principalColumn: "Id");
        }
    }
}
