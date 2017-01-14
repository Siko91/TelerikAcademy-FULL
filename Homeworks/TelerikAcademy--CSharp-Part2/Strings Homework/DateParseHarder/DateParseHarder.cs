using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

namespace DateParseHarder
{
    class DateParseHarder
    {
        static string regexDate = @"((?<day>[01-3][01-9])/(?<month>[01][01-9])/(?<year>[01-9]{4})/((?<hours>[012][01-9]):(?<minutes>[01-5][01-9]):(?<seconds>[01-5][01-9]))){1}";
        static void Main(string[] args)
        {
            CultureInfo bg = new CultureInfo("bg-BG");
            Thread.CurrentThread.CurrentCulture = bg;

            Console.WriteLine("Input date in format [ DD/MM/YYYY/hh:mm:ss ]: ");
            Match date = Regex.Match(Console.ReadLine(), regexDate);
            int[] nums = new int[6];
            DateTime inputDate;

            while (!date.Success)
            {
                Console.WriteLine("Invalid input. Try again. ( DD/MM/YYYY/hh:mm:ss )");
                date = Regex.Match(Console.ReadLine(), regexDate);
            }

            if (!date.Success)
            {
                Console.WriteLine("Invalid input (not a date)");
                return;
            }
            else
            {
                nums[0] = int.Parse(date.Groups["year"].ToString());
                nums[1] = int.Parse(date.Groups["month"].ToString());
                nums[2] = int.Parse(date.Groups["day"].ToString());
                nums[3] = int.Parse(date.Groups["hours"].ToString());
                nums[4] = int.Parse(date.Groups["minutes"].ToString());
                nums[5] = int.Parse(date.Groups["seconds"].ToString());

                // Console.WriteLine(string.Join(" - ", nums));

                if (nums[0] == 0)
                { Console.WriteLine("Invalid input (year is 0)"); return; }
                if (nums[1] > 12 && nums[1] == 0)
                { Console.WriteLine("Invalid input (month must be between 01 and 12)"); return; }
                if (nums[2] > 31 && nums[2] == 0)
                { Console.WriteLine("Invalid input (day must be between 01 and 31)"); return; }
                if (nums[3] > 23)
                { Console.WriteLine("Invalid input (hours must be between 00 and 23)"); return; }
                // minutes and seconds are checked by the regex.

                inputDate = new DateTime(nums[0], nums[1], nums[2], nums[3], nums[4], nums[5]);

                inputDate = inputDate.AddHours(6);
                inputDate = inputDate.AddMinutes(30);

                Console.WriteLine(inputDate);
                PrintDayOfWeek(inputDate);
            }
        }

        static void PrintDayOfWeek(DateTime day)
        {
            switch (day.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("Понеделник / Ponedelnik");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("Вторник / Vtornik");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Сряда / Srqda");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("Четвъртък / Chetvartak");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Петък / Petak");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("Събота / Sabota");
                    break;
                case DayOfWeek.Sunday:
                    Console.WriteLine("Неделя / Nedelq");
                    break;
                default:
                    break;
            }
        }
    }
}
