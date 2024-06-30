using Gulayan.Models;
using Microsoft.EntityFrameworkCore;

namespace Gulayan.DataContexts
{
    public class ProductDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ProductDB.db");
        }

        public DbSet<Product> Products { get; set; }
    }
}