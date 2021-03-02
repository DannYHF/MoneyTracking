using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {}
    }
}