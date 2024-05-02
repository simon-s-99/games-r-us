using games_r_us_source.Models;

namespace games_r_us_source.Classes
{
    public class GamesRUsAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationDataStorage _authenticationDataStorage;

        public GamesRUsAccountService(HttpClient httpClient, AuthenticationDataStorage authenticationDataStorage)
        {
            _httpClient = httpClient;
            _authenticationDataStorage = authenticationDataStorage;
        }

        public async Task<Account?> SendAuthenticateRequestAsync(string accountName)
        {
            var response = await _httpClient.GetAsync();

            // true if we get a response in 200-299 range 
            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();
                var claimPrincipal = CreateClaimsPrincipalFromToken(token);
                var account = Account.FromClaimsPrincipal(claimPrincipal);
            }

            return null;
        }
    }
}
