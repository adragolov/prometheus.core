namespace Prometheus.Core.Tests.Security
{
    using GeoSpatial;
    using Xunit;

    public class GeoSpatialTests
    {
        /// <summary>
        ///     Attempt to match results from this online calculator.
        ///     https://gps-coordinates.org/distance-between-coordinates.php
        /// </summary>
        [Theory(DisplayName = "GeoSpatial: Distance agreement with Google Maps.")]
        /// Expecting high precision in small-distances
        [InlineData(42.6956d, 23.32191222d, 42.6978d, 23.32194257d, 0.24464d, 4)]
        /// Loss of precision over bigger distances.
        [InlineData(42.6956131212d, 23.12d, 41.123d, 26.434d, 325.21d, 1)]
        public void CalculatedDistanceExpectedPrecision(double lat1, double lon1, double lat2, double lon2, 
            double expectedDistanceInKm, int decimalPlacesPrecision)
        {
            var calculated = GeoSpatial.GetDistance(lat1, lon1, lat2, lon2, GeoSpatialDistanceUnit.Kilometer);

            Assert.Equal(calculated, expectedDistanceInKm, decimalPlacesPrecision);
        }
    }
}