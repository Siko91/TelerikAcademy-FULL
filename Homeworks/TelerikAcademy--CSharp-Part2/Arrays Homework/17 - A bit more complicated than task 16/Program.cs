using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/** Write a program that reads three integer numbers N, K and S and an array of N elements from the console. Find in the array a subset of K elements that have sum S or indicate about its absence.
*/


class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();

        bool thereAreResults = false;

        int sizeN = r.Next(10, 21);
        int subSizeK = r.Next(2, 5);
        int sumS = r.Next(30, 61);

        int[] arr = new int[sizeN];
        for (int i = 0; i < sizeN; i++) arr[i] = r.Next(0, 21);

        Console.Write("The array and numbers are generated automaticly.\n\nArray: ");
        for (int i = 0; i < sizeN; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine("\n");
        Console.WriteLine("Size: {0}\nSub size: {1}\nSearching sum: {2}\n", sizeN, subSizeK, sumS);

        int combinations = (int)Math.Pow(2, sizeN) - 1;

        for (int combination = 0; combination < combinations; combination++)
        {
            int currentSum = 0;
            int curentElements = 0;
            for (int element = 0; element < sizeN; element++)
            {
                if (((combination >> element) & 1) == 1)
                {
                    curentElements++;
                    currentSum += arr[element];
                }
            }
            if (curentElements == subSizeK)
            {
                if (currentSum == sumS)
                {
                    thereAreResults = true;
                    curentElements = 0;
                    for (int element = 0; element < sizeN; element++)
                    {
                        if (((combination >> element) & 1) == 1)
                        {
                            curentElements++;
                            Console.Write("{0:d2}", arr[element]);
                            if (curentElements < subSizeK)
                            {
                                Console.Write(" + ");
                            }
                        }
                    }
                    Console.WriteLine(" = " + sumS);
                }
            }
        }

        if (!thereAreResults)
        {
            Console.WriteLine("There are no results.");
        }
    }
}
