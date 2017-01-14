using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task04_LongestSubsequenceOfEquals;

namespace Task07_CountItems
{
    internal class Program
    {
        /*
         * Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
         * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
         * 2  2 times
         * 3  4 times
         * 4  3 times
         */

        private static void Main(string[] args)
        {
            List<int> numbers = Task01_StoreValuesInList.Program.ReadNumbers();
            SubsequenceFinder<int> finder = new SubsequenceFinder<int>();
            var result = finder.CountItemAppearences(numbers);
            Console.WriteLine("---------------------");
            foreach (var key in result.Keys)
            {
                Console.WriteLine(string.Format("Item {0} appeared {1} times", key, result[key]));
            }
        }
    }
}