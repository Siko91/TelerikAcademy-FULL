using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5Variations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> letters = new List<string>() { "hi", "a", "b" };
            PrintAllVariations<string>(letters, 2);
        }

        private static void PrintAllVariations<T1>(List<T1> elements, int sizeOfVariation)
        {
            PrintAllVariations<T1>(elements, sizeOfVariation, new List<int>());
        }

        private static void PrintAllVariations<T1>(List<T1> elements, int sizeOfVariation, List<int> current)
        {
            if (current.Count() >= sizeOfVariation)
            {
                var result = new List<T1>();
                for (int i = 0; i < current.Count(); i++)
                {
                    result.Add(elements[current[i]]);
                }
                Console.WriteLine(string.Format("< {0} >", string.Join(" > < ", result)));
                return;
            }

            for (int currentNum = 0; currentNum < elements.Count(); currentNum++)
            {
                current.Add(currentNum);
                PrintAllVariations(elements, sizeOfVariation, current);
                current.RemoveAt(current.Count() - 1);
            }
        }
    }
}