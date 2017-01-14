namespace CatalogueOfFreeContent
{
    using CatalogueOfFreeContent.Enumerations;
    using CatalogueOfFreeContent.Interfaces;
    using System;

    public class Content : IComparable, IContent
    {
        private string author;
        private long size;
        private string title;
        private ContentType type;
        private string url;

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ConsoleInputParsingIndexes.Title];
            this.Author = commandParams[(int)ConsoleInputParsingIndexes.Author];
            this.Size = this.GetSize(commandParams[(int)ConsoleInputParsingIndexes.Size]);
            this.Url = commandParams[(int)ConsoleInputParsingIndexes.Url];
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Author can not be empty");
                }
                this.author = value;
            }
        }

        public long Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (0 > value ||
                    value > 10000000000)
                {
                    throw new ArgumentOutOfRangeException("Size is out of range");
                }
                this.size = value;
            }
        }

        public string TextRepresentation
        {
            get
            {
                return this.ToString();
            }

            set
            {
                // do nothing
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title can not be empty");
                }
                this.title = value;
            }
        }

        public ContentType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("URL can not be empty");
                }
                this.url = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                throw new ArgumentNullException("Can not compare with null");
            }

            Content otherContent = obj as Content;

            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }
            else
            {
                throw new ArgumentException("Object is not a Content");
            }
        }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.Url);

            return output;
        }

        private long GetSize(string sizeString)
        {
            try
            {
                return long.Parse(sizeString);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Size must be a number", ex);
            }
        }
    }
}