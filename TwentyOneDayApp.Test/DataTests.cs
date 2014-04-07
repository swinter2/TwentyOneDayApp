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

        public MongoCollection<User> UsersCollection
        {
            get { return _usersCollection; }
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
