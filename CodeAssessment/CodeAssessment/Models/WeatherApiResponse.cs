using CodeAssessment.Enums;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Primary weather properties for the time of the record.
        /// </summary>
        public WeatherRecordMainProperties Main { get; set; }

        /// <summary>
        /// Additional weather details for the time of the record.
        /// </summary>
        /// <remarks>
        /// The documentation for the API is unfortunately pretty limited.
        /// There's no clear explanation for why this would be an array rather than a vaule.
        /// Further, this entity is a collection, while <see cref="WeatherRecordWeatherProperties.Main"/> is listed
        /// as "Group of weather parameters", yet is a single value.
        /// </remarks>
        public List<WeatherRecordWeatherProperties> Weather { get; set; }


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

            /// <summary>
            /// Typed representation of <see cref="Main"/>.
            /// </summary>
            public WeatherCondition Condition {
                get
                {
                    if (Enum.TryParse(typeof(WeatherCondition), Main, out object result))
                    {
                        return (WeatherCondition)result;
                    }

                    return WeatherCondition.Unknown;
                }
            }
        }
    }
}
