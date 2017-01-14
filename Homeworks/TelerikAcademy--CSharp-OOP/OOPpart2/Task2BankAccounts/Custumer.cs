using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2BankAccounts
{
    class Custumer
    {
        protected bool custumerIsCompany;
        protected string customer;
        protected decimal balance;
        protected decimal interestRate;

        public string Name
        {
            get { return this.customer; }
        }

        public virtual decimal CheckBalance()
        {
            return this.balance;
        }
        public virtual decimal CalcSimpleInterestRate(int months)
        {
            if (months < 1)
	        {
		        throw new ArgumentException("Months must be positive");
	        }

            return (months * (interestRate * balance));
        }
        public virtual decimal CalcAdvancingInterestRate(int months)
        {
            if (months < 1)
            {
                throw new ArgumentException("Months must be positive");
            }

            decimal result = balance;
            for (int i = 0; i < months; i++)
            {
                result += result * interestRate;
            }

            return (result - this.balance);
        }
        public virtual void Deposit(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException("deposit money must be positive");
            }
            this.balance += money;
        }
    }
}
