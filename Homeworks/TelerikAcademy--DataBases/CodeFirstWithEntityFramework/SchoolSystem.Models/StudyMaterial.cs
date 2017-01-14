using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolSystem.Models;

namespace StudentSystem.Models
{
    public class StudyMaterial : IHaveNameAndId
    {
        public virtual Course Course { get; set; }

        public int CourseId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}