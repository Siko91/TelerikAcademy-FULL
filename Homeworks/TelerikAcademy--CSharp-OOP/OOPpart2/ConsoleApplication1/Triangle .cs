using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1Shapes
{
    class Triangle : Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Triangle(double Width, double Height)
        {
            if (Width <= 0)
            {
                throw new ArgumentException("Width must be positive.");
            }

            if (Height <= 0)
            {
                throw new ArgumentException("Height must be positive.");
            }
            this.Width = Width;
            this.Height = Height;
        }

        public override double CalculateSurface() { return (Height * Width / 2); }
    }
}
