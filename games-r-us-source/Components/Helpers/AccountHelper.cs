using games_r_us_source.Data;

namespace games_r_us_source.Components.Helpers
{
    public class AccountHelper
    {
        public static ApplicationUser GetAccountFromUserName(string userName, ApplicationDbContext context)
        {
            ApplicationUser account = context.ApplicationUsers.Where(a => a.Email == userName).FirstOrDefault();
            return account;
        }
    }
}
