using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models;

namespace StudentSystem.Models
{
    public class Student : IHaveNameAndId
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public long Number { get; set; }
    }
}