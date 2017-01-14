using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models;
using StudentSystem.Data;

namespace Task2_ConsoleClient
{
    public class ConsoleClient
    {
        public ConsoleClient(StudentSystemDbContext dbContext)
        {
            this.Context = dbContext;
        }

        public void Add<T>(T item) where T : class
        {
            var set = this.All<T>();
            set.Add(item);
        }

        public DbSet<T> All<T>() where T : class
        {
            return this.Context.Get<T>();
        }

        public void Delete<T>(T item) where T : class
        {
            var set = this.All<T>();
            set.Remove(item);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public void ShowAll<T>() where T : class
        {
            var all = this.All<T>();
            foreach (IHaveNameAndId item in all)
            {
                Console.WriteLine(item.Id + ", " + item.Name);
            }
        }

        private StudentSystemDbContext Context { get; set; }
    }
}