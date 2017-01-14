using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using NorthwindDBContext;

namespace Task9OrderAddingWithTransaction
{
    public class OrderAdder
    {
        public void InsertNewOrder(Order order, NorthwindEntities db)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.Serializable;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            using (db)
            {
                db.Orders.Add(order);
                db.SaveChanges();

                scope.Complete();
            }
        }
    }
}