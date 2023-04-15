using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class atualizandotabelapessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_pessoas_PessoaFisicaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_pessoas_PessoaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_pessoas_PessoaJuridicaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Empregador_pessoas_PessoaFisicaId",
                table: "Empregador");

            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_pessoas_PessoaId",
                table: "enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_telefones_pessoas_PessoaId",
                table: "telefones");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PessoaId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pessoas",
                table: "pessoas");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "pessoas");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "pessoas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "pessoas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "pessoas");

            migrationBuilder.RenameTable(
                name: "pessoas",
                newName: "pessoasjuridicas");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "telefones",
                newName: "PessoaJuridicaId");

            migrationBuilder.RenameIndex(
                name: "IX_telefones_PessoaId",
                table: "telefones",
                newName: "IX_telefones_PessoaJuridicaId");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "enderecos",
                newName: "PessoaJuridicaId");

            migrationBuilder.RenameIndex(
                name: "IX_enderecos_PessoaId",
                table: "enderecos",
                newName: "IX_enderecos_PessoaJuridicaId");

            migrationBuilder.AddColumn<int>(
                name: "PessoaFisicaId",
                table: "telefones",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaFisicaId",
                table: "enderecos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_pessoasjuridicas",
                table: "pessoasjuridicas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "pessoasfisicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteração = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoasfisicas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_telefones_PessoaFisicaId",
                table: "telefones",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_PessoaFisicaId",
                table: "enderecos",
                column: "PessoaFisicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_pessoasfisicas_PessoaFisicaId",
                table: "AspNetUsers",
                column: "PessoaFisicaId",
                principalTable: "pessoasfisicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_pessoasjuridicas_PessoaJuridicaId",
                table: "AspNetUsers",
                column: "PessoaJuridicaId",
                principalTable: "pessoasjuridicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empregador_pessoasfisicas_PessoaFisicaId",
                table: "Empregador",
                column: "PessoaFisicaId",
                principalTable: "pessoasfisicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enderecos_pessoasfisicas_PessoaFisicaId",
                table: "enderecos",
                column: "PessoaFisicaId",
                principalTable: "pessoasfisicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enderecos_pessoasjuridicas_PessoaJuridicaId",
                table: "enderecos",
                column: "PessoaJuridicaId",
                principalTable: "pessoasjuridicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_telefones_pessoasfisicas_PessoaFisicaId",
                table: "telefones",
                column: "PessoaFisicaId",
                principalTable: "pessoasfisicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_telefones_pessoasjuridicas_PessoaJuridicaId",
                table: "telefones",
                column: "PessoaJuridicaId",
                principalTable: "pessoasjuridicas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_pessoasfisicas_PessoaFisicaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_pessoasjuridicas_PessoaJuridicaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Empregador_pessoasfisicas_PessoaFisicaId",
                table: "Empregador");

            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_pessoasfisicas_PessoaFisicaId",
                table: "enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_pessoasjuridicas_PessoaJuridicaId",
                table: "enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_telefones_pessoasfisicas_PessoaFisicaId",
                table: "telefones");

            migrationBuilder.DropForeignKey(
                name: "FK_telefones_pessoasjuridicas_PessoaJuridicaId",
                table: "telefones");

            migrationBuilder.DropTable(
                name: "pessoasfisicas");

            migrationBuilder.DropIndex(
                name: "IX_telefones_PessoaFisicaId",
                table: "telefones");

            migrationBuilder.DropIndex(
                name: "IX_enderecos_PessoaFisicaId",
                table: "enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pessoasjuridicas",
                table: "pessoasjuridicas");

            migrationBuilder.DropColumn(
                name: "PessoaFisicaId",
                table: "telefones");

            migrationBuilder.DropColumn(
                name: "PessoaFisicaId",
                table: "enderecos");

            migrationBuilder.RenameTable(
                name: "pessoasjuridicas",
                newName: "pessoas");

            migrationBuilder.RenameColumn(
                name: "PessoaJuridicaId",
                table: "telefones",
                newName: "PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_telefones_PessoaJuridicaId",
                table: "telefones",
                newName: "IX_telefones_PessoaId");

            migrationBuilder.RenameColumn(
                name: "PessoaJuridicaId",
                table: "enderecos",
                newName: "PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_enderecos_PessoaJuridicaId",
                table: "enderecos",
                newName: "IX_enderecos_PessoaId");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "pessoas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "pessoas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "pessoas",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_pessoas",
                table: "pessoas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PessoaId",
                table: "AspNetUsers",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_pessoas_PessoaFisicaId",
                table: "AspNetUsers",
                column: "PessoaFisicaId",
                principalTable: "pessoas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_pessoas_PessoaId",
                table: "AspNetUsers",
                column: "PessoaId",
                principalTable: "pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_pessoas_PessoaJuridicaId",
                table: "AspNetUsers",
                column: "PessoaJuridicaId",
                principalTable: "pessoas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empregador_pessoas_PessoaFisicaId",
                table: "Empregador",
                column: "PessoaFisicaId",
                principalTable: "pessoas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enderecos_pessoas_PessoaId",
                table: "enderecos",
                column: "PessoaId",
                principalTable: "pessoas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_telefones_pessoas_PessoaId",
                table: "telefones",
                column: "PessoaId",
                principalTable: "pessoas",
                principalColumn: "Id");
        }
    }
}
