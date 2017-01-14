using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program that compares two char arrays lexicographically (letter by letter).

class CompareChars
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input first string of chars.");
        string firstString = Console.ReadLine();
        Console.WriteLine("Input second string of chars.");
        string secondString = Console.ReadLine();

        char[] firstCharArr = firstString.ToCharArray();
        char[] secondCharArr = secondString.ToCharArray();

        int shorter = firstCharArr.Length;
        int longer = secondCharArr.Length;

        if (firstCharArr.Length > secondCharArr.Length)
        {
            shorter = secondCharArr.Length;
            longer = firstCharArr.Length;
        }

        for (int i = 0; i < shorter; i++)
        {
            if (firstCharArr[i].Equals(secondCharArr[i]))
            { Console.WriteLine("Char {0} of the first string is equal to char {0} of the second string.", i); }
            else
            { Console.WriteLine("Char {0} of the first string is NOT equal to char {0} of the second string.", i); }
        }

        for (int i = shorter; i < longer; i++)
        { Console.WriteLine("Cannot compare char {0}", i); }
    }
}