using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5JsonToPoco.POCOs
{
    public class Channel
    {
        public string description { get; set; }

        public List<Item> item { get; set; }

        public string link { get; set; }

        public string title { get; set; }
    }
}