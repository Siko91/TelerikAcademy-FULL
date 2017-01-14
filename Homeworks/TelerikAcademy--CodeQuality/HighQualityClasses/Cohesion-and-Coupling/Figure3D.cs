using System;

namespace CohesionAndCoupling
{
    class Figure3D
    {
        public Figure3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonal3D()
        {
            Point3D zeroPoint = new Point3D(0, 0, 0);
            Point3D point = new Point3D(this.Width, this.Height, this.Depth);
            double distance = JustGeometry.CalcDistance3D(zeroPoint, point);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            Point2D zeroPoint = new Point2D(0, 0);
            Point2D point = new Point2D(this.Width, this.Height);
            double distance = JustGeometry.CalcDistance2D(zeroPoint, point);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            Point2D zeroPoint = new Point2D(0, 0);
            Point2D point = new Point2D(this.Width, this.Depth);
            double distance = JustGeometry.CalcDistance2D(zeroPoint, point);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            Point2D zeroPoint = new Point2D(0, 0);
            Point2D point = new Point2D(this.Height, this.Depth);
            double distance = JustGeometry.CalcDistance2D(zeroPoint, point);
            return distance;
        }
    }
}
