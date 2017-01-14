using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Task3ParseXmlToJson
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            using (StreamReader reader = new StreamReader("..\\..\\DownloadedFile.xml"))
            {
                doc.LoadXml(reader.ReadToEnd());
            }
            string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            using (StreamWriter writer = new StreamWriter("..\\..\\Result.json"))
            {
                writer.Write(jsonText);
            }
        }
    }
}