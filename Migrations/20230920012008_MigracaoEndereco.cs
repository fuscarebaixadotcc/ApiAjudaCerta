using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Pessoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EnderecoId",
                table: "Pessoa",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Endereco_EnderecoId",
                table: "Pessoa",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Endereco_EnderecoId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_EnderecoId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Pessoa");
        }
    }
}
