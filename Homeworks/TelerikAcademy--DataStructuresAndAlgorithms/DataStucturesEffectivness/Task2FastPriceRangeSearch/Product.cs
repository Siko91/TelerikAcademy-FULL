using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2FastPriceRangeSearch
{
    public class Product : IComparable
    {
        public string Barcode;

        public double Price;

        public string Title;

        public string Vendor;

        public Product(string title, double price)
        {
            this.Title = title;
            this.Price = price;
        }

        public int CompareTo(object obj)
        {
            return this.Price.CompareTo(((Product)obj).Price);
        }
    }
}