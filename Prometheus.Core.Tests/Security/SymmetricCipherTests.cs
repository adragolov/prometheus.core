using System;
using Xunit;

namespace Prometheus.Core.Tests.Security
{
    using Prometheus.Core.Security;
    
    public class SymmetricCipherTests
    {
        [Fact(DisplayName = "AES(256): Trivial use with random values")]
        public void AES256TrivialUsecase()
        {
            var cipher = new Aes256SymmetricCipher();

            var original = Guid.NewGuid().ToString();
            var password = $"{Guid.NewGuid()}{Guid.NewGuid()}";
            var salt = Guid.NewGuid().ToString();
            var encrypted = cipher.Encrypt(original, password, salt);
            var decrypted = cipher.Decrypt(encrypted, password, salt);

            Assert.Equal(original, decrypted);
        }

        [Fact(DisplayName = "AES(128): Trivial use with random values")]
        public void AES128TrivialUsecase()
        {
            var cipher = new Aes128SymmetricCipher();

            var original = Guid.NewGuid().ToString();
            var password = $"{Guid.NewGuid()}{Guid.NewGuid()}";
            var salt = Guid.NewGuid().ToString();
            var encrypted = cipher.Encrypt(original, password, salt);
            var decrypted = cipher.Decrypt(encrypted, password, salt);

            Assert.Equal(original, decrypted);
        }
    }
}