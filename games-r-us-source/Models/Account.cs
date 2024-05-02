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

        // The following claimsprincipal is needed for user authentication when loggin in. 
        public ClaimsPrincipal ToClaimsPrincipal() => new(
            new ClaimsIdentity(
                new Claim[]
                {
                    new(ClaimTypes.Name, this.Name),
                }, "Games R Us"));

        public static Account FromClaimsPrincipal(ClaimsPrincipal principal) => new()
        {
            Name = principal.FindFirst(ClaimTypes.Name)?.Value ?? "",
        };
    }
}
