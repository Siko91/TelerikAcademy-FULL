using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task5XmlReaderExtractSongNames
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            string filePath = "..\\..\\AlbumCollection.xml";
            XmlReader reader = XmlReader.Create(filePath, settings);

            reader.MoveToContent();

            // Parse the file and display each of the nodes.
            bool inSongElement = false;
            bool inSongTitle = false;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "Album")
                        {
                            Console.WriteLine("--");
                        }
                        if (reader.Name == "Song")
                        {
                            inSongElement = true;
                        }
                        else if (reader.Name == "Title" && inSongElement)
                        {
                            inSongTitle = true;
                        }
                        break;

                    case XmlNodeType.Text:
                        if (inSongElement && inSongTitle)
                        {
                            Console.WriteLine(reader.Value);
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if (reader.Name == "Song")
                        {
                            inSongElement = false;
                        }
                        if (reader.Name == "Title")
                        {
                            inSongTitle = false;
                        }
                        break;
                }
            }
        }
    }
}