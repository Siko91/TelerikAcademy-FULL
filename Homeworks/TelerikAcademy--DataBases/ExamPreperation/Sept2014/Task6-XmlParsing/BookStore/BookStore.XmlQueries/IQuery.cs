using System.Collections.Generic;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.XmlQueries
{
    public interface IQuery
    {
        IEnumerable<Review> ExecuteSelf(BookStoreDbContext db);
    }
}