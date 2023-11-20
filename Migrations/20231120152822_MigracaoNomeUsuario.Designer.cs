﻿// <auto-generated />
using System;
using ApiAjudaCerta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231120152822_MigracaoNomeUsuario")]
    partial class MigracaoNomeUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiAjudaCerta.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Doacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgendaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<double>("Dinheiro")
                        .HasColumnType("float");

                    b.Property<int>("IdDoacaoOrigem")
                        .HasColumnType("int");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("StatusDoacao")
                        .HasColumnType("int");

                    b.Property<int>("TipoDoacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId")
                        .IsUnique();

                    b.HasIndex("PessoaId");

                    b.ToTable("Doacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Eletrodomestico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Condicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemDoacaoId")
                        .HasColumnType("int");

                    b.Property<string>("Medida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusItem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemDoacaoId");

                    b.ToTable("Eletrodomestico");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bloco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bairro = "Jardim Tremembé",
                            Cep = "02319000",
                            Cidade = "São Paulo",
                            Estado = "São Paulo",
                            Numero = "1091",
                            Rua = "Avenida Josino Vieira de Goes"
                        });
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.ItemDoacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoItem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.ItemDoacaoDoado", b =>
                {
                    b.Property<int>("DoacaoId")
                        .HasColumnType("int");

                    b.Property<int>("ItemDoacaoId")
                        .HasColumnType("int");

                    b.HasKey("DoacaoId", "ItemDoacaoId");

                    b.HasIndex("ItemDoacaoId");

                    b.ToTable("ItemDoacaoDoado");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Mensagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinatarioId")
                        .HasColumnType("int");

                    b.Property<int>("RemetenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinatarioId");

                    b.HasIndex("RemetenteId");

                    b.ToTable("Mensagem");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Mobilia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Condicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemDoacaoId")
                        .HasColumnType("int");

                    b.Property<string>("Medida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusItem")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemDoacaoId");

                    b.ToTable("Mobilia");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("fisicaJuridica")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pessoa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNasc = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "ONG Estrela Dalva",
                            Tipo = 2,
                            fisicaJuridica = 2
                        });
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataPostagem")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ItemDoacaoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusItem")
                        .HasColumnType("int");

                    b.Property<int>("TipoProduto")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemDoacaoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Roupa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Condicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FaixaEtaria")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int?>("ItemDoacaoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusItem")
                        .HasColumnType("int");

                    b.Property<string>("Tamanho")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemDoacaoId");

                    b.ToTable("Roupa");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Senha_Hash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Senha_Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("UltimoAcesso")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ongestreladalva@gmail.com",
                            Senha_Hash = new byte[] { 145, 136, 31, 169, 236, 212, 67, 207, 52, 100, 155, 165, 176, 145, 240, 209, 199, 30, 200, 204, 24, 141, 111, 125, 48, 194, 162, 3, 242, 226, 160, 237, 248, 216, 47, 235, 155, 190, 165, 173, 233, 222, 37, 234, 65, 233, 35, 36, 238, 191, 102, 47, 221, 65, 196, 32, 82, 212, 14, 20, 232, 100, 252, 181 },
                            Senha_Salt = new byte[] { 172, 175, 85, 9, 172, 65, 113, 106, 129, 192, 247, 143, 200, 8, 113, 23, 83, 223, 154, 220, 204, 128, 163, 4, 175, 224, 207, 229, 255, 99, 205, 123, 76, 112, 173, 206, 176, 198, 155, 114, 160, 22, 227, 42, 224, 255, 155, 111, 55, 208, 52, 84, 22, 27, 61, 98, 95, 226, 111, 111, 53, 166, 141, 254, 95, 162, 25, 121, 213, 75, 155, 114, 35, 117, 45, 9, 215, 205, 150, 198, 200, 246, 7, 255, 115, 156, 215, 112, 168, 7, 79, 21, 25, 246, 142, 70, 37, 123, 188, 221, 203, 18, 137, 79, 132, 182, 46, 26, 196, 31, 33, 162, 25, 168, 119, 181, 241, 131, 163, 73, 73, 149, 25, 191, 238, 61, 27, 141 },
                            UltimoAcesso = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Agenda", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Endereco", "Endereco")
                        .WithMany("Agendas")
                        .HasForeignKey("EnderecoId");

                    b.HasOne("ApiAjudaCerta.Models.Pessoa", "Pessoa")
                        .WithMany("Agendas")
                        .HasForeignKey("PessoaId");

                    b.Navigation("Endereco");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Doacao", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Agenda", "Agenda")
                        .WithOne("Doacao")
                        .HasForeignKey("ApiAjudaCerta.Models.Doacao", "AgendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiAjudaCerta.Models.Pessoa", "Pessoa")
                        .WithMany("Doacoes")
                        .HasForeignKey("PessoaId");

                    b.Navigation("Agenda");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Eletrodomestico", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.ItemDoacao", "ItemDoacao")
                        .WithMany("Eletrodomesticos")
                        .HasForeignKey("ItemDoacaoId");

                    b.Navigation("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.ItemDoacaoDoado", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Doacao", "Doacao")
                        .WithMany("ItemDoacaoDoados")
                        .HasForeignKey("DoacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiAjudaCerta.Models.ItemDoacao", "ItemDoacao")
                        .WithMany("ItemDoacaoDoados")
                        .HasForeignKey("ItemDoacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doacao");

                    b.Navigation("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Mensagem", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Pessoa", "Destinatario")
                        .WithMany("MensagensEnviadas")
                        .HasForeignKey("DestinatarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiAjudaCerta.Models.Pessoa", "Remetente")
                        .WithMany("MensagensRecebidas")
                        .HasForeignKey("RemetenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destinatario");

                    b.Navigation("Remetente");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Mobilia", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.ItemDoacao", "ItemDoacao")
                        .WithMany("Mobilias")
                        .HasForeignKey("ItemDoacaoId");

                    b.Navigation("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Pessoa", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Endereco", "Endereco")
                        .WithMany("Pessoa")
                        .HasForeignKey("EnderecoId");

                    b.HasOne("ApiAjudaCerta.Models.Usuario", "Usuario")
                        .WithMany("Pessoas")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Endereco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Produto", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.ItemDoacao", "ItemDoacao")
                        .WithMany("Produtos")
                        .HasForeignKey("ItemDoacaoId");

                    b.Navigation("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Roupa", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.ItemDoacao", "ItemDoacao")
                        .WithMany("Roupas")
                        .HasForeignKey("ItemDoacaoId");

                    b.Navigation("ItemDoacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Agenda", b =>
                {
                    b.Navigation("Doacao");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Doacao", b =>
                {
                    b.Navigation("ItemDoacaoDoados");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Endereco", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.ItemDoacao", b =>
                {
                    b.Navigation("Eletrodomesticos");

                    b.Navigation("ItemDoacaoDoados");

                    b.Navigation("Mobilias");

                    b.Navigation("Produtos");

                    b.Navigation("Roupas");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Pessoa", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Doacoes");

                    b.Navigation("MensagensEnviadas");

                    b.Navigation("MensagensRecebidas");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Usuario", b =>
                {
                    b.Navigation("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
