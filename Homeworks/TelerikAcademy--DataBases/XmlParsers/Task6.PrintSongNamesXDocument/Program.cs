using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task6.PrintSongNamesXDocument
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string filePath = "..\\..\\AlbumCollection.xml";
            XDocument albumCollection = XDocument.Load(filePath);
            string[] songNames = (from song in albumCollection.Descendants("Album").Descendants("Songs").Descendants("Song")
                                  select song.Element("Title").Value)
                                  .ToArray();
            Console.WriteLine(string.Join("\n", songNames));
        }
    }
}