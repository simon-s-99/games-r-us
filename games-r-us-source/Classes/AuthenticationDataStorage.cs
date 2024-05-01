namespace games_r_us_source.Classes
{
    // Class holds our users logged in token, for dev-purposes this
    // is stored in volatile memory but a long term solution would be 
    // localStorage or something similar. 
    public class AuthenticationDataStorage
    {
        public string Token { get; set; } = "";
    }
}
