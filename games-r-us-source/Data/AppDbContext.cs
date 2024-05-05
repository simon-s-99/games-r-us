using games_r_us_source.Models;
using Microsoft.EntityFrameworkCore;

namespace games_r_us_source.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Listing> Listings { get; set; }

        public DbSet<Bid> Bids { get; set; }
    }
}
