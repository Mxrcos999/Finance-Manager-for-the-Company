using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class estruturadepessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_AspNetUsers_ApplicationUserId",
                table: "enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_telefones_AspNetUsers_ApplicationUserId",
                table: "telefones");

            migrationBuilder.DropIndex(
                name: "IX_telefones_ApplicationUserId",
                table: "telefones");

            migrationBuilder.DropIndex(
                name: "IX_enderecos_ApplicationUserId",
                table: "enderecos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "telefones");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "enderecos");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "telefones",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "enderecos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "pessoasfisicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteração = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoasfisicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pessoasjuridicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RazaoSocial = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    FaturamentoMensal = table.Column<decimal>(type: "numeric", nullable: false),
                    FaturamentoANual = table.Column<decimal>(type: "numeric", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteração = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoasjuridicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empregador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PessoaFisicaId = table.Column<int>(type: "integer", nullable: true),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteração = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empregador_pessoasfisicas_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "pessoasfisicas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<List<string>>(type: "text[]", nullable: false),
                    PessoaFisicaId = table.Column<int>(type: "integer", nullable: false),
                    PessoaJuridicaId = table.Column<int>(type: "integer", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataHoraAlteração = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pessoas_pessoasfisicas_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "pessoasfisicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pessoas_pessoasjuridicas_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "pessoasjuridicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_telefones_PessoaId",
                table: "telefones",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_PessoaId",
                table: "enderecos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PessoaId",
                table: "AspNetUsers",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empregador_PessoaFisicaId",
                table: "Empregador",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoas_PessoaFisicaId",
                table: "pessoas",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoas_PessoaJuridicaId",
                table: "pessoas",
                column: "PessoaJuridicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_pessoas_PessoaId",
                table: "AspNetUsers",
                column: "PessoaId",
                principalTable: "pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_pessoas_PessoaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_pessoas_PessoaId",
                table: "enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_telefones_pessoas_PessoaId",
                table: "telefones");

            migrationBuilder.DropTable(
                name: "Empregador");

            migrationBuilder.DropTable(
                name: "pessoas");

            migrationBuilder.DropTable(
                name: "pessoasfisicas");

            migrationBuilder.DropTable(
                name: "pessoasjuridicas");

            migrationBuilder.DropIndex(
                name: "IX_telefones_PessoaId",
                table: "telefones");

            migrationBuilder.DropIndex(
                name: "IX_enderecos_PessoaId",
                table: "enderecos");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PessoaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "telefones");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "enderecos");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "telefones",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "enderecos",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_telefones_ApplicationUserId",
                table: "telefones",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_ApplicationUserId",
                table: "enderecos",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_enderecos_AspNetUsers_ApplicationUserId",
                table: "enderecos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_telefones_AspNetUsers_ApplicationUserId",
                table: "telefones",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
