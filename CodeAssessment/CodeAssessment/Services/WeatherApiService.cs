using CodeAssessment.Models;
using System;

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
        public WeatherApiResponse RetrieveWeatherData()
        {
            throw new NotImplementedException();
        }


    }
}
