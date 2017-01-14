using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02___randoms
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
                Console.Write(rnd.Next(100, 200) + " ");
            Console.WriteLine();
        }
    }
}
