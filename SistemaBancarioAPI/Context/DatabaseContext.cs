using Microsoft.EntityFrameworkCore;
using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Models;

namespace SistemaBancarioAPI.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Titular> Titulares { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(now())");
            });

        }
    }
}