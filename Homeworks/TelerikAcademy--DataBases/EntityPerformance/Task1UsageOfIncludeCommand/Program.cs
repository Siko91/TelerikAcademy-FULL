using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademyDBContext;

namespace Task1UsageOfIncludeCommand
{
    internal class Program
    {
        private static void DoItWithInclude(TelerikAcademyEntities context)
        {
            var empls = context.Employees.Include("Department").Include("Address.Town");

            foreach (var empl in empls)
            {
                string str = empl.FirstName + " " + empl.LastName + " - " + empl.Department.Name + " - " + empl.Address.Town.Name;

                //Console.WriteLine(str);
            }
        }

        private static void DoItWithoutInclude(TelerikAcademyEntities context)
        {
            var empls = context.Employees;
            foreach (var empl in empls)
            {
                string str = empl.FirstName + " " + empl.LastName + " - " + empl.Department.Name + " - " + empl.Address.Town.Name;

                //Console.WriteLine(str);
            }
        }

        private static void Main(string[] args)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            DoItWithInclude(context);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            watch = new Stopwatch();
            watch.Start();
            DoItWithoutInclude(context);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }
    }
}