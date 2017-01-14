using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task3ReadAlbumCollectionXML
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string filePath = "..\\..\\AlbumCollection.xml";
            XDocument albumCollection = XDocument.Load(filePath);
            string[] artistsPerAlbum = (from album in albumCollection.Descendants("Album")
                                        select album.Element("Artist").Element("Name").Value).ToArray();

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