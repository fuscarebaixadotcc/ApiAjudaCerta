using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoNomeUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 145, 136, 31, 169, 236, 212, 67, 207, 52, 100, 155, 165, 176, 145, 240, 209, 199, 30, 200, 204, 24, 141, 111, 125, 48, 194, 162, 3, 242, 226, 160, 237, 248, 216, 47, 235, 155, 190, 165, 173, 233, 222, 37, 234, 65, 233, 35, 36, 238, 191, 102, 47, 221, 65, 196, 32, 82, 212, 14, 20, 232, 100, 252, 181 }, new byte[] { 172, 175, 85, 9, 172, 65, 113, 106, 129, 192, 247, 143, 200, 8, 113, 23, 83, 223, 154, 220, 204, 128, 163, 4, 175, 224, 207, 229, 255, 99, 205, 123, 76, 112, 173, 206, 176, 198, 155, 114, 160, 22, 227, 42, 224, 255, 155, 111, 55, 208, 52, 84, 22, 27, 61, 98, 95, 226, 111, 111, 53, 166, 141, 254, 95, 162, 25, 121, 213, 75, 155, 114, 35, 117, 45, 9, 215, 205, 150, 198, 200, 246, 7, 255, 115, 156, 215, 112, 168, 7, 79, 21, 25, 246, 142, 70, 37, 123, 188, 221, 203, 18, 137, 79, 132, 182, 46, 26, 196, 31, 33, 162, 25, 168, 119, 181, 241, 131, 163, 73, 73, 149, 25, 191, 238, 61, 27, 141 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Pessoa");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 20, 171, 17, 144, 85, 164, 242, 170, 69, 59, 222, 253, 247, 242, 107, 242, 200, 44, 80, 178, 149, 30, 101, 55, 67, 194, 179, 19, 244, 87, 8, 46, 162, 47, 75, 68, 28, 242, 41, 251, 176, 87, 72, 229, 201, 32, 123, 137, 133, 172, 201, 246, 238, 41, 11, 57, 250, 62, 102, 203, 215, 190, 101, 128 }, new byte[] { 158, 100, 96, 82, 122, 37, 76, 201, 32, 105, 37, 219, 51, 243, 228, 83, 8, 98, 34, 94, 160, 134, 36, 113, 175, 58, 21, 46, 151, 177, 227, 171, 132, 37, 132, 187, 171, 200, 67, 28, 201, 52, 115, 146, 156, 20, 29, 127, 152, 156, 241, 220, 201, 100, 113, 47, 247, 178, 186, 174, 145, 57, 192, 86, 26, 142, 109, 226, 42, 188, 165, 18, 175, 1, 174, 118, 144, 214, 42, 2, 103, 55, 158, 146, 112, 98, 83, 118, 216, 238, 157, 23, 119, 127, 131, 126, 245, 146, 139, 68, 191, 202, 38, 231, 78, 78, 181, 216, 238, 179, 105, 63, 149, 169, 82, 227, 127, 199, 107, 187, 66, 168, 77, 109, 123, 217, 16, 40 } });
        }
    }
}
