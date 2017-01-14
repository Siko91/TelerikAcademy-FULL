using CatalogueOfFreeContent.Enumerations;
using System;
using System.Linq;

namespace CatalogueOfFreeContent.Testing.TestsData
{
    public class ContentTestsData
    {
        public ContentTestsData()
        {
        }

        public string Author
        {
            get
            {
                return "author";
            }
        }

        public string CommandString
        {
            get
            {
                return string.Format("Add book: {0}; {1}; {2}; {3}", this.Title, this.Author, this.Size, this.Url);
            }
        }

        public string[] Parameters
        {
            get
            {
                return new string[] { this.Title, this.Author, this.Size.ToString(), this.Url };
            }
        }

        public long Size
        {
            get
            {
                return 5;
            }
        }

        public string Title
        {
            get
            {
                return "title";
            }
        }

        public string Url
        {
            get
            {
                return "url";
            }
        }

        public Content CreateContent()
        {
            string commandString = string.Format("Add book: {0}; {1}; {2}; {3}", this.Title, this.Author, this.Size, this.Url);
            var command = new CommandTestsData().CreateCommand(commandString);
            return new Content(ContentType.Book, command.Parameters);
        }

        public Content CreateContent(string commandString)
        {
            var command = new CommandTestsData().CreateCommand(commandString);
            return new Content(ContentType.Book, command.Parameters);
        }

        public Content CreateContent(string[] parameters)
        {
            return new Content(ContentType.Book, parameters);
        }
    }
}