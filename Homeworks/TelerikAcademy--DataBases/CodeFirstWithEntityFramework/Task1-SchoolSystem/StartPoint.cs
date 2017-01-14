using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using StudentSystem.Models;

namespace Task1_StudentSystem
{
    internal class StartPoint
    {
        private static void Main()
        {
            StudentSystemDbContext db = new StudentSystemDbContext();
            db.Students.Add(new Student());
            Console.WriteLine("There are " + db.Students.Count() + " students in the data base ");
        }
    }
}