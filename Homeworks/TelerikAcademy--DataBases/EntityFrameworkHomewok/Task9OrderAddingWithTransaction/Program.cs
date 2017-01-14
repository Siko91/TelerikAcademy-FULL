using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDBContext;

namespace Task9OrderAddingWithTransaction
{
    public class Program
    {
        public static void Main()
        {
            NorthwindEntities db = new NorthwindEntities();

            var orderDetails = new List<Order_Detail>();
            var order = new Order();
            for (int i = 0; i < 5; i++)
            {
                orderDetails.Add(new Order_Detail()
                {
                    Order = order,
                    Product = db.Products.FirstOrDefault(p => p.ProductID >= 20 + i),
                    UnitPrice = i + 1,
                    Quantity = 2,
                    Discount = 0
                });
            }

            order.OrderDate = DateTime.Now;
            order.Order_Details = orderDetails;

            OrderAdder adder = new OrderAdder();
            adder.InsertNewOrder(order, db);
        }
    }
}