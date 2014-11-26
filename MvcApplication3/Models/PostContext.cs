using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MvcApplication3.Models
{
    public class PostContext
    {
        private MongoDatabase db;
        public PostContext()
        {
            string connAddress = "localHost";
            int connPort = 123;
            string connDatabase = "Wall";
            var client = new MongoClient();
            var server = client.GetServer();
            this.db = server.GetDatabase(connDatabase);
        }
        public MongoCollection<Post> Posts
        {
            get
            {
                return db.GetCollection<Post>("Post");
            }
        }
    }
}