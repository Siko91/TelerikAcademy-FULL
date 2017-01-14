using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookStore.Data;

namespace BookStore.JustRun
{
    public class JustRun
    {
        private static void Main()
        {
            var db = BookStoreDbContext.WorkingInstance;
            Console.WriteLine("Connected");
        }
    }
}