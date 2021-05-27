using CodeAssessment.Services;
using System.Threading.Tasks;
using Xunit;

namespace CodeAssessment.Tests
{
    public class WeatherApiServiceTest
    {
        private const string WeatherDataApiUrl = "http://api.openweathermap.org/data/2.5/forecast?q=minneapolis,us&units=imperial&APPID=09110e603c1d5c272f94f64305c09436";

        private readonly WeatherApiService _weatherService = new(WeatherDataApiUrl);

        [Fact]
        public async Task ProducesResultData()
        {
            // verify weather data is returned.
            var results = await _weatherService.RetrieveWeatherDataAsync();

            Assert.NotNull(results);

            // we don't have any control over what the API returns since we're feeding it a static URL, but let's check for results anyways
            Assert.NotEmpty(results.List);
        }
    }
}
