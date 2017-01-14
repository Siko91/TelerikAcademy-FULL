using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace _18___Extract_Dates
{
    class Program
    {
        static string text = "aaaa 24.12.2014 aaa 02.2.2015 .. 5.10.15 (this one will not match)";
        static char[] seperators = { ' ' };

        static void PrintCanadianDate(int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);
            Console.WriteLine(date);
        }

        static void Main(string[] args)
        {
            CultureInfo canada = new CultureInfo("en-CA");
            Thread.CurrentThread.CurrentCulture = canada;

            Console.WriteLine("Text: "+text);
            Console.WriteLine();
            string[] words = text.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                // Console.WriteLine(word);
                Match dateMatcher = Regex.Match(word, @"(?<day>[0-9]{1,2})\.(?<month>[0-9]{1,2})\.(?<year>[0-9]{4}){1}");
                if (dateMatcher.Success)
                {
                    int day = int.Parse(dateMatcher.Groups["day"].ToString());
                    int month = int.Parse(dateMatcher.Groups["month"].ToString());
                    int year = int.Parse(dateMatcher.Groups["year"].ToString());

                    PrintCanadianDate(year, month, day);
                }
            }
            Console.WriteLine();
        }
    }
}
