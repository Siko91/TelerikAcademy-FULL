using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDBContext;

namespace Task3FindCustomersByOrders
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            NorthwindEntities db = new NorthwindEntities();

            var result = db.Customers.Where(c =>
                c.Orders
                    .Where(ord =>
                        ord.OrderDate.Value.Year == 1997)
                    .Where(ord =>
                        ord.ShipCountry == "Canada")
                    .Count() > 0);
            foreach (var item in result)
            {
                Console.WriteLine(item.City + ", " + item.ContactName);
            }
        }
    }
}