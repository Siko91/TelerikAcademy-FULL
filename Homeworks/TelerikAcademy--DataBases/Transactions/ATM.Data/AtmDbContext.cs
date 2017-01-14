using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data.Migrations;
using ATM.Models;

namespace ATM.Data
{
    public class AtmDbContext : DbContext
    {
        public AtmDbContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmDbContext, Configuration>());
        }

        public AtmDbContext()
            : this(Settings.Default.ConnectionString)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<TransactionLog> TransactionLogs { get; set; }

        public void RetrieveMoneyFromAccount(string cardNumber, string cardPin, decimal money)
        {
            var acc = CheckCardAuthentication(cardNumber, cardPin);
            acc.RetrieveSomeMoney(money);
            this.GiveMoneyToCardOwner(money);
            this.CreateNewTransactionLog(cardNumber, money);

            this.SaveChanges();
        }
 
        private Account CheckCardAuthentication(string cardNumber, string cardPin)
        {
            var acc = this.Accounts
                          .FirstOrDefault(a =>
                                              a.CardNumber == cardNumber &&
                                              a.CardPIN == cardPin);
            if (acc == null)
            {
                throw new AccountNotFoundExeption();
            }
            return acc;
        }

        private void CreateNewTransactionLog(string cardNumber, decimal money)
        {
            this.TransactionLogs.Add(new TransactionLog()
            {
                CardNumber = cardNumber,
                Ammount = money,
                TransactionDate = DateTime.Now
            });
        }
 
        private void GiveMoneyToCardOwner(decimal money)
        {
            Console.WriteLine("Money extracted : $" + Math.Floor(money*100)/100);
        }
    }
}
