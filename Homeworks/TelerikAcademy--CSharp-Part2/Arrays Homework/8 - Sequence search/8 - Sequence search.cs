using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Write a program that finds the sequence of maximal sum in given array. Example:
	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
	Can you do it with only one loop (with single scan through the elements of the array)?
*/

class SequenceSearch
{
    static void Main(string[] args)
    {
        Console.Write("Input array length: ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("How many numbers to sum?: ");
        int subNum = int.Parse(Console.ReadLine());

        if (num < subNum)
        {
            Console.WriteLine("K must not be biger than N!");
            return;
        }

        int[] intArray = new int[num];

        for (int i = 0; i < num; i++)
        {
            Console.Write("Element [{0}]: ", i);
            intArray[i] = int.Parse(Console.ReadLine());
        }


        // main logic
        int currentSum = 0, largestSum = 0, position = 0;

        for (int i = 0; i < num - subNum + 1; i++)
        {
            currentSum = intArray[i];

            for (int y = i+1; y < subNum + i; y++)
            {
                currentSum += intArray[y];
            }
            if (currentSum > largestSum)
            {
                largestSum = currentSum;
                position = i;
            }
        }

        // results

        Console.Write("Included element positions: ");
        for (int i = 0; i < subNum; i++)
        {
            Console.Write(position + i);

            if (i < subNum - 1)
            {
                Console.Write(", ");
            }
            else
            {
                Console.Write(";");
            }
        }
        Console.WriteLine();

        Console.Write("Included element values: ");
        for (int i = 0; i < subNum; i++)
        {
            Console.Write(intArray[position + i]);

            if (i < subNum - 1)
            {
                Console.Write(", ");
            }
            else
            {
                Console.Write(";");
            }
        }
        Console.WriteLine();

        Console.WriteLine("Sum: {0}", largestSum);
    }
}
