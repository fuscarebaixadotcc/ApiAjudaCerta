using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoTipoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoItem",
                table: "ItemDoacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[] { "Id", "DataNasc", "Documento", "EnderecoId", "Genero", "Nome", "Telefone", "Tipo", "UsuarioId", "fisicaJuridica" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "ONG Estrela Dalva", null, 2, null, 2 });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 102, 160, 4, 126, 39, 128, 97, 244, 170, 168, 140, 53, 73, 171, 224, 76, 252, 57, 127, 168, 22, 189, 26, 210, 43, 25, 62, 213, 48, 65, 59, 71, 86, 70, 129, 48, 32, 194, 166, 22, 35, 206, 61, 36, 42, 233, 45, 222, 158, 37, 75, 48, 165, 188, 200, 241, 162, 41, 200, 93, 158, 4, 160, 243 }, new byte[] { 210, 117, 80, 20, 53, 112, 181, 118, 43, 97, 243, 21, 20, 49, 233, 242, 114, 26, 11, 140, 184, 178, 203, 210, 222, 116, 196, 122, 57, 135, 17, 33, 35, 211, 237, 157, 66, 11, 207, 51, 170, 124, 26, 224, 124, 110, 43, 243, 14, 169, 145, 36, 207, 7, 126, 28, 76, 59, 15, 141, 216, 96, 222, 124, 23, 84, 34, 150, 159, 154, 242, 62, 98, 132, 185, 216, 193, 111, 32, 34, 241, 252, 163, 238, 82, 124, 214, 215, 56, 173, 73, 39, 192, 225, 39, 236, 228, 185, 185, 175, 32, 229, 185, 163, 91, 103, 20, 77, 164, 61, 110, 111, 202, 237, 130, 135, 192, 160, 211, 197, 75, 81, 157, 187, 144, 49, 44, 29 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "TipoItem",
                table: "ItemDoacao");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Senha_Hash", "Senha_Salt" },
                values: new object[] { new byte[] { 84, 175, 188, 117, 6, 62, 165, 169, 48, 118, 188, 28, 83, 234, 91, 27, 142, 0, 13, 65, 159, 40, 144, 138, 97, 92, 185, 34, 4, 39, 158, 248, 136, 21, 182, 199, 158, 190, 43, 16, 65, 232, 32, 116, 189, 65, 48, 166, 108, 114, 244, 111, 188, 158, 221, 177, 9, 101, 59, 208, 200, 158, 205, 11 }, new byte[] { 119, 64, 73, 141, 167, 248, 120, 60, 15, 230, 156, 77, 38, 236, 31, 30, 65, 192, 102, 10, 16, 216, 9, 125, 116, 61, 199, 189, 96, 239, 0, 107, 0, 112, 130, 30, 239, 242, 193, 137, 255, 128, 199, 223, 200, 99, 113, 173, 231, 144, 217, 231, 55, 62, 1, 173, 76, 220, 163, 37, 35, 248, 55, 116, 37, 176, 52, 125, 234, 243, 14, 149, 195, 118, 187, 6, 216, 228, 10, 150, 70, 240, 15, 203, 64, 89, 190, 213, 151, 187, 3, 228, 73, 92, 205, 48, 102, 79, 5, 4, 173, 60, 70, 183, 181, 12, 182, 82, 188, 181, 63, 188, 207, 33, 226, 145, 53, 52, 145, 75, 195, 37, 234, 12, 69, 24, 220, 245 } });
        }
    }
}
