using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace MvcApplication3.Controllers
{
    public class WallController : Controller
    {
        PostContext ctxPost = new PostContext();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPosts()
        {
            var posts = ctxPost.Posts.FindAll();
            return Json(new { Posts = posts });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string title, string author, string body)
        {
            Post post = new Post(title, author, body);
            ctxPost.Posts.Insert(post);
            return View("Index");
        }

        public ActionResult Delete(string id)
        {
            var query = Query<Post>.EQ(e => e.Id, id);
            ctxPost.Posts.Remove(query);
            return View("Index");
        }
        public JsonResult GetPost(string id)
        {
            var query = Query<Post>.EQ(e => e.Id, id);
            var post = ctxPost.Posts.FindOne(query);
            return Json(new { Post = post });
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(string id, string title, string author, string body)
        {
            var query = Query<Post>.EQ(e => e.Id, id);
            var update = Update<Post>.Set(e => e.Title, title)
                                     .Set(e => e.Author, author)
                                     .Set(e => e.Body, body);
            ctxPost.Posts.Update(query, update);
            return View("Index");
        }
        public ActionResult Details(string id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
