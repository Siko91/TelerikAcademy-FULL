using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolProgram
{
    public class School
    {
        private int nextFreeUniqueStudentId = 10000;
        private int nextFreeUniqueCourseId = 0;
        private List<Course> courses = new List<Course>();
        private List<Student> students = new List<Student>();

        public List<Course> Courses
        {
            get
            {
                List<Course> clonedArr = new List<Course>();
                for (int i = 0; i < courses.Count; i++)
	            {
                    clonedArr.Add((Course)courses[i].Clone());
	            }
                return clonedArr;
            }
            private set
            {
                this.courses = value;
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
        
        public Course CreateCourse(string name) 
        {
            Course course = new Course(name, nextFreeUniqueCourseId++);
            this.courses.Add(course);
            return (Course)course.Clone();
        }

        public Student CreateStudent(string name)
        {
            if (this.nextFreeUniqueStudentId > 99999)
            {
                throw new OverflowException("Too many students were created in this school");
            }

            Student student = new Student(name, nextFreeUniqueStudentId++);
            this.students.Add(student);
            return (Student)student.Clone();
        }

        public void AddStudentToCourse(int studentID, int courseID)
        {
            Course course = this.courses[courseID];
            Student stud = this.students[studentID - 10000];

            course.AddStudent(stud);
        }
    }
}
