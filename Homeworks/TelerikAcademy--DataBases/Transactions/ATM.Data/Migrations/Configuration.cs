namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ATM.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ATM.Data.AtmDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ATM.Data.AtmDbContext context)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                context.Accounts.Add(new Account()
                    {
                        CardPIN = "0000",
                        CardCash = rnd.Next(10,10000),
                        CardNumber = rnd.Next(1000000000, int.MaxValue).ToString()
                    });
            }
            
        }
    }
}
