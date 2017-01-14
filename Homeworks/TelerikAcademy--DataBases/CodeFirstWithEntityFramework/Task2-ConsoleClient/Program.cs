using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using StudentSystem.Models;

namespace Task2_ConsoleClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var consoleClient = new ConsoleClient(new StudentSystemDbContext());

            consoleClient.Add<Student>(new Student());
            consoleClient.Add<Course>(new Course());
            consoleClient.Add<StudyMaterial>(new StudyMaterial());
            consoleClient.Add<Homework>(new Homework());

            consoleClient.Save();
            consoleClient.ShowAll<StudyMaterial>();
        }
    }
}