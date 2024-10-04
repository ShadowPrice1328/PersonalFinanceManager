using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception)
            {
                return;
            }
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
