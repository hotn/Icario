using Xunit;
using CodeAssessment.Helpers;
using CodeAssessment.Models;
using System.Collections.Generic;
using CodeAssessment.Enums;

namespace CodeAssessment.Tests
{
    public class WeatherHelperTest
    {
        [Fact]
        public void CorrectlyIdentifiesEmailContactConditions()
        {
            // check that between 55 and 75 matches

            // All we need for this test is a collection of temps. Dates and conditions don't matter.
            var records = BuildRecords(new List<(int, WeatherCondition)> { (60, WeatherCondition.Unknown), (55, WeatherCondition.Unknown), (75, WeatherCondition.Unknown) });

            var contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.Equal(ContactMethod.Email, contactMethod);

            // check that below 55 fails
            // Welcome to MN!
            records = BuildRecords(new List<(int, WeatherCondition)> { (30, WeatherCondition.Unknown), (20, WeatherCondition.Unknown), (-20, WeatherCondition.Unknown) });

            contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.NotEqual(ContactMethod.Email, contactMethod);

            // check that above 75 fails
            // Again, welcome to MN! (what's wrong with us? why do we stay living here?)
            records = BuildRecords(new List<(int, WeatherCondition)> { (75, WeatherCondition.Unknown), (90, WeatherCondition.Unknown), (110, WeatherCondition.Unknown) });

            contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.NotEqual(ContactMethod.Email, contactMethod);
        }

        [Fact]
        public void CorrectlyIdentifiesTextContactConditions()
        {
            // check that sunny and warmer than 70 matches
            // All we need for this test is a collection of temps and conditions. Dates don't matter.
            var records = BuildRecords(new List<(int, WeatherCondition)> { (70, WeatherCondition.Clear), (85, WeatherCondition.Clouds), (75, WeatherCondition.Clear) });

            var contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.Equal(ContactMethod.Text, contactMethod);

            // check that sunny and cooler than 70 fails
            records = BuildRecords(new List<(int, WeatherCondition)> { (60, WeatherCondition.Clear), (65, WeatherCondition.Clouds), (55, WeatherCondition.Clear) });

            contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.NotEqual(ContactMethod.Text, contactMethod);

            // check that not sunny and warmer than 70 fails
            // Sure, 75 degrees and snowy seems reasonable!
            records = BuildRecords(new List<(int, WeatherCondition)> { (70, WeatherCondition.Rain), (85, WeatherCondition.Clouds), (75, WeatherCondition.Snow) });

            contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.NotEqual(ContactMethod.Text, contactMethod);

            // check that not sunny and cooler than 70 fails
            records = BuildRecords(new List<(int, WeatherCondition)> { (60, WeatherCondition.Rain), (65, WeatherCondition.Clouds), (35, WeatherCondition.Snow) });

            contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.NotEqual(ContactMethod.Text, contactMethod);
        }

        [Fact]
        public void CorrectlyIdentifiesPhoneContactConditions()
        {
            // check that rainy and below 55 matches
            // All we need for this test is a collection of temps and conditions. Dates don't matter.
            var records = BuildRecords(new List<(int, WeatherCondition)> { (50, WeatherCondition.Clear), (45, WeatherCondition.Rain), (55, WeatherCondition.Rain) });

            var contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.Equal(ContactMethod.Phone, contactMethod);

            // check that rainy or below 55 passes (check rainy first, noting that 55-75 degrees should result in "email" regardless of conditions)
            records = BuildRecords(new List<(int, WeatherCondition)> { (50, WeatherCondition.Rain), (45, WeatherCondition.Clear), (55, WeatherCondition.Rain) });

            contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.Equal(ContactMethod.Phone, contactMethod);

            // check that rainy or below 55 passes (now check temp)
            records = BuildRecords(new List<(int, WeatherCondition)> { (50, WeatherCondition.Clear), (45, WeatherCondition.Clear), (55, WeatherCondition.Rain) });

            contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.Equal(ContactMethod.Phone, contactMethod);

            // check that rainy and above 55 fails
            records = BuildRecords(new List<(int, WeatherCondition)> { (60, WeatherCondition.Clear), (65, WeatherCondition.Rain), (55, WeatherCondition.Rain) });

            contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.NotEqual(ContactMethod.Phone, contactMethod);

            // check that not rainy and above 55 fails
            records = BuildRecords(new List<(int, WeatherCondition)> { (60, WeatherCondition.Clear), (65, WeatherCondition.Rain), (55, WeatherCondition.Clear) });

            contactMethod = WeatherHelper.GetOptimalContactMethodForWeatherRecords(records);
            Assert.NotEqual(ContactMethod.Phone, contactMethod);
        }

        private IEnumerable<WeatherRecord> BuildRecords(IEnumerable<(int temp, WeatherCondition condition)> tempsAndConditions)
        {
            foreach (var (temp, condition) in tempsAndConditions)
            {
                yield return new()
                {
                    Main = new()
                    {
                        Temp = temp
                    },
                    Weather = new()
                    {
                        new()
                        {
                            Main = condition.ToString()
                        }
                    }
                };
            }
        }
    }
}
