using games_r_us_source.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace games_r_us_source.Models
{
    public class Account
    {
        public int ID { get; set; }

        public string OpenIDIssuer { get; set; }

        public string OpenIDSubject { get; set; }

        public string Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        // v move this 

        /// <summary>
        /// </summary>
        /// <param name="authState"></param>
        /// <returns>The account associated with the AuthenticationState</returns>
        //public Account? GetAccountFromAuthState(AuthenticationState authState)
        //{
        //    // exit method if user is not logged in 
        //    if (authState == null) { return null; }

        //    string username = authState.User.Identity.Name;

        //    Account loggedInAccount;

        //    using (var dbContext = new AppDbContext())
        //    {

        //    }

        //    return loggedInAccount;
        //    //IEnumerable<ClaimsIdentity> userIdentities = authState.User.Identities;
        //    //IEnumerable<Claim> claims = authState.User.Claims;
        //}
    }
}
