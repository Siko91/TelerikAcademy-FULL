using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
.*/

class CopyOfProgram4
{
    static void Main(string[] args)
    {
        Console.Write("The Array will be a integers. Input length: ");
        int num = int.Parse(Console.ReadLine());

        int[] intArray = new int[num];

        for (int i = 0; i < num; i++)
        {
            intArray[i] = int.Parse(Console.ReadLine());
        }

        int longestLength = 0;
        int position = 0;

        for (int i = 0; i < intArray.Length; i++)
        {
            int temp = 1;

            for (int y = i+1; y < intArray.Length; y++)
            {
                if (intArray[i]+y-i == intArray[y])
                {
                    temp++;
                }
                else
                {
                    break;
                }
            }
            if (temp > longestLength)
            {
                position = i;
                longestLength = temp;
            }
        }
        Console.Write("Bigest sequence: ");
        for (int i = 0; i < longestLength; i++)
        {
            Console.Write(intArray[i + position] + " ");
        }
        Console.WriteLine();
    }
}
