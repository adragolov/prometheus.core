using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Prometheus.Core.Security
{
    /// <summary>
    ///     Base class for all symmetric ciphers in the Prometheus framework.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the symmetric algorithm used for the needs of encryption.
    /// </typeparam>
    public abstract class SymmetricCipherBase<T> where T : SymmetricAlgorithm
    {
        /// <summary>
        ///     Retrieves an instance of the symmetric algorithm required by the cipher.
        /// </summary>
        protected abstract SymmetricAlgorithm CreateSymmetricAlgorithm();

        /// <summary>
        ///     Performs symmetric encryption of a source original string and returns the encrypted string.
        /// </summary>
        /// <param name="original">The originating string, required.</param>
        /// <param name="password">The password used to encrypt the original string, required.</param>
        /// <param name="salt">Random salt, ensuring that the encryption blob i unique.</param>
        public virtual string Encrypt(string original, string password, string salt)
        {
            using (var passwordDerivation = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt)))
            {
                using (var algorithm = CreateSymmetricAlgorithm())
                {
                    var rgbKey = passwordDerivation.GetBytes(algorithm.KeySize >> 3);
                    var rgbIV = passwordDerivation.GetBytes(algorithm.BlockSize >> 3);

                    using (var encryptor = algorithm.CreateEncryptor(rgbKey, rgbIV))
                    {
                        using (var memoryBuffer = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryBuffer, encryptor, CryptoStreamMode.Write))
                            {
                                using (var writer = new StreamWriter(cryptoStream, Encoding.Unicode))
                                {
                                    writer.Write(original);
                                }
                            }

                            return Uri.UnescapeDataString(
                                Convert.ToBase64String(memoryBuffer.ToArray())
                            );
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Performs symmetric decryption of a source encrypted string and returns the originating string.
        /// </summary>
        /// <param name="encrypted">The encrypted string, required.</param>
        /// <param name="password">The password used to encrypt the original string, required.</param>
        /// <param name="salt">Random salt, ensuring that the encryption blob i unique.</param>
        public virtual string Decrypt(string encrypted, string password, string salt)
        {
            encrypted = Uri.UnescapeDataString(encrypted);

            using (var passwordDerivation = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt)))
            {
                using (var algorithm = CreateSymmetricAlgorithm())
                {
                    var rgbKey = passwordDerivation.GetBytes(algorithm.KeySize >> 3);
                    var rgbIV = passwordDerivation.GetBytes(algorithm.BlockSize >> 3);

                    using (var decryptor = algorithm.CreateDecryptor(rgbKey, rgbIV))
                    {
                        using (var buffer = new MemoryStream(Convert.FromBase64String(encrypted)))
                        {
                            using (var stream = new CryptoStream(buffer, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
                                {
                                    return reader.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}