using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task04_LongestSubsequenceOfEquals;

namespace Task06_RemoveNumsThatOccureOddNumberOfTimes
{
    internal class Program
    {
        /*
         * Write a program that removes from given sequence all numbers that occur odd number of times.
         * Example:
         * {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}
         */

        private static void Main(string[] args)
        {
            List<int> numbers = Task01_StoreValuesInList.Program.ReadNumbers();
            SubsequenceFinder<int> finder = new SubsequenceFinder<int>();
            var result = finder.RemoveElementsThatOccureOddNumberOfTimes(numbers);
            Console.WriteLine("---------------------");
            Console.WriteLine(string.Format("Only Positives: {0}", string.Join(", ", result)));
        }
    }
}