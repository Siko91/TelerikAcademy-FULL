using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademyDBContext;

namespace Task2DontDoQueriesLikeThisOne
{
    internal class Program
    {
        private static void DoItFast(TelerikAcademyEntities context)
        {
            int sofiaMentions = context.Employees
                .Select(e => e.Address)
                .Select(a => a.Town)
                .Where(t => t.Name == "Sofia")
                .Count();
            Console.WriteLine("Sofia is mentioned " + sofiaMentions + " times");
        }

        private static void DoItSlow(TelerikAcademyEntities context)
        {
            int sofiaMentions = context.Employees
                .ToList()
                .Select(e => e.Address)
                .ToList()
                .Select(a => a.Town)
                .ToList()
                .Where(t => t.Name == "Sofia")
                .Count();
            Console.WriteLine("Sofia is mentioned " + sofiaMentions + " times");
        }

        private static void Main(string[] args)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            DoItFast(context);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            watch = new Stopwatch();
            watch.Start();
            DoItSlow(context);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }
    }
}