using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleClassLibrary
{
    /// <summary>
    /// Calculator with advanced features
    /// </summary>
    public class AdvansedCalculator : Calculator
    {
        /// <summary>
        /// Returns the Leftover after devide.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns></returns>
        public int LeftOverAfterDevide(int first, int second)
        {
            return first % second;
        }

        /// <summary>
        /// Powers the specified number.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns></returns>
        public int Power(int first, int second)
        {
            return (int)Math.Pow(first, second);
        }
    }
}
