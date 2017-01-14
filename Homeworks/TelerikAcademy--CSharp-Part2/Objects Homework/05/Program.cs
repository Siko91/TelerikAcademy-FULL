using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Warning! The program is slow if the year is too far away. Do NOT input years greater than 2200. Thank you.

namespace _05
{
    class Program
    {
        static int[] InputDate()
        {
            string temp;
            int year, month, day;
            DateTime today = DateTime.Now;

            Console.WriteLine("Input year (YYYY), month (MM) and day (DD):");
            while (true)
            {
                temp = Console.ReadLine();
                if (temp.Length <= 4)
                    if (int.TryParse(temp, out year))
                        if (year >= today.Year)
                            if (year >= today.Year + 100)
                            {
                                Console.WriteLine("That's a bit too far away...");
                                Console.WriteLine("input 'ok' to keep the year, or an empty string to change it again.");
                                if (Console.ReadLine().ToLower().Equals("ok"))
                                    break;
                            }
                            else
                                break;
                Console.Write("Incurect year. Try again:");
            }
            while (true)
            {
                temp = Console.ReadLine();
                if (temp.Length <= 2)
                    if (int.TryParse(temp, out month))
                        if (month > 0 && month < 13)
                            break;
                Console.Write("Incurect month. Try again:");
            }
            while (true)
            {
                temp = Console.ReadLine();
                if (temp.Length <= 2)
                    if (int.TryParse(temp, out day))
                        if (month > 0 && month < 32)
                            break;
                Console.Write("Incurect day. Try again:");
            }

            int[] dayArr = { year, month, day };
            return dayArr;
        }


        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            int[] date = InputDate();
            DateTime inputDay = new DateTime(date[0], date[1], date[2]);

            Console.WriteLine("\n" + today);
            Console.WriteLine(inputDay + "\n");

            List<DateTime> hollyDays = new List<DateTime>();

            hollyDays.Add(new DateTime(today.Year, 12, 25));
            hollyDays.Add(new DateTime(today.Year, 12, 31));
            hollyDays.Add(new DateTime(today.Year + 1, 1, 1));
            // and so on...

            long sum = 0;

            for (DateTime day = today; day.CompareTo(inputDay) <= 0; day = day.AddHours(24))
            {
                Console.Write("{0,15} - ", day.DayOfWeek);

                bool notWeekend = false;
                switch (day.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Wednesday:
                        notWeekend = true;
                        break;
                    default:
                        break;
                }
                if (notWeekend && hollyDays.Count() > 0)
                {
                    for (int i = 0; i < hollyDays.Count(); i++)
                    {
                        if (day.Equals(hollyDays[i]))
                        {
                            notWeekend = false;
                            break;
                        }
                    }
                }
                if (notWeekend)
                {
                    sum++;
                    Console.WriteLine("Work");
                }
                else
                {
                    Console.WriteLine("Hollyday");
                }
                if (day.DayOfWeek.ToString().Equals("Sunday"))
                {
                    DateTime temp = day.AddDays(1);
                    Console.WriteLine("\n  Week Number: {0,2}. From {1} to {2}. ({3} year)", (day.DayOfYear / 7 + 1), temp.Day.ToString() + "-" + temp.Month.ToString(), temp.AddDays(7).Day.ToString() + "-" + temp.AddDays(7).Month.ToString(), day.Year);
                    Console.WriteLine("-----------------------------");

                }
            }

            Console.WriteLine();
            Console.WriteLine("Work Days: " + sum);
        }
    }
}