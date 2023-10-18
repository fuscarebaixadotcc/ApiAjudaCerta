using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoEnderecoOng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "Id", "Bairro", "Bloco", "Cep", "Cidade", "Complemento", "Estado", "Numero", "Rua" },
                values: new object[] { 1, "Jardim Tremembé", null, "02319000", "São Paulo", null, "São Paulo", "1091", "Avenida Josino Vieira de Goes" });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 84, 175, 188, 117, 6, 62, 165, 169, 48, 118, 188, 28, 83, 234, 91, 27, 142, 0, 13, 65, 159, 40, 144, 138, 97, 92, 185, 34, 4, 39, 158, 248, 136, 21, 182, 199, 158, 190, 43, 16, 65, 232, 32, 116, 189, 65, 48, 166, 108, 114, 244, 111, 188, 158, 221, 177, 9, 101, 59, 208, 200, 158, 205, 11 }, new byte[] { 119, 64, 73, 141, 167, 248, 120, 60, 15, 230, 156, 77, 38, 236, 31, 30, 65, 192, 102, 10, 16, 216, 9, 125, 116, 61, 199, 189, 96, 239, 0, 107, 0, 112, 130, 30, 239, 242, 193, 137, 255, 128, 199, 223, 200, 99, 113, 173, 231, 144, 217, 231, 55, 62, 1, 173, 76, 220, 163, 37, 35, 248, 55, 116, 37, 176, 52, 125, 234, 243, 14, 149, 195, 118, 187, 6, 216, 228, 10, 150, 70, 240, 15, 203, 64, 89, 190, 213, 151, 187, 3, 228, 73, 92, 205, 48, 102, 79, 5, 4, 173, 60, 70, 183, 181, 12, 182, 82, 188, 181, 63, 188, 207, 33, 226, 145, 53, 52, 145, 75, 195, 37, 234, 12, 69, 24, 220, 245 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Endereco",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 67, 44, 60, 149, 80, 128, 253, 216, 0, 105, 227, 178, 243, 221, 29, 159, 48, 241, 21, 224, 0, 141, 17, 145, 43, 56, 247, 137, 153, 195, 84, 122, 250, 200, 203, 104, 109, 27, 134, 190, 154, 78, 152, 63, 20, 126, 53, 45, 111, 253, 157, 99, 46, 57, 239, 226, 16, 90, 179, 254, 13, 176, 232, 187 }, new byte[] { 195, 49, 183, 41, 236, 12, 228, 95, 109, 188, 247, 62, 69, 246, 96, 111, 188, 255, 200, 94, 194, 55, 57, 63, 94, 127, 190, 230, 223, 221, 194, 80, 99, 215, 196, 209, 87, 163, 145, 226, 180, 100, 137, 13, 131, 240, 45, 9, 24, 176, 98, 252, 219, 193, 150, 148, 71, 216, 233, 255, 2, 183, 242, 203, 228, 0, 250, 93, 173, 195, 3, 219, 70, 234, 177, 207, 119, 212, 20, 12, 139, 250, 36, 135, 210, 196, 113, 203, 27, 21, 95, 223, 18, 137, 123, 32, 6, 55, 201, 11, 45, 154, 56, 223, 15, 159, 9, 230, 54, 59, 57, 96, 186, 30, 200, 19, 78, 38, 232, 252, 110, 154, 88, 90, 86, 58, 30, 210 } });
        }
    }
}
