using System;

namespace CodeAssessment.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="DateTime"/> objects.
    /// </summary>
    public static class UnixEpochExtensions
    {
        /// <summary>
        /// Convert a <see cref="DateTime"/> object to Unix epoch-based timestamp.
        /// </summary>
        /// <param name="dateTime">Date/time to convert.</param>
        /// <returns>Date/time represented in seconds from Unix epoch.</returns>
        public static long ToUnixTimestamp(this DateTime dateTime) => ((DateTimeOffset)dateTime).ToUnixTimeSeconds();

        /// <summary>
        /// Convert a Unix epoch-based timestamp to a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="timestamp">Unix epoch-based timestamp.</param>
        /// <returns>Timestamp represented as a <see cref="DateTime"/>.</returns>
        public static DateTime ToDateTime(this long timestamp) => DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
    }
}
