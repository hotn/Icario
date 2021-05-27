﻿using System.Collections.Generic;

namespace CodeAssessment.Models
{
    /// <summary>
    /// API response model.
    /// </summary>
    public class WeatherApiResponse
    {
        public List<WeatherRecord> List { get; set; }
    }

    public class WeatherRecord
    {
        /// <summary>
        /// Date of weather record in Unix timestamp format.
        /// </summary>
        public int Dt { get; set; }


        public class WeatherRecordMainProperties
        {
            /// <summary>
            /// Predicted temperature.
            /// </summary>
            public double Temp { get; set; }
        }

        public class WeatherRecordWeatherProperties
        {
            /// <summary>
            /// General weather description.
            /// </summary>
            /// <remarks>
            /// This will return less specific values, such as "rain" rather than "light rain" or "heavy rain".
            /// </remarks>
            public string Main { get; set; }
        }
    }
}
