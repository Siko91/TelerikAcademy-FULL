using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParsers.Classes.AlbumCollection
{
    public class Album
    {
        public Person Artist { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Person Producer { get; set; }

        public ICollection<Song> Songs { get; set; }

        public DateTime Year { get; set; }
    }
}