using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Senha_Hash", "Senha_Salt", "UltimoAcesso" },
                values: new object[] { 1, "fuscatcc@gmail.com", new byte[] { 67, 44, 60, 149, 80, 128, 253, 216, 0, 105, 227, 178, 243, 221, 29, 159, 48, 241, 21, 224, 0, 141, 17, 145, 43, 56, 247, 137, 153, 195, 84, 122, 250, 200, 203, 104, 109, 27, 134, 190, 154, 78, 152, 63, 20, 126, 53, 45, 111, 253, 157, 99, 46, 57, 239, 226, 16, 90, 179, 254, 13, 176, 232, 187 }, new byte[] { 195, 49, 183, 41, 236, 12, 228, 95, 109, 188, 247, 62, 69, 246, 96, 111, 188, 255, 200, 94, 194, 55, 57, 63, 94, 127, 190, 230, 223, 221, 194, 80, 99, 215, 196, 209, 87, 163, 145, 226, 180, 100, 137, 13, 131, 240, 45, 9, 24, 176, 98, 252, 219, 193, 150, 148, 71, 216, 233, 255, 2, 183, 242, 203, 228, 0, 250, 93, 173, 195, 3, 219, 70, 234, 177, 207, 119, 212, 20, 12, 139, 250, 36, 135, 210, 196, 113, 203, 27, 21, 95, 223, 18, 137, 123, 32, 6, 55, 201, 11, 45, 154, 56, 223, 15, 159, 9, 230, 54, 59, 57, 96, 186, 30, 200, 19, 78, 38, 232, 252, 110, 154, 88, 90, 86, 58, 30, 210 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
