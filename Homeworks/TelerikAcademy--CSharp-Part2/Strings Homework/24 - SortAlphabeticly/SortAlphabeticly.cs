using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortAlphabeticly
{
    class SortAlphabeticly
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input words seperated by spaces: ");
            List<string> words = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

            Console.WriteLine();

            words.Sort();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }
    }
}
