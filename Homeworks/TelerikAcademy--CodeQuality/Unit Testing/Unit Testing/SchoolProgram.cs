using System;
using System.Linq;
using System.Collections.Generic;

namespace UnitTesting
{
    class SchoolProgram
    {
        static void Main(string[] args)
        {
            School school = new School();

            Course math = school.CreateCourse("Math");
            Course biology = school.CreateCourse("Biology");

            List<Student> students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                students.Add(school.CreateStudent("studentName" + i));
                if (i % 2 == 0)
                {
                    math.AddStudent(students[i]);
                }
                else
                {
                    biology.AddStudent(students[i]);
                }
            }

            Console.WriteLine("Students who study math:");
            List<Student> mathSudents = math.Students;
            foreach (Student stud in mathSudents)
            {
                Console.WriteLine("- " + stud.Name);
            }

            Console.WriteLine("\n\nStudents who study biology:");
            List<Student> bioSudents = biology.Students;
            foreach (Student stud in bioSudents)
            {
                Console.WriteLine("- " + stud.Name);
            }
        }
    }
}
