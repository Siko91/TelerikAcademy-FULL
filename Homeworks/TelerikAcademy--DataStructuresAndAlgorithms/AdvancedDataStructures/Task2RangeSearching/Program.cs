using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task2RangeSearching
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            Random rnd = new Random();
            OrderedMultiDictionary<double, string> itemCollection = new OrderedMultiDictionary<double, string>(true);

            timer.Start();
            for (int i = 0; i < 500000; i++)
            {
                itemCollection.Add(rnd.Next(), "itemName" + i);
            }
            timer.Stop();
            Console.WriteLine("Adding elements (x500 000): " + timer.Elapsed);

            timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 10000; i++)
            {
                itemCollection.Range(rnd.Next(), true, rnd.Next(), true);
            }
            timer.Stop();
            Console.WriteLine("Searching ranges (x10 000): " + timer.Elapsed);

            timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 1000000; i++)
            {
                itemCollection.Range(rnd.Next(), true, rnd.Next(), true);
            }
            timer.Stop();
            Console.WriteLine("Searching ranges (x1 000 000): " + timer.Elapsed);
        }
    }
}