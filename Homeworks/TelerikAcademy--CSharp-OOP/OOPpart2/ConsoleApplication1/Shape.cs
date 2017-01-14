using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1Shapes
{
    public abstract class Shape
    {
        public virtual double CalculateSurface() { return -1; }
    }
}
