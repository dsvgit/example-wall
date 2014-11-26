using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MvcApplication3.Models
{
    public class Post
    {
        [BsonId]
        public string Id{ get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public Post()
        {

        }
        public Post(string title, string author, string body)
        {
            Id = ObjectId.GenerateNewId().ToString();
            Title = title;
            Author = author;
            Body = body;
        }
    }
}