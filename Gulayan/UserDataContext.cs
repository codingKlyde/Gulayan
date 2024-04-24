using Microsoft.EntityFrameworkCore;

namespace Gulayan
{
    public class UserDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DataFile.db");
        }

        public DbSet<User> Users { get; set; }
    }
}
