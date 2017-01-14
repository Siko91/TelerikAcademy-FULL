using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice
{
    class Program
    {
        static long GetNum(string str)
        {
            //Console.WriteLine(str);
            string[] nums = { "CHU", "TEL", "OFT", "IVA", "EMY",
                                "VNB", "POQ", "ERI", "CAD", "K-A",
                                "IIA", "YLO", "PLA", };
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
            string input = Console.ReadLine().ToUpper();

            long result = 0;
            long currentNum = 0;
            int power = 0;

            for (int i = input.Length - 3; i >= 0; i -= 3)
            {
                currentNum = (long)Math.Pow(13, power) * GetNum(input.Substring(i, 3));
                //Console.WriteLine(currentNum);
                power++;
                result += currentNum;
            }
            Console.WriteLine(result);
        }
    }
}
