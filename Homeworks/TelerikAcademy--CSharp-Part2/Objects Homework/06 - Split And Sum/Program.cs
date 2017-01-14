using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace _06___Split_And_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            Console.WriteLine("input string (like \"05 999 -23 4.233 55\")");
            string[] str = Console.ReadLine().Split(' ');
            List<double> list = new List<double>();
            double temp;
            for (int i = 0; i < str.Length; i++)
                if (double.TryParse(str[i], out temp))
                    list.Add(temp);
            temp = 0;
            for (int i = 0; i < list.Count; i++)
                temp += list[i];
            Console.WriteLine("Sum is {0}", temp);
        }
    }
}
