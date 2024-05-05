using games_r_us_source.Data;

namespace games_r_us_source.Components.Helpers
{
    public class AccountHelper
    {
        public static ApplicationUser GetAccountFromAccountID(string accountID, ApplicationDbContext context)
        {
            ApplicationUser account = context.ApplicationUsers.Where(a => a.Id == accountID).FirstOrDefault();
            return account;
        }
    }
}
