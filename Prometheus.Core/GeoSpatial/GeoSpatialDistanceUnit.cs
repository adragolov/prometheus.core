namespace Prometheus.Core.GeoSpatial
{
    /// <summary>
    ///     Enumerates the supported geo spatial distance units.
    /// </summary>
    public enum GeoSpatialDistanceUnit
    {
        /// <summary>
        ///     Default geo-spatial measurement unit, a mile.
        /// </summary>
        Mile = 0,

        /// <summary>
        ///     Measurement unit for a kilometer.
        /// </summary>
        Kilometer = 1,

        /// <summary>
        ///     Measurement unit for a nautical mile.
        /// </summary>
        NauticalMile = 2
    }
}