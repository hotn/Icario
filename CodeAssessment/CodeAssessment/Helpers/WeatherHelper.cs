using CodeAssessment.Enums;
using CodeAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeAssessment.Helpers
{
    /// <summary>
    /// Helper class for processing weather records.
    /// </summary>
    public static class WeatherHelper
    {
        /// <summary>
        /// Get the optimal <see cref="ContactMethod"/> for a given set of weather records.
        /// </summary>
        /// <param name="records">Records to analyze.</param>
        /// <returns>Optimal contact method for weather records.</returns>
        public static ContactMethod GetOptimalContactMethodForWeatherRecords(IEnumerable<WeatherRecord> records)
        {
            // No business rules have been provided for how to best process weather data.
            // Unless additional guidance is provided, proceed by using averages across the data set.

            var averageTemp = records.Sum(record => record.Main.Temp) / records.Count();
            var conditions = records.SelectMany(record => record.Weather.Select(weather => weather.Condition)).GroupBy(condition => condition);

            // determine the most prevalent condition throughout the day, opting for best condition upon ties
            var primaryCondition = conditions.Aggregate((group1, group2) =>
            {
                if (group1.Count() > group2.Count())
                {
                    return group1;
                }
                if (group2.Count() > group1.Count())
                {
                    return group2;
                }

                // No business rules have been provided for choosing one weather condition over another in cases where they're equally likely,
                // so if the two groups have the same values, let's return results as if we're an optimistic weatherperson.
                // I mean, predicting the weather is already a questionable science, so who can say we're any more correct or incorrect than the next meteorologist?
                foreach(var condition in new List<WeatherCondition> { WeatherCondition.Clear, WeatherCondition.Clouds, WeatherCondition.Rain, WeatherCondition.Snow, WeatherCondition.Unknown })
                {
                    if (group1.Key == condition)
                    {
                        return group1;
                    }
                    if (group2.Key == condition)
                    {
                        return group2;
                    }
                }

                // we shouldn't ever hit this, but gotta have a final return
                return group1;
            }).Key;

            // all criteria given uses temp ranges, so start by filtering on temp
            if (averageTemp > 75 && primaryCondition == WeatherCondition.Clear)
            {
                return ContactMethod.Text;
            }
            if (averageTemp >= 55 && averageTemp <= 75)
            {
                return ContactMethod.Email;
            }
            if (averageTemp < 55 || primaryCondition == WeatherCondition.Rain)
            {
                return ContactMethod.Phone;
            }

            // TODO: The provided business rules cover most cases, but there are still conditions that will not match the given rules.
            // For now, return "Unknown", but work on determining better rules to cover the edge cases.
            return ContactMethod.Unknown;
        }

        /// <summary>
        /// Get the weather description for a given set of weather records.
        /// </summary>
        /// <param name="records">Records to analyze.</param>
        /// <returns>Weather description for weather records.</returns>
        public static string GetWeatherDescriptionForWeatherRecords(IEnumerable<WeatherRecord> records)
        {
            throw new NotImplementedException();
        }
    }
}
