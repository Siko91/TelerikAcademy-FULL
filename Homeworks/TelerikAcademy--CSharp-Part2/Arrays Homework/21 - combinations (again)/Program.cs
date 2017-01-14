using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        List<int> myList = new List<int>();

        Random rnd = new Random();

        int length = rnd.Next(5, 10);
        int subLength = length + 1;
        while (subLength > length)
        {
            subLength = rnd.Next(3, 7);
        }

        Console.Write("Array: ");
        for (int i = 0; i < length; i++)
        {
            myList.Add(rnd.Next(0, 15));
            Console.Write(myList[i] + " ");
        }
        Console.WriteLine("\nElements in combinations: " + subLength);

        WriteCombinations(myList, subLength);
    }

    static void WriteCombinations(List<int> myList, int subLength)
    {
        int counterA = 0, countToA = 3;
        if (subLength > 5) countToA = 2;

        int length = myList.Count();

        int combinations = (int)Math.Pow(2, length) - 1;

        for (int combination = 0; combination < combinations; combination++)
        {
            int counterE = 0;
            for (int element = 0; element < length; element++)
            {
                if (((combination >> element) & 1) == 1)
                {
                    counterE++;
                }
            }
            if (counterE == subLength)
            {
                counterE = 0;
                Console.Write("[");
                for (int element = 0; element < length; element++)
                {
                    if (((combination >> element) & 1) == 1)
                    {
                        counterE++;
                        Console.Write("{0,2}", myList[element]);
                        if (counterE < subLength) Console.Write(", ");
                    }
                }
                Console.Write("]");

                counterA++;
                if (counterA >= countToA) { Console.WriteLine(""); counterA = 0; }
                else Console.Write(" -- ");
            }
        }
        Console.WriteLine();
        return;
    }
}
