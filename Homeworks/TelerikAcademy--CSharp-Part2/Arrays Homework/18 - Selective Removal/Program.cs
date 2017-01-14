using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();

        bool thereAreResults = false;

        int sizeN = r.Next(5, 16);

        int[] arr = new int[sizeN];
        for (int i = 0; i < sizeN; i++) arr[i] = r.Next(0, 21);

        Console.Write("The array and numbers are generated automaticly.\n\nArray: ");
        for (int i = 0; i < sizeN-1; i++)
        {
            Console.Write(arr[i] + ", ");
        }
        Console.WriteLine("{0}\nSize: {1}",arr[sizeN-1], sizeN);

        int combinations = (int)Math.Pow(2, sizeN) - 1;

        int[] numbersRemovedInCombination = new int[combinations];
        bool[] combinationIsSuccessful = new bool[combinations];
        for (int i = 0; i < combinations; i++){ combinationIsSuccessful[i] = false; }

        for (int comb = 0; comb < combinations; comb++)
        {
            int temp = 0;
            bool curentCombIsGood = true;
            int numbersRemoved = 0;
            for (int element = 0; element < sizeN; element++)
            {
                if (((comb >> element) & 1) != 1)
                {
                    if (temp <= arr[element])
                    {
                        temp = arr[element];
                    }
                    else
	                {
                        curentCombIsGood = false;
	                }
                }
                else
                {
                    numbersRemoved++;
                }
            }

            numbersRemovedInCombination[comb] = numbersRemoved;

            if (curentCombIsGood)
            {
                combinationIsSuccessful[comb] = true;
                thereAreResults = true;
            }
        }

        if (!thereAreResults)
        {
            Console.WriteLine("No results.");
            return;
        }

        // work on the reslts //

        int min = 99999;
        for (int i = 0; i < combinations; i++)
        {
            if (combinationIsSuccessful[i])
            {
                if (min > numbersRemovedInCombination[i])
                {
                    min = numbersRemovedInCombination[i];
                }
            }
        }
        Console.WriteLine("Elements removed: " + min + "\n");
        Console.WriteLine("Posible combinations:\n");
        for (int comb = 0; comb < combinations; comb++)
        {
            if (combinationIsSuccessful[comb])
            {
                if (min == numbersRemovedInCombination[comb])
                {
                    Console.Write(">>> ");
                    for (int element = 0; element < sizeN; element++)
                    {
                        if (((comb >> element) & 1) != 1)
                            Console.Write("{0:d2}", arr[element]);
                        else
                            Console.Write("--");

                        if (element < sizeN - 1) Console.Write(", ");
                    }
                    Console.WriteLine();
                }
            }
        }
        Console.WriteLine("\n");
    }
}
