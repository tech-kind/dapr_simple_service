namespace NumberCollectionService.Proxies
{
    public class NumberRegistrationService
    {
        private HttpClient _httpClient;

        public NumberRegistrationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<int> GetNumber()
        {
            return await _httpClient.GetFromJsonAsync<int>("number");
        }
    }
}
