using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1UsageOfSortedDictionary
{
    internal class Program
    {
        public struct Student
        {
            public string courseName;
            public string fName;
            public string lName;
        }

        private static void Main(string[] args)
        {
            string path = "..\\..\\TextFile.txt";
            SortedDictionary<string, List<Student>> courcesWithStudents;
            courcesWithStudents = ParseTextFile(path);
            foreach (var course in courcesWithStudents)
            {
                var studs = course.Value.OrderBy(st => st.lName).ThenBy(st => st.fName).Select(st => st.fName + " " + st.lName);
                Console.WriteLine(course.Key + ": " + string.Join(", ", studs));
            }
        }

        private static Student ParseLine(string line)
        {
            string[] parts = line.Split('|').Select(word => word.Trim()).ToArray();

            return new Student()
            {
                fName = parts[0],
                lName = parts[1],
                courseName = parts[2]
            };
        }

        private static SortedDictionary<string, List<Student>> ParseTextFile(string path)
        {
            SortedDictionary<string, List<Student>> courcesWithStudents = new SortedDictionary<string, List<Student>>();
            List<Student> studs = new List<Student>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Student stud = ParseLine(line);
                    studs.Add(stud);
                    line = reader.ReadLine();
                }
            }

            foreach (Student stud in studs)
            {
                List<Student> courseStudentsList;
                if (courcesWithStudents.TryGetValue(stud.courseName, out courseStudentsList))
                {
                    courseStudentsList.Add(stud);
                }
                else
                {
                    courseStudentsList = new List<Student>();
                    courseStudentsList.Add(stud);
                    courcesWithStudents.Add(stud.courseName, courseStudentsList);
                }
            }
            return courcesWithStudents;
        }
    }
}