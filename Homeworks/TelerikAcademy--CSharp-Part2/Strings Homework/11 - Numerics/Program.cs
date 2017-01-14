using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11___Numerics
{
    class Program
    {
        static int aligment = 15;

        static void Main(string[] args)
        {
            Console.Write("input number: ");
            bool inputDone = false;
            double num = 0;

            while (!inputDone)
            {
                try
                {
                    num = double.Parse(Console.ReadLine());
                    inputDone = true;
                }
                catch (FormatException e)   { Console.WriteLine(e.Message); }
                catch (OverflowException e) { Console.WriteLine(e.Message); }
            }

            Console.WriteLine("10: {0," + aligment + "}", num);
            Console.WriteLine("16: {0," + aligment + ":x}", (long)num);
            Console.WriteLine(" %: {0," + aligment + ":p}", num / 100);
            Console.WriteLine(" E: {0," + aligment + ":e}", num);
        }
    }
}
