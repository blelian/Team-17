using System.Net.Http.Json;

namespace ConnectionsManager.Data
{
    public class ZenQuoteService
    {
        private readonly HttpClient _http;

        public ZenQuoteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Quote?> GetDailyQuote()
        {
            try
            {
                // ZenQuotes returns a list with one object
                var response = await _http.GetFromJsonAsync<List<Quote>>("https://zenquotes.io/api/random");
                return response?.FirstOrDefault();
            }
            catch
            {
                // Fallback message if API fails
                return new Quote
                {
                    q = "Keep moving forward. Even small steps count.",
                    a = "System"
                };
            }
        }
    }
}
