using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models;

namespace StudentSystem.Models
{
    public class Course : IHaveNameAndId
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        [Column(TypeName = "ntext")]
        [MaxLength]
        public string Description { get; set; }

        public int Id { get; set; }

        public virtual ICollection<StudyMaterial> Materials { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}