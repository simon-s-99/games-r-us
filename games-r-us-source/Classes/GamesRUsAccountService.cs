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
    }
}
