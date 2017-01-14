using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework1
{
    public class Display
    {
        private readonly double width;
        private readonly double height;
        private readonly ulong numberOfColors;

        public Display(double width, double height, ulong numberOfColors)
        {
            if (width <= 0)
            { throw new ArgumentException("Field width must be a positive number"); }
            if (height <= 0)
            { throw new ArgumentException("Field height must be a positive number"); }

            this.width = width;
            this.height = height;
            this.numberOfColors = numberOfColors;
        }
        public double Width
        {
            get { return this.width; }
        }
        public double Height
        {
            get { return this.height; }
        }
        public double NumberOfColors
        {
            get { return this.numberOfColors; }
        }
    }
}
