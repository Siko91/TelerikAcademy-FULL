using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static string TakeHexChar(long num)
    {
        switch (num)
        {
            case 0: return "0";
            case 1: return "1";
            case 2: return "2";
            case 3: return "3";
            case 4: return "4";
            case 5: return "5";
            case 6: return "6";
            case 7: return "7";
            case 8: return "8";
            case 9: return "9";
            case 10: return "A";
            case 11: return "B";
            case 12: return "C";
            case 13: return "D";
            case 14: return "E";
            case 15: return "F";

            default: return "?";
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Input int: ");

            long num;
            if (long.TryParse(Console.ReadLine(), out num))
            {
                string result = "";

                while (num != 0)
                {
                    result += TakeHexChar(num % 16);
                    num /= 16;
                }

                string reversed = "";
                for (int i = result.Length-1; i >=0; i--)
                {
                    reversed += result.Substring(i, 1);
                }
                Console.WriteLine("Result: " + reversed + "\n\n");
            }
        }
    }
}
