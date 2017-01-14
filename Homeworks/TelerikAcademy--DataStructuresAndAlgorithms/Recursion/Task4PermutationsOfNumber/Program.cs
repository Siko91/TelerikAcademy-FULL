using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4PermutationsOfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 3;
            PrintPermutations(3, new List<int>());
        }

        private static void PrintPermutations(int num, List<int> current)
        {
            if (current.Count() >= num)
            {
                Console.WriteLine("{" +string.Join("-", current) + "}");
                return;
            }

            for (int currentNum = 1; currentNum <= num; currentNum++)
            {
                if (!current.Contains(currentNum))
                {
                    current.Add(currentNum);
                    PrintPermutations(num, current);
                    current.RemoveAt(current.Count() - 1);
                }
            }
        }
    }
}
