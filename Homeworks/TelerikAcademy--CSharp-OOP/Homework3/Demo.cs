using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    class Demo
    {
        static void Main()
        {
            Console.WriteLine("\n------------------\nTask 1\n");
            Console.WriteLine("Substringing of StringBuilder: " + new StringBuilder().Append("1234567890").Substring(3,5));

            Console.WriteLine("\n------------------\nTask 2\n");
            List<int> arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            Console.WriteLine(arr.Sum() + "\n" +
                arr.Product() + "\n" +
                arr.Min() + "\n" +
                arr.Max() + "\n" +
                arr.Average() );
            
            List<Student> students = new List<Student>();
            students.Add(new Student("Ati", "Zaev", 20, 111106111, "02/555555", "FakeMail@abv.bg", new List<int> { 3, 2, 2 }, 2));
            students.Add(new Student("Zlatio", "Kolchevich", 25, 111111112, "02/555555", "FakeMail@mail.bg", new List<int> { 3, 6, 4 }, 2));
            students.Add(new Student("Ivan", "Ivanchov", 15, 111106113, "02/555555", "FakeMail@abv.bg", new List<int> { 3, 6, 4 }, 5));
            students.Add(new Student("Alex", "Zelchev", 20, 111111111, "02/555555", "FakeMail@abv.bg", new List<int> { 2, 3, 2 }, 2));
            students.Add(new Student("Zlatio", "Kolchev", 25, 111106112, "02/555555", "FakeMail@mail.bg", new List<int> { 3, 3, 4 }, 2));
            students.Add(new Student("Ivan", "Ivanchov", 15, 111111113, "02/555555", "FakeMail@abv.bg", new List<int> { 3, 6, 4 }, 5));
            students.Add(new Student("Alex", "Zelchev", 20, 111111111, "02/555555", "FakeMail@abv.bg", new List<int> { 3, 3, 4 }, 3));
            students.Add(new Student("Zlatio", "Kolchev", 25, 111111112, "02/555555", "FakeMail@mail.bg", new List<int> { 2, 2, 2 }, 2));
            students.Add(new Student("Ivan", "Ivanchov", 15, 111111113, "02/555555", "FakeMail@abv.bg", new List<int> { 3, 6, 4 }, 5));

            Console.WriteLine("\n------------------\nTask 3\n");
            var result = students.FilterByLastNameBeforeFirstName();
            foreach (Student st in result)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Age + ")");
            }

            Console.WriteLine("\n------------------\nTask 4\n");
            result = students.FilterByAgeBetween(18, 24);
            foreach (Student st in result)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Age + ")");
            }

            Console.WriteLine("\n------------------\nTask 5\n");
            Console.WriteLine("   (Lambda)");
            result = students.OrderBy(st => st.FirstName).ThenBy(st => st.LastName);
            foreach (Student st in result)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Age + ")");
            }
            Console.WriteLine("   (LINQ)");
            result = from st in students
                     orderby st.FirstName, st.LastName
                     select st;
            foreach (Student st in result)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Age + ")");
            }

            Console.WriteLine("\n------------------\nTask 6\n");
            Console.WriteLine("   (Lambda)");
            IEnumerable<int> result2 = from n in arr
                                where (n % 3 == 0 || n % 7 == 0)
                                select n;
            Console.WriteLine(string.Join(", ", result2));
            Console.WriteLine("   (LINQ)");
            result2 = arr.Where(n => (n % 3 == 0 || n % 7 == 0));
            Console.WriteLine(string.Join(", ", result2));

            Console.WriteLine("\n------------------\nTask 7\n");
            Console.WriteLine("This task uses a timer.\nThe demo will clear the console after you press [enter].");
            Console.ReadLine();
            Console.Clear();
            DemoOfTimers.Demo();
            Console.Clear();

            Console.WriteLine("\n------------------\nTask 8\n");
            Console.WriteLine("I' too lazy for this!\n");

            Console.WriteLine("\n------------------\nTask 9\n");
            result = from st in students
                     where st.GroupNumber == 2
                     select st;
            foreach (Student st in result)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Age + ") - group: " + st.GroupNumber);
            }

            Console.WriteLine("\n------------------\nTask 10\n");
            result = students.Where(st => st.GroupNumber == 2);
            foreach (Student st in result)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Age + ") - group: " + st.GroupNumber);
            }

            Console.WriteLine("\n------------------\nTask 11\n");
            result = from st in students
                     where (st.Email.Trim().EndsWith("abv.bg"))
                     select st;
            foreach (Student st in result)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Age + ") -- " + st.Email);
            }

            Console.WriteLine("\n------------------\nTask 12\n");
            result = from st in students
                     where (st.Tel.Trim().StartsWith("02"))
                     select st;
            foreach (Student st in result)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Age + ") - Tel: " + st.Tel);
            }

            Console.WriteLine("\n------------------\nTask 13\n");
            var studentsWithExcellentMark =
                from st in students
                where st.Marks.Contains(6)
                select new { FullName = st.FirstName + " " + st.LastName, Marks = st.Marks };
            foreach (var st in studentsWithExcellentMark)
            {
                Console.WriteLine(st.FullName + " - (" + string.Join(",",st.Marks) + ")");
            }

            Console.WriteLine("\n------------------\nTask 14\n");
            var marksOfDumbStudents = students.GetMarksOfDumbStudents();
            foreach (List<int> marksOfSt in marksOfDumbStudents)
            {
                Console.WriteLine("(" + string.Join(",", marksOfSt) + ")");
            }


            Console.WriteLine("\n------------------\nTask 15\n");
            result = from st in students
                     where (st.FN.ToString().Substring(4, 2).Equals("06"))
                     select st;
            foreach (var st in result)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.FN + ")");
            }

            Console.WriteLine("\n------------------\nTask 16\n");
            result = from st in students
                     where (st.Departament.Equals(Group.Math))
                     select st;
            foreach (var st in result)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Departament.DepartmentName + ")");
            }

            Console.WriteLine("\n------------------\nTask 17\n");
            result = from st in students
                     orderby (st.FirstName + " " + st.LastName).Length
                     select st;
            Student studentWithLongestName = result.Last();
            Console.WriteLine(studentWithLongestName.FirstName + " " + studentWithLongestName.LastName + " has the longest name.");

            Console.WriteLine("\n------------------\nTask 18\n");
            IEnumerable<IEnumerable<Student>> groups =
                from st in students
                group st by st.GroupNumber into gr
                orderby gr.Key
                select gr;
            foreach (var gr in groups)
            {
                foreach (Student st in gr)
                {
                    Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Departament.DepartmentName + ")");
                }
            }

            Console.WriteLine("\n------------------\nTask 19\n");
            groups = null;
            groups = students.GroupByDepartament();
            foreach (var gr in groups)
            {
                foreach (Student st in gr)
                {
                    Console.WriteLine(st.FirstName + " " + st.LastName + " (" + st.Departament.DepartmentName + ")");
                }
            }

            Console.WriteLine("\n------------------\nTask 20\n");

            getNextNumber getNext = delegate (double num, double devider)
                                { return num/devider; };
            getNextNumber getNextDevider = delegate (double num, double devider)
                                { return num*2; };
            double aproximateResult = LastDemo.GetResult(1, getNext, getNextDevider);
            Console.WriteLine("1 + 1/2 + 1/4 + 1/8 + 1/16! + ... = {0:F2}", aproximateResult);

            getNext = delegate(double num, double devider)
            { return num / devider; };
            getNextDevider = delegate(double steps, double useless)
            {
                steps++;
                double resultDevider = 1;
                for (int i = 1; i <= steps; i++)
                {
                    resultDevider *= i;
                }
                return resultDevider; 
            };
            aproximateResult = LastDemo.GetResult(2, getNext, getNextDevider);
            Console.WriteLine("1 + 1/2! + 1/4! + 1/8! + 1/16! +... = {0:F2}", aproximateResult);

            getNext = delegate(double num, double devider)
            { return num / devider; };
            getNextDevider = delegate(double devider, double useless)
            { return -(devider*2); };
            aproximateResult = LastDemo.GetResult(1, getNext, getNextDevider);
            Console.WriteLine("1 + 1/2 + (-1/4) + 1/8 (-1/16) + ... = {0:F2}", aproximateResult);
        }
    }
}