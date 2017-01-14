using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2CombinationsWithRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int limitNum = 3;
            int combinationSize =2;

            CreateCombinations(limitNum, combinationSize, new Stack<int>());
        }

        private static void CreateCombinations(int limitNum, int combinationSize, Stack<int> stack)
        {
            if (stack.Count() >= combinationSize)
            {
                Console.WriteLine(string.Join(",",stack));
                return;
            }
            for (int i = 1; i <= limitNum; i++)
            {
                stack.Push(i);
                CreateCombinations(limitNum, combinationSize, stack);
                stack.Pop();
            }
        }
    }
}
