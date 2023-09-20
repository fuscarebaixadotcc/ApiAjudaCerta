using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoItemDoacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemDoacaoId",
                table: "Roupa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemDoacaoId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemDoacaoId",
                table: "Mobilia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemDoacaoId",
                table: "Eletrodomestico",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roupa_ItemDoacaoId",
                table: "Roupa",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ItemDoacaoId",
                table: "Produto",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobilia_ItemDoacaoId",
                table: "Mobilia",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eletrodomestico_ItemDoacaoId",
                table: "Eletrodomestico",
                column: "ItemDoacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eletrodomestico_ItemDoacao_ItemDoacaoId",
                table: "Eletrodomestico",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobilia_ItemDoacao_ItemDoacaoId",
                table: "Mobilia",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_ItemDoacao_ItemDoacaoId",
                table: "Produto",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roupa_ItemDoacao_ItemDoacaoId",
                table: "Roupa",
                column: "ItemDoacaoId",
                principalTable: "ItemDoacao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eletrodomestico_ItemDoacao_ItemDoacaoId",
                table: "Eletrodomestico");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobilia_ItemDoacao_ItemDoacaoId",
                table: "Mobilia");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_ItemDoacao_ItemDoacaoId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Roupa_ItemDoacao_ItemDoacaoId",
                table: "Roupa");

            migrationBuilder.DropIndex(
                name: "IX_Roupa_ItemDoacaoId",
                table: "Roupa");

            migrationBuilder.DropIndex(
                name: "IX_Produto_ItemDoacaoId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Mobilia_ItemDoacaoId",
                table: "Mobilia");

            migrationBuilder.DropIndex(
                name: "IX_Eletrodomestico_ItemDoacaoId",
                table: "Eletrodomestico");

            migrationBuilder.DropColumn(
                name: "ItemDoacaoId",
                table: "Roupa");

            migrationBuilder.DropColumn(
                name: "ItemDoacaoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ItemDoacaoId",
                table: "Mobilia");

            migrationBuilder.DropColumn(
                name: "ItemDoacaoId",
                table: "Eletrodomestico");
        }
    }
}
