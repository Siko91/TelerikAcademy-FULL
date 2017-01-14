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
    public class Homework : IHaveNameAndId
    {
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string Content { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Student Student { get; set; }

        public int StudentId { get; set; }
    }
}