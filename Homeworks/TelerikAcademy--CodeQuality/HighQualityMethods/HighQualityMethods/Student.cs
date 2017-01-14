using System;

namespace HighQualityMethods
{
    class Student
    {
        public Student(
            string firstName,
            string lastName,
            DateTime birthDay,
            string city = null,
            string occupation = null,
            string results = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.City = city;
            this.Occupation = occupation;
            this.Results = results;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDay { get; private set; }
        public string City { get; private set; }
        public string Occupation { get; private set; }
        public string Results { get; private set; }

        public bool IsOlderThan(Student other)
        {
            return this.BirthDay > other.BirthDay;
        }
    }
}
