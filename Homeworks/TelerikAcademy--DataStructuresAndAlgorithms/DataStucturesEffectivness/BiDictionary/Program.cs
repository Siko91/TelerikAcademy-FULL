using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BiDictionary<int, int, int> myStrangeCollection = new BiDictionary<int, int, int>();
            Random rnd = new Random();

            int length = 1000000;

            var timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < length; i++)
            {
                myStrangeCollection.Add(rnd.Next(), rnd.Next(), rnd.Next());
            }

            timer.Stop();
            Console.WriteLine("adding: " + timer.Elapsed);
            timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < length; i++)
            {
                myStrangeCollection.FindByBothKeys(rnd.Next(), rnd.Next());
            }

            timer.Stop();
            Console.WriteLine("search by 2 keys: " + timer.Elapsed);
            timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < length; i++)
            {
                myStrangeCollection.FindByFirstKey(rnd.Next());
            }

            timer.Stop();
            Console.WriteLine("search by 1st key: " + timer.Elapsed);
            timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < length; i++)
            {
                myStrangeCollection.FindBySecondKey(rnd.Next());
            }

            timer.Stop();
            Console.WriteLine("search by 2nd key: " + timer.Elapsed);
            timer = new Stopwatch();
        }
    }
}