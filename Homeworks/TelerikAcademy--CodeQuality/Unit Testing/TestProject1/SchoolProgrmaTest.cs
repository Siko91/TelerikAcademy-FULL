using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SchoolProgram;

namespace SchoolProgram.Test
{
    [TestClass]
    public class SchoolProgrmaTest
    {
        School school;
        readonly string defaultStudName = "John Doe";
        readonly string defaultCourseName = "CourseName";

        void ResetSchool() {
            school = new School();
        }

        [TestMethod]
        public void StudentShouldNotBeNull()
        {
            ResetSchool();

            Student stud = school.CreateStudent(defaultStudName);
            Assert.IsNotNull(stud);
        }

        [TestMethod]
        public void StudentNameShouldBeTheSameAsTheGivenArgumentString()
        {
            ResetSchool();

            Student stud = school.CreateStudent(defaultStudName);
            Assert.AreEqual(defaultStudName, stud.Name);
        }

        [TestMethod]
        public void StudentIdShouldBeBiggerThan10000()
        {
            ResetSchool();

            Student stud = school.CreateStudent(defaultStudName);
            Assert.IsTrue(10000 <= stud.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        [Ignore]  // This test is slow
        public void SchoolShouldNotBeAbleToCreateMoreThan90000Students()
        {
            ResetSchool();

            Student stud;
            for (int i = 0; i < 90001; i++)
            {
                stud = school.CreateStudent(defaultStudName + " " + i);
            }
        }

        [TestMethod]
        [Ignore]  // This test is slow
        public void SchoolIDsAreUnique()
        {
            ResetSchool();

            List<int> studIDs = new List<int>();
            for (int i = 0; i < 90000; i++)
            {
                studIDs.Add(school.CreateStudent(defaultStudName + " " + i).ID);
            }
            for (int i = 0; i < studIDs.Count; i++)
            {
                Assert.IsTrue(studIDs.IndexOf(studIDs[i], i + 1) == -1);
            }
        }

        [TestMethod]
        public void StudentIsCloned()
        {
            ResetSchool();

            Student stud = school.CreateStudent(defaultStudName);
            Assert.AreNotSame(stud, school.Students[0]);
        }

        [TestMethod]
        public void CourseShouldNotBeNull()
        {
            ResetSchool();

            Course course = school.CreateCourse(defaultCourseName);
            Assert.IsNotNull(course);
        }

        [TestMethod]
        public void CourseNameShouldBeTheSameAsTheGivenArgumentString()
        {
            ResetSchool();

            Course course = school.CreateCourse(defaultCourseName);
            Assert.AreEqual(defaultCourseName, course.Name);
        }

        [TestMethod]
        public void CourseIdShouldBeBiggerThan0()
        {
            ResetSchool();

            Student course = school.CreateStudent(defaultCourseName);
            Assert.IsTrue(0 <= course.ID);
        }

        [TestMethod]
        public void CourseIsCloned()
        {
            ResetSchool();

            Course course = school.CreateCourse(defaultCourseName);
            Assert.AreNotSame(course, school.Courses[0]);
        }

        [TestMethod]
        public void StudentsCanBeAddedToCourses()
        {
            ResetSchool();

            Course course = school.CreateCourse(defaultCourseName);
            Student stud = school.CreateStudent(defaultStudName);

            course.AddStudent(stud);

            Assert.AreEqual(stud.ID, course.Students[0].ID);
            Assert.AreEqual(stud.Name, course.Students[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentsCanBeAddedToCoursesOfSchoolOnlyByTheSchool()
        {
            ResetSchool();

            Course course = school.CreateCourse(defaultCourseName);
            Student stud = school.CreateStudent(defaultStudName);
            course.AddStudent(stud);

            Assert.IsFalse(stud == school.Courses[0].Students[0], "There should be no students in the course at the School");
        }
    }
}
