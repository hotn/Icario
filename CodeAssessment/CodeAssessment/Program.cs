using System;
using System.Linq;
using System.Threading.Tasks;
using CodeAssessment.Services;
using CodeAssessment.Extensions;
using System.Collections.Generic;
using CodeAssessment.Enums;
using CodeAssessment.Helpers;
using CodeAssessment.Models;

namespace CodeAssessment
{
    class Program
    {
        // TODO: in real app, move this to a config file, environment variable, db record, etc.
        private const string WeatherDataApiUrl = "http://api.openweathermap.org/data/2.5/forecast?q=minneapolis,us&units=imperial&APPID=09110e603c1d5c272f94f64305c09436";

        private static readonly WeatherApiService _weatherApiService = new(WeatherDataApiUrl);

        static async Task Main(string[] args)
        {
            await RunProgram();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static async Task RunProgram()
        {
            // retrieve weather
            WeatherApiResponse weatherData = null;
            try
            {
                weatherData = await _weatherApiService.RetrieveWeatherDataAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception has occurred.");
                Console.WriteLine(e.Message);
            }

            if (weatherData == null)
            {
                Console.WriteLine("An error occurred and the app cannot provide weather information.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

                return;
            }

            // separate weather details out into days
            var dayGroups = weatherData.List.GroupBy(record => record.Dt.ToDateTime().Day).OrderBy(group => group.First().Dt);

            // process each day to find optimal contact method
            var contactMethods = new List<ContactMethod>();
            foreach (var days in dayGroups)
            {
                contactMethods.Add(WeatherHelper.GetOptimalContactMethodForWeatherRecords(days));
            }

            // print out contact method and weather description, or warning if no match
            for (var i = 0; i < dayGroups.Count(); i++)
            {
                var dayGroup = dayGroups.Skip(i).First();
                var contactMethod = contactMethods[i];
                var dailyCondition = dayGroup
                    .SelectMany(group => group.Weather)
                    .Select(weather => weather.Condition)
                    .GroupBy(weather => weather)
                    .OrderByDescending(group => group.Count())
                    .First().Key;

                Console.WriteLine("**************************");
                Console.WriteLine($"Date: {dayGroup.First().Dt.ToDateTime().ToShortDateString()}");
                Console.WriteLine($"Average Temperature: {Math.Round(WeatherHelper.GetAverageTemperatureForWeatherRecords(dayGroup))}°F");
                Console.WriteLine($"Prevalent Weather Condition: {WeatherHelper.GetPrevalentWeatherConditionForRecords(dayGroup)}");
                Console.WriteLine($"Best Contact Method: {WeatherHelper.GetOptimalContactMethodForWeatherRecords(dayGroup)}");
                Console.WriteLine("**************************");
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
