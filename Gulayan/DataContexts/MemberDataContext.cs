using Gulayan.Models;
using Microsoft.EntityFrameworkCore;

namespace Gulayan.DataContexts
{
    public class MemberDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = MemberDB.db");
        }

        public DbSet<Member> Members { get; set; }
    }
}


