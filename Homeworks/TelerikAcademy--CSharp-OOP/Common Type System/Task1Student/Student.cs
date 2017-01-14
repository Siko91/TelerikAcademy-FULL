using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1Student
{
    class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private long ssn;
        private string permanentAddress;
        private string mobilePhone;
        private string phone;
        private string eMail;
        private int course;
        private Speciality specialty;
        private University university;
        private Faculty faculty;

        public string FirstName { get { return this.firstName; } }
        public string MiddleName { get { return this.middleName; } }
        public string LastName { get { return this.lastName; } }
        public long SSN { get { return this.ssn; } }
        public string PermanentAddress { get { return this.permanentAddress; } }
        public string MobilePhone { get { return this.mobilePhone; } }
        public string Phone { get { return this.Phone; } }
        public string EMail { get { return this.eMail; } }
        public int Course { get { return this.course; } }
        public Speciality Specialty { get { return this.specialty; } }
        public University University { get { return this.university; } }
        public Faculty Faculty { get { return this.faculty; } }

        public Student(
                            University university,
                            string firstName,
                            string middleName,
                            string lastName,
                            long ssn,
                            string permanentAddress,
                            int course = 1,
                            Speciality specialty = Speciality.NotDecidetYet,
                            Faculty faculty = Faculty.NotDecidetYet,
                            string eMail = "",
                            string mobilePhone = "",
                            string phone = "")
        {
            if (string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(middleName) ||
                string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException("Name can not be empty");
            }
            if (ssn.ToString().Length != 9 || ssn < 0)
            {
                throw new ArgumentException("Invalid Social Sequirity Number");
            }
            if (string.IsNullOrEmpty(permanentAddress))
            {
                throw new ArgumentNullException("Address can not be empty");
            }
            if (course < 1)
            {
                throw new ArgumentException("Invalid cource");
            }
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.ssn = ssn;
            this.permanentAddress = permanentAddress;
            this.mobilePhone = mobilePhone;
            this.phone = phone;
            this.course = course;
            this.university = university;
            this.specialty = specialty;
            this.faculty = faculty;
            this.eMail = eMail;
        }
        public bool Equals(Student student)
        {
            if (this.SSN.Equals(student.SSN) &&
                this.FirstName.Equals(student.FirstName) &&
                this.MiddleName.Equals(student.MiddleName) &&
                this.LastName.Equals(student.LastName))
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object student)
        {
            if (!(student is Student))
            {
                return false;
            }
            else
            {
                return this.Equals((Student)student);
            }
        }
        public override string ToString()
        {
            return
            (
                string.Format("{0} {1} {2}. Studies {3} at {4} Faculty at {5} - cource {6}. Address: {7}",
                this.FirstName, this.MiddleName, this.LastName,
                this.Specialty, this.Faculty, this.University,
                this.Course, this.PermanentAddress)
            );
        }
        public override int GetHashCode()
        {
            return (this.GetHashCode() ^ ssn.GetHashCode());
        }

        static public bool operator ==(Student st1, Student st2)
        {
            return (st1.Equals(st2));
        }
        static public bool operator !=(Student st1, Student st2)
        {
            return (!st1.Equals(st2));
        }
        public object Clone()
        {
            Student clone = new Student(
                this.University,
                (string)this.firstName.Clone(),
                (string)this.middleName.Clone(),
                (string)this.lastName.Clone(),
                this.ssn,
                (string)this.permanentAddress.Clone(),
                this.course,
                this.Specialty,
                this.Faculty,
                (string)this.eMail.Clone(),
                (string)this.mobilePhone.Clone(),
                (string)this.phone.Clone());

            return clone;
        }
        public int CompareTo(Student student)
        {
            int result = (this.FirstName + this.MiddleName + this.LastName).CompareTo(student.FirstName + student.MiddleName + student.LastName);
            if (result == 0)
            {
                result = this.SSN.CompareTo(student.SSN);
            }
            return result;
        }
    }
}
