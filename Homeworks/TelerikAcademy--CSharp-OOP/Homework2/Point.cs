using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    public class Point
    {
        static readonly Point StartPoint = new Point(0,0,0);

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public override string ToString()
        {
            return this.X + " " + this.Y + " " + this.Z; 
        }

        public double GetDistance(Point point2)
        {
            return Math.Sqrt(
                        Math.Pow( this.X - point2.X , 2) + 
                        Math.Pow( this.Y - point2.Y , 2) + 
                        Math.Pow( this.Z - point2.Z , 2)
                        );
        }
        static public double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(
                        Math.Pow(p1.X - p2.X, 2) +
                        Math.Pow(p1.Y - p2.Y, 2) +
                        Math.Pow(p1.Z - p2.Z, 2)
                        );
        }
    }
}
