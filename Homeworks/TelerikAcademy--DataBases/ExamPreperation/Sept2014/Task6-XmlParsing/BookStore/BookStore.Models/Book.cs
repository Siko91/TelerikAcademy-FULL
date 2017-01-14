using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public Book()
        {
            this.authors = new HashSet<Author>();
            this.reviews = new HashSet<Review>();
        }

        public virtual ICollection<Author> Authors
        {
            get
            {
                return this.authors;
            }

            set
            {
                this.authors = value;
            }
        }

        [Key]
        public virtual int Id { get; set; }

        [StringLength(13)]
        public virtual string Isbn
        {
            get
            {
                return this.isbn;
            }

            set
            {
                if (value.Length != 13)
                {
                    throw new InvalidIsbnException();
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new InvalidIsbnException();
                    }
                }
                this.isbn = value;
            }
        }

        public virtual string OfficialWebPage { get; set; }

        public virtual decimal? Price { get; set; }

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

        [Required]
        public virtual string Title { get; set; }

        public bool IsFreeOfCharge()
        {
            return this.Price.HasValue == false;
        }

        private ICollection<Author> authors;
        private string isbn;
        private ICollection<Review> reviews;
    }
}