using Bar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bar.Data
{
    public class BarContext : DbContext
    {
        public BarContext(DbContextOptions<BarContext> options) : base(options) { }

        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
    }
}
