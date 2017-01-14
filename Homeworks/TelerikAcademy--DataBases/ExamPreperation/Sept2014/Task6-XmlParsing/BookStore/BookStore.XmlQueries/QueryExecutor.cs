using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.XmlQueries
{
    internal class QueryExecutor
    {
        internal IEnumerable<Review> Execute(BookStoreDbContext db, IQuery query)
        {
            return query.ExecuteSelf(db);
        }
    }
}