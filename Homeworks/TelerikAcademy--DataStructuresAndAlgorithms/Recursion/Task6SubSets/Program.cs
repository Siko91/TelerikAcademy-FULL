using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6SubSets
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> letters = new List<string>() { "test", "rock", "fun" };
            PrintAllVariations<string>(letters, 2);
        }

        private static void PrintAllVariations<T1>(List<T1> elements, int sizeOfVariation)
        {
            PrintAllVariations<T1>(elements, sizeOfVariation, new List<int>(), 0);
        }

        private static void PrintAllVariations<T1>(List<T1> elements, int sizeOfVariation, List<int> current, int currentIndex)
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

            for (int currentNum = currentIndex; currentNum < elements.Count(); currentNum++)
            {
                if (!current.Contains(currentNum))
                {
                    current.Add(currentNum);
                    PrintAllVariations(elements, sizeOfVariation, current, currentNum + 1);
                    current.RemoveAt(current.Count() - 1);
                }
            }
        }
    }
}
