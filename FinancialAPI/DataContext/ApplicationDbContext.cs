using FinancialAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        public DbSet<Income> Income { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
