using Gulayan.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Gulayan.DataContexts
{
    public class ProductDataContext : DbContext
    {
        private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductDB.db");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        public DbSet<Product> Products { get; set; }
    }
}   