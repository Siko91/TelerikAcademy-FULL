using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Review
    {
        [Required]
        public virtual Author Author { get; set; }

        public virtual int AuthorId { get; set; }

        [Required]
        public virtual Book Book { get; set; }

        public virtual int BookId { get; set; }

        [Key]
        public virtual int Id { get; set; }
    }
}