using System;

namespace ATM.Data
{
    public class AccountNotFoundExeption : Exception
    {
        public AccountNotFoundExeption() : base()
        {
        }

        public AccountNotFoundExeption(string message) : base(message)
        { 
        }
    }
}