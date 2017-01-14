using System;
using System.Linq;

namespace BunnyEscape.Core
{
    public class Point2D
    {
        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public static double GetDistance(Point2D p1, Point2D p2) 
        {
            double xd = p1.X - p2.X;
            double yd = p1.Y - p2.Y;

            return Math.Sqrt(xd * xd + yd * yd);
        }

        public double DistanceTo(Point2D p2)
        {
            return Point2D.GetDistance(this, p2);
        }

        public bool IsLeftOf(Point2D p2)
        {
            return this.X < p2.X;
        }

        public bool IsRightOf(Point2D p2)
        {
            return this.X > p2.X;
        }

        public bool IsBellowOf(Point2D p2)
        {
            return this.Y > p2.Y;
        }

        public bool IsAbove(Point2D p2)
        {
            return this.Y < p2.Y;
        }

        public double ToAngle()
        {
            double angleInDegrees = Math.Atan2(this.Y, this.X) * 180 / Math.PI;
            return angleInDegrees;
        }

        public double DirectionTo(Point2D target)
        {
            double deltaY = target.Y - this.Y;
            double deltaX = target.X - this.X;

            double angleInDegrees = Math.Atan2(deltaY, deltaX) * 180 / Math.PI;
            return angleInDegrees;
        }
    }
}