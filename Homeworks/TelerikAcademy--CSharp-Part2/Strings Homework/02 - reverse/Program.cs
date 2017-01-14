using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02___reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input str: ");
            string str = Console.ReadLine();
            IEnumerable<char> reversedCharArray = str.Reverse();
            Console.WriteLine(string.Join("",reversedCharArray));  // a lazy way to do it.
        }
    }
}
