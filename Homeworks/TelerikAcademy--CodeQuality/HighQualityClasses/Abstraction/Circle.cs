using System;

namespace Abstraction
{
    class Circle : Figure
    {
        public Circle(double radius)
            : base(0, 0)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return (this.Width / 2);
            }
            set
            {
                try
                {
                    this.Width = value * 2;
                    this.Height = value * 2;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    throw new ArgumentOutOfRangeException("Radius can not be negative.", e);
                }

            }
        }

        /// <summary>
        /// The diameter of the circle is also it's width.
        /// Important! By changing the width of the circle, you'll also change it's height.
        /// </summary>
        public override double Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        /// <summary>
        /// The diameter of the circle is also it's height.
        /// Important! By changing the height of the circle, you'll also change it's width.
        /// </summary>
        public override double Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
