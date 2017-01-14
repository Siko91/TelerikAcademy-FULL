using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1Student
{
    class Start
    {
        static void Main()
        {
            Student stud = new Student(University.University1,
                "Name1",
                "Name2", 
                "Name3", 
                123456789, 
                "Address1", 
                1,
                Speciality.Kung_Fu,
                Faculty.Faculty1, 
                "MyMail@MyHost.somewhere",
                "0999/99-99-99",
                "123/45-67-89");

            Student stud2 = (Student)stud.Clone();

        }
    }
}
