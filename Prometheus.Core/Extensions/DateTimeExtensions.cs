using System;

namespace Prometheus.Core.Extensions
{
    /// <summary>
    ///     Extensions to the <seealso cref="DateTime"/> structure.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Contants definition for date time.
        /// </summary>
        public static class Constants
        {
            /// <summary>
            ///     The ISO 8601 date time format.
            /// </summary>
            public const string ISO8601DateFormat = "yyyy-MM-ddTHH:mm:ssZ";
        }

        /// <summary>
        ///     Returns the ISO 8601 date time formatted string.
        /// </summary>
        public static string ToISO8601String(this DateTime dateTime)
        {
            return dateTime.ToString(Constants.ISO8601DateFormat);
        }

        /// <summary>
        ///     Retrieves a date object, configured at the start of the
        ///     current date time instance (seconds precision).
        /// </summary>
        public static DateTime StartOfTheDay(this DateTime dateTime) => new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                0, 0, 0, 0, dateTime.Kind);

        /// <summary>
        ///     Retrieves a date object, configured at the end of the
        ///     current date time instance (seconds precision).
        /// </summary>
        public static DateTime EndOfTheDay(this DateTime dateTime) => new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                23, 59, 59, 0, dateTime.Kind);

        /// <summary>
        ///     Converts the date time object to a unix timestamp in milliseconds.
        /// </summary>
        /// <param name="source">The source date time object.</param>
        public static long ToUnixTimestamp(this DateTime source)
        {
            return (long)(
                source
                    .ToUniversalTime()
                    .Subtract(
                        new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                    )
                    .TotalMilliseconds);
        }

        /// <summary>
        ///     Converts a unix timestamp (in milliseconds) to a date time object.
        /// </summary>
        /// <param name="source">The source unix timestamp.</param>
        public static DateTime ToDateTime(this long source)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(source);
        }
    }
}