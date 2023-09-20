using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoDoacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgendaId",
                table: "Doacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DinheiroId",
                table: "Doacao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Doacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_AgendaId",
                table: "Doacao",
                column: "AgendaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_DinheiroId",
                table: "Doacao",
                column: "DinheiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_PessoaId",
                table: "Doacao",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Agenda_AgendaId",
                table: "Doacao",
                column: "AgendaId",
                principalTable: "Agenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Dinheiro_DinheiroId",
                table: "Doacao",
                column: "DinheiroId",
                principalTable: "Dinheiro",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doacao_Pessoa_PessoaId",
                table: "Doacao",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Agenda_AgendaId",
                table: "Doacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Dinheiro_DinheiroId",
                table: "Doacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacao_Pessoa_PessoaId",
                table: "Doacao");

            migrationBuilder.DropIndex(
                name: "IX_Doacao_AgendaId",
                table: "Doacao");

            migrationBuilder.DropIndex(
                name: "IX_Doacao_DinheiroId",
                table: "Doacao");

            migrationBuilder.DropIndex(
                name: "IX_Doacao_PessoaId",
                table: "Doacao");

            migrationBuilder.DropColumn(
                name: "AgendaId",
                table: "Doacao");

            migrationBuilder.DropColumn(
                name: "DinheiroId",
                table: "Doacao");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Doacao");
        }
    }
}
