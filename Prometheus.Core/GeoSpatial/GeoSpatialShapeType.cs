namespace Prometheus.Core.GeoSpatial
{
    /// <summary>
    ///     Enumerates the supported Geo-Spatial object shapes.
    /// </summary>
    public enum GeoSpatialShapeType
    {
        /// <summary>
        ///     A shape object with a central point and radius.
        /// </summary>
        Circle      =   0,

        /// <summary>
        ///     An open shape between a collection of geo spatial points.
        /// </summary>
        Polyline    =   100,

        /// <summary>
        ///     A closed boundary between a collection of geo spatial points.
        /// </summary>
        Polygon     =   200,
    }
}