using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1LoopsWithRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 3;
            RecursiveLoop(num, new Stack<int>());
        }

        static void RecursiveLoop(int num, Stack<int> nums)
        {
            if (nums.Count() >= num)
            {
                Console.WriteLine(string.Join("-",nums));
                return;
            }

            for (int currentNum = 0; currentNum < num; currentNum++)
            {
                nums.Push(currentNum);
                RecursiveLoop(num, nums);
                nums.Pop();
            }
        }
    }
}
