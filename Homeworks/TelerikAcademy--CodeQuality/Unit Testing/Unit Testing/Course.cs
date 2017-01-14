using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProgram
{
    public class Course : ICloneable
    {
        private int id;
        private string name;
        private List<Student> students = new List<Student>();

        public Course(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name of course must be filled");
                }
                this.name = value;
            }
        }


        public int ID
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (0 > value)
                {
                    throw new ArgumentOutOfRangeException("Course Id can not be negative");
                }
                this.id = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                List<Student> clonedArr = new List<Student>();
                for (int i = 0; i < students.Count; i++)
	            {
		            clonedArr.Add((Student)students[i].Clone());
	            }
                return clonedArr;
            }
            private set
            {
                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (null == student)
	        {
                throw new ArgumentNullException("Student can not be null");
	        }
            if (this.students.Count >= 30)
            {
                throw new OverflowException("Course is full. Can not Add more students.");
            }
            this.students.Add(student);
        }

        public object Clone()
        {
            return new Course(this.Name, this.ID);
        }
    }
}
