using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bloco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemDoacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoItem = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDoacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataPostagem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha_Hash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Senha_Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UltimoAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eletrodomestico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusItem = table.Column<int>(type: "int", nullable: false),
                    ItemDoacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eletrodomestico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eletrodomestico_ItemDoacao_ItemDoacaoId",
                        column: x => x.ItemDoacaoId,
                        principalTable: "ItemDoacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mobilia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusItem = table.Column<int>(type: "int", nullable: false),
                    ItemDoacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobilia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobilia_ItemDoacao_ItemDoacaoId",
                        column: x => x.ItemDoacaoId,
                        principalTable: "ItemDoacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoProduto = table.Column<int>(type: "int", nullable: false),
                    StatusItem = table.Column<int>(type: "int", nullable: false),
                    ItemDoacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_ItemDoacao_ItemDoacaoId",
                        column: x => x.ItemDoacaoId,
                        principalTable: "ItemDoacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roupa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    FaixaEtaria = table.Column<int>(type: "int", nullable: false),
                    StatusItem = table.Column<int>(type: "int", nullable: false),
                    ItemDoacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roupa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roupa_ItemDoacao_ItemDoacaoId",
                        column: x => x.ItemDoacaoId,
                        principalTable: "ItemDoacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fisicaJuridica = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    EnderecoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pessoa_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    EnderecoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agenda_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DestinatarioId = table.Column<int>(type: "int", nullable: false),
                    RemetenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagem_Pessoa_DestinatarioId",
                        column: x => x.DestinatarioId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensagem_Pessoa_RemetenteId",
                        column: x => x.RemetenteId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusDoacao = table.Column<int>(type: "int", nullable: false),
                    TipoDoacao = table.Column<int>(type: "int", nullable: false),
                    IdDoacaoOrigem = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    AgendaId = table.Column<int>(type: "int", nullable: false),
                    Dinheiro = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doacao_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacao_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "Id", "Bairro", "Bloco", "Cep", "Cidade", "Complemento", "Estado", "Numero", "Rua" },
                values: new object[] { 1, "Jardim Tremembé", null, "02319000", "São Paulo", null, "São Paulo", "1091", "Avenida Josino Vieira de Goes" });

            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[] { "Id", "DataNasc", "Documento", "EnderecoId", "Genero", "Nome", "Telefone", "Tipo", "UsuarioId", "fisicaJuridica" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "ONG Estrela Dalva", null, 2, null, 2 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Foto", "Senha_Hash", "Senha_Salt", "UltimoAcesso" },
                values: new object[] { 1, "ongestreladalva@gmail.com", null, new byte[] { 20, 171, 17, 144, 85, 164, 242, 170, 69, 59, 222, 253, 247, 242, 107, 242, 200, 44, 80, 178, 149, 30, 101, 55, 67, 194, 179, 19, 244, 87, 8, 46, 162, 47, 75, 68, 28, 242, 41, 251, 176, 87, 72, 229, 201, 32, 123, 137, 133, 172, 201, 246, 238, 41, 11, 57, 250, 62, 102, 203, 215, 190, 101, 128 }, new byte[] { 158, 100, 96, 82, 122, 37, 76, 201, 32, 105, 37, 219, 51, 243, 228, 83, 8, 98, 34, 94, 160, 134, 36, 113, 175, 58, 21, 46, 151, 177, 227, 171, 132, 37, 132, 187, 171, 200, 67, 28, 201, 52, 115, 146, 156, 20, 29, 127, 152, 156, 241, 220, 201, 100, 113, 47, 247, 178, 186, 174, 145, 57, 192, 86, 26, 142, 109, 226, 42, 188, 165, 18, 175, 1, 174, 118, 144, 214, 42, 2, 103, 55, 158, 146, 112, 98, 83, 118, 216, 238, 157, 23, 119, 127, 131, 126, 245, 146, 139, 68, 191, 202, 38, 231, 78, 78, 181, 216, 238, 179, 105, 63, 149, 169, 82, 227, 127, 199, 107, 187, 66, 168, 77, 109, 123, 217, 16, 40 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_EnderecoId",
                table: "Agenda",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PessoaId",
                table: "Agenda",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_AgendaId",
                table: "Doacao",
                column: "AgendaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_PessoaId",
                table: "Doacao",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Eletrodomestico_ItemDoacaoId",
                table: "Eletrodomestico",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDoacaoDoado_ItemDoacaoId",
                table: "ItemDoacaoDoado",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_DestinatarioId",
                table: "Mensagem",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_RemetenteId",
                table: "Mensagem",
                column: "RemetenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobilia_ItemDoacaoId",
                table: "Mobilia",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EnderecoId",
                table: "Pessoa",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_UsuarioId",
                table: "Pessoa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ItemDoacaoId",
                table: "Produto",
                column: "ItemDoacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Roupa_ItemDoacaoId",
                table: "Roupa",
                column: "ItemDoacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eletrodomestico");

            migrationBuilder.DropTable(
                name: "ItemDoacaoDoado");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Mobilia");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Roupa");

            migrationBuilder.DropTable(
                name: "Doacao");

            migrationBuilder.DropTable(
                name: "ItemDoacao");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
