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
            string conexao = "Host=aws-1-us-east-1.pooler.supabase.com;Database=postgres;Username=postgres.cgxzrzqzrapjpcehefwu;Password="+senhaBanco+";SSL Mode=Require;Trust Server Certificate=true";
            optionsBuilder.UseNpgsql(conexao, builder => {
                builder.EnableRetryOnFailure(
                    maxRetryCount: 2,
                    maxRetryDelay: TimeSpan.FromSeconds(1),
                    errorCodesToAdd: null);
            });
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemRPG>()
                .HasDiscriminator<string>("Tipo")
                .HasValue<Arma>("Arma")
                .HasValue<Pocao>("Pocao");

            modelBuilder.Entity<Venda>()
                .HasKey(v => new { v.NomeItem, v.DataVenda });
            modelBuilder.Entity<Aventureiro>();
        }
    }
}
