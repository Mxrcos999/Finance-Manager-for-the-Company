using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Tornandoendereçoopcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contasfinanceiras_categorias_CategoriaId",
                table: "contasfinanceiras");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "contasfinanceiras",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_contasfinanceiras_categorias_CategoriaId",
                table: "contasfinanceiras",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contasfinanceiras_categorias_CategoriaId",
                table: "contasfinanceiras");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "contasfinanceiras",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_contasfinanceiras_categorias_CategoriaId",
                table: "contasfinanceiras",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
