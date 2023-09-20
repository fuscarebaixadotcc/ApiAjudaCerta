using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoAgenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Agenda",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Agenda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_EnderecoId",
                table: "Agenda",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PessoaId",
                table: "Agenda",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Endereco_EnderecoId",
                table: "Agenda",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Pessoa_PessoaId",
                table: "Agenda",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Endereco_EnderecoId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Pessoa_PessoaId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_EnderecoId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_PessoaId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Agenda");
        }
    }
}
