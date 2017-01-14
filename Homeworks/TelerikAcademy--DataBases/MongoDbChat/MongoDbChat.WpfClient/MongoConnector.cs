using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDbChat.WpfClient
{
    internal class MongoConnector
    {
        public MongoConnector()
            : this(Settings.Default.ConnectionString)
        {
        }

        public MongoConnector(string connectionString)
        {
            this.db = this.GetMongoDatabase(connectionString, "telerik_chat");

            this.mongoCollection = this.db.GetCollection("telerik_chat");
        }

        public static MongoConnector LocalMongoConnector()
        {
            return new MongoConnector(Settings.Default.LocalString);
        }

        public void AddMessage(Message message)
        {
            this.mongoCollection.Insert(message);
        }

        public ICollection<Message> GetMessages()
        {
            ICollection<Message> reports = GetAllRecordsInCollection();
            return reports;
        }

        private readonly MongoDatabase db;

        private readonly MongoCollection<BsonDocument> mongoCollection;

        private void AddManyMessages(ICollection<Message> messages)
        {
            foreach (Message msg in messages)
            {
                this.mongoCollection.Insert(msg);
            }
        }

        private ICollection<Message> GetAllRecordsInCollection()
        {
            MongoCursor<BsonDocument> messages = this.mongoCollection.FindAll();
            List<Message> results = new List<Message>();
            if (messages.Count() > 0)
            {
                foreach (BsonDocument msg in messages)
                {
                    string user = msg["user"].AsString;
                    string text = msg["text"].AsString;
                    DateTime date = msg["date"].ToUniversalTime();

                    results.Add(new Message(user, date, text));
                }
            }

            return results;
        }

        private MongoDatabase GetMongoDatabase(string connectionString, string ninjasDBName)
        {
            return new MongoClient(connectionString).GetServer().GetDatabase(ninjasDBName);
        }
    }
}