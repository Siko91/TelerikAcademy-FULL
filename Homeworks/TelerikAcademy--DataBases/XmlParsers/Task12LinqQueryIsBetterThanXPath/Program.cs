using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task12LinqQueryIsBetterThanXPath
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string filePath = "..\\..\\AlbumCollection.xml";
            XDocument doc = XDocument.Load(filePath);
            IEnumerable<string> prices = doc.Root
                                            .Descendants("Album")
                                            .Where(al =>
                                                        DateTime.Parse(al.Element("Year").Value).Year <= DateTime.Now.Year - 5)
                                            .Select(al => al.Element("Price").Value);

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