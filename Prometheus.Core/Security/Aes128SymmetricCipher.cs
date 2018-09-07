using System.Security.Cryptography;

namespace Prometheus.Core.Security
{
    /// <summary>
    ///     Represents a symmetric cipher using AES algorithm with key size of 128 bytes.
    /// </summary>
    public class Aes128SymmetricCipher : SymmetricCipherBase<Aes>, ISymmetricCipher
    {
        /// <summary>
        ///     Retrieves an instance of the symmetric algorithm required by the cipher.
        /// </summary>
        protected override SymmetricAlgorithm CreateSymmetricAlgorithm()
        {
            var result = Aes.Create();

            result.KeySize = 128;

            return result;
        }
    }
}