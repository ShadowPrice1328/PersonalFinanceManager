using Microsoft.EntityFrameworkCore;
using Personal_Finance_Manager.Models;

namespace Personal_Finance_Manager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            try
            {
                // Ensure the database is created
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
