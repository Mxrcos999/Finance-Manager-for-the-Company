using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mapeandocategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contasfinanceiras_categorias_CategoriasId",
                table: "contasfinanceiras");

            migrationBuilder.DropIndex(
                name: "IX_contasfinanceiras_CategoriasId",
                table: "contasfinanceiras");

            migrationBuilder.RenameColumn(
                name: "CategoriasId",
                table: "contasfinanceiras",
                newName: "CategoriaId");

            migrationBuilder.AddColumn<int>(
                name: "ContaFinanceiraId",
                table: "categorias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categoria_cf",
                table: "contasfinanceiras");

            migrationBuilder.DropIndex(
                name: "IX_contasfinanceiras_CategoriaId",
                table: "contasfinanceiras");

            migrationBuilder.DropColumn(
                name: "ContaFinanceiraId",
                table: "categorias");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "contasfinanceiras",
                newName: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_contasfinanceiras_CategoriasId",
                table: "contasfinanceiras",
                column: "CategoriasId");

            migrationBuilder.AddForeignKey(
                name: "FK_contasfinanceiras_categorias_CategoriasId",
                table: "contasfinanceiras",
                column: "CategoriasId",
                principalTable: "categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
