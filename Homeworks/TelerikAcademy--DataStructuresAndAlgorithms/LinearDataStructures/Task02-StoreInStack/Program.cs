using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_StoreInStack
{
    internal class Program
    {
        /*
         * Write a program that reads N integers from the console
         * and reverses them using a stack.
         * Use the Stack<int> class.
         */

        private static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
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
                numbers.Push(number);
            }

            Console.WriteLine("---------------------");
            while (numbers.Count() > 0)
            {
                Console.WriteLine(numbers.Pop());
            }
        }
    }
}