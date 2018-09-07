namespace Prometheus.Core.Security
{
    /// <summary>
    ///     Hashing provider implementation based on the Blowfish cipher.
    /// </summary>
    public class BCryptHashProvider : IHashProvider
    {
        static class Defaults
        {
            public const int WorkFactor = 2 * 2 * 2;
        }

        /// <summary>
        ///     Gets or sets the work factory (complexity) used by the provider during hashing.
        /// </summary>
        public int WorkFactor { get; set; }

        /// <summary>
        ///     Initializes a new instance of the BCrypt hash provider.
        /// </summary>
        public BCryptHashProvider() : this(Defaults.WorkFactor)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the BCrypt hash provider.
        /// </summary>
        /// <param name="factor">
        ///     The work factor (complexity) used by the provider during hashing.
        /// </param>
        public BCryptHashProvider(int factor)
        {
            WorkFactor = factor;
        }

        /// <summary>
        ///     Generates a salt for hashing.
        /// </summary>
        public string GenerateSalt()
        {
            return BCrypt.BCryptHelper.GenerateSalt(Defaults.WorkFactor);
        }

        /// <summary>
        ///     Hashes the original string.
        /// </summary>
        /// <param name="original">The string to be hashed. Required.</param>
        /// <param name="salt">The salt to be used for hashing. Needs to be created via the <seealso cref="GenerateSalt"/> method.</param>
        public string HashString(string original, string salt = null)
        {
            salt = string.IsNullOrEmpty(salt) ?
                GenerateSalt() :
                salt;

            return BCrypt.BCryptHelper.HashPassword(original, salt);
        }

        /// <summary>
        ///     Verifies that the specified hash is matching the original string and optional salt.
        /// </summary>
        /// <param name="hash">The hashing string. Required.</param>
        /// <param name="original">The string to be hashed. Required.</param>
        /// <param name="salt">The salt to be used for hashing. Needs to be created via the <seealso cref="GenerateSalt"/> method.</param>
        public bool Verify(string original, string hash, string salt = null)
        {
            return BCrypt.BCryptHelper.CheckPassword(original, hash);
        }
    }
}
