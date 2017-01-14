using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Task4DeleteAlbumsDomParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CultureInfo ci = System.Globalization.CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = ci;
            string filePath = "..\\..\\AlbumCollection.xml";
            string savePath = "..\\..\\AlbumCollection-Cleared.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNodeList albums = doc.DocumentElement.GetElementsByTagName("Album");
            List<XmlElement> pricesOfAlbumsToDelete = new List<XmlElement>();
            foreach (XmlElement album in albums)
            {
                pricesOfAlbumsToDelete.Add((XmlElement)album.GetElementsByTagName("Price")[0]);
            }
            foreach (var price in pricesOfAlbumsToDelete)
            {
                double prc = double.Parse(price.InnerText);
                if (prc > 20)
                {
                    doc.DocumentElement.RemoveChild(price.ParentNode);
                    Console.WriteLine("Deleting an Album");
                }
            }
            doc.Save(savePath);
        }
    }
}