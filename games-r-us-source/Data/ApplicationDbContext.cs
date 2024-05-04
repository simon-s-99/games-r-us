using games_r_us_source.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace games_r_us_source.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Listing> Listings { get; set; }

        public DbSet<Bid> Bids { get; set; }
    }
}
