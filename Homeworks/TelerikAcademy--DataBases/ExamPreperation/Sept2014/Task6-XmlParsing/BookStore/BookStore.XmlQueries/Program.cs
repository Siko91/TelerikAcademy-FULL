using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.XmlQueries
{
    public class Program
    {
        private static void Main(string[] args)
        {
            QueryReader reader = new QueryReader();
            var queries = reader.ReadQueries("..\\..\\Query.xml");
            var results = new List<IEnumerable<Review>>();
            var executor = new QueryExecutor();
            var db = BookStoreDbContext.WorkingInstance;
            foreach (var query in queries)
            {
                results.Add(executor.Execute(db, query));
                Console.WriteLine(results.Last().Count());
            }
        }
    }
}