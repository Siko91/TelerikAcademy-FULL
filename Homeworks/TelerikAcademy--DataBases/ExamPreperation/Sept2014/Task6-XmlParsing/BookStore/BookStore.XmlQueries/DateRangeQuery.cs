using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.XmlQueries
{
    internal class DateRangeQuery : IQuery
    {
        public IEnumerable<Models.Review> ExecuteSelf(Data.BookStoreDbContext db)
        {
            return db.Reviews.Include("Book").Include("Author").Where(r => this.DateFrom <= r.DateOfCreation && r.DateOfCreation <= this.DateTo);
        }

        internal DateTime DateFrom { get; set; }

        internal DateTime DateTo { get; set; }
    }
}