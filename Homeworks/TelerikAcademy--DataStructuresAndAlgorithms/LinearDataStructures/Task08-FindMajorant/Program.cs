using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task04_LongestSubsequenceOfEquals;

namespace Task08_FindMajorant
{
    internal class Program
    {
        /*
         * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
         * Write a program to find the majorant of given array (if exists).
         * Example:
         * {2, 2, 3, 3, 2, 3, 4, 3, 3}  3
         */

        private static void Main(string[] args)
        {
            List<int> numbers = Task01_StoreValuesInList.Program.ReadNumbers();
            SubsequenceFinder<int> finder = new SubsequenceFinder<int>();
            var result = finder.CountItemAppearences(numbers);
            Console.WriteLine("---------------------");
            int majorant = 0;
            bool majorantIsFound = false;
            foreach (var key in result.Keys)
            {
                if (result[key] > numbers.Count / 2)
                {
                    majorantIsFound = true;
                    majorant = key;
                    break;
                }
            }

            if (majorantIsFound)
            {
                Console.WriteLine(string.Format("Majorant is {0}", majorant));
            }
            else
            {
                Console.WriteLine("No majorant found...");
            }
        }
    }
}