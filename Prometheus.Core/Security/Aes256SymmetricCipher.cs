using System.Security.Cryptography;

namespace Prometheus.Core.Security
{
    /// <summary>
    ///     Represents a symmetric cipher using AES algorithm with key size of 256 bytes.
    /// </summary>
    public class Aes256SymmetricCipher : SymmetricCipherBase<Aes>, ISymmetricCipher
    {
        /// <summary>
        ///     Retrieves an instance of the symmetric algorithm required by the cipher.
        /// </summary>
        protected override SymmetricAlgorithm CreateSymmetricAlgorithm() {

            var result = Aes.Create();

            result.KeySize = 256;

            return result;
        }
    }
}