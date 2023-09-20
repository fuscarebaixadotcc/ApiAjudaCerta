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

            modelBuilder.Entity("ApiAjudaCerta.Models.Dinheiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dinheiro");
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

                    b.Property<int?>("DinheiroId")
                        .HasColumnType("int");

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

                    b.HasIndex("DinheiroId");

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
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.ItemDoacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ItemDoacaoId")
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

                    b.Property<byte[]>("Senha_Hash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Senha_Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("UltimoAcesso")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
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

                    b.HasOne("ApiAjudaCerta.Models.Dinheiro", "Dinheiro")
                        .WithMany("Doacoes")
                        .HasForeignKey("DinheiroId");

                    b.HasOne("ApiAjudaCerta.Models.Pessoa", "Pessoa")
                        .WithMany("Doacoes")
                        .HasForeignKey("PessoaId");

                    b.Navigation("Agenda");

                    b.Navigation("Dinheiro");

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

            modelBuilder.Entity("ApiAjudaCerta.Models.Dinheiro", b =>
                {
                    b.Navigation("Doacoes");
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
                });

            modelBuilder.Entity("ApiAjudaCerta.Models.Usuario", b =>
                {
                    b.Navigation("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
