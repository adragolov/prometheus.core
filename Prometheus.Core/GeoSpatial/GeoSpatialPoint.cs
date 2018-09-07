using System;
using System.Numerics;

namespace Prometheus.Core.GeoSpatial
{
    /// <summary>
    ///     Represents the data for a single geo-spatial location.
    /// </summary>
    public struct GeoSpatialPoint : IEquatable<GeoSpatialPoint>, IEquatable<Vector2>
    {
        /// <summary>
        ///     Gets the longitude degrees for the point.
        /// </summary>
        public double Longitude { get; private set; }

        /// <summary>
        ///     Gets the latitude degrees for the point.
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        ///     Creates a new spatial point.
        /// </summary>
        /// <param name="lat">The point latitude degrees.</param>
        /// <param name="lon">The point longitude degrees.</param>
        public GeoSpatialPoint(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }

        /// <summary>
        ///     Creates a new spatial point.
        /// </summary>
        /// <param name="vector">Originating vector object.</param>
        public GeoSpatialPoint(Vector2 vector)
        {
            Latitude = vector.X;
            Longitude = vector.Y;
        }

        /// <summary>
        ///     Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="other">The other object to be compared.</param>
        public override bool Equals(object other)
        {
            return other != null && other is GeoSpatialPoint && Equals((GeoSpatialPoint)other);
        }

        /// <summary>
        ///     Gets a vector instance for this spatial point.
        /// </summary>
        public Vector2 ToVector()
        {
            return new Vector2(
                Convert.ToSingle(Latitude), 
                Convert.ToSingle(Longitude));
        }

        /// <summary>
        ///     Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="other">The other spatial point to be compared.</param>
        public bool Equals(GeoSpatialPoint other)
        {
            return Latitude == other.Latitude && Longitude == other.Longitude;
        }

        /// <summary>
        ///     Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="other">The other spatial point to be compared.</param>
        public bool Equals(Vector2 other)
        {
            return Latitude == other.X && Longitude == other.Y;
        }

        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }

        /// <summary>
        ///     Operator == overloading.
        /// </summary>
        /// <param name="p1">The first spatial point.</param>
        /// <param name="p2">The second spatial point.</param>
        public static bool operator==(GeoSpatialPoint p1, GeoSpatialPoint p2)
        {
            return p1.Equals(p2);
        }

        /// <summary>
        ///     Operator != overloading.
        /// </summary>
        /// <param name="p1">The first spatial point.</param>
        /// <param name="p2">The second spatial point.</param>
        public static bool operator !=(GeoSpatialPoint p1, GeoSpatialPoint p2)
        {
            return !p1.Equals(p2);
        }

        /// <summary>
        ///     Operator == overloading.
        /// </summary>
        /// <param name="p1">The first spatial point.</param>
        /// <param name="p2">The second spatial point.</param>
        public static bool operator ==(GeoSpatialPoint p1, Vector2 p2)
        {
            return p1.Equals(p2);
        }
        
        /// <summary>
        ///     Operator != overloading.
        /// </summary>
        /// <param name="p1">The first spatial point.</param>
        /// <param name="p2">The second spatial point.</param>
        public static bool operator !=(GeoSpatialPoint p1, Vector2 p2)
        {
            return !p1.Equals(p2);
        }
    }
}