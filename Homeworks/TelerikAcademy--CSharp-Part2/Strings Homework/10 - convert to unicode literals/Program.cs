using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10___convert_to_unicode_literals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input str: ");
            string str = Console.ReadLine();
            foreach (char ch in str)
            {
                Console.Write("\\{0:X4} ",(int)ch);
            }
            Console.WriteLine();
        }
    }
}
