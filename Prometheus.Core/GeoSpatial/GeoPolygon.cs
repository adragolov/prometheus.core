using System.Collections.Generic;

namespace Prometheus.Core.GeoSpatial
{
    /// <summary>
    ///     Represents a geo spatial polygon shape.
    /// </summary>
    public class GeoSpatialPolygon : GeoSpatialShapeBase
    {
        /// <summary>
        ///     Gets the collection of spatial points in the polygon.
        ///     A minimum of three points is required for a valid polygon shape.
        /// </summary>
        public ICollection<GeoSpatialPoint> Paths { get; protected set; }
            = new List<GeoSpatialPoint>();

        /// <summary>
        ///     Returns the polygon shape type.
        /// </summary>
        public override GeoSpatialShapeType GetShapeType()
        {
            return GeoSpatialShapeType.Polygon;
        }
    }
}