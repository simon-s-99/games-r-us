using games_r_us_source.Data;

namespace games_r_us_source.Components.Helpers
{
    public class ApplicationUserHelper
    {
        public static ApplicationUser GetAccountFromUserName(string userName, ApplicationDbContext context)
        {
            // userName, in this case, is the email the user used when signing up
            ApplicationUser account = context.ApplicationUsers.Where(a => a.Email == userName).FirstOrDefault();
            return account;
        }

        public static ApplicationUser GetAccountFromUserID(string userID, ApplicationDbContext context)
        {
            ApplicationUser account = context.ApplicationUsers.Where(a => a.Id == userID).FirstOrDefault();
            return account;
        }

        public static bool IsUserListingOwner(string userName, Data.Listing listing, ApplicationDbContext context)
        {
            ApplicationUser account = GetAccountFromUserID(userName, context);

            if (listing.ApplicationUserID == account.Id) { return true; }

            return false;
        }
    }
}
