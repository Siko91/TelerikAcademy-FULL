using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Write a method that return the maximal element in a portion of array of integers starting at given index. Using it write another method that sorts an array in ascending / descending order.

class Program
{
    static int FindMaxInPortion(int[] arr, int start, int end)
    {
        int max = arr[start];
        int index = start;

        for (int i = start+1; i <= end; i++)
        {
            if (arr[i]>max)
            {
                max = arr[i];
                index = i;
            }
        }

        return index;
    }

    static int[] SortIncreasing(int[] arr)
    {
        for (int i = arr.Length-1; i > 0; i--)
		{
            int index = FindMaxInPortion(arr, 0, i);

            int temp = arr[index];
            arr[index] = arr[i];
            arr[i] = temp;
		}

        return arr;
    }

    static int[] SortDecreasing(int[] arr)
    {
        for (int i = 0; i < arr.Length-1; i++)
        {
            int index = FindMaxInPortion(arr, i, arr.Length - 1);

            int temp = arr[index];
            arr[index] = arr[i];
            arr[i] = temp;
        }

        return arr;
    }

    static void PrintArr(string str, int[] arr)
    {
        Console.Write("{0,11}: ", str);

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0,3}",arr[i]);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Random rnd = new Random();
        while (true)
        {
            int size = rnd.Next(10, 21);

            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(100);
            }

            PrintArr("Array", arr);
            PrintArr("Increasing", SortIncreasing(arr));
            PrintArr("Decreasing", SortDecreasing(arr));

            Console.WriteLine("\n\n\nPress [enter] to restart.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
