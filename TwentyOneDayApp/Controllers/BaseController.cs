using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TwentyOneDayApp.Models;

namespace TwentyOneDayApp.Controllers
{
    public class BaseController : Controller
    {
        private const string _connString = "mongodb://localhost";
        private readonly MongoClient _client;
        private readonly MongoServer _server;
        private readonly MongoDatabase _db;
        private readonly MongoCollection<User> _usersCollection;

        public BaseController()
        {
            _client = new MongoClient(_connString);
            _server = _client.GetServer();
            _db = _server.GetDatabase("TwentyOneDayApp");
            _usersCollection = _db.GetCollection<User>("Users");
        }

        public MongoCollection<User> UsersCollection
        {
            get { return _usersCollection; }
        }

        public User CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    return UsersCollection.FindOne(Query<User>.EQ(f => f.Username, User.Identity.Name));
                }
                return null;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.user = CurrentUser;
        }
    }
}