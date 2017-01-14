using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.XmlQueries
{
    internal class AuthorQuery : IQuery
    {
        public IEnumerable<Review> ExecuteSelf(BookStoreDbContext db)
        {
            return db.Reviews.Include("Book").Include("Author").Where(r => r.Author.Name == this.AuthorName);
        }

        internal string AuthorName { get; set; }
    }
}