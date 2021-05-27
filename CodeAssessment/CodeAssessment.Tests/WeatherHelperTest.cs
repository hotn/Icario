using Xunit;

namespace CodeAssessment.Tests
{
    public class WeatherHelperTest
    {
        [Fact]
        public void CorrectlyIdentifiesEmailContactConditions()
        {
            // TODO: check that between 55 and 75 matches

            // TODO: check that below 55 fails

            // TODO: check that above 75 fails
        }

        [Fact]
        public void CorrectlyIdentifiesTextContactConditions()
        {
            // TODO: check that sunny and warmer than 70 matches

            // TODO: check that sunny and cooler than 70 fails

            // TODO: check that not sunny and warmer than 70 fails

            // TODO: check that not sunny and cooler than 70 fails
        }

        [Fact]
        public void CorrectlyIdentifiesPhoneContactConditions()
        {
            // TODO: check that rainy and below 55 matches

            // TODO: check that rainy and above 55 fails

            // TODO: check that not rainy and below 55 fails

            // TODO: check that not rainy and above 55 fails
        }
    }
}
