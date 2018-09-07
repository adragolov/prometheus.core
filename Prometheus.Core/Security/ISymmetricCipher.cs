namespace Prometheus.Core.Security
{
    /// <summary>
    ///     Interface model for a symmetric cipher used to encrypt and decrypt encrypted strings.
    /// </summary>
    public interface ISymmetricCipher
    {
        /// <summary>
        ///     Performs symmetric decryption of a source encrypted string and returns the originating string.
        /// </summary>
        /// <param name="encrypted">The encrypted string, required.</param>
        /// <param name="password">The password used to encrypt the original string, required.</param>
        /// <param name="salt">Random salt, ensuring that the encryption blob i unique.</param>
        string Decrypt(string encrypted, string password, string salt);

        /// <summary>
        ///     Performs symmetric encryption of a source original string and returns the encrypted string.
        /// </summary>
        /// <param name="original">The originating string, required.</param>
        /// <param name="password">The password used to encrypt the original string, required.</param>
        /// <param name="salt">Random salt, ensuring that the encryption blob i unique.</param>
        string Encrypt(string original, string password, string salt);
    }
}