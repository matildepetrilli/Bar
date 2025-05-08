using Bar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bar.Data
{
     public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Categoria> Categorie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prodotto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Prodotti)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}