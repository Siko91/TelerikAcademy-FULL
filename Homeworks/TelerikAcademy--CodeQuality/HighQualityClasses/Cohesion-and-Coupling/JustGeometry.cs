using System;
using System.Linq;

namespace CohesionAndCoupling
{
    class JustGeometry
    {

        public static double CalcDistance2D(Point2D pointA, Point2D pointB)
        {
            double squaredVerticalDistance = Math.Pow((pointB.X - pointA.X), 2);
            double squaredHorizontalDistance = Math.Pow((pointB.Y - pointA.Y), 2);
            double distance = Math.Sqrt(squaredVerticalDistance + squaredHorizontalDistance);
            return distance;
        }

        public static double CalcDistance3D(Point3D pointA, Point3D pointB)
        {
            double squaredVerticalDistance = Math.Pow((pointB.X - pointA.X), 2);
            double squaredHorizontalDistance = Math.Pow((pointB.Y - pointA.Y), 2);
            double squaredDebthDistance = Math.Pow((pointB.Z - pointA.Z), 2);
            double distance = Math.Sqrt(squaredVerticalDistance + squaredHorizontalDistance + squaredDebthDistance);
            return distance;
        }

    }
}
