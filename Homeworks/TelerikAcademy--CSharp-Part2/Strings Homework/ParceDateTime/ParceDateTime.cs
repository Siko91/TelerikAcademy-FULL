using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ParceDateTime
{
    class ParceDateTime
    {
        static string regexDate = @"((?<day>[0123][1-9])/(?<month>[01][1-9])/(?<year>[01-9]{3}[1-9]{1})){1}";

        static void Main(string[] args)
        {
            string[] dateStr = new string[2];
            DateTime[] dates = new DateTime[2];
            int year = 0, month = 0, day = 0;

            for (int i = 0; i < 2; i++)
            {
                Console.Write("Input date number " + (1 + i) + " in the format DD/MM/YYYY: ");
                dateStr[i] = Console.ReadLine();
                Match date = Regex.Match(dateStr[i], regexDate);
                //Console.WriteLine(date.Value);
                if (!date.Success)
                {
                    i--;
                }
                else
                {
                    year = int.Parse(date.Groups["year"].ToString());
                    month = int.Parse(date.Groups["month"].ToString());
                    day = int.Parse(date.Groups["day"].ToString());

                    dates[i] = new DateTime(year, month, day);
                }
            }
            if (dates[0].CompareTo(dates[1]) >= 1)
            {
                Console.WriteLine("The first date is after the second, or they are equal");
            }
            else
            {
                long days = 0;
                for (; dates[0].CompareTo(dates[1]) <= 0; dates[0] = dates[0].AddDays(1))
                {
                    days++;
                }
                Console.WriteLine("Days between : " + days);
            }
        }
    }
}
