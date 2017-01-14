using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Write a program that reads two arrays from the console and compares them element by element.

class AnotherSimpleArrayOperation
{
    static void Main(string[] args)
    {
        Console.Write("Input size of arrays: ");
        int num = int.Parse(Console.ReadLine());

        int[] arr1 = new int[num];
        int[] arr2 = new int[num];

        for (int y = 0; y < num; y++)
        {
            Console.Write("Input element {0} of the first array: ", y);
            arr1[y] = int.Parse(Console.ReadLine());
        }
        for (int y = 0; y < num; y++)
        {
            Console.Write("Input element {0} of the second array: ", y);
            arr2[y] = int.Parse(Console.ReadLine());
        }

        string result = "";

        for (int i = 0; i < num; i++)
        {
            if (arr1[i] == arr2[i]) { result = "equal to"; }
            else if (arr1[i] > arr2[i]) { result = "biger than"; }
            else { result = "smaller than"; }

            Console.WriteLine("Element [{0}] of the first array is {1} element [{0}] of the second array.", i, result);
        }
    }
}