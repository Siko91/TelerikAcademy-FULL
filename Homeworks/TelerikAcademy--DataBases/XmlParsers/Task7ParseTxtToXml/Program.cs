using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlParsers.Classes.PhoneBookItem;

namespace Task7ParseTxtToXml
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<PhoneBookItem> ParsedRows = new List<PhoneBookItem>();

            using (StreamReader reader = new StreamReader("..\\..\\TextFile.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] lineParts = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(part => part.Trim()).ToArray();
                    ParsedRows.Add(
                        new PhoneBookItem()
                        {
                            PersonName = lineParts[0],
                            PersonAddress = lineParts[1],
                            PersonTelephone = lineParts[2],
                        });

                    line = reader.ReadLine();
                }

                XElement ninjaXml = new XElement("PhoneBook");

                foreach (var item in ParsedRows)
                {
                    ninjaXml.Add(
                        new XElement(
                            "PhoneBookItem",
                            new XElement("Name", item.PersonName),
                            new XElement("Address", item.PersonAddress),
                            new XElement("Phone", item.PersonTelephone)
                            ));
                }

                ninjaXml.Save("..\\..\\PhoneBook.xml");
            }
        }
    }
}