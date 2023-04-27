using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relacionandocontasfinanceirascomentradasesaidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entradas_contasfinanceiras_ContaFinanceiraId",
                table: "entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_saidas_contasfinanceiras_ContaFinanceiraId",
                table: "saidas");

            migrationBuilder.DropIndex(
                name: "IX_saidas_ContaFinanceiraId",
                table: "saidas");

            migrationBuilder.DropIndex(
                name: "IX_entradas_ContaFinanceiraId",
                table: "entradas");

            migrationBuilder.DropColumn(
                name: "ContaFinanceiraId",
                table: "saidas");

            migrationBuilder.DropColumn(
                name: "ContaFinanceiraId",
                table: "entradas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "saidas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "entradas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_entradas_contasfinanceiras_Id",
                table: "entradas",
                column: "Id",
                principalTable: "contasfinanceiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_saidas_contasfinanceiras_Id",
                table: "saidas",
                column: "Id",
                principalTable: "contasfinanceiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entradas_contasfinanceiras_Id",
                table: "entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_saidas_contasfinanceiras_Id",
                table: "saidas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "saidas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ContaFinanceiraId",
                table: "saidas",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "entradas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ContaFinanceiraId",
                table: "entradas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_saidas_ContaFinanceiraId",
                table: "saidas",
                column: "ContaFinanceiraId");

            migrationBuilder.CreateIndex(
                name: "IX_entradas_ContaFinanceiraId",
                table: "entradas",
                column: "ContaFinanceiraId");

            migrationBuilder.AddForeignKey(
                name: "FK_entradas_contasfinanceiras_ContaFinanceiraId",
                table: "entradas",
                column: "ContaFinanceiraId",
                principalTable: "contasfinanceiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_saidas_contasfinanceiras_ContaFinanceiraId",
                table: "saidas",
                column: "ContaFinanceiraId",
                principalTable: "contasfinanceiras",
                principalColumn: "Id");
        }
    }
}
