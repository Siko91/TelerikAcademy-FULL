using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03___day_of_week
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            Console.WriteLine(today.DayOfWeek);
        }
    }
}
