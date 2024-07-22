using Gulayan.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Gulayan.DataContexts
{
    public class AdminDataContext : DbContext
    {
        private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AdminDB.db");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        public DbSet<Admin> Admins { get; set; }
    }
}