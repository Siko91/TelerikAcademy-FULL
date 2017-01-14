using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

class Sorting
{
    static void Main(string[] args)
    {
        Console.Write("Input array length: ");
        int num = int.Parse(Console.ReadLine());

        int[] intArray = new int[num];
        int[] sortedIntArray = new int[num];

        for (int i = 0; i < num; i++)
        {
            Console.Write("Element [{0}]: ", i);
            intArray[i] = int.Parse(Console.ReadLine());
            sortedIntArray[i] = intArray[i];
        }

        for (int i = 0; i < num - 1; i++)
        {
            if (i > 0)
            {
                if (sortedIntArray[i] > sortedIntArray[i + 1])
                {
                    int temp = sortedIntArray[i + 1];
                    sortedIntArray[i + 1] = sortedIntArray[i];
                    sortedIntArray[i] = temp;

                    if (i > 1) { i -= 2; }
                }
            }
        }


        Console.Write("Unaranged: ");
        for (int i = 0; i < num; i++)
        {

            Console.Write(intArray[i] + "; ");
        }
        Console.WriteLine();

        Console.Write("Aranged: ");
        for (int i = 0; i < num; i++)
        {

            Console.Write(sortedIntArray[i] + "; ");
        }
        Console.WriteLine();
    }
}
