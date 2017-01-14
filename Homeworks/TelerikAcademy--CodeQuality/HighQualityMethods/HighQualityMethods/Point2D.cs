using System;
using System.Linq;

namespace HighQualityMethods
{
    class Point2D
    {
        private double x;
        private double y;

        public Point2D(double x, double y) 
        {
            this.X = x;
            this.Y = y;
        }

        public double X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
    }
}
