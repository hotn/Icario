using CodeAssessment.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
