using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace games_r_us_source.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        // the dbset for applicationUser here is so that we can reference to it 
        // when we reference dbContext, it is still set as AspNetUsers in the database 
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Listing> Listings { get; set; }

        public DbSet<Bid> Bids { get; set; }
    }
}
