using CodeAssessment.Models;
using System;

namespace CodeAssessment.Services
{
    /// <summary>
    /// Service used for interacting with the weather API.
    /// </summary>
    public class WeatherApiService
    {
        private const string WeatherDataApiUrl = "http://api.openweathermap.org/data/2.5/forecast?q=minneapolis,us&units=imperial&APPID=09110e603c1d5c272f94f64305c09436";

        /// <summary>
        /// Retrieve weather data for 5 days in 3 hour increments from the weather API.
        /// </summary>
        public WeatherApiResponse RetrieveWeatherData()
        {
            throw new NotImplementedException();
        }


    }
}
