using Microsoft.AspNetCore.Identity;

namespace games_r_us_source.Data
{
	// Add profile data for application users by adding properties to the ApplicationUser class
	public class ApplicationUser : IdentityUser
    {
        // users first + last name
        // FullName is nullable in case we can't set it with Cookie middleware 
        public string? FullName { get; set; }
        
        // users address 
        public string? Address { get; set; }
    }

}
