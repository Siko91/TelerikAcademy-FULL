using System;
using System.Linq;

namespace CohesionAndCoupling
{
    class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
