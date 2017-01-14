using System;

namespace Abstraction
{
    abstract class Figure
    {
        private double width;
        private double height;

        public virtual double Width 
        {
            get 
            {
                return this.width;
            }
            set
            {
                if (0 > value)
                {
                    throw new ArgumentOutOfRangeException("Width can not be negative");
                }
                this.width = value;
            }
        }
        public virtual double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (0 > value)
                {
                    throw new ArgumentOutOfRangeException("Height can not be negative");
                }
                this.height = value;
            }
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
