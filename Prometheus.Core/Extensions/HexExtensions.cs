using System;
using System.Globalization;

namespace Prometheus.Core.Extensions
{
    /// <summary>
    ///     Extension methods related to HEX string operations.
    /// </summary>
    public static class HexExtensions
    {
        /// <summary>
        ///     Converts a hex string to a byte array sequence.
        /// </summary>
        /// <param name="hexString">The source hex string.</param>
        public static byte[] ToByteArray(this string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return HexAsBytes;
        }

        /// <summary>
        ///     Converts a source hex string to a single byte. Expects at least one hex value in the string.
        /// </summary>
        /// <param name="hexString">The source hex string.</param>
        public static byte ToByte(this string hexString)
        {
            return hexString.ToByteArray()[0];
        }

        /// <summary>
        ///     Converts a source integer value to a hex string.
        /// </summary>
        /// <param name="source">The source integer.</param>
        public static string ToHex(this int source)
        {
            return source.ToString("X2");
        }


        /// <summary>
        ///     Converts a base64String to a hex string.
        /// </summary>
        /// <param name="base64Encoded">The source integer.</param>
        public static string ToHexFromBase64(this string base64Encoded)
        {
            byte[] convertedByte = Convert.FromBase64String(base64Encoded);
            string hex = BitConverter.ToString(convertedByte).Replace("-", "");
            return hex;
        }
    }
}