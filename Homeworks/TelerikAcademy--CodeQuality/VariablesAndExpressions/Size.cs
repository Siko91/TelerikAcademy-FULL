using System;
using System.Linq;

namespace VariablesAndExpressions
{
    /// <summary>
    /// Basic 2D measurment class.
    /// </summary>
    public class Size
    {
        private double width;
        private double height;

        public double Width 
        {
            get 
            {
                return this.width;
            }
            set 
            {
                if (0 < value)
                {
                    throw new ArgumentException("Width can't be negative.");
                }
                this.width = value;
            } 
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (0 < value)
                {
                    throw new ArgumentException("Height can't be negative.");
                }
                this.height = value;
            }
        }

        /// <summary>
        /// Initializes a <see cref="Size" /> object
        /// </summary>
        /// <param name="width">Must be a positive number</param>
        /// <param name="height">Must be a positive number</param>
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}