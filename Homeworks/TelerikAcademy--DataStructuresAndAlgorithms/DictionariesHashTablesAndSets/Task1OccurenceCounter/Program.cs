using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1OccurenceCounter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<double> myCollection = new List<double>();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                myCollection.Add(rnd.Next(0, 10) + 0.5);
            }
            AppearenceCounter<double> appCounter = new AppearenceCounter<double>(myCollection);
            foreach (double key in appCounter.Appearences.Keys)
            {
                Console.WriteLine(key + " ==> " + appCounter.Appearences[key] + " times");
            }
        }
    }
}