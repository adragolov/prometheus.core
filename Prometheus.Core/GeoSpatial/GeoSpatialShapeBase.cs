namespace Prometheus.Core.GeoSpatial
{
    /// <summary>
    ///     A business object that represents a geo spatial shape.
    /// </summary>
    public abstract class GeoSpatialShapeBase
    {
        /// <summary>
        ///     Gets the shape type.
        /// </summary>
        public abstract GeoSpatialShapeType GetShapeType();
    }
}