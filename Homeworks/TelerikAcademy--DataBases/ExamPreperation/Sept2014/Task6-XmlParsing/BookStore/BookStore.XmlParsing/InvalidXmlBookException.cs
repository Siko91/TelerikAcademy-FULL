using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.XmlParsing
{
    public class InvalidXmlBookException : Exception
    {
        public InvalidXmlBookException()
            : base()
        {
        }

        public InvalidXmlBookException(string message)
            : base(message)
        {
        }
    }
}