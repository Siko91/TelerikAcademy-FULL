using System;
using System.Linq;

namespace SchoolProgram
{
    public class Student : ICloneable
    {
        private string name;
        private int id;

        public Student(string name, int id) {
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
                if (10000 > value || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Student Id is out of range");
                }
                this.id = value;
            }
        }

        public object Clone()
        {
            return new Student(this.Name, this.ID);
        }
    }
}
