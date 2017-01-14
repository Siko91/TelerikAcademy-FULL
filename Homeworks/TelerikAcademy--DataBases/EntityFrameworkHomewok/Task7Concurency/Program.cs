using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDBContext;

namespace Task7Concurency
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            NorthwindEntities db1 = new NorthwindEntities();
            NorthwindEntities db2 = new NorthwindEntities();

            Product pr1 = db1.Products.First();
            Product pr2 = db2.Products.First();

            pr1.ProductName += "_editedByFirstContext";
            pr2.ProductName += "_editedBySecondContext";

            //Exception: Validation failed for one or more entities. See 'EntityValidationErrors' property for more details.
            db1.SaveChanges();
            db2.SaveChanges();
        }
    }
}