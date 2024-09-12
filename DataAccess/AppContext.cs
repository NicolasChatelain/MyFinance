using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppContext : DbContext
    {
        public DbSet<ExpenseEF> Expense { get; set; }
        public DbSet<IncomeEF> Income { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=MyFinance;user=root;password=root", new MySqlServerVersion(new Version(8, 3, 0)));
        }
    }
}
