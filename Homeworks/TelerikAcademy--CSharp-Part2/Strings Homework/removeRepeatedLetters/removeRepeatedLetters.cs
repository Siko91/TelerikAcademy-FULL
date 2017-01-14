using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace removeRepeatedLetters
{
    class removeRepeatedLetters
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input str: ");
            string str = Console.ReadLine();

            for (int i = 1; i < str.Length; i++)
            {
                if (str.Substring(i - 1, 1).Equals(str.Substring(i, 1)))
                {
                    str = str.Substring(0, i) + str.Substring(i + 1);
                    i--;
                }
            }
            Console.WriteLine(str);
        }
    }
}
