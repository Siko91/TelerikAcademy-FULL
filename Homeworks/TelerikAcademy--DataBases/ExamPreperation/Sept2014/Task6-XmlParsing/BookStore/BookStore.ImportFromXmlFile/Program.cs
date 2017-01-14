using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using BookStore.XmlParsing;

namespace BookStore.ImportFromXmlFile
{
    internal class Program
    {
        private static void AddBookToDb(Book book, BookStoreDbContext db)
        {
            AuthorChecker checker = new AuthorChecker();
            foreach (var auth in book.Authors)
            {
                ReplaceOrAddAuthor(db, auth, checker);
            }
            foreach (var rev in book.Reviews)
            {
                ReplaceOrAddAuthor(db, rev.Author, checker);
            }
            db.Books.Add(book);
        }

        private static void Main(string[] args)
        {
            XmlParser parser = new XmlParser();
            IEnumerable<Book> books = parser.ParseXml("..\\..\\books.xml");
            BookStoreDbContext db = BookStoreDbContext.WorkingInstance;

            try
            {
                foreach (var book in books)
                {
                    AddBookToDb(book, db);
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException)
            {
                Console.WriteLine("Invalid book found! Aborting the program!");
            }
        }

        private static void ReplaceOrAddAuthor(BookStoreDbContext db, Author author)
        {
            ReplaceOrAddAuthor(db, author, new AuthorChecker());
        }

        private static void ReplaceOrAddAuthor(BookStoreDbContext db, Author author, AuthorChecker checker)
        {
            checker.ReplaceOrAddAuthorWithoutSaving(db, author);
        }
    }
}