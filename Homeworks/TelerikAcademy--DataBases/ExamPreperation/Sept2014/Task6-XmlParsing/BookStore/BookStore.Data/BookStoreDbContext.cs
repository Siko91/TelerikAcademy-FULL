using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Migrations;
using BookStore.Models;

namespace BookStore.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
            : this("Server=.;Database=BookStoreDatabase;Trusted_Connection=True;")
        {
        }

        public BookStoreDbContext(string connectionString)
            : base(connectionString)
        {
            this.Database.CommandTimeout = 5;
            if (!this.Database.Exists())
            {
                this.Database.CommandTimeout = 30;
            }

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());
        }

        public static BookStoreDbContext WorkingInstance
        {
            get
            {
                try
                {
                    // Default
                    return new BookStoreDbContext();
                }
                catch (TimeoutException)
                {
                    // Express edition
                    return new BookStoreDbContext(@"Server=.\SQLEXPRESS;Database=BookStoreDatabase;Trusted_Connection=True;");
                }
            }
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public IQueryable<Author> BookAuthors()
        {
            return this.Authors.Where(a => a.Books.Count() > 0);
        }

        public IQueryable<Author> ReviewAuthors()
        {
            return this.Authors.Where(a => a.Reviews.Count() > 0);
        }
    }
}