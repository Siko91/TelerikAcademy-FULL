using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06___add_symbols_to_make_length
{
    class Program
    {
        static char symbol = '*';

        static void Main(string[] args)
        {
            Console.Write("Input string with length <= 20: ");
            string str = Console.ReadLine();

            while (str.Length > 20)
            {
                Console.Write("String length should be <= 20. Input again: ");
                str = Console.ReadLine();
            }

            string symbols = new string(symbol, (20 - str.Length));
            str += symbols;

            Console.Write("\n" + "Index:  ");
            for (int i = 0; i < 10; i++) { Console.Write(i); }
            for (int i = 0; i < 10; i++) { Console.Write(i); }
            Console.WriteLine("\n" + "String: " + str);
        }
    }
}
