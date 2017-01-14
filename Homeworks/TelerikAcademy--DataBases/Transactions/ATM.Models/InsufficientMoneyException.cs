using System;

namespace ATM.Models
{
    public class InsufficientMoneyException : Exception
    {
        public InsufficientMoneyException() : base()
        {
        }

        public InsufficientMoneyException(string message) : base(message)
        { 
        }
    }
}