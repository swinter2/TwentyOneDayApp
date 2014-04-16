using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TwentyOneDayApp.Models;

namespace TwentyOneDayApp.Test
{
    [TestClass]
    public class DataTests
    {
        private const string _connString = "mongodb://localhost";
        private MongoClient _client;
        private MongoServer _server;
        private MongoDatabase _db;
        private MongoCollection<User> _usersCollection;

        public DataTests()
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

        [TestMethod]
        public void SetPassword()
        {
            var user = UsersCollection.FindOne(Query<User>.EQ(f => f.Username, "swinter"));
            if (user != null)
            {
                user.Password = "sam";
                UsersCollection.Save(user);
            }
        }

        [TestMethod]
        public void CreateUsers()
        {
            var swinter = UsersCollection.FindOne(Query<User>.EQ(f => f.Username, "swinter"));
            if (swinter == null)
            {
                UsersCollection.Insert(new User
                {
                    Username = "swinter",
                    Email = "sam.winter@gmail.com",
                    Password = "sam123",
                    ContainerCollections = new List<ContainerCollection>
                        {
                            ContainerCollection.CreateDefault()
                        }
                });
            }

        }

        [TestMethod]
        public void RemoveUsers()
        {
            UsersCollection.Remove(Query<User>.EQ(e => e.Username, "swinter"));

        }
    }
}
