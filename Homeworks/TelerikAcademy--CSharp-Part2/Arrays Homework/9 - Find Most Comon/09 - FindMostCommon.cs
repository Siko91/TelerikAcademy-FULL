using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Write a program that finds the most frequent number in an array. Example:
	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
*/

class SequenceSearch
{
    static void Main(string[] args)
    {
        Console.Write("Input array length: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Array will be string[] type. No need to whatch what you're typing.");

        string[] strArray = new string[num];

        for (int i = 0; i < num; i++)
        {
            Console.Write("Element [{0}]: ", i);
            strArray[i] = Console.ReadLine();
        }

        int mostAppearences = 0, curentAppearences = 0, position = 0;

        for (int i = 0; i < num; i++)
        {
            curentAppearences = 1;

            for (int y = i+1; y < num; y++)
            {
                if (strArray[i].Equals(strArray[y]))
                {
                    curentAppearences++;
                }
            }
            if (curentAppearences > mostAppearences)
            {
                position = i;
                mostAppearences = curentAppearences;
            }
        }

        Console.WriteLine("Element \'{0}\' has appeared {1} times in the array.", strArray[position], mostAppearences);
    }
}
