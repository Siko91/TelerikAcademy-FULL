using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbChat.WpfClient
{
    public class Message
    {

        public Message()
        {
        }
        public Message(string user, string text) 
        {
            this.user = user;
            this.date = DateTime.Now;
            this.text = text;
        }
        public Message(string user, DateTime date, string text)
        {
            this.user = user;
            this.date = date;
            this.text = text;
        }
        public string text;
        public DateTime date;
        public string user;
    }
}
