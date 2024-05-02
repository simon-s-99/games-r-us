using Microsoft.AspNetCore.Components.Authorization;

namespace games_r_us_source.Classes
{
    public class GamesRUsAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly GamesRUsAccountService _gamesRUsAccountService;

        public GamesRUsAuthenticationStateProvider(GamesRUsAccountService gamesRUsAccountService)
        {
            _gamesRUsAccountService = gamesRUsAccountService;
        }

        // temp code, to be implemented 
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
