namespace NinjaFactory.NinjaCatalogue
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Xml;

    public class NinjaCatalogueJsonParser
    {
        public virtual NinjaCatalogueItem[] Parse(string filePath)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(NinjaCatalogueItem[]));
                NinjaCatalogueItem[] catalogue = (NinjaCatalogueItem[])serializer.ReadObject(stream);
                return catalogue;
            }
        }
    }
}