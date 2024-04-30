using Gulayan.Models;
using Microsoft.EntityFrameworkCore;

namespace Gulayan
{
    public class AdminDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = AdminDB.db");
        }

        public DbSet<Admin> Admins { get; set; }

    }
}
