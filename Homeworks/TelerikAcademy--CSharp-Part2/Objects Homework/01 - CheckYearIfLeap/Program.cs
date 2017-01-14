using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01___CheckYearIfLeap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("IsYearLeap = " + DateTime.IsLeapYear(year).ToString());
        }
    }
}
