namespace Prometheus.Core.Tests.Security
{
    using Prometheus.Core.Security;
    using Xunit;
    using System;

    public class HashProviderTests
    {
        [Fact(DisplayName = "BCrypt: Trivial use with random values")]
        public void BCryptTrivialUsecase()
        {
            var hasher = new BCryptHashProvider();

            var original = Guid.NewGuid().ToString();
            var password = $"{Guid.NewGuid()}{Guid.NewGuid()}";
            var salt = hasher.GenerateSalt();

            Assert.NotNull(salt);

            var hashed = hasher.HashString(original, salt);

            Assert.NotNull(hashed);

            var match = hasher.Verify(original, hashed, salt);

            Assert.True(match);
        }
        
        [Fact(DisplayName = "BCrypt: Trivial use with an embeded salt")]
        public void BCryptEmbededSalt()
        {
            var hasher = new BCryptHashProvider();

            var original = Guid.NewGuid().ToString();
            var password = $"{Guid.NewGuid()}{Guid.NewGuid()}";

            var hashed = hasher.HashString(original, null);

            Assert.NotNull(hashed);

            var match = hasher.Verify(original, hashed, null);

            Assert.True(match);
        }
        
        [Theory(DisplayName = "BCrypt: Increased complexity and performance")]
        [InlineData(128, 100)]
        [InlineData(256, 150)]
        [InlineData(512, 200)]
        public void BCryptWorkFactorPerformance(int workFactor, double expectedDurationInMilliseconds)
        {
            var start = DateTimeOffset.Now;
            var hasher = new BCryptHashProvider(workFactor);

            var original = Guid.NewGuid().ToString();
            var password = $"{Guid.NewGuid()}{Guid.NewGuid()}";

            var hashed = hasher.HashString(original, null);

            Assert.NotNull(hashed);

            var match = hasher.Verify(original, hashed, null);

            Assert.True(match);

            Assert.True((DateTimeOffset.Now - start).TotalMilliseconds < expectedDurationInMilliseconds);
        }
    }
}