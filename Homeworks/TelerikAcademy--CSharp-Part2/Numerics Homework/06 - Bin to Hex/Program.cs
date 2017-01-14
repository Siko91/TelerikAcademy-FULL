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
            case "0000": return "0";
            case "0001": return "1";
            case "0010": return "2";
            case "0011": return "3";
            case "0100": return "4";
            case "0101": return "5";
            case "0110": return "6";
            case "0111": return "7";
            case "1000": return "8";
            case "1001": return "9";
            case "1010": return "A";
            case "1011": return "B";
            case "1100": return "C";
            case "1101": return "D";
            case "1110": return "E";
            case "1111": return "F";

            default: return "....";
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.Write("Input Bin: ");
            string bin = Console.ReadLine().ToLower();
            bool isBinary = true;

            for (int i = 0; i < bin.Length; i++)
            {
                if (bin.Substring(i, 1).Equals("1"))
                { continue; }
                else if (bin.Substring(i, 1).Equals("0"))
                { continue; }
                else
                {
                    isBinary = false;
                    break;
                }
            }
            if (!isBinary)
            {
                Console.WriteLine("invalid input...\n\n");
                continue;
            }

            while (bin.Length % 4 != 0)
            {
                bin = "0" + bin;
            }

            string result = "";
            for (int i = 0; i < bin.Length / 4; i += 1)
            {
                result += GetValue(bin.Substring(i*4, 4));
            }
            Console.WriteLine("Result: {0}\n\n", result);
        }
    }
}
