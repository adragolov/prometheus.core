namespace Prometheus.Core.Security
{
    /// <summary>
    ///     Interface model for the functionality of a string hasher.
    /// </summary>
    public interface IHashProvider
    {
        /// <summary>
        ///     Generates a salt for hashing.
        /// </summary>
        string GenerateSalt();

        /// <summary>
        ///     Hashes the original string.
        /// </summary>
        /// <param name="original">The string to be hashed. Required.</param>
        /// <param name="salt">The salt to be used for hashing. Needs to be created via the <seealso cref="GenerateSalt"/> method.</param>
        string HashString(string original, string salt);

        /// <summary>
        ///     Verifies that the specified hash is matching the original string and optional salt.
        /// </summary>
        /// <param name="hash">The hashing string. Required.</param>
        /// <param name="original">The string to be hashed. Required.</param>
        /// <param name="salt">The salt to be used for hashing. Needs to be created via the <seealso cref="GenerateSalt"/> method.</param>
        bool Verify(string original, string hash, string salt);
    }
}