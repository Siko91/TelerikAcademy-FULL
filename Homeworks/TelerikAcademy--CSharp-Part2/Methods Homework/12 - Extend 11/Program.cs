using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a method that adds two polynomials. Represent them as arrays of their coefficients 

class Program
{
    static void PrintPolinom(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            string str = "(";
            str += arr[i];

            if (i > 0) str += " X^" + i;
            str += ")";

            Console.Write("{0,11}", str);

            if (i< arr.Length-1)
                Console.Write(" +");
        }
        Console.WriteLine();
    }

    static int[] AddPolinomes(int[] arr1, int[] arr2)
    {
        if (arr1.Length < arr2.Length)
            return AddPolinomes(arr2, arr1);

        int[] result = new int[arr1.Length];

        for (int i = 0; i < arr2.Length; i++)
        {
            result[i] = arr1[i] + arr2[i];
        }
        for (int i = arr2.Length; i < arr1.Length; i++)
        {
            result[i] = arr1[i];
        }

        return result;
    }
    static int[] SubstractPolinomes(int[] arr1, int[] arr2)
    {
        int size = arr1.Length;
        if (arr1.Length < arr2.Length)
            size = arr2.Length;

        int[] result = new int[size];

        for (int i = 0; i < size; i++)
        {
            result[i] = 0;
            if (arr1.Length > i) result[i] += arr1[i];
            if (arr2.Length > i) result[i] -= arr2[i];
        }
        return result;
    }

    static int[] MultiplyPolinomes(int[] arr1, int[] arr2)
    {
        int size = arr1.Length;
        if (arr1.Length < arr2.Length)
            size = arr2.Length;

        int[] result = new int[size];

        for (int i = 0; i < size; i++)
        {
            result[i] = 1;
            if (arr1.Length > i) result[i] = arr1[i];
            if (arr2.Length > i) result[i] *= arr2[i];
        }
        return result;
    }

    static void Main(string[] args)
    {
        Random rnd = new Random();

        while (true)
        {
            Console.WriteLine("     " + "Press [Enter] to restart the program.");
            Console.WriteLine("     " + "Press [Escape] to exit.");
            Console.WriteLine("     " + "Press [1] to add the polinomes.");
            Console.WriteLine("     " + "Press [2] to substract the polinomes.");
            Console.WriteLine("     " + "Press [3] to multiply the polinomes.\n\n\n\n");

            int size1 = rnd.Next(1, 6);
            int size2 = rnd.Next(1, 6);

            int[] arr1 = new int[size1];
            int[] arr2 = new int[size2];

            for (int i = 0; i < size1; i++) arr1[i] = rnd.Next(-99, 100);
            for (int i = 0; i < size2; i++) arr2[i] = rnd.Next(-99, 100);

            PrintPolinom(arr1);
            Console.WriteLine("and");
            PrintPolinom(arr2);

            for (int i = 0; i < 70; i++) Console.Write("-");
            Console.WriteLine();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.Enter)
                    { break; }
                    else if (pressedKey.Key == ConsoleKey.Escape)
                    { return; }
                    else if (pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.NumPad1)
                    {
                        Console.WriteLine(" Add...");
                        int[] result = AddPolinomes(arr1, arr2);
                        PrintPolinom(result);
                    }
                    else if (pressedKey.Key == ConsoleKey.D2 || pressedKey.Key == ConsoleKey.NumPad2)
                    {
                        Console.WriteLine(" Substract...");
                        int[] result = SubstractPolinomes(arr1, arr2);
                        PrintPolinom(result);
                    }
                    else if (pressedKey.Key == ConsoleKey.D3 || pressedKey.Key == ConsoleKey.NumPad3)
                    {
                        Console.WriteLine(" Multyply...");
                        int[] result = MultiplyPolinomes(arr1, arr2);
                        PrintPolinom(result);
                    }
                }
            }

            Console.Clear();
        }
    }
}
