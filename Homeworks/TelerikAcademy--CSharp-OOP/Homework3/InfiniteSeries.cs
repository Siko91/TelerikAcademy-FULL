using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    public delegate double getNextNumber(double num, double devider);

    public class LastDemo
    {
        public static double GetResult(double devider, getNextNumber pathToNext, getNextNumber pathToNextDevider)
        {
            double result = 1;
            double prevous = 0;

            while (Math.Abs(result - prevous) >= 0.009)
            {
                prevous = result;
                devider = pathToNextDevider(devider, 0);
                result += pathToNext(1, devider);
            }
            return result;
        }
    }
}
