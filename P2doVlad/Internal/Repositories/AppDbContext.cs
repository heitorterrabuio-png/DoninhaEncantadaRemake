using Microsoft.EntityFrameworkCore;
using P2doVlad.Internal.Models;

namespace P2doVlad.Internal.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<ItemRPG> Itens { get; set; }
        public DbSet<Aventureiro> Aventureiros { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? senhaBanco = Environment.GetEnvironmentVariable("DB_PASSWORD2");
            optionsBuilder.UseNpgsql($"Host=db.cgxzrzqzrapjpcehefwu.supabase.co;Port=5432;Database=P2_Vlad;Username=postgres;Password={senhaBanco};");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemRPG>()
                .HasDiscriminator<string>("Tipo")
                .HasValue<Arma>("Arma")
                .HasValue<Pocao>("Pocao");

            modelBuilder.Entity<Venda>()
                .HasKey(v => new { v.NomeItem, v.DataVenda });
        }
    }
}
