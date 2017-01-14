using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task4LinqToJson
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StreamReader re = File.OpenText("..\\..\\Result.json");
            JsonTextReader reader = new JsonTextReader(re);
            var jsonObj = JObject.Load(reader);
            var tits = jsonObj.Descendants()
                    .OfType<JProperty>()
                    .Where(p => p.Name == "title");
            foreach (var tit in tits)
            {
                Console.WriteLine(tit);
            }
        }
    }
}