using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAjudaCerta.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAjudaCerta.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)  : base(options)
        {
            
        }

        public DbSet<Usuario> Usuario { get; set;}
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Doacao> Doacao { get; set; }
        public DbSet<Dinheiro> Dinheiro { get; set; }
        public DbSet<ItemDoacao> ItemDoacao { get; set;}
        public DbSet<Roupa> Roupa { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Mobilia> Mobilia { get; set; }
        public DbSet<Eletrodomestico> Eletrodomestico { get; set; }
        public DbSet<ItemDoacaoDoado> ItemDoacaoDoado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemDoacaoDoado>()
                .HasKey(idd => new {idd.DoacaoId, idd.ItemDoacaoId});
        }
    }
}