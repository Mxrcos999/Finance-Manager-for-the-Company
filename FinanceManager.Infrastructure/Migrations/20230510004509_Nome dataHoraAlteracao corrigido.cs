using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NomedataHoraAlteracaocorrigido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHoraAlteração",
                table: "telefones",
                newName: "DataHoraAlteracao");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteração",
                table: "lancamentosrecorrentes",
                newName: "DataHoraAlteracao");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteração",
                table: "historico",
                newName: "DataHoraAlteracao");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteração",
                table: "enderecos",
                newName: "DataHoraAlteracao");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteração",
                table: "Empregador",
                newName: "DataHoraAlteracao");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteração",
                table: "categorias",
                newName: "DataHoraAlteracao");

            migrationBuilder.AddColumn<string>(
                name: "TituloLancamentoRecorrente",
                table: "lancamentosrecorrentes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TituloLancamentoRecorrente",
                table: "lancamentosrecorrentes");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteracao",
                table: "telefones",
                newName: "DataHoraAlteração");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteracao",
                table: "lancamentosrecorrentes",
                newName: "DataHoraAlteração");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteracao",
                table: "historico",
                newName: "DataHoraAlteração");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteracao",
                table: "enderecos",
                newName: "DataHoraAlteração");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteracao",
                table: "Empregador",
                newName: "DataHoraAlteração");

            migrationBuilder.RenameColumn(
                name: "DataHoraAlteracao",
                table: "categorias",
                newName: "DataHoraAlteração");
        }
    }
}
