using System;
using System.Collections.Generic;
using System.Linq;

namespace Task05_FilterNegatives
{
    internal class Program
    {
        /*
         * Write a program that removes from given sequence all negative numbers.
         */

        private static void Main(string[] args)
        {
            List<int> numbers = Task01_StoreValuesInList.Program.ReadNumbers();
            var result = numbers.Where(num => num > 0);
            Console.WriteLine("---------------------");
            Console.WriteLine(string.Format("Only Positives: {0}", string.Join(", ", result)));
        }
    }
}