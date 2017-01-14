using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static int GetValue(string ch)
    {
        switch (ch)
        {
            case "0": return 0;
            case "1": return 1;
            case "2": return 2;
            case "3": return 3;
            case "4": return 4;
            case "5": return 5;
            case "6": return 6;
            case "7": return 7;
            case "8": return 8;
            case "9": return 9;
            case "a": return 10;
            case "b": return 11;
            case "c": return 12;
            case "d": return 13;
            case "e": return 14;
            case "f": return 15;

            default: return 0;
        }
    }

    static void Main()
    {
        while (true)
	    {
	        Console.Write("Input Hex: ");
            string str = Console.ReadLine().ToLower();
            double num = 0;

            for (int i = str.Length-1; i >= 0; i--)
            {
                int power = str.Length - i - 1;
                num += GetValue(str.Substring(i, 1)) * Math.Pow(16, power);
            }
            Console.WriteLine("Result: {0}\n\n", num);
	    }
    }
}
