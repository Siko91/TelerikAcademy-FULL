using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDBContext;

namespace Task5FindSalesByRegionAndPeriod
{
    internal class Program
    {
        private static void FindSalesByRegionAndPeriod(NorthwindEntities db, string country, DateTime start, DateTime end)
        {
            var result = db.Orders.Where(o => o.ShipCountry == country).Where(o => o.OrderDate >= start).Where(o => o.OrderDate <= end);

            foreach (Order ord in result)
            {
                Console.WriteLine(ord.OrderID + ", " + ord.ShipCountry + ", " + ord.OrderDate);
            }
        }

        private static void FindSalesInUSAFor1996(NorthwindEntities db)
        {
            string region = "USA";
            DateTime start = new DateTime(1996, 1, 1);
            DateTime end = new DateTime(1997, 1, 1);

            FindSalesByRegionAndPeriod(db, region, start, end);
        }

        private static void Main(string[] args)
        {
            NorthwindEntities db = new NorthwindEntities();
            FindSalesInUSAFor1996(db);
        }
    }
}