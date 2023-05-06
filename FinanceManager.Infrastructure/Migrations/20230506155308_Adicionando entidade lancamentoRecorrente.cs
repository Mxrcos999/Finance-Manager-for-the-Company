using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoentidadelancamentoRecorrente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "categorias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "lancamentosrecorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ValorLancamento = table.Column<decimal>(type: "numeric", nullable: false),
                    DataPrevistaLancamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TipoLancamento = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<string>(type: "text", nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteração = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamentosrecorrentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lancamentosrecorrentes_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lancamentosrecorrentes_categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categorias_UsuarioId",
                table: "categorias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_lancamentosrecorrentes_CategoriaId",
                table: "lancamentosrecorrentes",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_lancamentosrecorrentes_UsuarioId",
                table: "lancamentosrecorrentes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_categorias_AspNetUsers_UsuarioId",
                table: "categorias",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categorias_AspNetUsers_UsuarioId",
                table: "categorias");

            migrationBuilder.DropTable(
                name: "lancamentosrecorrentes");

            migrationBuilder.DropIndex(
                name: "IX_categorias_UsuarioId",
                table: "categorias");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "categorias");
        }
    }
}
