using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a method that adds two polynomials. Represent them as arrays of their coefficients 

class Program
{
    static void PrintPolinom(int[] arr)
    {
        string str = "(";
        for (int i = 0; i < arr.Length; i++)
	    {
            if (arr[i] > 99)
                str += " " + arr[i];
            else if (arr[i] > 9)
                str += "  " + arr[i];
            else if (arr[i] < -99)
                str += arr[i];
            else if (arr[i] < -9)
                str += " " + arr[i];
            else if (arr[i] < 0)
                str += "  " + arr[i];
            else
                str += "   " + arr[i];

            if (i>0)
            {
                str += " X^" + i;
            }
            if (i<arr.Length-1)
            {
                str += ") + (";
            }
            else
            {
                str += ")";
            }
	    }

        Console.WriteLine("   " + str);
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

    static void Main(string[] args)
    {
        Random rnd = new Random();

        while (true)
        {
            int size1 = rnd.Next(1, 6);
            int size2 = rnd.Next(1, 6);

            int[] arr1 = new int[size1];
            int[] arr2 = new int[size2];

            for (int i = 0; i < size1; i++) arr1[i] = rnd.Next(-99, 100);
            for (int i = 0; i < size2; i++) arr2[i] = rnd.Next(-99, 100);

            PrintPolinom(arr1);
            Console.WriteLine("        +");
            PrintPolinom(arr2);
            Console.WriteLine("-------------------------------------------------------------");

            int[] result = AddPolinomes(arr1, arr2);
            PrintPolinom(result);

            Console.WriteLine("\n\n\nPress [enter] to restart the program.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
