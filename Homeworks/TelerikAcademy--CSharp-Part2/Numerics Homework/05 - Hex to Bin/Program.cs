using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static string GetValue(string ch)
    {
        switch (ch)
        {
            case "0": return "0000";
            case "1": return "0001";
            case "2": return "0010";
            case "3": return "0011";
            case "4": return "0100";
            case "5": return "0101";
            case "6": return "0110";
            case "7": return "0111";
            case "8": return "1000";
            case "9": return "1001";
            case "a": return "1010";
            case "b": return "1011";
            case "c": return "1100";
            case "d": return "1101";
            case "e": return "1110";
            case "f": return "1111";

            default: return "....";
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.Write("Input Hex: ");
            string str = Console.ReadLine().ToLower();
            string bin = "";

            for (int i = 0; i < str.Length; i++)
            {
                bin += GetValue(str.Substring(i, 1));
            }

            Console.WriteLine("Result: {0}\n\n", bin);
        }
    }
}
