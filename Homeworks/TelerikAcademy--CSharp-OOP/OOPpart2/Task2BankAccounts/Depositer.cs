using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2BankAccounts
{
    class Depositer : Custumer
    {
        private decimal currentInterestRate;

        public Depositer(bool isCompany, string name, decimal balance, decimal interestRate)
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

            SetCurrentInterestRate();
        }
        private void SetCurrentInterestRate()
        {
            if (this.balance < 1000)
            {
                this.currentInterestRate = 0;
            }
            else
            {
                this.currentInterestRate = this.interestRate;
            }
        }

        public void Withdraw(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException("Withdraw money must be positive");
            }
            if (this.balance < money)
            {
                throw new ArgumentOutOfRangeException("Can not withdraw more than you have.");
            }
            this.balance -= money;
            SetCurrentInterestRate();
        }
        public override decimal CalcSimpleInterestRate(int months)
        {
            if (months < 1)
            {
                throw new ArgumentException("Months must be positive");
            }

            return (months * (this.currentInterestRate * this.balance));
        }
        public override decimal CalcAdvancingInterestRate(int months)
        {
            if (months < 1)
            {
                throw new ArgumentException("Months must be positive");
            }

            decimal result = balance;
            for (int i = 0; i < months; i++)
            {
                result += result * this.currentInterestRate;
            }

            return (result - this.balance);
        }
    }
}
