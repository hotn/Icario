using CodeAssessment.Enums;
using CodeAssessment.Models;
using System;
using System.Collections.Generic;

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
        public static ContactMethod GetOptimalContactMethodForWeatherRecords(List<WeatherRecord> records)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the weather description for a given set of weather records.
        /// </summary>
        /// <param name="records">Records to analyze.</param>
        /// <returns>Weather description for weather records.</returns>
        public static string GetWeatherDescriptionForWeatherRecords(List<WeatherRecord> records)
        {
            throw new NotImplementedException();
        }
    }
}
