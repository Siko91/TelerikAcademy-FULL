using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1Shapes
{
    class Circle : Shape
    {
        public double Radius { get; private set; }

        public Circle(double Radius)
        {
            if (Radius <= 0)
            {
                throw new ArgumentException("Radius must be positive.");
            }
            this.Radius = Radius;
        }

        public override double CalculateSurface() { return (Math.PI * Radius * Radius); }
    }
}
