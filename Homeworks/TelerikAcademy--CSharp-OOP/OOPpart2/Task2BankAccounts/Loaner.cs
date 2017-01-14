using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2BankAccounts
{
    class Loaner : Custumer
    {
        private int monthsWithoutInterest;
        
        public Loaner(bool isCompany, string name, decimal balance, decimal interestRate)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can not be empty.");
            }
            if (balance <= 0)
            {
                throw new ArgumentException("Balance can not be negative.");
            }
            if (interestRate <= 0)
            {
                throw new ArgumentException("Interest rate can not be negative.");
            }
    
            this.custumerIsCompany = isCompany;
            this.customer = name;
            this.balance = balance;
            this.interestRate = interestRate;

            if (isCompany)
            {
                this.monthsWithoutInterest = 2;
            }
            else
                this.monthsWithoutInterest = 3;
        }

        public override decimal CalcSimpleInterestRate(int months)
        {
            if (months < 1)
            {
                throw new ArgumentException("Months must be positive");
            }

            months = months - this.monthsWithoutInterest;
            if (months < 0)
            {
                months = 0;
            }

            return (months * (this.interestRate * this.balance));
        }
        public override decimal CalcAdvancingInterestRate(int months)
        {
            if (months < 1)
            {
                throw new ArgumentException("Months must be positive");
            }

            months = months - this.monthsWithoutInterest;
            if (months < 0)
            {
                months = 0;
            }

            decimal result = balance;
            for (int i = 0; i < months; i++)
            {
                result += result * this.interestRate;
            }

            return (result - this.balance);
        }
    }
}
