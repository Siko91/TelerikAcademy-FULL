using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Task11XPathQuery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> prices = new List<string>();
            string fileName = "..\\..\\AlbumCollection.xml";
            XPathDocument doc = new XPathDocument(fileName);
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iterator = nav.Select("/AlbumCollection/Album");
            while (iterator.MoveNext())
            {
                bool yearIsBefore5Years = true;

                XPathNodeIterator yearIterator = iterator.Current.Select("/Year");
                while (yearIterator.MoveNext())
                {
                    DateTime date = DateTime.Parse(iterator.Current.Value);

                    if (date.Year > DateTime.Now.Year - 5)
                    {
                        yearIsBefore5Years = false;
                    }
                }
                XPathNodeIterator priceIterator = iterator.Current.Select("/Price");
                while (priceIterator.MoveNext())
                {
                    prices.Add(priceIterator.Current.Value + " $");
                }
            }
            if (prices.Count() > 0)
            {
                Console.WriteLine(string.Join("\n", prices));
            }
            else
            {
                Console.WriteLine("No such albums");
            }
        }
    }
}