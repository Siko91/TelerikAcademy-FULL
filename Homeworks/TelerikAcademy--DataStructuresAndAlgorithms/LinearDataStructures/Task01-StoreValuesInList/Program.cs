using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01_StoreValuesInList
{
    public class Program
    {
        /*
         * Write a program that reads from the console a sequence of positive integer numbers.
         * The sequence ends when empty line is entered.
         * Calculate and print the sum and average of the elements of the sequence.
         * Keep the sequence in List<int>.
         */

        public static List<int> ReadNumbers()
        {
            List<int> numbers = new List<int>();
            bool inputStopped = false;

            Console.WriteLine("Input numbers or white space to stop");
            while (!inputStopped)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    inputStopped = true;
                    continue;
                }
                int number = int.Parse(line);
                numbers.Add(number);
            }
            return numbers;
        }

        private static void Main(string[] args)
        {
            List<int> numbers = ReadNumbers();

            Console.WriteLine("---------------------");
            Console.WriteLine(string.Format("SUM: {0}", numbers.Sum()));
            Console.WriteLine(string.Format("AVG: {0}", numbers.Average()));
        }
    }
}