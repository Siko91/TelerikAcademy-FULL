using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Author
    {
        public Author()
        {
            this.books = new HashSet<Book>();
            this.reviews = new HashSet<Review>();
        }

        public virtual ICollection<Book> Books
        {
            get
            {
                return this.books;
            }

            set
            {
                this.books = value;
            }
        }

        [Key]
        public virtual int Id { get; set; }

        //should be unique
        [Required]
        [StringLength(50)]
        [Index("IX_Name", 1, IsUnique = true)]
        public virtual string Name { get; set; }

        public virtual ICollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
            }
        }

        private ICollection<Book> books;
        private ICollection<Review> reviews;
    }
}