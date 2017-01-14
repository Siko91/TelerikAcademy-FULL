using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Exersises
{
    class Program
    {
        static long GetNum(string str)
        {
            //Console.WriteLine(str);
            string[] nums = { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };

            for (int i = 0; i < nums.Length; i++)
            {
                if (str.Equals(nums[i]))
                {
                    return i;
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            long result = 0;
            long currentNum = 0;
            int power = 0;

            for (int i = input.Length - 4; i >= 0; i -= 4)
            {
                currentNum = (long)Math.Pow(15, power) * GetNum(input.Substring(i, 4));
                //Console.WriteLine(currentNum);
                power++;
                result += currentNum;
            }
            Console.WriteLine(result);
        }
    }
}
