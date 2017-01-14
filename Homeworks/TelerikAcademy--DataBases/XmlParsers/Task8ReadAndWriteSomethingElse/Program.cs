using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlParsers.Classes.AlbumCollection;

namespace Task8ReadAndWriteSomethingElse
{
    internal class Program
    {
        private static void LoadAlbums(List<Album> loadedAlbums)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            string filePath = "..\\..\\AlbumCollection.xml";
            using (XmlReader reader = XmlReader.Create(filePath, settings))
            {
                reader.MoveToContent();

                // Parse the file and display each of the nodes.
                bool inAlbum = false;
                bool inAlbumName = false;
                bool inArtist = false;
                bool inArtistName = false;
                Album current = null;
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "Album")
                            {
                                inAlbum = true;
                            }
                            if (reader.Name == "Artist")
                            {
                                inArtist = true;
                            }
                            else if (reader.Name == "Name")
                            {
                                if (inArtist)
                                {
                                    inArtistName = true;
                                }
                                else if (inAlbum)
                                {
                                    inAlbumName = true;
                                }
                            }
                            break;

                        case XmlNodeType.Text:
                            if (inAlbumName)
                            {
                                current = new Album()
                                {
                                    Name = reader.Value
                                };
                            }
                            else if (inArtistName && current != null)
                            {
                                current.Artist = new Person()
                                {
                                    Name = reader.Value
                                };
                                loadedAlbums.Add(current);
                                current = null;
                            }
                            break;

                        case XmlNodeType.EndElement:
                            if (reader.Name == "Album")
                            {
                                inAlbum = false;
                            }
                            if (reader.Name == "Artist")
                            {
                                inArtist = false;
                            }
                            if (reader.Name == "Name")
                            {
                                inArtistName = false;
                                inAlbumName = false;
                            }
                            break;
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            List<Album> loadedAlbums = new List<Album>();

            LoadAlbums(loadedAlbums);
            WriteAlbums(loadedAlbums);
        }

        private static void WriteAlbums(List<Album> loadedAlbums)
        {
            var settings = new XmlWriterSettings();
            settings.ConformanceLevel = ConformanceLevel.Auto;
            using (XmlWriter writer = XmlWriter.Create("..\\..\\AlbumsShortList.xml", settings))
            {
                writer.WriteRaw("<Albums>");
                foreach (var album in loadedAlbums)
                {
                    writer.WriteRaw("<Album>");
                    writer.WriteRaw(@"<Name>" + album.Name + @"</Name><Artist>" + album.Artist.Name + @"</Artist>");
                    writer.WriteRaw("</Album>");
                }
                writer.WriteRaw("</Albums>");
            }
        }
    }
}