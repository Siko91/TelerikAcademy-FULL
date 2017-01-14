using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.


class SimpleArrayProgram
{
    static void Main(string[] args)
    {
        int[] arr = new int[20];

        for (int i = 0; i < 20; i++)
        {
            Console.Write("Input arr[{0}]: ", i);
            arr[i] = int.Parse(Console.ReadLine());
            arr[i] = arr[i] * 5;
        }

        Console.WriteLine("The array is:");
        for (int i = 0; i < 20; i++)
        {
            Console.Write("{0}, ", arr[i]);
        }

    }
}