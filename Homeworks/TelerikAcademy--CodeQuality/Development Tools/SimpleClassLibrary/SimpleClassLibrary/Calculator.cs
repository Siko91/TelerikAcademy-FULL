using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleClassLibrary
{
    /// <summary>
    /// A basic Calculator
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds the specified numbers.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>The sum.</returns>
        public int Add(int first, int second)
        {
            return first + second;
        }

        /// <summary>
        /// Substracts the specified numbers.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>The result.</returns>
        public int Substract(int first, int second)
        {
            return first - second;
        }

        /// <summary>
        /// Devides the specified numbers.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>The result.</returns>
        public int Devide(int first, int second)
        {
            return first / second;
        }

        /// <summary>
        /// Multiplyes the specified numbers.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>The result.</returns>
        public int Multiply(int first, int second)
        {
            return first * second;
        }
    }
}
