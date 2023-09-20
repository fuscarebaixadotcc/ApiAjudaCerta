using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoItemDoacaoDoado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemDoacaoDoado",
                columns: table => new
                {
                    DoacaoId = table.Column<int>(type: "int", nullable: false),
                    ItemDoacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDoacaoDoado", x => new { x.DoacaoId, x.ItemDoacaoId });
                    table.ForeignKey(
                        name: "FK_ItemDoacaoDoado_Doacao_DoacaoId",
                        column: x => x.DoacaoId,
                        principalTable: "Doacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDoacaoDoado_ItemDoacao_ItemDoacaoId",
                        column: x => x.ItemDoacaoId,
                        principalTable: "ItemDoacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDoacaoDoado_ItemDoacaoId",
                table: "ItemDoacaoDoado",
                column: "ItemDoacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDoacaoDoado");
        }
    }
}
