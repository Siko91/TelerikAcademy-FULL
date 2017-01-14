using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Task5JsonToPoco.POCOs;

namespace Task5JsonToPoco
{
    public class JsonToPoco
    {
        public static RootObject ParseRootOfRss(string filePath)
        {
            StreamReader re = File.OpenText(filePath);
            JsonTextReader reader = new JsonTextReader(re);
            var jsonObj = JObject.Load(reader);
            return JsonConvert.DeserializeObject<RootObject>(jsonObj.Root.ToString());
        }

        private static void Main(string[] args)
        {
            var root = ParseRootOfRss("..\\..\\Result.json");
            Console.WriteLine(root.rss.channel.item.Count() + " items in channel");
        }
    }
}