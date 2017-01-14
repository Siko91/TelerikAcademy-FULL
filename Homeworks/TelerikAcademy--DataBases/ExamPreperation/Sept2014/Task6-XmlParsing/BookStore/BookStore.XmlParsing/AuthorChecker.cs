using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.XmlParsing
{
    public class AuthorChecker
    {
        public void JustReplaceAllAuthorsIfExisting(BookStoreDbContext db, IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                foreach (var bookAuthor in book.Authors)
                {
                    JustReplaceAuthorIfExists(db, bookAuthor);
                }
                foreach (var review in book.Reviews)
                {
                    JustReplaceAuthorIfExists(db, review.Author);
                }
            }
        }

        public void JustReplaceAuthorIfExists(BookStoreDbContext db, Author author)
        {
            if (author == null)
            {
                return;
            }
            var matchingAuthor = db.Authors.FirstOrDefault(a => a.Name == author.Name);
            if (matchingAuthor != null)
            {
                author = matchingAuthor;
            }
        }

        public void ReplaceOrAddAuthorWithoutSaving(BookStoreDbContext db, Author author)
        {
            if (author == null)
            {
                return;
            }
            var matchingAuthor = db.Authors.FirstOrDefault(a => a.Name == author.Name);
            if (matchingAuthor != null)
            {
                author = matchingAuthor;
            }
            else
            {
                db.Authors.Add(author);
            }
        }
    }
}