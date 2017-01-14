using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4HashTable
{
    internal class Program
    {
        internal class Point
        {
            internal int x;

            internal int y;
        }

        private static void Main(string[] args)
        {
            var table = new HashTable<Point, int>();

            for (int i = 0; i < 1000; i++)
            {
                table.Add(new Point() { x = i, y = i }, i);
            }

            int myCounter = 0;
            foreach (var item in table)
            {
                myCounter++;
            }
            Console.WriteLine("Counted by foreach: " + myCounter);
            Console.WriteLine("Counted by .Count(): " + table.Count());
        }
    }
}