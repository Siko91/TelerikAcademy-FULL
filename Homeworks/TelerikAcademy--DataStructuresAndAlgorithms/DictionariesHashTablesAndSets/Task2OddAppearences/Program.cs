using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task1OccurenceCounter;

namespace Task2OddAppearences
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> myCollection = new List<string>() { "C#", "SQL", "PHP", "PHP", "SQL", "SQL", "C#", "SQL", "PHP", "PHP", "SQL", "SQL", "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            AppearenceCounter<string> counter = new AppearenceCounter<string>(myCollection);
            foreach (string item in counter.Appearences.Keys)
            {
                if (counter.Appearences[item] % 2 == 1)
                {
                    Console.WriteLine(item + " ==> " + counter.Appearences[item] + " times");
                }
                else
                {
                    Console.WriteLine(item + " ==> Even number of times");
                }
            }
        }
    }
}