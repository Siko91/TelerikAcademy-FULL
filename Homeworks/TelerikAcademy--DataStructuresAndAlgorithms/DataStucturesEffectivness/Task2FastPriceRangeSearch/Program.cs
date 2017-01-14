using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task2FastPriceRangeSearch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            OrderedMultiDictionary<double, Product> productsByPrice = new OrderedMultiDictionary<double, Product>(true);
            Random rnd = new Random();

            timer.Start();

            for (int i = 0; i < 1000000; i++)
            {
                Product pr = new Product("Title", rnd.Next() + (rnd.Next(100) / 100));
                productsByPrice.Add(pr.Price, pr);
            }

            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < 2000000; i++)
            {
                var range = productsByPrice.Range(0, true, rnd.Next(), true);
            }

            timer.Stop();
            Console.WriteLine(timer.Elapsed);
        }
    }
}