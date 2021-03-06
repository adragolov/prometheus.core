﻿namespace Prometheus.Core.GeoSpatial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    /// <summary>
    ///     Utility class for Geo-Spatial computation ops.
    /// </summary>
    public partial class GeoSpatial
    {
        static class Constants {

            public const double MinutesInDegree = 60d;

            public const double StatuteMilesInNauticalMile = 1.1515d;

            public const double KilometersInMile = 1.609344d;

            public const double NauticalMilesInMile = 0.8684d;
        }

        /// <summary>
        ///     Calculates geo-spatial distance between two locations.
        /// </summary>
        /// <param name="p1">The first point.</param>
        /// <param name="p2">The second point.</param>
        /// <param name="unit">
        ///     The desired distance measurement unit.
        /// </param>
        public static double GetDistance(
            GeoSpatialPoint p1,
            GeoSpatialPoint p2,
            GeoSpatialDistanceUnit unit = GeoSpatialDistanceUnit.NauticalMile)
        {
            return GetDistance(
                p1.Latitude,
                p1.Longitude,
                p2.Latitude,
                p2.Longitude,
                unit);
        }

        /// <summary>
        ///     Calculates geo-spatial distance between two locations.
        /// </summary>
        /// <param name="lat1">
        ///     The initial location latitude degrees.
        /// </param>
        /// <param name="lon1">
        ///     The initial location longitude degrees.
        /// </param>
        /// <param name="lat2">
        ///     The target location latitude degrees.
        /// </param>
        /// <param name="lon2">
        ///     The target location longitude degrees.
        /// </param>
        /// <param name="unit">
        ///     The desired distance measurement unit.
        /// </param>
        public static double GetDistance(
            double lat1, 
            double lon1, 
            double lat2, 
            double lon2, 
            GeoSpatialDistanceUnit unit = GeoSpatialDistanceUnit.NauticalMile)
        {
            double theta = lon1 - lon2;
            double dist = 
                Math.Sin(DegreesToRadians(lat1)) * Math.Sin(DegreesToRadians(lat2))
                + Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) * Math.Cos(DegreesToRadians(theta));
            dist = Math.Acos(dist);
            dist = RadiansToDegrees(dist);

            dist = 
                dist * 
                Constants.MinutesInDegree * 
                Constants.StatuteMilesInNauticalMile;

            if (unit ==  GeoSpatialDistanceUnit.Kilometer)
            {
                dist = dist * Constants.KilometersInMile;
            }
            else if (unit ==  GeoSpatialDistanceUnit.NauticalMile)
            {
                dist = dist * Constants.NauticalMilesInMile;
            }

            return dist;
        }

        /// <summary>
        ///     Verifies if a given vector point is contained in a given polygon of points.
        /// </summary>
        /// <param name="point">The originating point.</param>
        /// <param name="polygonPoints">The polygon points. A minimum of three is required.</param>
        public static bool IsPointInPolygon(Vector2 point, IEnumerable<Vector2> polygonPoints)
        {
            if (polygonPoints == null) throw new ArgumentNullException(nameof(polygonPoints));
            
            Vector2[] polygon = polygonPoints.ToArray();

            int polygonLength = polygon.Length, i = 0;
            bool inside = false;
            // x, y for tested point.
            float pointX = point.X, pointY = point.Y;
            // start / end point for the current polygon segment.
            float startX, startY, endX, endY;
            Vector2 endPoint = polygon[polygonLength - 1];
            endX = endPoint.X;
            endY = endPoint.Y;
            while (i < polygonLength)
            {
                startX = endX; startY = endY;
                endPoint = polygon[i++];
                endX = endPoint.X; endY = endPoint.Y;
                //
                inside ^= (endY > pointY ^ startY > pointY) /* ? pointY inside [startY;endY] segment ? */
                          && /* if so, test if it is under the segment */
                          ((pointX - endX) < (pointY - endY) * (startX - endX) / (startY - endY));
            }
            return inside;
        }

        /// <summary>
        ///     Verifies if a given vector point is contained in a given polygon of points.
        /// </summary>
        /// <param name="point">The originating point.</param>
        /// <param name="polygonPoints">The polygon points. A minimum of three is required.</param>
        public static bool IsPointInPolygon(GeoSpatialPoint point, IEnumerable<GeoSpatialPoint> polygonPoints)
        {
            return IsPointInPolygon(point.ToVector(), polygonPoints?.Select(p => p.ToVector()));
        }

        /// <summary>
        ///     Converts degrees to radians.
        /// </summary>
        /// <param name="deg">The input degrees value.</param>
        public static double DegreesToRadians(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
        /// <summary>
        ///     Converts radians to degrees.
        /// </summary>
        /// <param name="rad">The input radians value.</param>
        public static double RadiansToDegrees(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
