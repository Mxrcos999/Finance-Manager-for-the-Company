using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relacionandocategoriaecontaFinanceiraumacategoriaparamuitascontas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categoria_cf",
                table: "contasfinanceiras");

            migrationBuilder.DropIndex(
                name: "IX_contasfinanceiras_CategoriaId",
                table: "contasfinanceiras");

            migrationBuilder.CreateIndex(
                name: "IX_contasfinanceiras_CategoriaId",
                table: "contasfinanceiras",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_contasfinanceiras_categorias_CategoriaId",
                table: "contasfinanceiras",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contasfinanceiras_categorias_CategoriaId",
                table: "contasfinanceiras");

            migrationBuilder.DropIndex(
                name: "IX_contasfinanceiras_CategoriaId",
                table: "contasfinanceiras");

            migrationBuilder.CreateIndex(
                name: "IX_contasfinanceiras_CategoriaId",
                table: "contasfinanceiras",
                column: "CategoriaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_categoria_cf",
                table: "contasfinanceiras",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
