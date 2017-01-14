using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Combinations
{
    static void Main(string[] args)
    {
        Console.Write("Input array length: ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("How many numbers to sum?: ");
        int subNum = int.Parse(Console.ReadLine());

        if (num < subNum)
        {
            Console.WriteLine("K must be < than N!");
            return;
        }

        int[] intArray = new int[num];
        int[] positions = new int[num];
        int[] sortedIntArray = new int[num];

        for (int i = 0; i < num; i++)
        {
            Console.Write("Element [{0}]: ", i);
            intArray[i] = int.Parse(Console.ReadLine());
            sortedIntArray[i] = intArray[i];
            positions[i] = i;
        }

        for (int i = 0; i < num-1; i++)
        {
            if (i>0)
            {
                if (sortedIntArray[i] > sortedIntArray[i + 1])
                {
                    int temp = sortedIntArray[i + 1];
                    sortedIntArray[i + 1] = sortedIntArray[i];
                    sortedIntArray[i] = temp;

                    temp = positions[i + 1];
                    positions[i + 1] = positions[i];
                    positions[i] = temp;
                    
                    if (i > 1) { i -= 2; }
                }
            }
        }

        for (int i = 1; i <= subNum; i++)
        {
            Console.WriteLine("Element {0} is {1}, and has index of {2}.", i, intArray[positions[num - i]], positions[num - i]);
        }
    }
}
