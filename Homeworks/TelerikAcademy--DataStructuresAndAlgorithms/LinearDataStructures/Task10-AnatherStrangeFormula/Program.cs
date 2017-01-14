using System;
using System.Collections.Generic;
using System.Linq;

namespace Task10_AnatherStrangeFormula
{
    internal class Program
    {
        /*
             We are given numbers N and M and the following operations:

                N = N+1
                N = N+2
                N = N*2

                Write a program that finds the shortest sequence of operations
                    from the list above that starts from N and finishes in M. Hint: use a queue.

                Example: N = 5, M = 16
                Sequence: 5  7  8  16
         */

        private static void Main(string[] args)
        {
            Console.Write("N: ");
            int numN = int.Parse(Console.ReadLine());
            Console.Write("M: ");
            int numM = int.Parse(Console.ReadLine());

            if (numN > numM)
            {
                throw new ArgumentException("It's not funny to do that. You just can't do that.");
            }

            int currentNum = numN;
            Queue<int> que = new Queue<int>();
            que.Enqueue(currentNum);

            while (currentNum != numM)
            {
                if (currentNum <= numM / 2)
                {
                    currentNum *= 2;
                }
                else if (currentNum <= numM - 2)
                {
                    currentNum += 2;
                }
                else if (currentNum <= numM - 1)
                {
                    currentNum += 1;
                }
                que.Enqueue(currentNum);
            }

            Console.WriteLine("[" + string.Join("], [", que) + "]");
            Console.WriteLine("I didn't really understand why I needed a Queue.\n Any IEnumerable would've done the trick.");
            Console.WriteLine("This is called a greedy algorithm.");
        }
    }
}