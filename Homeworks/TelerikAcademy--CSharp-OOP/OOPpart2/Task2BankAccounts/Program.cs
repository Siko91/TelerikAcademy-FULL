using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2BankAccounts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Custumer> custumerList = new List<Custumer>() {
            new Depositer(false, "depositer1", 2000, (decimal)0.01),
            new Depositer(false, "depositer2", 500, (decimal)0.01),
            new Loaner(false, "loaner1", 600, (decimal)0.05),
            new Loaner(true, "loaner2", 600, (decimal)0.05),
            new Mortgager(false, "mortgager1", 600, (decimal)0.05),
            new Mortgager(true, "mortgager2", 600, (decimal)0.05)
            };

            foreach (Custumer cust in custumerList)
            {
                Console.WriteLine("2 months of (simple) interest for '" + cust.Name + "' with balance of " + cust.CheckBalance() + " : {0:f2}", cust.CalcSimpleInterestRate(2));
                Console.WriteLine("2 months of (advanced) interest for '" + cust.Name + "' with balance of " + cust.CheckBalance() + " : {0:f2}", cust.CalcAdvancingInterestRate(2));
                Console.WriteLine("20 months of (simple) interest for '" + cust.Name + "' with balance of " + cust.CheckBalance() + " : {0:f2}", cust.CalcSimpleInterestRate(20));
                Console.WriteLine("20 months of (advanced) interest for '" + cust.Name + "' with balance of " + cust.CheckBalance() + " : {0:f2}", cust.CalcAdvancingInterestRate(20));
                Console.WriteLine("----------");
            }
        }
    }
}
