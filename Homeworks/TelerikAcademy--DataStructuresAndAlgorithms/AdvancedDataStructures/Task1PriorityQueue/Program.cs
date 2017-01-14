using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task1PriorityQueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rnd = new Random();
            PriorityQueue<int> intQueue = new PriorityQueue<int>();
            for (int i = 0; i < 5000; i++)
            {
                intQueue.Enqueue(rnd.Next());
            }

            StringBuilder builder = new StringBuilder();
            foreach (var item in intQueue)
            {
                builder.Append(item + "\n");
            }
            Console.WriteLine(builder);
        }
    }
}