using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_LongestSubsequenceOfEquals
{
    internal class Program
    {
        /*
         * Write a method that finds the longest subsequence of equal numbers
         * in given List<int> and returns the result as new List<int>.
         * Write a program to test whether the method works correctly.
         */

        private static void Main(string[] args)
        {
            List<int> numbers = Task01_StoreValuesInList.Program.ReadNumbers();
            SubsequenceFinder<int> finder = new SubsequenceFinder<int>();
            IList<int> result = finder.FindLongestSubsequenceOfEqualElements(numbers);
            Console.WriteLine("---------------------");
            Console.WriteLine(string.Format("Longest Equal sub sequence: {0}", string.Join(", ", result)));
        }
    }
}