using CodeAssessment.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace CodeAssessment.Services
{
    /// <summary>
    /// Service used for interacting with the weather API.
    /// </summary>
    public class WeatherApiService
    {
        private readonly string _apiUrl;

        public WeatherApiService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        /// <summary>
        /// Retrieve weather data for 5 days in 3 hour increments from the weather API.
        /// </summary>
        public async Task<WeatherApiResponse> RetrieveWeatherDataAsync()
        {
            using var client = new HttpClient();

            // TODO: consider adding exception handling within this service so we can deal with them
            // closer to the source of their occurrence and provide easier to consume results to the caller
            var response = await client.GetAsync(_apiUrl);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<WeatherApiResponse>(json);
        }
    }
}
