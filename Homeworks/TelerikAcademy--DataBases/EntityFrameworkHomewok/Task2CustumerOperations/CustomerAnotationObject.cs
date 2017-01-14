using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDBContext;

namespace Task2CustumerOperations
{
    public class CustomerAnotationObject
    {
        public static void ChangeCustomerTo(NorthwindDBContext.Customer customer1, NorthwindDBContext.Customer customer2, NorthwindEntities db)
        {
            ChangeCustomerTo(customer1.CustomerID, customer2, db);
        }

        public static void ChangeCustomerTo(string customerId, NorthwindDBContext.Customer customer2, NorthwindEntities db)
        {
            Customer custumerToUpdate = db.Customers.FirstOrDefault(c => c.CustomerID.Equals(customerId));
            custumerToUpdate = customer2;
            db.SaveChanges();
        }

        public static void DeleteCustomer(NorthwindDBContext.Customer customer, NorthwindEntities db)
        {
            DeleteCustomer(customer.CustomerID, db);
        }

        public static void DeleteCustomer(string customerId, NorthwindEntities db)
        {
            Customer custumerToDelete = db.Customers.FirstOrDefault(c => c.CustomerID.Equals(customerId));
            db.Customers.Remove(custumerToDelete);
            db.SaveChanges();
        }

        public static void InsertNewCustomer(NorthwindDBContext.Customer customer, NorthwindEntities db)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
    }
}