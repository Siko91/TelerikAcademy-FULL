using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Task2ReadAlbumCollectionXML
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string filePath = "..\\..\\AlbumCollection.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNodeList albums = doc.DocumentElement.GetElementsByTagName("Album");
            List<string> artistsPerAlbum = new List<string>();
            foreach (XmlElement album in albums)
            {
                XmlElement name =
                    (XmlElement)
                    (
                        (XmlElement)album
                            .GetElementsByTagName("Artist")[0]
                    )
                    .GetElementsByTagName("Name")[0];
                artistsPerAlbum.Add(name.InnerText);
            }

            Dictionary<string, int> albumCountPerArtist = new Dictionary<string, int>();
            foreach (var artistName in artistsPerAlbum)
            {
                if (albumCountPerArtist.ContainsKey(artistName))
                {
                    albumCountPerArtist[artistName]++;
                }
                else
                {
                    albumCountPerArtist.Add(artistName, 1);
                }
            }
            foreach (var artistName in albumCountPerArtist.Keys)
            {
                Console.WriteLine("Artist " + artistName + " has " + albumCountPerArtist[artistName] + " albums.");
            }
        }
    }
}