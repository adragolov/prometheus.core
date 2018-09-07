using System;
using System.Collections.Generic;
using System.Text;

namespace Prometheus.Core.Extensions
{
    /// <summary>
    ///     Extension methods for the <seealso cref="string"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Returns the base-64 encoded version of the source string.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="encoding">The encoding used for the end string, defaults to <seealso cref="Encoding.UTF8"/></param>
        public static string Base64Encode(this string source, Encoding encoding = null)
        {
            var bytes = (encoding ?? Encoding.UTF8).GetBytes(source);

            return Uri.UnescapeDataString(
                Convert.ToBase64String(bytes)
            );
        }

        /// <summary>
        ///     Returns the base-64 decoded version of the source string.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="encoding">The encoding used for the end string, defaults to <seealso cref="Encoding.UTF8"/></param>
        public static string Base64Decode(this string source, Encoding encoding = null)
        {
            var bytes = Convert.FromBase64String(
                Uri.UnescapeDataString(source)
            );

            return (encoding ?? Encoding.UTF8).GetString(bytes);
        }

        /// <summary>
        ///     Returns a collection of child chunks for a specified length.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="chunkSize">The chunk size.</param>
        public static IEnumerable<string> SplitChunks(this string source, int chunkSize)
        {
            for (int i = 0; i < source.Length; i += chunkSize)
                yield return source.Substring(i, chunkSize);
        }
    }
}