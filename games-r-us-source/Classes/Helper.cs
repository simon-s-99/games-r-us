using games_r_us_source.Models;
using games_r_us_source.Data;

namespace games_r_us_source.Classes
{
    public class Helper
    {

        public static Account GetAccountFromAccountID(int accountID, AppDbContext context)
        {
            Account account = context.Accounts.Where(a => a.ID == accountID).First();
            return account;
        }

        public static Listing GetListingFromListingID(int listingID, AppDbContext context)
        {
            Listing listing = context.Listings.Where(a => a.ID == listingID).First();
            return listing;
        }
    }
}
