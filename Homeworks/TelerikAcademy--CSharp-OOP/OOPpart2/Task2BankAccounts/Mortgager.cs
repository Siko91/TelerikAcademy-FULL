using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2BankAccounts
{
    class Mortgager : Custumer
    {
        private int monthsWithoutInterest;
        private decimal startingInterestRate;

        public Mortgager(bool isCompany, string name, decimal balance, decimal interestRate)
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
                this.monthsWithoutInterest = 0;
                this.startingInterestRate = interestRate / 2;
            }
            else
                this.monthsWithoutInterest = 6;
                this.startingInterestRate = interestRate;
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

            decimal result = 0;
            for (int i = 0; i < months; i++)
            {
                if (i < 12)
                {
                    result += this.startingInterestRate * this.balance;
                }
                else
                {
                    result += this.interestRate * this.balance;
                }
            }

            return result;
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

            decimal result = this.balance;
            for (int i = 0; i < months; i++)
            {
                if (i < 12)
                {
                    result += this.startingInterestRate * result;
                }
                else
                {
                    result += this.interestRate * result;
                }
            }

            return (result - this.balance);
        }
    }
}
