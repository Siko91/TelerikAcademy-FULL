using System;
using System.Linq;

namespace VariablesAndExpressions
{
    /// <summary>
    /// Printer that uses the console.
    /// </summary>
    public class ConsolePrinter
    {
        /// <summary>
        /// Pritnts a proper sentence including the value.
        /// </summary>
        public void PrintMax(double maxValue)
        {
            Console.WriteLine("The maximum value is {0}.", maxValue);
        }

        /// <summary>
        /// Pritnts a proper sentence including the value.
        /// </summary>
        public void PrintMin(double minValue)
        {
            Console.WriteLine("The minimum value is {0}.", minValue);
        }

        /// <summary>
        /// Pritnts a proper sentence including the value.
        /// </summary>
        public void PrintAvg(double averageValue)
        {
            Console.WriteLine("The average value is {0}.", averageValue);
        }
    }
}