﻿// <auto-generated />
using System;
using ApiAjudaCerta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiAjudaCerta.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
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

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

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

                    b.Property<int>("EnderecoId")
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

                    b.Property<int>("UsuarioId")
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
                            EnderecoId = 1,
                            Nome = "ONG Estrela Dalva",
                            Tipo = 2,
                            Username = "@ong_estreladalva",
                            UsuarioId = 1,
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
                            Senha_Hash = new byte[] { 162, 5, 136, 235, 239, 69, 16, 108, 179, 64, 152, 99, 174, 96, 179, 189, 197, 14, 254, 29, 227, 21, 206, 13, 46, 84, 33, 204, 7, 204, 38, 188, 68, 5, 115, 157, 153, 146, 145, 80, 70, 9, 78, 158, 202, 115, 185, 95, 155, 203, 16, 171, 154, 112, 112, 119, 7, 164, 63, 86, 129, 163, 147, 1 },
                            Senha_Salt = new byte[] { 140, 125, 217, 70, 231, 177, 5, 170, 65, 140, 242, 43, 91, 97, 158, 234, 104, 242, 196, 147, 139, 220, 16, 55, 244, 218, 212, 229, 178, 223, 92, 79, 110, 175, 246, 53, 57, 25, 58, 13, 251, 153, 143, 10, 123, 188, 196, 84, 245, 182, 219, 222, 85, 158, 56, 106, 99, 31, 6, 129, 136, 108, 113, 213, 244, 121, 95, 74, 214, 88, 242, 15, 234, 55, 190, 220, 211, 94, 73, 57, 76, 72, 236, 25, 41, 39, 73, 182, 7, 177, 121, 49, 9, 104, 128, 139, 165, 127, 47, 240, 73, 250, 135, 16, 23, 194, 231, 8, 152, 178, 56, 20, 23, 1, 53, 163, 116, 255, 251, 240, 75, 176, 136, 147, 129, 234, 80, 36 },
                            UltimoAcesso = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Agenda", b =>
                {
                    b.HasOne("ApiAjudaCerta.Models.Endereco", "Endereco")
                        .WithMany("Agendas")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiAjudaCerta.Models.Pessoa", "Pessoa")
                        .WithMany("Agendas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiAjudaCerta.Models.Usuario", "Usuario")
                        .WithMany("Pessoas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
