using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Data;

namespace CodeFirst.CreateDatabase
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = CarsDbContext.WorkingInstance;
            Console.WriteLine("Database created.");
        }
    }
}