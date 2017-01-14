using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3CombinationsWithoutRepetitions
{
    class Program
    {
        static void Main(string[] args)
        {
            int limitNum = 4;
            int combinationSize = 2;

            CreateCombinations(limitNum, combinationSize, new SortedSet<int>(), new List<int[]>());
        }

        private static void CreateCombinations(int limitNum, int combinationSize, SortedSet<int> currentCombination, List<int[]> combinations)
        {
            if (currentCombination.Count() >= combinationSize)
            {
                int[] arr = currentCombination.ToArray();
                bool combinationExists = false;
                foreach (var comb in combinations)
                {
                    bool allAreSame = true;
                    for (int i = 0; i < combinationSize; i++)
                    {
                        if (comb[i] != arr[i])
                        {
                            allAreSame = false;
                            break;
                        }
                    }
                    if (allAreSame)
                    {
                        combinationExists = true;
                        break;
                    }
                }

                if (!combinationExists)
                {
                    combinations.Add(currentCombination.ToArray());
                    Console.WriteLine(string.Join(",", currentCombination));
                    return;
                }
            }
            for (int i = 1; i <= limitNum; i++)
            {
                if (!currentCombination.Contains(i))
                {
                    currentCombination.Add(i);
                    CreateCombinations(limitNum, combinationSize, currentCombination, combinations);
                    currentCombination.Remove(i);
                }
            }
        }
    }
}
