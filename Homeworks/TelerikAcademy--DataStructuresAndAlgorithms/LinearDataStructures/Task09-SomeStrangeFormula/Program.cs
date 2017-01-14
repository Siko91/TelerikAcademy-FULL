using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task09_SomeStrangeFormula
{
    internal class Program
    {
        /*
            We are given the following sequence:
            S1 = N;
            S2 = S1 + 1;
            S3 = 2*S1 + 1;
            S4 = S1 + 2;
            S5 = S2 + 1;
            S6 = 2*S2 + 1;
            S7 = S2 + 2;
            ...
            Using the Queue<T> class write a program to print its first 50 members for given N.
            Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
         */

        private static void AddElements(Queue<int> que, int elementBasis)
        {
            que.Enqueue(elementBasis + 1);
            que.Enqueue(2 * elementBasis + 1);
            que.Enqueue(elementBasis + 2);
        }

        private static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("---------------");

            Queue<int> que = new Queue<int>();
            que.Enqueue(num);

            int currentElement = 0;
            int count = 0;
            while (count < 50)
            {
                count++;
                currentElement = que.Dequeue();
                Console.WriteLine(currentElement);
                if (que.Count < 50)
                {
                    AddElements(que, currentElement);
                }
            }
        }
    }
}