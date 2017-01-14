using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).


class Program
{
    static void Main(string[] args)
    {
        int limit = 10000000;
        bool[] MarksOfPrimeNumbers = new bool[limit];

        for (int i = 0; i < limit; i++)
	    {
            MarksOfPrimeNumbers[i] = true;
	    }

        for (int i = 2 * 2; i < limit; i += 2)
        {
            MarksOfPrimeNumbers[i] = false;
        }
        for (int i = 3 * 2; i < limit; i += 3)
        {
            MarksOfPrimeNumbers[i] = false;
        }
        for (int i = 5 * 2; i < limit; i += 5)
        {
            MarksOfPrimeNumbers[i] = false;
        }
        for (int i = 7 * 2; i < limit; i += 7)
        {
            MarksOfPrimeNumbers[i] = false;
        }

        Console.Write("Prime numbers: ");
        for (int i = 0; i < limit; i++)
        {
            if (MarksOfPrimeNumbers[i])
            {
                Console.Write((i+2) + " "); 
            }
        }
        Console.WriteLine();
    }
}
