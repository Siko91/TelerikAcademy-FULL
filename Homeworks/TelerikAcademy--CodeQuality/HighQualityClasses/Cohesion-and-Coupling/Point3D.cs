using System;
using System.Linq;

namespace CohesionAndCoupling
{
    class Point3D : Point2D
    {
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
            : base(x, y)
        {
            this.Z = z;
        }
    }
}
