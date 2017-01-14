using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookStore.Models;

namespace BookStore.XmlParsing
{
    public class XmlParser
    {
        public IEnumerable<Book> ParseXml(string path)
        {
            var xmlFile = XElement.Load(path);
            List<Book> books = new List<Book>();

            foreach (var book in xmlFile.Elements("book"))
            {
                Book parsedBook = this.ParseBook(book);
                books.Add(parsedBook);
            }

            return books;
        }

        private Book ParseBook(XElement book)
        {
            var parsedBook = new Book();

            if (book.Element("title") == null)
            {
                throw new InvalidXmlBookException("Book must have a title");
            }
            else
            {
                parsedBook.Title = book.Element("title").Value;
            }

            if (book.Element("authors") != null)
            {
                foreach (var author in book.Element("authors").Elements("author"))
                {
                    // Autor checking (if already exists) will be done in a different class. This
                    // class has no connection to the database whatsoever
                    parsedBook.Authors.Add(new Author()
                    {
                        Name = author.Value
                    });
                }
            }
            if (book.Element("reviews") != null)
            {
                foreach (var review in book.Element("reviews").Elements("review"))
                {
                    parsedBook.Reviews.Add(this.ParseReview(review));
                }
            }

            if (book.Element("isbn") != null)
            {
                parsedBook.Isbn = book.Element("isbn").Value;
            }

            if (book.Element("price") != null)
            {
                parsedBook.Price = decimal.Parse(book.Element("price").Value, CultureInfo.InvariantCulture);
            }

            return parsedBook;
        }

        private Review ParseReview(XElement review)
        {
            Review parsedReview = new Review()
            {
                Text = review.Value,
                DateOfCreation = DateTime.Now
            };
            var attributes = review.Attributes();
            foreach (var attr in attributes)
            {
                if (attr.Name == "author")
                {
                    // Autor checking (if already exists) will be done in a different class. This
                    // class has no connection to the database whatsoever
                    parsedReview.Author = new Author()
                    {
                        Name = attr.Value
                    };
                }
                else if (attr.Name == "date")
                {
                    parsedReview.DateOfCreation = DateTime.ParseExact(attr.Value, "d-MMM-yyyy", CultureInfo.InvariantCulture);
                }
            }
            return parsedReview;
        }
    }
}