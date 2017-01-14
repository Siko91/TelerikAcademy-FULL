using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XmlParsers.Classes.AlbumCollection;

namespace Task1AlbumCatalogueToXML
{
    internal class Program
    {
        private static void AddSampleAlbumToCatalogue(List<Album> catalogue)
        {
            catalogue.Add(new Album()
            {
                Name = "AlbumName",
                Year = DateTime.Now,
                Price = 59.99,
                Artist = new Person()
                {
                    Name = "ArtistName",
                    Age = 45
                },
                Producer = new Person()
                {
                    Name = "ProducerName",
                    Age = 45
                },
                Songs = new List<Song>()
                {
                    new Song()
                    {
                        Title = "SongTitle1",
                        Duration = 250
                    },
                    new Song()
                    {
                        Title = "SongTitle2",
                        Duration = 250
                    },
                    new Song()
                    {
                        Title = "SongTitle3",
                        Duration = 250
                    }
                }
            });
        }

        private static void CreateXmlFile(List<Album> catalogue, string filePath)
        {
            XElement ninjaXml = new XElement("AlbumCollection");

            foreach (var album in catalogue)
            {
                var Songs = new XElement("Songs");
                ninjaXml.Add(
                    new XElement(
                        "Album",
                        new XElement("Name", album.Name),
                        new XElement("Price", album.Price),
                        new XElement("Year", album.Year),
                        new XElement("Artist",
                            new XElement("Name", album.Artist.Name),
                            new XElement("Name", album.Artist.Age)),
                        new XElement("Producer",
                            new XElement("Name", album.Producer.Name),
                            new XElement("Name", album.Producer.Age)),
                        Songs
                        ));
                foreach (var song in album.Songs)
                {
                    Songs.Add(new XElement("Song",
                        new XElement("Title", song.Title),
                        new XElement("Duration", song.Duration)
                        ));
                }
            }

            ninjaXml.Save(filePath);
        }

        private static void Main(string[] args)
        {
            List<Album> catalogue = new List<Album>();
            for (int i = 0; i < 5; i++)
            {
                AddSampleAlbumToCatalogue(catalogue);
            }

            string filePath = "..\\..\\AlbumCollection.xml";
            CreateXmlFile(catalogue, filePath);
        }
    }
}