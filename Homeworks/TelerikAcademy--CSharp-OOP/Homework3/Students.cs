using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public long FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }
        public Group Departament { get; set; }

        public Student(string FirstName, string LastName, int Age, long FN,string Tel,string Email, List<int> Marks, int GroupNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.FN = FN;
            this.Tel = Tel;
            this.Email = Email;
            this.Marks = Marks;
            this.GroupNumber = GroupNumber;

            foreach (Group departament in Group.Departaments)
            {
                if (this.GroupNumber.Equals(departament.GroupNumber))
                {
                    this.Departament = departament;
                }
            }
        }
    }
    public static class StudentExtensions
    {
        public static IEnumerable<Student> FilterByLastNameBeforeFirstName(this IEnumerable<Student> students)
        {
            students = from student in students
                       where student.FirstName.CompareTo(student.LastName) == 1
                       select student;
            return students;
        }
        public static IEnumerable<Student> FilterByAgeBetween(this IEnumerable<Student> students, int MinAge, int MaxAge)
        {
            students = from student in students
                       where student.Age >= MinAge && student.Age <= MaxAge
                       select student;
            return students;
        }

        public static IEnumerable<List<int>> GetMarksOfDumbStudents(this IEnumerable<Student> students)
        {
            IEnumerable<List<int>> MarksOfDumbStudents = new List<List<int>>();
            MarksOfDumbStudents = from st in students
                                  where st.Marks.Count(mark => mark == 2) == 2
                                  select st.Marks;
            return MarksOfDumbStudents;
        }

        public static IEnumerable<IEnumerable<Student>> GroupByDepartament(this IEnumerable<Student> students)
        {
            IEnumerable<IEnumerable<Student>> groups =
                from st in students
                group st by st.GroupNumber into gr
                orderby gr.Key
                select gr;

            return groups;
        }
    }
}
