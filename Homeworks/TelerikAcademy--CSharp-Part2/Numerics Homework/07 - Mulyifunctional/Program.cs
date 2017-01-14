using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

class Program
{
    static string[] chars = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
    static long GetValue(string ch)
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
            case "A": return 10;
            case "B": return 11;
            case "C": return 12;
            case "D": return 13;
            case "E": return 14;
            case "F": return 15;

            default: return 0;
        }
    }

    static long ToDecimal(string str, int sys)
    {
        long decValue = 0;

        for (int i = 0; i < str.Length; i++)
        {
            int power = str.Length - 1 - i;

            decValue += GetValue(str.Substring(i,1)) * (long)Math.Pow(sys, power);
        }

        return decValue;
    }

    static string ToSys2(long num, int sys)
    {
        string result = "";

        while (num != 0)
        {
            result += chars[num % sys];
            num /= sys;
        }

        string reversed = "";
        for (int i = result.Length-1; i >= 0; i--)
        {
            reversed += result.Substring(i, 1);
        }

        return reversed;
    }

    static void Main()
    {
        while (true)
        {
            int sys1 = 0;
            int sys2 = 0;

            Console.Write("Input numeral system #1: ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out sys1))
                {
                    if (2 <= sys1 && 16 >= sys1)
                    {
                        break;
                    }
                }

                Console.Write("Invalid Input. Input numeral system #1 again: ");
            }
            Console.Write("Input numeral system #2: ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out sys2))
                {
                    if (2 <= sys2 && 16 >= sys2)
                    {
                        break;
                    }
                }

                Console.Write("Invalid Input. Input numeral system #1 again: ");
            }

            Console.Clear();

            while (true)
            {
                Console.Write("System #1: " + sys1 + "\n");
                Console.Write("System #2: " + sys2 + "\n\n");

                Console.Write("Input number. It must be in numeral system #1.\nInput \"restart\" if you want to restart the program.\n\n");

                string str = Console.ReadLine().ToUpper();

                if (str.Equals("RESTART"))
                    { Console.Clear(); break; }
                else
                {
                    bool isInSys1 = false;

                    for (int ch = 0; ch < str.Length; ch++)
                    {
                        isInSys1 = false;
                        for (int sysyemCh = 0; sysyemCh < sys1; sysyemCh++)
                        {
                            if (str.Substring(ch, 1).Equals(chars[sysyemCh]))
                            {
                                isInSys1 = true;
                            }
                        }
                        if (!isInSys1) break;
                    }
                    if (!isInSys1)
                    {
                        Console.Clear();
                        Console.WriteLine("The number is not in the currect numeric system.\n");
                        continue;
                    }

                    /////////////////////
                    long decimalValue = ToDecimal(str, sys1);
                    str = ToSys2(decimalValue, sys2);

                    Console.Clear();
                    string spaces = "      ";
                    Console.WriteLine("\n\n" + spaces + " Result: " + str + "\n" + spaces + "(Decimal: " + decimalValue + ")\n\n" + spaces + " Restarting...\n\n" + spaces + " .....\n" + spaces + "  ...\n" + spaces + "   .\n\n");

                }
            }

        }
    }
}
