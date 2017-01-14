using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Data.Migrations;
using CodeFirst.Models;

namespace CodeFirst.Data
{
    public class CarsDbContext : DbContext
    {
        public const string DatabaseName = "Cars";

        public CarsDbContext()
            : this("Server=.;Database=" + DatabaseName + ";Trusted_Connection=True;")
        {
        }

        public CarsDbContext(string connectionString)
            : base(connectionString)
        {
            this.Database.CommandTimeout = 5;
            if (!this.Database.Exists())
            {
                this.Database.CommandTimeout = 30;
            }
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
            this.Database.CreateIfNotExists();
        }

        public static CarsDbContext WorkingInstance
        {
            get
            {
                try
                {
                    // Default
                    return new CarsDbContext();
                }
                catch (TimeoutException)
                {
                    // Express edition
                    return new CarsDbContext(@"Server=.\SQLEXPRESS;Database=" + DatabaseName + ";Trusted_Connection=True;");
                }
            }
        }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Dealer> Dealers { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
    }
}