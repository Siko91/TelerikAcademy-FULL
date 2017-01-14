using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03___examine_braclets
{
    class Program
    {
        static string wrong = "(2+(3+2))+(3+2)+)5/2) = ?";
        static string right = "(2+(3+2))+(3+2)+(5/2) = ?";

        static bool CheckBraclets(string str)
        {
            int bracletCounter = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (bracletCounter < 0)
                    return false;
                else if (str.Substring(i, 1).Equals("("))
                    bracletCounter++;
                else if (str.Substring(i, 1).Equals(")"))
                    bracletCounter--;
            }

            if (bracletCounter != 0)
                return false;
            else
                return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(wrong + "\nBraclets are currect : " + CheckBraclets(wrong));
            Console.WriteLine();
            Console.WriteLine(right + "\nBraclets are currect : " + CheckBraclets(right));
            Console.WriteLine();
        }
    }
}
