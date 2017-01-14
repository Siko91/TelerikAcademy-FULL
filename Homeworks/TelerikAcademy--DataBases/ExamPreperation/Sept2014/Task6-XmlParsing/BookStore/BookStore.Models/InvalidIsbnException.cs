using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Models
{
    public class InvalidIsbnException : Exception
    {
        public InvalidIsbnException()
            : base()
        {
        }

        public InvalidIsbnException(string message)
            : base(message)
        {
        }
    }
}