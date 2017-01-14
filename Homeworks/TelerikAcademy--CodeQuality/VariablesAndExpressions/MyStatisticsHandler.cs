using System;
using System.Linq;

namespace VariablesAndExpressions
{
    class MyStatisticsHandler
    {
        /// <summary>
        /// Prints the maximum, minimum, and average values of the inputed data, limited to a given index.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="count">Limit of how many values will be included in the equations.</param>
        public void PrintStatistics(double[] data, int limit)
        {
            int lastIndex = Math.Min(data.Length, limit);
            ConsolePrinter printer = new ConsolePrinter();

            double max = 0;
            for (int index = 0; index < lastIndex; index++)
            {
                if (data[index] > max)
                {
                    max = data[index];
                }
            }
            printer.PrintMax(max);

            double min = 0;
            for (int index = 0; index < lastIndex; index++)
            {
                if (data[index] < min)
                {
                    min = data[index];
                }
            }
            printer.PrintMin(min);

            double sum = 0;
            for (int index = 0; index < lastIndex; index++)
            {
                sum += data[index];
            }
            double average = sum / lastIndex;
            printer.PrintAvg(average);
        }
    }
}